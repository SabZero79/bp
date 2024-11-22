using BPCalculator;
using TechTalk.SpecFlow;

namespace BDDTestProject
{
    [Binding]
    public class BloodPressureSteps
    {
        public BloodPressure BP { get; private set; }
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