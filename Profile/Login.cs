using InstagramNavegador.Helpers.Wait;
using InstagramNavegador.Models.Results;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramNavegador.Profile.Login
{
    public static class ILogin
    {
        /// <summary>
        /// Realizar login no instagram
        /// </summary>
        /// <param name="insta">Instancia do InstaNav</param>
        /// <returns></returns>
        public static async Task<Result> LoginAccount(this InstaNav insta)
        {
            Result ret = new(0, "Default");
            try
            {
                insta.Driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
                insta.Wait.Until(d => d.FindElement(By.Name("username")));
                await Task.Delay(TimeSpan.FromSeconds(5));
                //Cookies
                try
                {
                    insta.Driver.FindElement(By.XPath("//button[text()='Aceitar tudo']")).Click();
                }
                catch
                {
                    try
                    {
                        insta.Driver.FindElement(By.XPath("//button[text()='Accept All']")).Click();
                    }
                    catch
                    { }
                }
                insta.Driver.FindElement(By.Name("username")).SendKeys(insta.Account.Username);
                await Task.Delay(100);
                insta.Driver.FindElement(By.Name("password")).SendKeys(insta.Account.Password);
                await Task.Delay(500);
                try
                {
                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//div[text()='Entrar']/ancestor::button[1]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                }
                catch
                {
                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//div[text()='Log In']/ancestor::button[1]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                }
                var waits = new List<IWait>
                {
                    new IWait { TYPE = WaitTypes.TYPE_CSS, VALUE = "img[data-testid=user-avatar]" },
                    new IWait { TYPE = WaitTypes.TYPE_CSS, VALUE = "label[for=choice_0]" },
                    new IWait { TYPE = WaitTypes.TYPE_CSS, VALUE = "p[data-testid=login-error-message]" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//span[text()='Discordar da decisão']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//span[text()='Disagree with the decision']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='OK']" }
                };
                var r = await Waits.Wait(waits, 10, insta.Driver);
                switch (r)
                {
                    case 0:
                        await Task.Delay(TimeSpan.FromSeconds(10));
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='OK']")).Click();
                            await Task.Delay(5412);
                        }
                        catch { }
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='Agora não']")).Click();
                            await Task.Delay(2645);
                        }
                        catch { }
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='Not Now']")).Click();
                            await Task.Delay(2645);
                        }
                        catch { }
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='Agora não']")).Click();
                            await Task.Delay(2645);
                        }
                        catch { }
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='Not Now']")).Click();
                            await Task.Delay(2645);
                        }
                        catch { }
                        ret.Status = 1;
                        ret.Response = "Sucesso ao entrar na conta";
                        return ret;
                    case 1:
                        ret.Status = -2;
                        ret.Response = "Block: Challenge";
                        return ret;
                    case 2:
                        ret.Status = 2;
                        ret.Response = "Dados incorretos";
                        return ret;
                    case 3:
                        ret.Status = -2;
                        ret.Response = "Challenge";
                        return ret;
                    case 4:
                        ret.Status = -2;
                        ret.Response = "Challenge";
                        return ret;
                    case 5:
                        await Task.Delay(TimeSpan.FromSeconds(10));
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='OK']")).Click();
                            await Task.Delay(5412);
                        }
                        catch { }
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='Agora não']")).Click();
                            await Task.Delay(2645);
                        }
                        catch { }
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='Not Now']")).Click();
                            await Task.Delay(2645);
                        }
                        catch { }
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='Agora não']")).Click();
                            await Task.Delay(2645);
                        }
                        catch { }
                        try
                        {
                            await Task.Delay(345);
                            insta.Driver.FindElement(By.XPath("//button[text()='Not Now']")).Click();
                            await Task.Delay(2645);
                        }
                        catch { }
                        ret.Status = 1;
                        ret.Response = "Sucesso ao entrar na conta";
                        return ret;
                    default:
                        ret.Status = -2;
                        ret.Response = "Conta com bloqueio de SMS";
                        return ret;
                }
            }
            catch (Exception err)
            {
                ret.Err = err;
                ret.Status = -1;
                ret.Response = "Login err: " + err.Message;
            }
            return ret;
        }
    }
}
