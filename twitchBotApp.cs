using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace twitchBot
{

    public class twitchBotApp
    {
        
        [Fact]
        public void loginStart()
        {
            //Cleans up after its finished
            using (IWebDriver cdriver = new ChromeDriver())
            {
                //if something is missing, timeout for 10 seconds before erroring.
                cdriver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(10));
                //navigate
                cdriver.Navigate().GoToUrl("https://www.twitch.tv/login");


                //user
                IWebElement twitchLoginField = cdriver.FindElement(By.Id("username"));
                twitchLoginField.SendKeys("SirTesterTestington");

                //pass
                IWebElement twitchPassField = cdriver.FindElement(By.Name("password"));
                //twitchPassField.Click();
                twitchPassField.SendKeys("SirTesterTestington");

                //click login button
                IWebElement twitchLogin = cdriver.FindElement(By.ClassName("js-login-text"));
                twitchLogin.Click();

                

                //while (twitchLogin.Displayed =false)
                //{
                //    System.Threading.Thread.Sleep(5000);
                // }

                //enter the game
                cdriver.Navigate().GoToUrl("https://www.twitch.tv/archonthewizard");

                //write to chat
                IWebElement chatBox = cdriver.FindElement(By.ClassName("ember - view js - chat - input chat - input"));
                chatBox.SendKeys("!alchemist !6");

                //submit chat
                //IWebElement chatSubmit = cdriver.FindElement(By.ClassName("button float-right qa-chat-buttons__submit js-chat-buttons__submit"));
                //chatSubmit.Click();
            }
        }

        public static void Main()
        {
            twitchBotApp tStart = new twitchBotApp();
            tStart.loginStart();
        }
    }
}
