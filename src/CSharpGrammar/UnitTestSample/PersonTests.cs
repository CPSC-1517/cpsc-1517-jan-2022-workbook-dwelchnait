using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PracticeConsole;
using PracticeConsole.Data;
using System.Collections.Generic;

namespace UnitTestSample
{
    //will NOT be considered a testing class UNLESS this annotation exists
    [TestClass]

    public class PersonTests
    {
        [TestMethod]
        [DataRow("Bob", "Changes")]
        public void CreatePerson_GoodCreate_PersonInstance(string firstname,
         string lastname)
        {
            try
            {
                Employment employment = new Employment("worker", SupervisoryLevel.Entry, 2.5);
                List<Employment> employments = new();
                employments.Add(employment);
                ResidentAddress employmentAddress = new ResidentAddress(1234, "Maple St.", "", "", "Edmonton", "AB");
                Person me = new Person(firstname, lastname, employments, employmentAddress);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        [DataRow("Bob", "Changes")]
        public void ChangeName_GoodChange_ChangePersonName(string firstname,
       string lastname)
        {
            try
            {
                Employment employment = new Employment("worker", SupervisoryLevel.Entry, 2.5);
                List<Employment> employments = new();
                employments.Add(employment);
                ResidentAddress employmentAddress = new ResidentAddress(1234, "Maple St.", "", "", "Edmonton", "AB");
                Person me = new Person(firstname, lastname, employments, employmentAddress);
                me.ChangeName(firstname, lastname);

            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType()} caught {ex.Message}");
            }
        }

        [TestMethod]
        [DataRow("", "Changes")]
        [DataRow("Bob", "")]
        public void ChangeName_BadChange_ChangePersonName(string firstname, string lastname)
        {
            try
            {
                //making the starting good position
                Employment employment = new Employment("worker", SupervisoryLevel.Entry, 2.5);
                List<Employment> employments = new();
                employments.Add(employment);
                ResidentAddress employmentAddress = new ResidentAddress(1234, "Maple St.", "", "", "Edmonton", "AB");
                Person me = new Person(firstname, lastname, employments, employmentAddress);

                //the logic being tested
                me.ChangeName(firstname, lastname); 
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
