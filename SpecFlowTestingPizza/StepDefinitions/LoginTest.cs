

using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Edge;

namespace SpecFlowTestingPizza.StepDefinitions
{
    [Binding]
    public class LoginTest
    {
        private IWebDriver driver;
        [Given(@"The user is on the login page")]
        public void GivenTheUserIsOnLoginPage()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://localhost:7292/Identity/Account/Login";
            Thread.Sleep(1000);
        }

        [When(@"The user enters the email ""(.*)"" and password ""(.*)""")]
        public void WhenTheUserEntersTheEmailAndPassword(string email, string password)
        {
            IWebElement emailInput = driver.FindElement(By.Name("Input.Email"));
            IWebElement passwordInput = driver.FindElement(By.Name("Input.Password"));

            // Input the email and password
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
        }
        [When(@"User clicks ""([^""]*)"" button")]
        public void UserClicksLoginButton(string buttonName)
        {
            IWebElement loginButton = driver.FindElement(By.Id("login-submit"));
            Assert.AreEqual(buttonName, loginButton.Text);
            loginButton.Click();
        }
        [Then(@"The user should be directed to home pages")]
        public void TheUserShouldBeDirectedToHomePage()
        {
            Assert.AreEqual("https://localhost:7292/", driver.Url);
        }
    }
}
