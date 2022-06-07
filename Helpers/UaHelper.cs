using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramNavegador.Helpers.Ua
{
    public static class UaHelper
    {
        private static List<string> Uas = new()
        {
            "",
            ""
        };

        public static string GetUa()
        {
            Random rand = new Random();
            int ua = rand.Next(0, Uas.Count);
            return Uas[ua];
        }

    }
}
