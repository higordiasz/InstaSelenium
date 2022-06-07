using InstagramNavegador.Helpers.Wait;
using InstagramNavegador.Models.Results;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramNavegador.Profile.Follow
{
    public static class IFollow
    {
        public static async Task<Result> FollowUser(this InstaNav insta, string username, bool first = true)
        {
            Result ret = new(0, "Default");
            try
            {
                if (insta.Driver.Url != "https://www.instagram.com/")
                {
                    insta.Driver.Navigate().GoToUrl("https://www.instagram.com/");
                }
                await Task.Delay(1547);
                insta.Wait.Until(d => d.FindElement(By.CssSelector("input[type='text']")));
                await Task.Delay(1253);
                insta.Driver.FindElement(By.CssSelector("input[type='text']")).SendKeys(username);
                await Task.Delay(854);
                var w = new WebDriverWait(insta.Driver, TimeSpan.FromSeconds(10));
                try
                {
                    w.Until(d => d.FindElement(By.XPath($"//div[text()='{username}']")));
                    insta.Driver.FindElement(By.XPath($"//div[text()='{username}']")).Click();
                    await Task.Delay(1345);
                }
                catch
                {
                    insta.Driver.Navigate().GoToUrl($"https://www.instagram.com/{username}/");
                    await Task.Delay(1248);
                }
                var waits = new List<IWait>
                {
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = $"//h2[text()='{username}']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h2[text()=='Esta página não está disponível.']" },
                    new IWait {TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h2[text()='Sorry, this page isn't available.']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h3[text()'Adicionar telefone para voltar ao Instagram']" },
                    new IWait {TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h3[text()='Add Phone Number to Get Back Into Instagram']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h2[text()='Confirme que é você fazendo login']" },
                    new IWait {TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h2[text()='Confirm that it's you by signing in']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h2[text()='Erro']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Seguir']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Seguir de volta']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Follow']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Follow Back']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button//div[text()='Enviar mensagem']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button//div[text()='Message']" }
                };
                var r = await Waits.Wait(waits, 10, insta.Driver);
                if (r == 0 || r == 8 || r == 9 || r == 10 || r == 11 || r == 12 || r == 13)
                {
                    waits.Clear();
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Seguir de volta']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Follow']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Seguir']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Follow Back']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button//div[text()='Enviar mensagem']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button//div[text()='Message']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h2[text()=='Esta página não está disponível.']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h2[text()='Sorry, this page isn't available.']" });
                    r = await Waits.Wait(waits, 10, insta.Driver);
                    if (r < 4)
                    {
                        await Task.Delay(1245);
                        var actions = new Actions(insta.Driver);
                        try
                        {
                            switch (r)
                            {
                                case 0:
                                    var element = insta.Driver.FindElement(By.XPath("//button[text()='Seguir']"));
                                    actions.MoveToElement(element);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    element.Click();
                                    break;
                                case 1:
                                    var element1 = insta.Driver.FindElement(By.XPath("//button[text()='Seguir de volta']"));
                                    actions.MoveToElement(element1);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    element1.Click();
                                    break;
                                case 2:
                                    var element2 = insta.Driver.FindElement(By.XPath("//button[text()='Follow']"));
                                    actions.MoveToElement(element2);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    element2.Click();
                                    break;
                                case 3:
                                    var element3 = insta.Driver.FindElement(By.XPath("//button[text()='Follow Back']"));
                                    actions.MoveToElement(element3);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    element3.Click();
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception err)
                        {
                            ret.Err = err;
                        }
                        await Task.Delay(1245);
                        waits.Clear();
                        waits.Add(new IWait { TYPE = 3, VALUE = "//button//div[text()='Enviar mensagem']" });
                        waits.Add(new IWait { TYPE = 3, VALUE = "//button//div[text()='Message']" });
                        waits.Add(new IWait { TYPE = 3, VALUE = "//h3[text()='Tente novamente mais tarde']" });
                        waits.Add(new IWait { TYPE = 3, VALUE = "//h3[text()='Try again later']" });
                        waits.Add(new IWait { TYPE = 3, VALUE = "//h3[text()='Você não pode seguir contas no momento']" });
                        waits.Add(new IWait { TYPE = 3, VALUE = "//h3[text()='You cannot follow accounts at the moment']" });
                        r = await Waits.Wait(waits, 10, insta.Driver);
                        switch (r)
                        {
                            case 0:
                            case 1:
                                ret.Status = 1;
                                ret.Response = "Sucesso ao seguir perfil";
                                break;
                            case 2:
                            case 3:
                                ret.Status = 4;
                                ret.Response = "Bloqueio temporário";
                                break;
                            case 4:
                            case 5:
                                ret.Status = 4;
                                ret.Response = "Bloqueio temporário";
                                break;
                            default:
                                if (first)
                                {
                                    return await insta.FollowUser(username, false);
                                }
                                else
                                {
                                    ret.Status = -1;
                                    ret.Response = "Erro ao carregar o perfil";
                                    return ret;
                                }
                        }
                    }
                    else
                    {
                        switch (r)
                        {
                            case 4:
                            case 5:
                                ret.Status = 3;
                                ret.Response = "Ja seguia o perfil";
                                break;
                            case 6:
                            case 7:
                                ret.Status = -1;
                                ret.Response = "Não foi possivel carregar o perfil";
                                break;
                            default:
                                if (first)
                                {
                                    return await insta.FollowUser(username, false);
                                }
                                else
                                {
                                    ret.Status = -1;
                                    ret.Response = "Erro ao carregar o perfil";
                                    return ret;
                                }
                        }
                    }
                }
                else
                {
                    switch (r)
                    {
                        case 1:
                        case 2:
                            ret.Status = -1;
                            ret.Response = "Não foi possivel carregar o perfil";
                            break;
                        case 3:
                        case 4:
                            ret.Status = 0;
                            ret.Response = "Bloqueio de SMS";
                            break;
                        case 5:
                        case 6:
                            ret.Status = 2;
                            ret.Response = "Confirmar login";
                            break;
                        case 7:
                            ret.Status = -1;
                            ret.Response = "Náo foi possivel carregar o perfil";
                            break;
                        default:
                            if (first)
                            {
                                return await insta.FollowUser(username, false);
                            }
                            else
                            {
                                ret.Status = -1;
                                ret.Response = "Erro ao carregar o perfil";
                                return ret;
                            }
                    }
                }
            }
            catch (Exception err)
            {
                ret.Err = err;
                ret.Status = -1;
                ret.Response = "Follow err: " + err.Message;
            }
            return ret;
        }
    }
}
