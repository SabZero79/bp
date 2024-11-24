using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;
       

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // Calculate Pulse pressure
        [DisplayName("Pulse Pressure")]
        public int? PulsePressure 
        {
            get
            {
                return CalculatePulsePressure();
            }
                
         }

        // calculate BP category
        public BPCategory Category
        {
            
            get
            {
                return CalculateBPCategory();
            }
        }

        // Main logic of how to calculate the blood pressure categories
        public BPCategory CalculateBPCategory()
        {
            BPCategory category;
            if (Systolic < 90)
            {
                if (Diastolic < 60) category = BPCategory.Low;
                else if (Diastolic < 80) category = BPCategory.Ideal;
                else if (Diastolic < 90) category = BPCategory.PreHigh;
                else category = BPCategory.High;
            }
            else if (Systolic < 120)
            {
                if (Diastolic < 80) category = BPCategory.Ideal;
                else if (Diastolic < 90) category = BPCategory.PreHigh;
                else category = BPCategory.High;
            }
            else if (Systolic < 140)
            {
                if (Diastolic < 90) category = BPCategory.PreHigh;
                else category = BPCategory.High;
            }
            else
            {
                category = BPCategory.High;
            }
            return category;
        }
        // New feature - calculate pulse pressure -
        //To calculate your pulse pressure, subtract the diastolic blood pressure from the systolic blood pressure
        public int CalculatePulsePressure()
        {
            return Systolic - Diastolic;
        }
    }
}
