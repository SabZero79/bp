using BPCalculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BPCalculator.Tests.Steps
{
    [Binding]
    [Category("BDD")]
    public class BloodPressureSteps
    {
        public required BloodPressure BP;
        private BPCategory calculatedCategory;

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

        [When(@"I calculate the blood pressure category")]
        public void WhenICalculateTheBloodPressureCategory()
        {
            calculatedCategory = BP.CalculateBPCategory();
        }

        [Then(@"the category should be ""(.*)""")]
        public void ThenTheCategoryShouldBe(string expectedCategory)
        {
            Assert.That(calculatedCategory.ToString(), Is.EqualTo(expectedCategory));
        }
    }
}
