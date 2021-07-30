﻿using FluentAssertions;
using FluentAssertions.Common;
using NUnitProject.Core;
using NUnitProject.Steps;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecflowProject
{
    [Binding]
    class CheckboxFilterFeatureDefinition
    {
        private readonly BaseSteps _baseSteps;
        private readonly QuadrocoptersSteps _quadrocopters;

        public CheckboxFilterFeatureDefinition()
        {
            _baseSteps = new BaseSteps();
            _quadrocopters = new QuadrocoptersSteps();
        }

        [Given(@"User is opening quadrocopters '(.*)' url")]
        public void GivenUserIsOpeningQuadrocoptersUrl(string url)
        {
            WebDriverManager.OpenUrl(url);
        }

        [Given(@"click on Brand Filter")]
        public void GivenClickOnBrandFilter()
        {
            _quadrocopters.ClickOnBrandFilter();
        }

        [When(@"user click on checkbox Mi")]
        public void WhenUserClickOnCheckboxMi()
        {
            _quadrocopters.ClickOnCheckboxMi();
        }

        [Then(@"expected quadrocopters with appropriate titles should be displayed on page")]
        public void ThenExpectedQuadrocoptersWithAppropriateTitlesShouldBeDisplayedOnPage()
        {
            var expectedQuadrocopters = new List<string>()
            {
            "Квадрокоптер Xiaomi Mi Drone White 4K", "Квадрокоптер Xiaomi Mi Drone White", "Трикоптер Xiaomi YI Erida"
            };
            _quadrocopters.GetMiProductsTitle().Should().IsSameOrEqualTo(expectedQuadrocopters);
        }

    }
}
