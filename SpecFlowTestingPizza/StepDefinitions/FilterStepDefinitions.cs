using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestingPizza.StepDefinitions
{
    [Binding]
    public class FilterStepDefinitions
    {
        private WebDriver driver;
        [Given(@"The user is logged in on the home page")]
        public void GivenTheUserIsLoggedInOnTheHomePage()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://localhost:7292/Identity/Account/Login";
            IWebElement emailInput = driver.FindElement(By.Name("Input.Email"));
            IWebElement passwordInput = driver.FindElement(By.Name("Input.Password"));
            // Input the email and password
            emailInput.SendKeys("pt@xyz.com");
            passwordInput.SendKeys("Abc@123");
            IWebElement loginButton = driver.FindElement(By.Id("login-submit"));
            loginButton.Click();
            Thread.Sleep(1000);
        }

        [When(@"The user enters the pizza name ""([^""]*)"" and chooses category as ""([^""]*)""")]
        public void WhenTheUserEntersThePizzaNameAndChoosesCategoryAs(string p0, string p1)
        {
            IWebElement searchInput = driver.FindElement(By.Id("sterm"));
            IWebElement categorySelect = driver.FindElement(By.Id("categoryId"));
            searchInput.SendKeys(p0);
            var categorySelectElement = new SelectElement(categorySelect);
            categorySelectElement.SelectByText(p1);
        }
        [When(@"The user clicks on ""([^""]*)"" button")]
        public void UserClicksOnSearchButton(string p0) 
        {
            IWebElement searchBtn = driver.FindElement(By.Id("searchSubmit"));
            Assert.AreEqual(p0, searchBtn.Text);
            searchBtn.Click();
        }
        [Then(@"The pizza ""([^""]*)"" should be displayed")]
        public void ThenThePizzaShouldBeDisplayed(string p0)
        {
            IWebElement searchResult = driver.FindElement(By.ClassName("card-title"));
            Assert.AreEqual(p0, searchResult.Text);
            Console.WriteLine(searchResult.Text);
            driver.Quit();
        }
    }
}
