﻿// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.ObjectModel;
using System.Linq;

namespace ShogunLib.CommandLine.Tests.Commands.Parameters.ArgumentValidation
{
    /// <summary>
    /// Used in argument validation tests.
    /// </summary>
    public class ValidationCollection : Collection<string>
    {
        public override string ToString()
        {
            return Items.Count == 0 ? string.Empty : Items.Aggregate((current, next) => current + " | " + next);
        }
    }
}
