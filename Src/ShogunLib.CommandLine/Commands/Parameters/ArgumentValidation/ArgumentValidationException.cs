// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Runtime.Serialization;

namespace ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation
{
    /// <summary>
    /// The exception that is thrown when the validation of the argument is fail.
    /// </summary>
    [Serializable]
    public class ArgumentValidationException : CommandLineInterpreterFrameworkException
    {
        /// <summary>
        /// Initializes a new instance of the ArgumentValidationException class.
        /// </summary>
        public ArgumentValidationException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentValidationException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ArgumentValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentValidationException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public ArgumentValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ArgumentValidationException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ArgumentValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
