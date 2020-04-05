using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

using CrossMail.Tests.Shared_Functions;
using System.Threading;


namespace CrossMail.Tests.PageObjects
{
    public class LoginPageObject : Reusable_Functions
    {

             //Username field
        public IWebElement Username => _browserDriver.FindElement(By.Id("identifierId"));

        //Next button on username Page
        public IWebElement Username_Nextbtn => _browserDriver.FindElement(By.XPath(" //*[text()='Next']"));

        //Password field
        public IWebElement Password => _browserDriver.FindElement(By.XPath("//*[@name='password']"));

        //Next button on Password Page
        public IWebElement passwordNext => _browserDriver.FindElement(By.Id("passwordNext"));

        public void enterusercredentials(string username, string password)
        {

            Username.SendKeys(username);
            ClickElement(Username_Nextbtn);
            
            driver_wait(By.XPath("//*[@name='password']"));
       
            Password.SendKeys(password);
            ClickElement(passwordNext);
        }

       



    }
}
