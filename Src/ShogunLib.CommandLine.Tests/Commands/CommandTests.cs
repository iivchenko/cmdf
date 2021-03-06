﻿// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Moq;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands;
using ShogunLib.CommandLine.Commands.Parameters;

namespace ShogunLib.CommandLine.Tests.Commands
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullName_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Command(null, FakeCreator.CommandDescription, new ParametersDictionary(), delegate { }));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_EmptyName_Throws()
        {
            Assert.Throws<ArgumentException>(() => new Command(string.Empty, FakeCreator.CommandDescription, new ParametersDictionary(), delegate { }));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesName_Throws()
        {
            Assert.Throws<ArgumentException>(() => new Command("   ", FakeCreator.CommandDescription, new ParametersDictionary(), delegate { }));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullDescription_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Command(FakeCreator.CommandName, null, new ParametersDictionary(), delegate { }));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_EmptyDescription_Throws()
        {
            Assert.Throws<ArgumentException>(() => new Command(FakeCreator.CommandName, string.Empty, new ParametersDictionary(), delegate { }));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesDescription_Throws()
        {
            Assert.Throws<ArgumentException>(() => new Command(FakeCreator.CommandName, "   ", new ParametersDictionary(), delegate { }));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullParameters_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, null, delegate { }));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullAction_Throws()
        {
            Assert.Throws<ArgumentNullException>(() => new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, new ParametersDictionary(), null));
        }

        [Test]
        public void Parameters_NoParameters_ReturnsEmptyString()
        {
            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, new ParametersDictionary(), delegate { });

            Assert.IsEmpty(command.Parameters);
        }

        [Test]
        public void Parameters_CorrectParametersAreUsed_ReturnsCorrectParametersInfo()
        {
            var expectedParameters = new[]
                                         {
                                             FakeCreator.CreateParameterInfo("parameter1", "description1"),
                                             FakeCreator.CreateParameterInfo("parameter2", "description2")
                                         };

            var commandParameters = new ParametersDictionary
                                        {
                                            { "parameter1", FakeCreator.CreateParameter("parameter1", "description1") },
                                            { "parameter2", FakeCreator.CreateParameter("parameter2", "description2") }
                                        };

            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, commandParameters, delegate { });

            Assert.IsTrue(expectedParameters.SequenceEqual(command.Parameters, new ParameterInfoComparer()), "Actual parameters should be equal to expected parameters");
        }

        [Test]
        public void Execute_NullArguments_Throws()
        {
            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, new ParametersDictionary(), delegate { });

            Assert.Throws<ArgumentNullException>(() => command.Execute(null));
        }

        [Test]
        public void Execute_Validation_ParameterValidationIsUsed()
        {
            var mockParameter = FakeCreator.CreateParameterFake(FakeCreator.ParameterName, FakeCreator.ParameterDescription);
            var parameters = new ParametersDictionary
                                 {
                                     mockParameter.Object
                                 };

            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, parameters, delegate { });

            command.Execute(new Collection<string>());

            mockParameter.Verify(parameter => parameter.Validate(It.IsAny<IEnumerable<string>>()), Times.Once());
        }

        [Test]
        public void Execute_AllConditionsAreMet_ActionIsExecuted()
        {
            var isActionExecuted = false;
            var command = new Command(FakeCreator.CommandName, 
                                      FakeCreator.CommandDescription, 
                                      new ParametersDictionary(), 
                                      actionArgument => isActionExecuted = true);

            command.Execute(new Collection<string>());

            Assert.IsTrue(isActionExecuted, "Command should execute Action delegate");
        }

        private class ParameterInfoComparer : EqualityComparer<IParameterInfo>
        {
            public override bool Equals(IParameterInfo x, IParameterInfo y)
            {
                return x.Name == y.Name && x.Description == y.Description;
            }

            public override int GetHashCode(IParameterInfo obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
