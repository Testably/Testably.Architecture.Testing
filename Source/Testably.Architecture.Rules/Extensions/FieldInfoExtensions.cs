﻿using System;
using System.Linq;
using System.Reflection;

namespace Testably.Architecture.Rules;

/// <summary>
///     Extension fields for <see cref="FieldInfo" />.
/// </summary>
public static class FieldInfoExtensions
{
	/// <summary>
	///     Checks if the <paramref name="fieldInfo" /> has the specified <paramref name="accessModifiers" />.
	/// </summary>
	/// <param name="fieldInfo">The <see cref="FieldInfo" /> which is checked to have the attribute.</param>
	/// <param name="accessModifiers">
	///     The <see cref="AccessModifiers" />.
	///     <para />
	///     Supports specifying multiple <see cref="AccessModifiers" />.
	/// </param>
	public static bool HasAccessModifier(
		this FieldInfo fieldInfo,
		AccessModifiers accessModifiers)
	{
		if (fieldInfo.IsAssembly)
		{
			return accessModifiers.HasFlag(AccessModifiers.Internal);
		}

		if (fieldInfo.IsFamily)
		{
			return accessModifiers.HasFlag(AccessModifiers.Protected);
		}

		if (fieldInfo.IsPrivate)
		{
			return accessModifiers.HasFlag(AccessModifiers.Private);
		}

		if (fieldInfo.IsPublic)
		{
			return accessModifiers.HasFlag(AccessModifiers.Public);
		}

		return false;
	}

	/// <summary>
	///     Checks if the <paramref name="fieldInfo" /> has an attribute which satisfies the <paramref name="predicate" />.
	/// </summary>
	/// <typeparam name="TAttribute">The type of the <see cref="Attribute" />.</typeparam>
	/// <param name="fieldInfo">The <see cref="FieldInfo" /> which is checked to have the attribute.</param>
	/// <param name="predicate">
	///     (optional) A predicate to check the attribute values.
	///     <para />
	///     If not set (<see langword="null" />), will only check if the attribute is present.
	/// </param>
	public static bool HasAttribute<TAttribute>(
		this FieldInfo fieldInfo,
		Func<TAttribute, bool>? predicate = null)
		where TAttribute : Attribute
	{
		object? attribute = fieldInfo.GetCustomAttributes(typeof(TAttribute))
			.FirstOrDefault();
		if (attribute is TAttribute castedAttribute)
		{
			return predicate?.Invoke(castedAttribute) ?? true;
		}

		return false;
	}
}
