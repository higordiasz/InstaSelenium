using InstagramNavegador.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramNavegador.Profile.Id
{
    public static class IUserId
    {
        public static Result GetUserId(this InstaNav insta)
        {
            Result ret = new(0, "Default");
            try
            {
                var cookir = insta.Driver.Manage().Cookies.GetCookieNamed("ds_user_id");
                ret.Response = cookir.Value;
                ret.Status = 1;
            }
            catch(Exception err)
            {
                ret.Err = err;
                ret.Status = -1;
                ret.Response = "Id Err: " + err.Message;
            }
            return ret;
        }
    }
}
