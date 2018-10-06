using HelpDesk.Domain.Modelo;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Helpdesk.Infrastructure.Data
{
    public class DALTipoPessoa
    {
        private DALConexao Conexao;

        public DALTipoPessoa(DALConexao dalConexao)
        {
            this.Conexao = dalConexao;
        }

        public void Incluir(TipoPessoa modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexao.ObjetoConexao;
            cmd.CommandText = "insert into TipoUsuario(nome) " +
                "values (@nome); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", modelo.Nome);
            Conexao.Conectar();
            cmd.ExecuteNonQuery();
            Conexao.Desconectar();
        }

        public void Alterar(TipoPessoa modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexao.ObjetoConexao;
            cmd.CommandText = "update TipoUsuario " +
                "set nome= (@nome) where TipoUsuarioId = @id";
            cmd.Parameters.AddWithValue("@id", modelo.TipoPessoaId);
            cmd.Parameters.AddWithValue("@nome", modelo.Nome);
            Conexao.Conectar();
            cmd.ExecuteNonQuery();
            Conexao.Desconectar();
        }

        public void Excluir(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexao.ObjetoConexao;
            cmd.CommandText = "delete from TipoUsuario " +
                "where TipoUsuarioId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            Conexao.Conectar();
                    cmd.ExecuteNonQuery();
            Conexao.Desconectar();
        }

        public DataTable Localizar(string valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TipoUsuario where nome like '%" +
                valor + "%'", Conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public TipoPessoa CarregaTipoPessoa(int id)
        {
            TipoPessoa modelo = new TipoPessoa();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexao.ObjetoConexao;
            cmd.CommandText = "select * from TipoUsuario where TipoUsuarioId = @id";
            cmd.Parameters.AddWithValue("@id", id);
            Conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if(registro.HasRows)
            {
                registro.Read();
                modelo.TipoPessoaId = Convert.ToInt32(registro["TipoUsuarioId"]);
                modelo.Nome = Convert.ToString(registro["Nome"]);
            }
            return modelo;
        }
    }
}
