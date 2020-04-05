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
   public class SendEMailPageObject :Reusable_Functions
    {
        //Compose New Email button
        public IWebElement Compose_Email => _browserDriver.FindElement(By.XPath("//*[text()='Compose']"));

        //Email - To field
        public IWebElement Compose_Email_To => _browserDriver.FindElement(By.Name("to"));

        //Email - To field
        public IWebElement Compose_Subject => _browserDriver.FindElement(By.Name("subjectbox"));


        //Email - Send button
        public IWebElement Send_button => _browserDriver.FindElement(By.XPath("//*[@role='button' and text()='Send']"));

        public void SendEmail(string email)
        {
            try
            {
                driver_wait(By.XPath("//*[text()='Compose']"));

                ClickElement(Compose_Email);

                driver_wait(By.Name("to"));

                Compose_Email_To.SendKeys(email + "@gmail.com");

                driver_wait(By.Name("subjectbox"));

                Compose_Subject.SendKeys("Test");

                
                driver_wait(By.XPath("//*[@role='button' and text()='Send']"));

                ClickElement(Send_button);
            }catch(Exception mail)
            {
                Console.WriteLine("Error on Send Email:" + mail.Message);
            }

        }
    }
}
