using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;

using System;
using InstagramNavegador.Models.Users;
using System.IO;
using InstagramNavegador.Helpers.Ua;

namespace InstagramNavegador
{
    public class InstaNav
    {
        internal IWebDriver Driver { get; set; }
        internal FirefoxOptions Options { get; set; }
        internal WebDriverWait Wait { get; set;}
        internal IJavaScriptExecutor JsExecutor { get; set; }
        internal User Account { get; set; }
        public bool Success { get; set; }
        public Exception Err { get; set; }
        public int DelayMin { get; set; }
        public int DelayMax { get; set; }
        public InstaNav(string username, string password)
        {
            try
            {
                Account = new(username, password);
                Options = new();
                Options.AcceptInsecureCertificates = true;
                var directory = Directory.GetCurrentDirectory();
                var edgeDriverService = FirefoxDriverService.CreateDefaultService(directory);
                //Options.BinaryLocation = $@"{directory}\chromedriver.exe";
                Options.AddArguments("--log-level-3");
                edgeDriverService.HideCommandPromptWindow = true;
                Options.AddArguments("--incognito");
                //Options.AddArguments("--headless");
                Options.AddArguments("--mute-audio");
                //Options.AddArguments("--disable-gpu");
                //Options.AddArguments("--disable-gpu-vsync");
                Options.AddArguments("--window-size=800,600");
                //Options.AddArguments("--blink-settings=imagesEnabled=false");
                //Options.AddArguments("--remote-debugging-port=4444");
                Options.AddArguments($"--user-agent={UaHelper.GetUa()}");
                Driver = new FirefoxDriver(edgeDriverService, Options);
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(80));
                JsExecutor = (IJavaScriptExecutor)Driver;
                Success = true;
            }
            catch (Exception err)
            {
                Err = err;
                Success = false;
            }
        }

        public void CloseNav()
        {
            Driver.Close();
        }

    }
}
