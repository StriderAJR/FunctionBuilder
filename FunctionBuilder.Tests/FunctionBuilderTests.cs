using FunctionBuilder.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FunctionBuilder.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase]
        public void SampleTest()
        {
            var result = new Function("1+2").ToString();
            Assert.AreEqual("1 2 +", result);
        }

        [TestCase("1+2", ExpectedResult = "1 2 +")]
        [TestCase("1+2/1", ExpectedResult = "1 2 1 / +")]
        public string Function_Test(string expression)
        {
            return new Function(expression).ToString();
        }

        [TestCaseSource(nameof(TestCases))]
        public void RPN_Test(string expression, int result, object[] rpnTokens)
        {
            Assert.That(rpnTokens, Is.EquivalentTo(new ReversePolishNotation().Parse(expression)));
            Assert.AreEqual(result, new Function(expression).Calculate());
        }

        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                Debug.WriteLine("Line 1");
                yield return new TestCaseData("1+2", 3, new object[] { 1.0, 2.0, new Plus() });
                Debug.WriteLine("Line 2");
                yield return new TestCaseData("1+2/1", 3, new object[] { 1.0, 2.0, 1.0, new Devide(), new Plus() });
            }
        }
    }
}