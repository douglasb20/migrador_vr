using System;
using System.Data;

namespace MigradorRP.libs
{
    internal class MateriaisPGDAO : DefaultModelPG
    {
        public MateriaisPGDAO()
        {
            this.tabela = "materiais";
        }

        public void LimpaTudoAntes()
        {
            try
            {
                string query = "truncate table materiais cascade; truncate table setor_estoque_material cascade";

                this.ExecuteNonQuery(query);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExportaProdutos()
        {
            string query = "select " +
                        "mat_003 as desc_pro," +
                        "'N'::varchar as tipo, " +
                        "ncm ," +
                        "(select uni_003 from unidades as u where u.uni_001 = m.uni_001) as unidade," +
                        "mat_012 as custo," +
                        "mat_008 as venda," +
                        "mat_018 as margem," +
                        "mat_004 as codbar," +
                        "(SELECT cat_002 from categoria as c where c.cat_001 = m.cat_001) as categ," +
                        "(SELECT quantidade from setor_estoque_material as sem where sem.id_material = m.mat_001) as estoque, " +
                        "cest, " +
                        "cso_codigo as csosn," +
                        "b_exporta_peso_balanca " +
                        "from materiais as m " +
                        (ConfigReader.GetConfigValue("Produtos", "mostra_inativos") == "true" ? "" : "where sit_001 = '4'");

            return this.ExecuteQuery(query);
        }

        public DataTable ExportaClientes()
        {
            string query = "select " +
                        "mat_001 as id_prod_int," +
                        "emp_001 as id_emp," +
                        "mat_003 as desc_pro," +
                        "mat_004 as codbar," +
                        (ConfigReader.sistema == "LeStore" ? "cod_ref as refer," : "") +
                        "(select uni_003 from unidades as u where u.uni_001 = m.uni_001) as unidade," +
                        "sit_001 as status," +
                        "mat_012 as custo," +
                        "mat_008 as venda," +
                        "mat_018 as margem," +
                        "(SELECT cat_002 from categoria as c where c.cat_001 = m.cat_001) as categ," +
                        "(select sub_002 from subcategoria as sb where sb.sub_001 = m.sub_001) as subcat," +
                        "(SELECT quantidade from setor_estoque_material as sem where sem.id_material = m.mat_001) as estoque," +
                        "cso_codigo as csosn," +
                        "cfop_consumidor as cfop," +
                        "icms as icms," +
                        "cst_consumidor as cst," +
                        "pis_codigo_saida as pis," +
                        "cof_codigo_saida as cofins," +
                        "cest," +
                        "ncm ," +
                        "b_exporta_peso_balanca " +
                        "from materiais as m";

            return this.ExecuteQuery(query);
        }

    }
}
