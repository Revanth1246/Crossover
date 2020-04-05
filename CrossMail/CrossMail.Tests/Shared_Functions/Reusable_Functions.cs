using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CrossMail.Tests.Shared_Functions
{

    public class Reusable_Functions
	{
		public static IWebDriver _browserDriver;
        public static string datapath = "";


        public static void Click(By by)
		{

            _browserDriver.FindElement(by).Click();

		}
        public static void GmailLogin(string URL,string browser)
        {
            try
            {

                _browserDriver = getBrowser(browser);
                _browserDriver.Manage().Cookies.DeleteAllCookies();
                _browserDriver.Manage().Window.Maximize();
                _browserDriver.Navigate().GoToUrl(URL);
                
               
            }
            catch (Exception e)
            {
               
     
            }
        }
        public static void SendKeys(By by, String text)
        {
            _browserDriver.FindElement(by).SendKeys(text);


        }
        public static void Clear(By by)
        {

            _browserDriver.FindElement(by).Clear();
        }
        public static void ClickElement(IWebElement element)
        {
            try
            {
                Scroll(element);
            }
            catch (Exception e)
            {
               
            }

            Thread.Sleep(1000);
            element.Click();

        }
        public static void Scroll(IWebElement Element)
        {
            try
            {
                Actions actions = new Actions(_browserDriver);
                actions.MoveToElement(Element);
                actions.Perform();
                Thread.Sleep(3000);
            }
            catch (Exception e)
            {
          
            }
        }
        public static IWebDriver getBrowser(String browserType)

        {         

            //if (_browserDriver == null)
            //{

                if (browserType.ToLower() == ("firefox"))

                {                                     
                    // FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(datapath + "Drivers\\", "geckoDriver.exe");
                    //_browserDriver = new FirefoxDriver(service);
                    //_browserDriver = new FirefoxDriver();
                    _browserDriver = new FirefoxDriver("./geckodriver.exe");
                }
                else if (browserType.ToLower() == ("chrome"))
                {                  
                    
                    _browserDriver = new ChromeDriver("./");
                }
                else if (browserType.ToLower() == ("ie"))
                {
                 
                
                 
                    try
                    {
                        InternetExplorerOptions caps = new InternetExplorerOptions();
                        caps.IgnoreZoomLevel = true;
                        caps.EnableNativeEvents = false;
                        //caps.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Accept;
                        caps.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        caps.EnablePersistentHover = true;
                        caps.EnsureCleanSession = true;
                        caps.RequireWindowFocus = true;
                        caps.AddAdditionalCapability("binary", datapath + "_browserDrivers\\IEDriverServer.exe");                       
                        _browserDriver = new InternetExplorerDriver(@datapath + "Drivers\\", caps);
                    }
                    catch (Exception IEError)
                    {
                       
                    }
                  
                }

            //}
            return _browserDriver;

        }
        public static void driver_wait(By by)
        {
            try
            {
                Thread.Sleep(2000);
                //Output.WriteLine("Waiting for value");
                WebDriverWait wait = new WebDriverWait(_browserDriver, TimeSpan.FromSeconds(150));
                IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
                {
               
                return d.FindElement(by);
                Thread.Sleep(2000);
                });
            }catch(Exception e)

            {
                
            }
        }
     

 
 

    }
}
