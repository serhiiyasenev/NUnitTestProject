using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using static NUnitProject.Core.WebDriverManager;

namespace NUnitProject.Utils
{
    public static class ElementExtensions
    {
        public static void ScrollToElement(this IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(false);", element);
        }

        public static void HoverOver(this IWebElement element)
        {
            var action = new Actions(Driver);
            action
                .MoveToElement(element)
                .Build()
                .Perform();
        }
    }
}
