using HelpDesk.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpdesk.Infrastructure.Data
{
    public class DALPessoa
    {
        private DALConexao Conexao;

        public DALPessoa(DALConexao dalConexao)
        {
            this.Conexao = dalConexao;
        }


        public void Incluir(Pessoa modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexao.ObjetoConexao;
            cmd.CommandText = "[dbo].[spTipoUsuarioInsert]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nome", modelo.Nome);
            Conexao.Conectar();
            cmd.ExecuteNonQuery();
            Conexao.Desconectar();
        }

        public void Alterar(Pessoa modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexao.ObjetoConexao;
            cmd.CommandText = "[dbo].[spTipoUsuarioUpdate]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", modelo.CPF);
            cmd.Parameters.AddWithValue("@nome", modelo.Nome);
            Conexao.Conectar();
            cmd.ExecuteNonQuery();
            Conexao.Desconectar();
        }

        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexao.ObjetoConexao;
            cmd.CommandText = "[dbo].[spTipoUsuarioDelete]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            Conexao.Conectar();
            cmd.ExecuteNonQuery();
            Conexao.Desconectar();
        }

        public DataTable Localizar(string valor)
        {

            DataTable tabela = new DataTable();
            SqlCommand cm = new SqlCommand("[dbo].[spPessoaLocaliza]", Conexao.Conectar());
            cm.CommandType = CommandType.StoredProcedure;
            cm.Parameters.AddWithValue("@valor", Convert.ToString(valor));
            SqlDataAdapter da = new SqlDataAdapter(cm);
            da.Fill(tabela);
            return tabela;
        }

        public TipoUsuario CarregaPessoaPF(int id)
        {
            TipoUsuario modelo = new TipoUsuario();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexao.ObjetoConexao;
            cmd.CommandText = "[dbo].[spPessoaPFLocaliza] ";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            Conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.TipoPessoaId = Convert.ToInt32(registro["PessoaPFId"]);
                modelo.Nome = Convert.ToString(registro["Nome"]);
            }
            return modelo;
        }
    }
}
