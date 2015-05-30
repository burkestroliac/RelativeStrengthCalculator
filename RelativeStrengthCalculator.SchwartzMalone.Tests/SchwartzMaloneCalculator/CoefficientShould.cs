﻿// --------------------------------
// <copyright file="CoefficientShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.SchwartzMalone.Tests.SchwartzMaloneCalculator
{
    using System.Diagnostics;

    using DotNetTestHelper;

    using global::RelativeStrengthCalculator.Tests.Helpers;
    using global::RelativeStrengthCalculator.WeightConverter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchwartzMaloneCalculator = global::RelativeStrengthCalculator.SchwartzMalone.SchwartzMaloneCalculator;

    [TestClass]
    public class CoefficientShould : CalculatorTestBase
    {
        [TestMethod]
        [DeploymentItem("SchwartzMaloneCalculator\\TestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectCoefficient()
        {
            var sut = new SutBuilder<SchwartzMaloneCalculator>().AddDependency(new WeightConverterService()).Build();
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.Coefficient(WeightUnit.Pounds, testCase.Sex, testCase.Weight);
            Assert.AreEqual(testCase.Coefficient, result);
        }

        [TestMethod]
        [DeploymentItem("SchwartzMaloneCalculator\\KiloTestData.csv")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\KiloTestData.csv", "KiloTestData#csv", DataAccessMethod.Sequential)]
        public void GenerateCorrectCoefficientForKilograms()
        {
            var sut = new SutBuilder<SchwartzMaloneCalculator>().AddDependency(new WeightConverterService()).Build();
            var testCase = this.GetTestCase();
            Debug.WriteLine(testCase);

            var result = sut.Coefficient(WeightUnit.Kilograms, testCase.Sex, testCase.Weight);
            Assert.AreEqual(testCase.Coefficient, result);
        }
    }
}