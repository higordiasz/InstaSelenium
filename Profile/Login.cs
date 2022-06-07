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
                    new IWait { TYPE = WaitTypes.TYPE_CSS, VALUE = "p[data-testid=login-error-message]"}
                };
                var r = await Waits.Wait(waits, 15, insta.Driver);
                switch (r)
                {
                    case 0:
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
                        insta.Wait.Until(d => d.FindElement(By.CssSelector("img[data-testid=user-avatar]")));
                        try
                        {
                            await Task.Delay(1249);
                            IWebElement ativity = null;
                            try
                            {
                                ativity = insta.Driver.FindElement(By.XPath("//*[name()='svg'][@aria-label='Feed de atividades']//ancestor::a[1]"));
                            }
                            catch
                            {
                                ativity = insta.Driver.FindElement(By.XPath("//*[name()='svg'][@aria-label='Activity Feed']//ancestor::a[1]"));
                            }
                            try
                            {
                                ativity.Click();
                                await Task.Delay(3178);
                            }
                            catch { }
                            try
                            {
                                insta.Driver.FindElement(By.CssSelector("body")).Click();
                                await Task.Delay(597);
                            }
                            catch { }
                            insta.Driver.FindElement(By.XPath("//nav//div//div//div//div//div//div//span//img//ancestor::span[1]")).Click();
                            //js.ExecuteScript("document.evaluate(\"//nav//div//div//div//div//div//div//span//img//ancestor::span[1]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                            await Task.Delay(1247);
                            try
                            {
                                insta.JsExecutor.ExecuteScript("document.evaluate(\"//div[text()='Configurações']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                await Task.Delay(1248);
                                insta.Wait.Until(d => d.FindElement(By.XPath("//a[text()='Atividade de login']")));
                                await Task.Delay(248);
                                insta.Driver.FindElement(By.XPath("//a[text()='Atividade de login']")).Click();
                                await Task.Delay(248);
                                insta.Wait.Until(d => d.FindElement(By.XPath("//h2[text()='Atividade de login']")));
                                await Task.Delay(467);
                                try
                                {
                                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//div[text()='Fui eu']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                    await Task.Delay(897);
                                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//button[text()='Confirmar']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                    await Task.Delay(1297);
                                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//*[name()='svg'][@aria-label='Página inicial']//ancestor::a[1]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                }
                                catch
                                {
                                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//*[name()='svg'][@aria-label='Página inicial']//ancestor::a[1]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                }
                            }
                            catch
                            {
                                insta.JsExecutor.ExecuteScript("document.evaluate(\"//div[text()='Settings']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                await Task.Delay(1248);
                                insta.Wait.Until(d => d.FindElement(By.XPath("//a[text()='Login Activity']")));
                                await Task.Delay(248);
                                insta.Driver.FindElement(By.XPath("//a[text()='Login Activity']")).Click();
                                await Task.Delay(248);
                                insta.Wait.Until(d => d.FindElement(By.XPath("//h2[text()='Login Activity']")));
                                await Task.Delay(467);
                                try
                                {
                                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//div[text()='This Was Me']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                    await Task.Delay(897);
                                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//button[text()='Confirm']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                    await Task.Delay(1297);
                                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//*[name()='svg'][@aria-label='Home']//ancestor::a[1]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                }
                                catch
                                {
                                    insta.JsExecutor.ExecuteScript("document.evaluate(\"//*[name()='svg'][@aria-label='Home']//ancestor::a[1]\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.click()");
                                }
                            }
                        }
                        catch (Exception err)
                        {
                            ret.Err = err; 
                        }
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
                    default:
                        ret.Status = -1;
                        ret.Response = "Erro ao entrar";
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
