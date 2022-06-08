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
        /// <summary>
        /// Seguir um perfil do instagram
        /// </summary>
        /// <param name="username">Username do perfil</param>
        /// <returns>
        /// -1 - Pagina não carrega
        /// 0 - Challenge
        /// 1 - Sucesso
        /// 2 - Confirmar Login
        /// 3 - Ja segue o perfil
        /// 4 - Block Temporario
        /// 5 - ERRO AO SEGUIR
        /// </returns>
        public static async Task<Result> FollowUser(this InstaNav insta, string username, bool first = true)
        {
            Result ret = new(0, "Default");
            try
            {
                Console.WriteLine(1);
                if (insta.Driver.Url != "https://www.instagram.com/")
                {
                    insta.Driver.Navigate().GoToUrl("https://www.instagram.com/");
                }
                Console.WriteLine(2);
                await Task.Delay(1547);
                insta.Wait.Until(d => d.FindElement(By.CssSelector("input[type='text']")));
                await Task.Delay(1253);
                insta.Driver.FindElement(By.CssSelector("input[type='text']")).SendKeys(username);
                await Task.Delay(854);
                Console.WriteLine(3);
                var w = new WebDriverWait(insta.Driver, TimeSpan.FromSeconds(10));
                try
                {
                    Console.WriteLine(4);
                    w.Until(d => d.FindElement(By.XPath($"//div[text()='{username}']")));
                    insta.Driver.FindElement(By.XPath($"//div[text()='{username}']")).Click();
                    await Task.Delay(1345);
                }
                catch
                {
                    insta.Driver.Navigate().GoToUrl($"https://www.instagram.com/{username}/");
                    await Task.Delay(1248);
                }
                Console.WriteLine(5);
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
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button//div[text()='Message']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//div[text()='Seguir']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//div[text()='Seguir de volta']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//div[text()='Follow']" },
                    new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//div[text()='Follow Back']" }
                };
                var r = await Waits.Wait(waits, 10, insta.Driver);
                Console.WriteLine(6);
                if (r == 0 || r == 8 || r == 9 || r == 10 || r == 11 || r == 12 || r == 13 || r == 14 || r == 15 || r == 16 || r == 17)
                {
                    Console.WriteLine(7);
                    waits.Clear();
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Seguir']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Seguir de volta']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Follow']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button[text()='Follow Back']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//div[text()='Seguir']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//div[text()='Seguir de volta']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//div[text()='Follow']" });
                    waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//div[text()='Follow Back']" });
                    r = await Waits.Wait(waits, 10, insta.Driver);
                    if (r != -1)
                    {
                        Console.WriteLine(8);
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
                                    Console.WriteLine(9);
                                    break;
                                case 1:
                                    var element1 = insta.Driver.FindElement(By.XPath("//button[text()='Seguir de volta']"));
                                    actions.MoveToElement(element1);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    element1.Click();
                                    Console.WriteLine(10);
                                    break;
                                case 2:
                                    var element2 = insta.Driver.FindElement(By.XPath("//button[text()='Follow']"));
                                    actions.MoveToElement(element2);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    element2.Click();
                                    Console.WriteLine(11);
                                    break;
                                case 3:
                                    var element3 = insta.Driver.FindElement(By.XPath("//button[text()='Follow Back']"));
                                    actions.MoveToElement(element3);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    element3.Click();
                                    Console.WriteLine(12);
                                    break;
                                case 4:
                                    var element4 = insta.Driver.FindElement(By.XPath("//button//div[text()='Seguir']"));
                                    var elementToClick4 = insta.Driver.FindElement(By.XPath("//button//div[text()='Seguir']/ancestor::button[1]"));
                                    actions.MoveToElement(element4);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    elementToClick4.Click();
                                    Console.WriteLine(13);
                                    break;
                                case 5:
                                    var element5 = insta.Driver.FindElement(By.XPath("//button//div[text()='Seguir de volta']"));
                                    var elementToClick5 = insta.Driver.FindElement(By.XPath("//button//div[text()='Seguir de volta']/ancestor::button[1]"));
                                    actions.MoveToElement(element5);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    elementToClick5.Click();
                                    Console.WriteLine(14);
                                    break;
                                case 6:
                                    var element6 = insta.Driver.FindElement(By.XPath("//button//div[text()='Follow']"));
                                    var elementToClick6 = insta.Driver.FindElement(By.XPath("//button//div[text()='Follow']/ancestor::button[1]"));
                                    actions.MoveToElement(element6);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    elementToClick6.Click();
                                    Console.WriteLine(15);
                                    break;
                                case 7:
                                    var element7 = insta.Driver.FindElement(By.XPath("//button//div[text()='Follow Back']"));
                                    var elementToClick7 = insta.Driver.FindElement(By.XPath("//button//div[text()='Follow Back']/ancestor::button[1]"));
                                    actions.MoveToElement(element7);
                                    actions.Perform();
                                    await Task.Delay(267);
                                    elementToClick7.Click();
                                    Console.WriteLine(16);
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception err)
                        {
                            Console.WriteLine(err.Message);
                            ret.Err = err;
                        }
                        await Task.Delay(2894);
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
                        waits.Clear();
                        waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button//div[text()='Enviar mensagem']" });
                        waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//button//div[text()='Message']" });
                        waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h2[text()=='Esta página não está disponível.']" });
                        waits.Add(new IWait { TYPE = WaitTypes.TYPE_XPATH, VALUE = "//h2[text()='Sorry, this page isn't available.']" });
                        r = await Waits.Wait(waits, 5, insta.Driver);
                        switch (r)
                        {
                            case 0:
                            case 1:
                                ret.Status = 3;
                                ret.Response = "Ja seguia o perfil";
                                break;
                            case 2:
                            case 3:
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
