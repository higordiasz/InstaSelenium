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

namespace InstagramNavegador.Media.Like
{
    public static class ILike
    {
        /// <summary>
        /// Curtir uma publicação do instagram
        /// </summary>
        /// <param name="shortcode">Shortcode da publicação</param>
        /// <returns>
        /// 0 - Challenge
        /// 1 - Sucesso
        /// 2 - Confirmar Login
        /// 3 - Ja segue o perfil
        /// 4 - Block Temporario
        /// 5 - ERRO AO CURTIR
        /// </returns>
        public static async Task<Result> LikeMedia(this InstaNav insta, string shortcode, bool first = true)
        {
            Result ret = new(0, "Default");
            try
            {
                insta.Driver.Navigate().GoToUrl($"https://instagram.com/p/{shortcode}/");
                await Task.Delay(1248);
                var waits = new List<IWait>
                {
                    new IWait { TYPE = 3, VALUE = "//*[name()='svg'][@aria-label='Curtir'][@height='24']"},
                    new IWait { TYPE = 3, VALUE = "//*[name()='svg'][@aria-label='Like'][@height='24']"},
                    new IWait { TYPE = 3, VALUE = "//*[name()='svg'][@aria-label='Descurtir'][@height='24']"},
                    new IWait { TYPE = 3, VALUE = "//*[name()='svg'][@aria-label='Unlike'][@height='24']"},
                    new IWait { TYPE = 3, VALUE = "//h2[text()='Esta página não está disponível.']"},
                    new IWait { TYPE = 3, VALUE = "//h2[text()='This page is not available.']"},
                    new IWait { TYPE = 3, VALUE = "//h3[text()'Adicionar telefone para voltar ao Instagram']" },
                    new IWait {TYPE = 3, VALUE = "//h3[text()='Add Phone Number to Get Back Into Instagram']" },
                    new IWait { TYPE = 3, VALUE = "//h2[text()='Confirme que é você fazendo login']" },
                    new IWait {TYPE = 3, VALUE = "//h2[text()='Confirm that it's you by signing in']" },
                    new IWait { TYPE = 3, VALUE = "//h2[text()='Erro']" }
                };
                var r = await Waits.Wait(waits, 15, insta.Driver);
                await Task.Delay(458);
                if (r < 2)
                {
                    try
                    {
                        var actions = new Actions(insta.Driver);
                        if (r == 0)
                        {
                            var element = insta.Driver.FindElement(By.XPath("//*[name()='svg'][@aria-label='Curtir'][@height='24']/ancestor::button[1]"));
                            try
                            {
                                actions.MoveToElement(element);
                                actions.Perform();
                                await Task.Delay(341);
                            }
                            catch { }
                            element.Click();
                        }
                        else
                        {
                            var element = insta.Driver.FindElement(By.XPath("//*[name()='svg'][@aria-label='Like'][@height='24']/ancestor::button[1]"));
                            try
                            {
                                actions.MoveToElement(element);
                                actions.Perform();
                                await Task.Delay(341);
                            }
                            catch { }
                            element.Click();
                        }
                    }
                    catch (Exception err)
                    {
                        ret.Err = err;
                    }
                    await Task.Delay(1342);
                    waits.Clear();
                    waits.Add(new IWait { TYPE = 3, VALUE = "//*[name()='svg'][@aria-label='Descurtir'][@height='24']" });
                    waits.Add(new IWait { TYPE = 3, VALUE = "//*[name()='svg'][@aria-label='Unlike'][@height='24']" });
                    waits.Add(new IWait { TYPE = 3, VALUE = "//h3[text()='Tente novamente mais tarde']" });
                    waits.Add(new IWait { TYPE = 3, VALUE = "//h3[text()='Try Again Later']" });
                    r = await Waits.Wait(waits, 5, insta.Driver);
                    await Task.Delay(1245);
                    switch (r)
                    {
                        case 0:
                        case 1:
                            ret.Status = 1;
                            ret.Response = "Sucesso ao curtir";
                            break;
                        case 2:
                        case 3:
                            ret.Status = 4;
                            ret.Response = "Bloqueio temporário";
                            break;
                        default:
                            ret.Status = -1;
                            ret.Response = "Erro ao carregar o perfil";
                            return ret;
                    }
                }
                else
                {
                    switch (r)
                    {
                        case 2:
                        case 3:
                            ret.Status = 3;
                            ret.Response = "Ja curtiu a publicação";
                            break;
                        case 4:
                        case 5:
                            ret.Status = -1;
                            ret.Response = "Não foi possivel carregar a pagina";
                            break;
                        case 6:
                        case 7:
                            ret.Status = 0;
                            ret.Response = "Bloqueio de SMS";
                            break;
                        case 8:
                        case 9:
                            ret.Status = 2;
                            ret.Response = "Confirmar login";
                            break;
                        default:
                            ret.Status = -1;
                            ret.Response = "Erro ao carregar o perfil";
                            return ret;
                    }
                }
            }
            catch (Exception err)
            {
                ret.Err = err;

                ret.Status = -1;
                ret.Response = "Like err: " + err.Message;
            }
            return ret;
        }
    }
}
