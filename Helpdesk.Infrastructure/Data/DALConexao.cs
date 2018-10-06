using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Infrastructure.Data
{
    public class DALConexao
    {

        private string _stringConexao= "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=help_desk;Integrated Security=True";
        private SqlConnection _conexao;

        public DALConexao()
        {
            this._conexao = new SqlConnection();
            this._conexao.ConnectionString = _stringConexao;
        }

        public string StringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }
        }

        public SqlConnection ObjetoConexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }
        }

        public SqlConnection Conectar()
        {
           if(_conexao.State== ConnectionState.Closed)
            {
                _conexao.Open();
            }
            return _conexao;
        }

        public SqlConnection Desconectar()
        {
            if (_conexao.State == ConnectionState.Open)
            {
                _conexao.Close();
            }
            return _conexao;
        }
    }
}
