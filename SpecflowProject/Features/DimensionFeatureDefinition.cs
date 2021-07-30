using FluentAssertions;
using NUnitProject.Const;
using NUnitProject.Core;
using NUnitProject.Steps;
using TechTalk.SpecFlow;

namespace SpecflowProject
{
    [Binding]
    class DimensionFeatureDefinition
    {

        private readonly BaseSteps _baseSteps;
        private (int, int) _oldDimension;

        public DimensionFeatureDefinition()
        {
            _baseSteps = new BaseSteps();
        }

        [Given(@"open browser window")]
        public void GivenOpenBrowserWindow()
        {
            _baseSteps.NavigateToUrl(Urls.Base);
        }

        [Given(@"get dimension size of full screen")]
        public void GivenGetDimensionSizeOfFullScreen()
        {
            _oldDimension = WebDriverManager.GetWindowSize();
        }

        [When(@"I change dimention resolutun to custom")]
        public void WhenIChangeDimentionResolutunToCustom()
        {
            WebDriverManager.ChangeWindowSize(600, 600);
        }

        [Then(@"resolution should be differe from initial")]
        public void ThenResolutionShouldBeDiffereFromInitial()
        {
            var newDimension = WebDriverManager.GetWindowSize();
            _oldDimension.Should().NotBeSameAs(newDimension);
        }
    }
}
