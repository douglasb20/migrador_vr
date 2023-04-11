using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigradorRP.libs
{
    internal class ClientesPGDAO : DefaultModelPG
    {
        public ClientesPGDAO (){
            this.tabela = "clientes";
        }

        public void LimpaTudoAntes()
        {
            try
            {
                string query = "delete from clientes";

                this.ExecuteNonQuery(query);
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        public DataTable ExportaClientes()
        {
            try
            {
                string query =  "select " +
                                "cli_001 as id, " +
                                "cli_002 as razao, " +
                                "cli_004 as cnpj_cpf, " +
                                "cli_005 as rg_ie, " +
                                "cep_004 as endereco, " +
                                "cli_008 as numero, " +
                                "cli_009 as comple, " +
                                "cep_003 as bairro, " +
                                "cidade_desc as cidade, " +
                                "uf as uf, " +
                                "cep_002 as cep, " +
                                "cli_012 as tel1, " +
                                "cli_013 as tel2, " +
                                "'' as dt_nasc, " +
                                "'C' as tipo, " +
                                "cli_003 as fant, " +
                                "email as email, " +
                                "'' as contato, " +
                                "'' as obs, " +
                                "email as emailnfe, " +
                                "'' as nome_contador, " +
                                "'' as email_contador " +
                                "from clientes";
                return this.ExecuteQuery(query);
            }
            catch(Exception err)
            {
                throw err;
            }
        }
    }
}
