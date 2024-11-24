using BPCalculator;
using Xunit;

namespace Unit_BDD_Tests
{
    public class BloodPressureTests
    {
        public BloodPressure BP { get; private set; }

        public BloodPressureTests()
        {
            BP = new BloodPressure();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_LowBloodPressure()
        {
            BP.Systolic = 85;
            BP.Diastolic = 55;
            Assert.Equal(BPCategory.Low, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_IdealBloodPressure()
        {
            BP.Systolic = 115;
            BP.Diastolic = 75;
            Assert.Equal(BPCategory.Ideal, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_PreHighBloodPressure()
        {
            BP.Systolic = 125;
            BP.Diastolic = 85;
            Assert.Equal(BPCategory.PreHigh, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_HighBloodPressure_SystolicBoundary()
        {
            BP.Systolic = 140;
            BP.Diastolic = 95;
            Assert.Equal(BPCategory.High, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_HighBloodPressure_DiastolicBoundary()
        {
            BP.Systolic = 150;
            BP.Diastolic = 100;
            Assert.Equal(BPCategory.High, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_LowSystolicHighDiastolic()
        {
            BP.Systolic = 80;
            BP.Diastolic = 95;
            Assert.Equal(BPCategory.High, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_IdealSystolicLowDiastolic()
        {
            BP.Systolic = 110;
            BP.Diastolic = 55;
            Assert.Equal(BPCategory.Ideal, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_PreHighSystolicIdealDiastolic()
        {
            BP.Systolic = 130;
            BP.Diastolic = 75;
            Assert.Equal(BPCategory.PreHigh, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_HighSystolicLowDiastolic()
        {
            BP.Systolic = 145;
            BP.Diastolic = 70;
            Assert.Equal(BPCategory.High, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_IdealDiastolicBoundary()
        {
            BP.Systolic = 85;
            BP.Diastolic = 75;
            Assert.Equal(BPCategory.Ideal, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_PreHighDiastolicBoundary()
        {
            BP.Systolic = 85;
            BP.Diastolic = 85;
            Assert.Equal(BPCategory.PreHigh, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_IdealSystolicBoundary()
        {
            BP.Systolic = 110;
            BP.Diastolic = 75;
            Assert.Equal(BPCategory.Ideal, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_PreHighSystolicBoundary()
        {
            BP.Systolic = 115;
            BP.Diastolic = 85;
            Assert.Equal(BPCategory.PreHigh, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_HighSystolicBoundary()
        {
            BP.Systolic = 135;
            BP.Diastolic = 95;
            Assert.Equal(BPCategory.High, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_PreHighDiastolicBoundary_SecondCheck()
        {
            BP.Systolic = 125;
            BP.Diastolic = 85;
            Assert.Equal(BPCategory.PreHigh, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_HighDiastolicBoundary_SecondCheck()
        {
            BP.Systolic = 125;
            BP.Diastolic = 95;
            Assert.Equal(BPCategory.High, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_HighDiastolicGreater90()
        {
            BP.Systolic = 115;
            BP.Diastolic = 95;
            Assert.Equal(BPCategory.High, BP.CalculateBPCategory());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculateBPCategory_HighDiastolicGreater90_SecondCheck()
        {
            BP.Systolic = 115;
            BP.Diastolic = 100;
            Assert.Equal(BPCategory.High, BP.CalculateBPCategory());
        }

        // Feature - Pulse Pressure Tests
        [Fact]
        [Trait("Category", "Unit")]
        public void CalculatePulsePressure_ShouldReturnCorrectValue()
        {
            BP.Systolic = 120;
            BP.Diastolic = 80;
            Assert.Equal(40, BP.CalculatePulsePressure());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculatePulsePressure_HandlesNormalValues()
        {
            BP.Systolic = 90;
            BP.Diastolic = 50;
            Assert.Equal(40, BP.CalculatePulsePressure());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculatePulsePressure_HandlesHighValues()
        {
            BP.Systolic = 180;
            BP.Diastolic = 110;
            Assert.Equal(70, BP.CalculatePulsePressure());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculatePulsePressure_HandlesMinimumValues()
        {
            BP.Systolic = BloodPressure.SystolicMin;
            BP.Diastolic = BloodPressure.DiastolicMin;
            Assert.Equal(30, BP.CalculatePulsePressure());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculatePulsePressure_HandlesMaximumValues()
        {
            BP.Systolic = BloodPressure.SystolicMax;
            BP.Diastolic = BloodPressure.DiastolicMax;
            Assert.Equal(90, BP.CalculatePulsePressure());
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CalculatePulsePressure_HandlesLowValues()
        {
            BP.Systolic = 100;
            BP.Diastolic = 90;
            Assert.Equal(10, BP.CalculatePulsePressure());
        }
    }
}
