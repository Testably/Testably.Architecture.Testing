﻿using System;
using System.Runtime.Serialization;

namespace Testably.Architecture.Testing.Exceptions;

/// <summary>
///     The data after applying all filters is empty.<br />
///     If this is an intended possibility, please specify <see cref="IExpectationStart{TType}.OrNone" />
///     to avoid getting this error!
/// </summary>
[Serializable]
public class EmptyDataException : Exception
{
	/// <summary>
	///     Initializes a new instance of <see cref="EmptyDataException" />.
	/// </summary>
	public EmptyDataException()
	{
	}

	/// <summary>
	///     Initializes a new instance of <see cref="EmptyDataException" />.
	/// </summary>
	public EmptyDataException(string message)
		: base(message)
	{
	}

	/// <summary>
	///     Initializes a new instance of <see cref="EmptyDataException" />.
	/// </summary>
	public EmptyDataException(string message, Exception inner)
		: base(message, inner)
	{
	}

	/// <summary>
	///     Initializes a new instance of <see cref="EmptyDataException" />.
	/// </summary>
	/// <param name="info">
	///     The <see cref="SerializationInfo"></see> that holds the serialized object data
	///     about the exception being thrown.
	/// </param>
	/// <param name="context">
	///     The <see cref="StreamingContext"></see> that contains contextual information
	///     about the source or destination.
	/// </param>
	public EmptyDataException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}
}
