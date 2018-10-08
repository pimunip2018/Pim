using Helpdesk.Infrastructure.Data;
using HelpDesk.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.BLL
{
    public class BLLPessoaPF
    {
        private DALConexao Conexao;


        public BLLPessoaPF(DALConexao dalConexao)
        {
            this.Conexao = dalConexao;
        }

        public void Incluir(PessoaPF modelo)
        {
            if (modelo.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do Tipo de Pessoa é obrigatório");
            }

            DALPessoaPF DalObj = new DALPessoaPF(Conexao);
            DalObj.Incluir(modelo);
        }

        public void Alterar(PessoaPF modelo)
        {
            if (modelo.PessoaPFId < 0)
            {
                throw new Exception("O código do Tipo de Pessoa é obrigatório");
            }
            if (modelo.Nome.Trim().Length == 0)
            {
                throw new Exception("O nome do Tipo de Pessoa é obrigatório");
            }

            DALPessoaPF DalObj = new DALPessoaPF(Conexao);
            DalObj.Alterar(modelo);
        }

        public void Excluir(int id)
        {
            DALPessoaPF DalObj = new DALPessoaPF(Conexao);
            DalObj.Excluir(id);
        }

        public DataTable Localizar(string valor)
        {
            DALPessoaPF DalObj = new DALPessoaPF(Conexao);
            return DalObj.Localizar(valor);

        }
        public TipoUsuario CarregaPessoaPF(int id)
        {
            DALPessoaPF DalObj = new DALPessoaPF(Conexao);
            return DalObj.CarregaPessoaPF(id);
        }
    }
}
