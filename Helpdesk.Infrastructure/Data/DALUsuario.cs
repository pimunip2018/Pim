using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Infrastructure.Data
{
    public class DALUsuario
    {
        private DALConexao conexao = new DALConexao();
        private SqlDataReader ler;

        public SqlDataReader iniciaSessao(string cpf, string senha)
        {
            SqlCommand cmd = new SqlCommand("spIniciaSessao",conexao.Conectar());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CPF", cpf);
            cmd.Parameters.AddWithValue("@Senha", senha);
            ler = cmd.ExecuteReader();
            return ler;

        }

    }
}
