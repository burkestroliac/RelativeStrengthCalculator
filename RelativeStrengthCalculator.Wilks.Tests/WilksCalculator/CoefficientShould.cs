﻿// --------------------------------
// <copyright file="CoefficientShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Wilks.Tests.WilksCalculator
{
    using System;
    using System.Diagnostics;

    using DotNetTestHelper;

    using global::RelativeStrengthCalculator.Tests.Helpers;
    using global::RelativeStrengthCalculator.WeightConverter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WilksCalculator = global::RelativeStrengthCalculator.Wilks.WilksCalculator;

    [TestClass]
    public class CoefficientShould : CalculatorTestBase
    {
        // All data is tested against this page
        // http://tsampa.org/training/scripts/relative_strength/
        [TestMethod]
        [DeploymentItem("WilksCalculator\\TestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectCoefficient()
        {
            var sut = new SutBuilder<WilksCalculator>().AddDependency(new WeightConverterService()).Build();
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.Coefficient(WeightUnit.Pounds, testCase.Sex, testCase.Weight);
            Assert.AreEqual(testCase.Coefficient, Math.Round(result, 9));
        }

        [TestMethod]
        [DeploymentItem("WilksCalculator\\KiloTestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\KiloTestData.csv", "KiloTestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectCoefficientForKilograms()
        {
            var sut = new SutBuilder<WilksCalculator>().AddDependency(new WeightConverterService()).Build();
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.Coefficient(WeightUnit.Kilograms, testCase.Sex, testCase.Weight);
            Assert.AreEqual(testCase.Coefficient, Math.Round(result, 9));
        }
    }
}