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

   public class SignOutPageObjects:Reusable_Functions
    {

        //Menu Logout option
        public IWebElement Logout_Menu => _browserDriver.FindElement(By.XPath("//*[contains(@aria-label,'Google Account: Crossover test')]"));

        //Email - To field
        public IWebElement Signout => _browserDriver.FindElement(By.XPath("//*[text()='Sign out']"));

        //Email - To field
        public IWebElement Compose_Subject => _browserDriver.FindElement(By.Name("subjectbox"));

        //Email - Send button
        public IWebElement Send_button => _browserDriver.FindElement(By.XPath("//*[@role='button' and text()='Send']"));

        public void Logout()
        {

            Thread.Sleep(1000);
            ClickElement(Logout_Menu);

            driver_wait(By.XPath("//*[text()='Sign out']"));

            ClickElement(Signout);

            driver_wait(By.XPath("//*[text()='Signed out']"));
        

        }
    }
}
