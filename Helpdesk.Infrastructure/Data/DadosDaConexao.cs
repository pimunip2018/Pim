using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Infrastructure.Data
{
    public class DadosDaConexao
    {
        public static string stringDeConexao
        {
            get { return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=help_desk;Integrated Security=True"; }
        }
    }
}
