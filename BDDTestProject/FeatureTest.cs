using BPCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BDDTestProject
{
    [Binding]
    [Scope(Tag = "FeatureTest")]
    public class FeatureTest
    {
        public BloodPressure BP { get; private set; }
        private int PulsePressure;

        [Given(@"the systolic pressure is (.*)")]
        public void GivenTheSystolicPressureIs(int systolic)
        {
            BP = new BloodPressure { Systolic = systolic };
        }
        [Given(@"the diastolic pressure is (.*)")]
        public void GivenTheDiastolicPressureIs(int diastolic)
        {
            BP.Diastolic = diastolic;
        }
        [When(@"I calculate the pulse pressure")]
        public void WhenICalculateTheBloodPressureCategory()
        {
            PulsePressure = BP.CalculatePulsePressure();
        }
        [Then(@"the value should be (.*)")]
        public void ThenThePlusePressureShouldBe(int expected)
        {
            Assert.That(PulsePressure, Is.EqualTo(expected));
        }
    }
}
