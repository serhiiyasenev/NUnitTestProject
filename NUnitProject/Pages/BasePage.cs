using NUnitProject.Core;
using SeleniumExtras.PageObjects;

namespace NUnitProject.Pages
{
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(WebDriverManager.Driver, this);
        }
    }
}
