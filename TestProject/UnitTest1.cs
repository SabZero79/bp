using BPCalculator;
namespace TestProject
{
    public class BloodPressureTests
    {
        public required BloodPressure BP;

        [SetUp]
        public void SetUp()
        {
            BP = new BloodPressure();
        }

        [Test]
        public void CalculateBPCategory_LowBloodPressure()
        {
            BP.Systolic = 85;
            BP.Diastolic = 55;
            Assert.That(BP.CalculateBPCategory(), Is.EqualTo(BPCategory.Low));
        }

        [Test]
        public void CalculateBPCategory_IdealBloodPressure()
        {
            BP.Systolic = 115;
            BP.Diastolic = 75;
            Assert.That(BP.CalculateBPCategory(), Is.EqualTo(BPCategory.Ideal));
        }

        [Test]
        public void CalculateBPCategory_PreHighBloodPressure()
        {
            BP.Systolic = 125;
            BP.Diastolic = 85;
            Assert.That(BP.CalculateBPCategory(), Is.EqualTo(BPCategory.PreHigh));
        }

        [Test]
        public void CalculateBPCategory_HighBloodPressure_SystolicBoundary()
        {
            BP.Systolic = 140;
            BP.Diastolic = 95;
            Assert.That(BP.CalculateBPCategory(), Is.EqualTo(BPCategory.High));
        }

        [Test]
        public void CalculateBPCategory_HighBloodPressure_DiastolicBoundary()
        {
            BP.Systolic = 150;
            BP.Diastolic = 100;
            Assert.That(BP.CalculateBPCategory(), Is.EqualTo(BPCategory.High));
        }

        //[Test]
        //public void CalculatePulsePressure_ShouldReturnCorrectValue()
        //{
        //    BP.Systolic = 120;
        //    BP.Diastolic = 80;
        //    Assert.That(BP.CalculatePulsePressure(), Is.EqualTo(40));
        //}

        //[Test]
        //public void CalculatePulsePressure_HandlesLowValues()
        //{
        //    BP.Systolic = 70;
        //    BP.Diastolic = 40;
        //    Assert.That(BP.CalculatePulsePressure(), Is.EqualTo(30));
        //}
    }
}