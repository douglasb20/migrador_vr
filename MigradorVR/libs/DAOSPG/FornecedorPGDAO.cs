﻿using System;
using System.Data;

namespace MigradorRP.libs
{
    internal class FornecedorPGDAO : DefaultModelPG
    {
        public FornecedorPGDAO()
        {
            this.tabela = "fornecedor";
        }

        public void LimpaTudoAntes()
        {
            try
            {
                string query = "delete from fornecedor; ALTER TABLE fornecedor DROP CONSTRAINT IF EXISTS fk_fornecedor_cidade";

                this.ExecuteNonQuery(query);
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        public DataTable ExportaFornecedores()
        {
            try
            {
                string query = "select " +
                                "id_fornecedor as id, " +
                                "razao_social as razao, " +
                                "cnpj as cnpj_cpf, " +
                                "inscricao_estadual as rg_ie, " +
                                "endereco_logradouro as endereco, " +
                                "endereco_numero as numero, " +
                                "endereco_complemento as comple, " +
                                "endereco_bairro as bairro, " +
                                "endereco_cidade as cidade, " +
                                "endereco_uf as uf, " +
                                "endereco_cep as cep, " +
                                "telefone1 as tel1, " +
                                "telefone2 as tel2, " +
                                "'' as dt_nasc, " +
                                "'F' as tipo, " +
                                "nome_fantasia as fant, " +
                                "email as email, " +
                                "'' as contato, " +
                                "'' as obs, " +
                                "email as emailnfe, " +
                                "'' as nome_contador, " +
                                "'' as email_contador " +
                                "from fornecedor";
                return this.ExecuteQuery(query);
            }
            catch(Exception err)
            {
                throw err;
            }
        }
    }
}
