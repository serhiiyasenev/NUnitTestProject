﻿using NUnitProject.Core;
using NUnitProject.Pages;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace NUnitProject.Steps
{
    public class QuadrocoptersSteps : BaseSteps
    {

        QuadrocoptersPage QuadrocoptersPage => new QuadrocoptersPage();

        public IWebDriver Driver { get; private set; }

        public void SortBy(string option)
        {
            QuadrocoptersPage.SortSelect.SelectByText(option);
        }
        public List<string> GetSortSelectOptions()
        {
            return QuadrocoptersPage.SortSelect.Options.Select(x => x.Text).ToList();
        }

        public string GetActiveOption()
        {
            return QuadrocoptersPage.SortSelect.AllSelectedOptions.Select(x => x.Text).FirstOrDefault();
        }

        public void ClickOnBrandFilter()
        {
            QuadrocoptersPage.BrandFilter.Click();
        }

        public void ClickOnCheckboxMi()
        {
            QuadrocoptersPage.CheckBoxMi.Click();
        }

        public List<string> GetMiProductsTitle()
        {
            WaitManager.WaitPageReady();
            return QuadrocoptersPage.MiQuadrocopters.Select(x => x.Text).ToList();
        }

    }
}
