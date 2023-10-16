using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTestingPizza.StepDefinitions
{
    [Binding]
    public class AddToCartStepDefinitions
    {
        private WebDriver driver;
        [Given(@"The user is logged in on")]
        public void GivenTheUserIsLoggedInOn()
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

        [When(@"Add to cart ""([^""]*)"" and ""([^""]*)""")]
        public void WhenAddToCart(string p0, string p1)
        {
          
            IWebElement pizza1 = driver.FindElement(By.Id(p0));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", pizza1);
            IWebElement pizza2 = driver.FindElement(By.Id(p1)); 
            js.ExecuteScript("arguments[0].click();", pizza2);
            Thread.Sleep(1000);
        }

        [When(@"User navigates to my cart page")]
        public void WhenUserNavigatesToMyCartPage()
        {
            driver.Url = "https://localhost:7292/Cart/GetUserCart";
        }

        [Then(@"Pizzas ""([^""]*)"" and ""([^""]*)"" should be displayed in the cart")]
        public void ThenPizzaAddedShouldBeDisplayedInTheCart(string p0, string p1)
        {
            IWebElement pizzaName1 = driver.FindElement(By.Id(p0));
            IWebElement pizzaName2 = driver.FindElement(By.Id(p1));
            Assert.AreEqual(p0, pizzaName1.Text);
            Assert.AreEqual(p1, pizzaName2.Text);
        }
    }
}
