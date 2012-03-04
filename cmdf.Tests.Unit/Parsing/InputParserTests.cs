﻿// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using CommandLineInterpreterFramework.Parsing;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Parsing
{
    [TestFixture]
    public class InputParserTests
    {
        private InputParser _inputParser;

        [SetUp]
        public void Setup()
        {
            _inputParser = new InputParser();
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Parse_EmptyInput_ReturnsEmptyParsedCommand(string input)
        {
            Assert.IsNull(_inputParser.Parse(input));
        }

        [TestCase("Command")]
        [TestCase("Command arg1")]
        [TestCase(" Command arg1  arg2 ")]
        [TestCase("Command \"hello man\"  arg1 \"how \\\"are\\\" you\"    \\\"")]
        public void Parse_ValidInput_ReturnsParsedCommand(string input)
        {
            var parsedCommand = _inputParser.Parse(input);
            Assert.IsNotNull(parsedCommand);
        }

        [TestCase("CommandName \"incorrect number of double quotes")]
        [TestCase("CommandName \"incorrect number of double quotes \"\"")]
        [TestCase("CommandName \"incorrect number of double quotes \" \" \\\"")]
        [ExpectedException(typeof(InputParserException))]
        public void Parse_InvalidInput_Throws(string input)
        {
            _inputParser.Parse(input);
        }
        
        [Test]
        public void Parse_ValidInput_ReturnsCorrectParsedCommand()
        {
            // TODO: Finish This Unit test
            const string Input = "Command \"hello man\" arg1 \"how \\\"are\\\" you\"    \\\"";

            const string Name = "Command";
            var args = new[] { "hello man", "arg1", "how \"are\" you", "\"" };
            
            var parsedCommand = _inputParser.Parse(Input);
            
            Assert.AreEqual(Name, parsedCommand.Name);

            ////Assert.IsTrue(Comparer<ICollection<string>>.Default.Compare(args, parsedCommand.Args) == 0);
            int i = 0;
            foreach (var arg in parsedCommand.Args)
            {
                Assert.AreEqual(args[i], arg);
                i++;
            }
        }
    }
}
