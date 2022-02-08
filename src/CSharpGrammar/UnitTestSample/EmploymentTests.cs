using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PracticeConsole;
using PracticeConsole.Data;

namespace UnitTestSample
{
    [TestClass]
    public class EmploymentTests
    {
        [TestMethod]
        [DataRow("worker",SupervisoryLevel.Entry,2.5)]
        public void CreateEmployment_GoodCreate_EmploymentInstance(string title,
            SupervisoryLevel level, double years)
        {
            try
            {
                Employment employment = new Employment(title, level, years);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        [DataRow("", SupervisoryLevel.Entry, 2.5)]
        [DataRow("worker", SupervisoryLevel.Entry, -2.5)]
        public void CreateEmployment_BadCreate_EmploymentInstance(string title,
                   SupervisoryLevel level, double years)
        {
            try
            {
                Employment employment = new Employment(title, level, years);
                Assert.Fail("Exception was expected and failed to be thrown");
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message");
            }
        }
    }
}