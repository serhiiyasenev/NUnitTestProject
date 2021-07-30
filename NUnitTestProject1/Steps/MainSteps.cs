﻿using NUnitProject.Pages;
using NUnitProject.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace NUnitProject.Steps
{
    public class MainSteps : BaseSteps
    {
        public MainPage MainPage => new MainPage();

        public void ScrollToCopyright()
        {
            MainPage.Copyright.ScrollToElement();
        }

        public string GetCopyrightText()
        {
            return MainPage.Copyright.Text;
        }

        public void TypeIntoSearch(string value)
        {
            MainPage.SearchField.SendKeys(value);
            MainPage.SearchField.SendKeys(Keys.Enter);
        }

        public void ClickOnSignIn()
        {
            MainPage.SignIn.Click();
        }

        public string GetSignInText()
        {
            return MainPage.SignIn.Text;
        }

        public int GetCatalogItems()
        { 
            return MainPage.CatalogItems.Count(x => x.Displayed);
        }

        public List<string> GetCatalogItemsTitles()
        {
            return MainPage.CatalogItems.Where(x => x.Displayed).Select(x => x.Text).ToList();
        }

        public void HoverOnTransportMenuItem()
        {
            MainPage.TransportMenuItem.HoverOver();
        }

        public void ClickOnQuadrocopterMenuItem()
        {
            MainPage.QuadrocoptersMenuItem.Click();
        }

        public void ClickOnLogo()
        {
            MainPage.Logo.Click();
        }
    }
}
