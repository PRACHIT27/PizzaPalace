using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestingPizza.StepDefinitions
{
    [Binding]
    public class RegistrationStepDefinitions
    {
        private WebDriver driver;
        [Given(@"The user is on the registation page")]
        public void GivenTheUserIsOnTheRegistationPage()
        {

            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://localhost:7292/Identity/Account/Register";
            Thread.Sleep(1000);
        }

        [When(@"The user enter email ""([^""]*)"" password ""([^""]*)"" and confirm passowrd as ""([^""]*)""")]
        public void WhenTheUserEnterEmailPasswordAndConfirmPassowrdAs(string p0, string p1, string p2)
        {
            IWebElement emailInput = driver.FindElement(By.Name("Input.Email"));
            IWebElement passwordInput = driver.FindElement(By.Name("Input.Password"));
            IWebElement confirmPasswordInput = driver.FindElement(By.Name("Input.ConfirmPassword"));
            emailInput.SendKeys(p0);
            passwordInput.SendKeys(p1);
            confirmPasswordInput.SendKeys(p2);
        }
        [When(@"User clicks the ""([^""]*)"" button")]
        public void UserClicksRegisterButton(string buttonName)
        {
            IWebElement loginButton = driver.FindElement(By.Id("registerSubmit"));
            Assert.AreEqual(buttonName, loginButton.Text);
            loginButton.Click();
        }
        [Then(@"The user lands on registration confirmed page with email ""([^""]*)""")]
        public void ThenTheUserLandsOnRegistrationConfirmedPage(string p0)
        {
            Assert.AreEqual("https://localhost:7292/Identity/Account/RegisterConfirmation?email="+p0+ "&returnUrl=%2F", driver.Url);
        }
    }
}
