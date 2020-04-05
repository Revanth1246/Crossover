using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using Xunit.Extensions;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using System.Threading;
using CrossMail.Tests.PageObjects;
using CrossMail.Tests.Shared_Functions;
using OpenQA.Selenium.Support.UI;
using Xunit.Abstractions;

namespace CrossMail.Tests
{
    public class GMailTests : Reusable_Functions, IDisposable
    {
        public ITestOutputHelper Output;
     
        //Created Pageobjects Class references
        SendEMailPageObject SEP = new SendEMailPageObject();
        LoginPageObject GPO = new LoginPageObject();
        SignOutPageObjects SOP = new SignOutPageObjects();
   
        //IWebDriver _browserDriver;
        IConfiguration _config;
        public GMailTests(ITestOutputHelper testOutputHelper)

        { 
             Output = testOutputHelper;
           //Loading the config.json file
            _config = new ConfigurationBuilder()
                     .AddJsonFile("config.json")
                     .Build();
            // Calling the browser
            _browserDriver = getBrowser(_config["browser"]);           
               
        }

        public void Dispose()
        {

            SOP.Logout();
            Output.WriteLine("Gmail Signout Successsfully");
            _browserDriver.Quit();
            Output.WriteLine("Browser Closed Successfully");
        }

        [Fact]
        public void Should_Send_Email()
        {
            try
            {
                string startupPath = System.IO.Directory.GetCurrentDirectory();
                Console.WriteLine("startupPath fact "+ startupPath);
                string startupPath1 = Environment.CurrentDirectory;

                Output.WriteLine("startupPath1:" + startupPath1);

                _browserDriver.Navigate().GoToUrl(_config["URL"]);
                // maximizing the window
                _browserDriver.Manage().Window.Maximize();
                Output.WriteLine("Username is " + _config["username"] + ": Password is " + _config["password"]);

                //calling Pageobjects enterusercredentials method
                GPO.enterusercredentials(_config["username"], _config["password"]);
                Output.WriteLine("Sending Email to "+ _config["username"]+"gmail.com");

                //calling SendMail
                SEP.SendEmail(_config["username"]);
                Output.WriteLine("Email Sent Successfully " + _config["username"] + "gmail.com");


            }
            catch (Exception e)
            {
                Output.WriteLine("Error on Gmail:" + e.Message);

            }
        }

    
    }
}

    

    
    

