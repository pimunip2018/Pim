using Helpdesk.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.BLL
{
    public class BLLUSuario
    {
        private DALUsuario Obj = new DALUsuario();
        public string usuario { get; set; }
        public string senha { get; set; }

        public BLLUSuario()
        {

        }

        public SqlDataReader IniciaSessao()
        {
            SqlDataReader Logar;
            Logar = Obj.iniciaSessao(usuario, senha);
            return Logar;
        }

    }
}
