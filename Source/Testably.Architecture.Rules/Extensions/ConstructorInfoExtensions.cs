﻿using System;
using System.Linq;
using System.Reflection;

namespace Testably.Architecture.Rules;

/// <summary>
///     Extension methods for <see cref="ConstructorInfo" />.
/// </summary>
public static class ConstructorInfoExtensions
{
	/// <summary>
	///     Checks if the <paramref name="constructorInfo" /> has the specified <paramref name="accessModifiers" />.
	/// </summary>
	/// <param name="constructorInfo">The <see cref="ConstructorInfo" /> which is checked to have the attribute.</param>
	/// <param name="accessModifiers">
	///     The <see cref="AccessModifiers" />.
	///     <para />
	///     Supports specifying multiple <see cref="AccessModifiers" />.
	/// </param>
	public static bool HasAccessModifier(
		this ConstructorInfo constructorInfo,
		AccessModifiers accessModifiers)
	{
		if (constructorInfo.IsAssembly)
		{
			return accessModifiers.HasFlag(AccessModifiers.Internal);
		}

		if (constructorInfo.IsFamily)
		{
			return accessModifiers.HasFlag(AccessModifiers.Protected);
		}

		if (constructorInfo.IsPrivate)
		{
			return accessModifiers.HasFlag(AccessModifiers.Private);
		}

		if (constructorInfo.IsPublic)
		{
			return accessModifiers.HasFlag(AccessModifiers.Public);
		}

		return false;
	}

	/// <summary>
	///     Checks if the <paramref name="constructorInfo" /> has an attribute which satisfies the
	///     <paramref name="predicate" />.
	/// </summary>
	/// <typeparam name="TAttribute">The type of the <see cref="Attribute" />.</typeparam>
	/// <param name="constructorInfo">The <see cref="ConstructorInfo" /> which is checked to have the attribute.</param>
	/// <param name="predicate">
	///     (optional) A predicate to check the attribute values.
	///     <para />
	///     If not set (<see langword="null" />), will only check if the attribute is present.
	/// </param>
	public static bool HasAttribute<TAttribute>(
		this ConstructorInfo constructorInfo,
		Func<TAttribute, bool>? predicate = null)
		where TAttribute : Attribute
	{
		object? attribute = constructorInfo.GetCustomAttributes(typeof(TAttribute))
			.FirstOrDefault();
		if (attribute is TAttribute castedAttribute)
		{
			return predicate?.Invoke(castedAttribute) ?? true;
		}

		return false;
	}
}
