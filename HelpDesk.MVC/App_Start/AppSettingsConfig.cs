using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HelpDesk.MVC.App_Start
{
    public class AppSettingsConfig
    {
        public static void Load()
        {
            var loadListPageSize = ListPageSize;
        }

        private static int _ListPageSize = -1;
        public static int ListPageSize
        {
            get
            {
                if (_ListPageSize <= 0)
                    if (!int.TryParse(ConfigurationManager.AppSettings["List:PageSize"], out _ListPageSize))
                        throw new ApplicationException("Configuração [List:PageSize] com valor inválido!");

                return _ListPageSize;
            }
        }
    }
}