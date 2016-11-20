// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands.Parameters;

namespace ShogunLib.CommandLine.Tests.Commands.Parameters
{
    [TestFixture]
    public class ParameterInfoTests
    {
        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Parameters.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_NullName_Throws()
        {
            new ParameterInfo(null, FakeCreator.ParameterDescription);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Parameters.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_EmptyName_Throws()
        {
            new ParameterInfo(string.Empty, FakeCreator.ParameterDescription);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Parameters.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesName_Throws()
        {
            new ParameterInfo("   ", FakeCreator.ParameterDescription);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Parameters.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_NullDescription_Throws()
        {
            new ParameterInfo(FakeCreator.ParameterName, null);
        }
        
        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Parameters.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_EmptyDescription_Throws()
        {
            new ParameterInfo(FakeCreator.ParameterName, string.Empty);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Parameters.ParameterInfo", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesDescription_Throws()
        {
            new ParameterInfo(FakeCreator.ParameterName, "   ");
        }

        [Test]
        public void Constructor_AllConditionsAreMet_ParameterInfoIsCreated()
        {
            var parameterInfo = new ParameterInfo(FakeCreator.ParameterName, FakeCreator.ParameterDescription);

            Assert.AreEqual(FakeCreator.ParameterName, parameterInfo.Name);
            Assert.AreEqual(FakeCreator.ParameterDescription, parameterInfo.Description);
        }
    }
}
