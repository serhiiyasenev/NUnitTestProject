using NUnitProject.Core;
using TechTalk.SpecFlow;

namespace SpecflowProject.Setup
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public void Setup()
        {
            //just for example
            //WebDriverManager.Driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterMethod()
        {
            WebDriverManager.CloseDriver();
        }
    }
}