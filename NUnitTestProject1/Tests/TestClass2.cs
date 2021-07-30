using NUnit.Framework;
using NUnitProject.Const;
using NUnitProject.Core;
using NUnitProject.Steps;
using System.Collections.Generic;

namespace NUnitProject.Tests
{
    [TestFixture]
    class TestClass2 : BaseTest
    {
        private readonly MainSteps _mainSteps;
        private readonly LoginSteps _loginSteps;
        private readonly QuadrocoptersSteps _quadrocoptersSteps;

        public TestClass2()
        {
            _mainSteps = new MainSteps();
            _loginSteps = new LoginSteps();
            _quadrocoptersSteps = new QuadrocoptersSteps();
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void DimensionTest()
        {
            var width = 600;
            var height = 600;
            var oldDimension = WebDriverManager.GetWindowSize();

            WebDriverManager.OpenUrl(Urls.Base);
            Logger.Info($"Window Size width: {oldDimension.Item1}, height: {oldDimension.Item2}");
            Logger.Info($"Change Wingow Size width: {width}, height: {height}");
            WebDriverManager.ChangeWindowSize(600, 600);
            var newDimension = WebDriverManager.GetWindowSize();
            Assert.AreNotEqual(oldDimension, newDimension, "WindowSize doesn't changed");
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void LoginTest()
        {
            var login = "asdf@gmail.com";
            var pass = "1234567";

            WebDriverManager.OpenUrl(Urls.Base);
            _mainSteps.ClickOnSignIn();
            Assert.True(_loginSteps.IsLoginFieldDisplayed(), "Login field doesn't displayed");
            _loginSteps.TypeEmail(login);
            _loginSteps.TypePass(pass);
            _loginSteps.clickOnSubmitButton();
            Assert.True(_loginSteps.IsErrorMessageDisplayed(), "ErrorMessage doesn't displayed");
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void MenuItemsTest()
        {
            var expectedItems = 10;
            var expectedMenuItems = new List<string>
             {
                  "Смартфоны, аксессуары", "Планшеты, Ноутбуки, Десктопы", "Батареи и аккумуляторы", "Часы, Фитнес-браслеты", "Хороший вкус", "Аудио", "ТВ, камеры, проекторы", "Smart devices", "Транспорт, дроны", "Еще больше"
             };

            WebDriverManager.OpenUrl(Urls.Base);
            Logger.Info("Verify number of categories");
            Assert.AreEqual(_mainSteps.GetCatalogItems(), expectedItems, "There are differ number of item");
            Logger.Info("Verify titles");
            Assert.AreEqual(expectedMenuItems, _mainSteps.GetCatalogItemsTitles());
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void HoverAndUrlTest()
        {
            var expectedUrl = "quadrocopters-and-droids";

            WebDriverManager.OpenUrl(Urls.Base);
            _mainSteps.HoverOnTransportMenuItem();
            _mainSteps.ClickOnQuadrocopterMenuItem();
            Assert.True(WebDriverManager.GetUrl().Contains(expectedUrl), "Current URL doesn't contain expected text:" + expectedUrl);
            _mainSteps.ClickOnLogo();
            Assert.AreEqual(Urls.Base, WebDriverManager.GetUrl());
        }

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void SortDropdownTest()
        {
            
            var expectedMenuItems = new List<string>
            {
                "По новизне" ,"Акции" ,"От дешевых к дорогим" ,"От дорогих к дешевым"
            };
            WebDriverManager.OpenUrl(Urls.Quadrocopters);
            Assert.AreEqual(expectedMenuItems, _quadrocoptersSteps.GetSortSelectOptions());
            _quadrocoptersSteps.SortBy("От дешевых к дорогим");
            Assert.AreEqual("От дешевых к дорогим", _quadrocoptersSteps.GetActiveOption());
            _quadrocoptersSteps.SortBy("Акции");
            Assert.AreEqual("Акции", _quadrocoptersSteps.GetActiveOption());
        }
    }
}