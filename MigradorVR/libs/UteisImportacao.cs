using MigradorRP.libs.DAOSPG;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Numerics;

namespace MigradorRP.libs
{
    public static class UteisImportacao
    {

        // FUNÇÕES UTEIS PARA O BANCO

        private static string[] Endereco(string text)
        {
            string[] gAddress   = new string[2];
            int indexVirgula    = text.Contains(",") ? text.LastIndexOf(",") : 0;

            if(indexVirgula > 0)
            {
                gAddress[0] = text.Substring(0, indexVirgula);
                gAddress[1] = text.Substring(++indexVirgula);
            }
            else
            {
                gAddress[0] = text;
                gAddress[1] = "S/N";
            }
            return gAddress;
        }
        private static int IbgeRet(string cidade)
        {
            try
            {
                int ibgeCod;
                CidadesPGDAO cidades = new CidadesPGDAO();
                DataRowCollection cidadeBD = cidades.GetQuery($" cid_002 = '{cidade.ToUpper()}' ").ReadAsCollection();

                return ibgeCod = cidadeBD.Count == 0 ? 0 : Convert.ToInt32(cidadeBD[0]["cid_001"].ToString());
            }
            catch (NpgsqlException err)
            {
                throw err;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        private static int undRet(string und)
        {
            try
            {
                UnidadesPGDAO unidades = new UnidadesPGDAO();

                DataRowCollection uniBD = unidades.GetQuery($"uni_003='{und}' ").ReadAsCollection();
                int uniCod;

                if (uniBD.Count == 0)
                {
                    uniBD = unidades.GetQuery("", " uni_001 desc", "1").ReadAsCollection();

                    int ultreg = uniBD.Count == 0 ? 1 : Int32.Parse(uniBD[0]["uni_001"].ToString()) + 1;
                    string dt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");

                    try
                    {
                        Dictionary<string, dynamic> bindUnid = new Dictionary<string, dynamic>()
                        {
                            {"uni_001", ultreg},
                            {"emp_001", 1},
                            {"uni_002", und},
                            {"uni_003", und},
                            {"sit_001", 4},
                            {"usu_001_1", 1 },
                            {"dat_001_1", dt},

                        };

                        unidades.Insert(bindUnid);
                        uniCod = ultreg;
                    }
                    catch (NpgsqlException e)
                    {
                        throw e;
                    }
                }
                else
                {
                    uniCod = Int32.Parse(uniBD[0]["uni_001"].ToString());
                }
                return uniCod;
            }
            catch(NpgsqlException ex) {
                throw new Exception($"Erro de Unidade na unidade {und}: {ex.Message}");
            }catch(Exception ex)
            {
                throw new Exception($"Erro de Unidade na unidade {und}: {ex.Message}");
            }
            
        }

        public static int catRet(string cat)
        {
            CategoriaPGDAO categoria = new CategoriaPGDAO();
            try
            {
                int catCod = 0;
                if (cat != "")
                {
                    DataRowCollection catBD = categoria.GetQuery($"cat_002='{cat.ToUpper()}' ").ReadAsCollection();

                    if (catBD.Count == 0)
                    {
                        catBD = categoria.GetQuery(""," cat_001 desc","1").ReadAsCollection();
                        int ultreg = catBD.Count == 0 ? 1 : Int32.Parse(catBD[0]["cat_001"].ToString()) + 1;
                        string dt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");

                        Dictionary<string, dynamic> bindCat = new Dictionary<string, dynamic>()
                        {
                            {"cat_001", ultreg},
                            {"emp_001", 1},
                            {"cat_002", cat.ToUpper()},
                            {"sit_001", 4},
                            {"usu_001_1", 1},
                            {"dat_001_1", dt },
                            {"cat_003", 1},
                            {"b_exibir_icone", false},

                        };

                        categoria.Insert(bindCat);
                        catCod = ultreg;

                    }
                    else
                    {
                        catCod = Int32.Parse(catBD[0]["cat_001"].ToString());
                    }
                }

                return catCod;
            }
            catch (NpgsqlException ex)
            {
                throw new Exception($"Erro de Categoria: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro de Categoria: {ex.Message}");
            }
            
        }

        private static int sbcatRet(string sbcat)
        {
            SubcategoriaPGDAO subcategoria = new SubcategoriaPGDAO();
            try
            {
                int sbcatCod = 0;
                DataRowCollection sbcatBD = subcategoria.GetQuery($"sub_002='{sbcat.ToUpper()}' ").ReadAsCollection();

                if (sbcatBD.Count == 0)
                {
                    sbcatBD = subcategoria.GetQuery(""," sub_001 desc","1").ReadAsCollection();

                    int ultreg = sbcatBD.Count == 0 ? 1 : Int32.Parse(sbcatBD[0]["sub_001"].ToString()) + 1;
                    string dt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss.fff");

                    Dictionary<string, dynamic> bindSbCat = new Dictionary<string, dynamic>()
                    {
                        {"sub_001", ultreg},
                        {"emp_001", 1},
                        {"sub_002", sbcat.ToUpper()},
                        {"sit_001", 4}
                    };

                    subcategoria.Insert(bindSbCat);
                    sbcatCod = ultreg;
                }
                else
                {
                    sbcatCod = Int32.Parse(sbcatBD[0]["sub_001"].ToString());
                }

                return sbcatCod;
            }catch(NpgsqlException ex)
            {
                throw new Exception($"Erro de SubCategoria: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro de SubCategoria: {ex.Message}");
            }
            
        }
        public async static Task PreparaProdutos(DataRowCollection produtos)
        {
            try
            {
                await Task.Run(() =>
                {
                    MateriaisPGDAO materiais = new MateriaisPGDAO();
                    EstoqueMateriaisPGDAO estoqueMaterial = new EstoqueMateriaisPGDAO();
                    try
                    {
                        ConnectionPG.BeginTransaction();

                        List<Dictionary<string, dynamic>> produtosFormatado  = new List<Dictionary<string, dynamic>>();
                        List<Dictionary<string, dynamic>> estoqueFormatado   = new List<Dictionary<string, dynamic>>();

                        Dictionary<string, string> campos = new Dictionary<string, string>()
                        {
                            {"id_prod_int"      , "mat_001"},
                            {"id_emp"           , "emp_001"},
                            {"desc_pro"         , "mat_003"},
                            {"codbar"           , "mat_004"},
                            {"refer"            , "cod_ref"},
                            {"unidade"          , "uni_001"},
                            {"mtp_001"          , "mtp_001"},
                            {"mat_009"          , "mat_009"},
                            {"status"           , "sit_001"},
                            {"custo"            , "mat_012"},
                            {"venda"            , "mat_008"},
                            {"margem"           , "mat_018"},
                            {"categ"            , "cat_001"},
                            {"subcat"           , "sub_001"},
                            {"setor"            , "id_setor"},
                            {"origem"           , "orm_codigo"},
                            {"csosn"            , "cso_codigo"},
                            {"cfop"             , "cfop_consumidor"},
                            {"icms"             , "icms"},
                            {"cst"              , "cst_consumidor"},
                            {"pis"              , "pis_codigo_saida"},
                            {"cofins"           , "cof_codigo_saida"},
                            {"cest"             , "cest"},
                            {"ncm"              , "ncm"},
                            {"ativa_balanca"    , "b_exporta_peso_balanca" },
                            {"fracionado"       , "b_permite_frac" }
                        };

                        int i = 1;
                        
                        foreach (DataRow row in produtos)
                        {

                            ValidaLinha(row);

                            dynamic subCat  = "";
                            string codigo   = (i).ToString();
                            string desc     = Funcoes.TiraAcento(row["nome_produto"].ToString().Trim());

                            string codean   =  ConfigReader.GetConfigValue("Produtos", "prod_remover_zeros_esquerda") == "true" 
                                ? row["codigo"].ToString().Trim().TrimStart('0') 
                                : row["codigo"].ToString().Trim();

                            string refer    = ConfigReader.GetConfigValue("Produtos", "prod_remover_zeros_esquerda") == "true" 
                                ? row["referencia"].ToString().Trim().TrimStart('0') 
                                : row["referencia"].ToString().Trim();

                            int unidade     = undRet(row["unidade"].ToString().Trim());
                            string estoque  = row["quantidade"].ToString().Replace(",",".") == "" ? "0" : row["quantidade"].ToString().Replace(",", ".");
                            string custo    = (row["compra"].ToString().Trim().Replace(",", "."));
                            string venda    = (row["venda"].ToString().Trim().Replace(",", "."));

                            string margem = ConfigReader.GetConfigValue("Produtos", "calcular_margem") == "true" ?
                                (((Convert.ToDouble(venda.Replace(".", ",")) / Convert.ToDouble(custo.Replace(".", ","))) - 1) * 100).ToString().Replace(",", ".")
                                : row["margem"].ToString().Replace(",", ".");

                            int categ = row["categoria"].ToString().Trim() == "" ? catRet("Padrao") : catRet(row["categoria"].ToString().Trim());
                            int csosn = row["csosn"].ToString().Trim() == "" ? 102 : Convert.ToInt32(row["csosn"].ToString());

                            string cfop = ConfigReader.GetConfigValue("Produtos", "ajusta_cfop_csosn") == "true" ?
                                (csosn == 102 ? "5102" : "5405") :
                                row["cfop"].ToString();

                            int cst             = row["cst"].ToString().Trim() == "" ? (csosn == 102  ? 0 : 60) : Convert.ToInt32(row["cst"].ToString().Trim());
                            int pis             = csosn == 102 ? 99 : 04;
                            int cofins          = csosn == 102 ? 99 : 04;
                            string cest         = row["cest"].ToString().Trim();
                            string ncm          = row["ncm"].ToString().Trim();
                            bool ativa_balanca  = false;

                            if(ConfigReader.GetConfigValue("Produtos","subcategoria_padrao") != "true")
                            {
                                if (row["subcategoria"].ToString().Trim() != "")
                                {
                                    subCat = sbcatRet(row["subcategoria"].ToString().Trim());
                                }
                            }
                            else
                            {
                                subCat = sbcatRet("Padrao");
                            }
                    
                            if(ConfigReader.GetConfigValue("Produtos", "importa_balanca") == "true" && row["unidade"].ToString().Trim() == "KG")
                            {
                                ativa_balanca = true;
                            }

                            Dictionary<string, dynamic> prods = new Dictionary<string, dynamic>()
                            {
                                { campos["id_prod_int"].ToString()      , codigo },
                                { campos["codbar"].ToString()           , codean },
                                { campos["id_emp"].ToString()           , "1" },
                                { campos["desc_pro"].ToString()         , desc },
                                { campos["unidade"].ToString()          , unidade },
                                { campos["mtp_001"].ToString()          , 1 },
                                { campos["mat_009"].ToString()          , 0 },
                                { campos["status"].ToString()           , 4},
                                { campos["custo"].ToString()            , custo },
                                { campos["venda"].ToString()            , venda },
                                { campos["margem"].ToString()           , margem },
                                { campos["categ"].ToString()            , categ },
                                { campos["subcat"].ToString()           , subCat },
                                { campos["setor"].ToString()            , 1 },
                                { campos["origem"].ToString()           , 0 },
                                { campos["cfop"].ToString()             , cfop },
                                { campos["csosn"].ToString()            , csosn },
                                { campos["icms"].ToString()             , 12.00 },
                                { campos["cst"].ToString()              , cst },
                                { campos["pis"].ToString()              , pis },
                                { campos["cofins"].ToString()           , cofins },
                                { campos["cest"].ToString()             , cest },
                                { campos["ncm"].ToString()              , ncm },
                                { campos["ativa_balanca"].ToString()    , ativa_balanca },
                            };

                            if(ConfigReader.sistema == "LeStore")
                            {
                                prods.Add(campos["refer"].ToString(), refer);
                            }
                            if(ConfigReader.sistema == "LeCheff")
                            {
                                prods.Add(campos["fracionado"].ToString(), true);
                            }

                            produtosFormatado.Add(prods);

                            estoqueFormatado.Add(new Dictionary<string, dynamic>()
                            {
                                {"id_material"  , codigo},
                                {"id_setor"     , 1},
                                {"id_empresa"   , 1},
                                {"quantidade"   , estoque},
                            });

                            i++;
                        }

                        materiais.LimpaTudoAntes();
                        materiais.InsertMultiplos(produtosFormatado);

                        if(ConfigReader.GetConfigValue("Produtos", "importa_quantidade") == "true")
                        {
                            estoqueMaterial.InsertMultiplos(estoqueFormatado);
                        }

                        ConnectionPG.Commit();

                    }
                    catch (Exception ex)
                    {
                        ConnectionPG.Rollback();
                        throw ex;
                    }

                });
            }catch(Exception ex)
            {
                throw ex;
            }

        }

        public async static Task PreparaClientes(DataRowCollection clientes)
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        ClientesPGDAO clientesDB = new ClientesPGDAO();
                        List<Dictionary<string, dynamic>> clientesFormatado = new List<Dictionary<string, dynamic>>();

                        ConnectionPG.BeginTransaction();
                    

                        var campos = new Dictionary<string, string>()
                        {
                            {"id_cli"   , "cli_001"},
                            {"id_emp"   , "emp_001"},
                            {"razao"    , "cli_002"},
                            {"fant"     , "cli_003"},
                            {"cnpj"     , "cli_004"},
                            {"rgie"     , "cli_005"},
                            {"sit_ie"   , "situacao_ie"},
                            {"endereco" , "cep_004"},
                            {"numero"   , "cli_008"},
                            {"bairro"   , "cep_003"},
                            {"cidade"   , "cidade_desc"},
                            {"cidibge"  , "cid_001"},
                            {"uf"       , "uf"},
                            {"comple"   , "cli_009"},
                            {"cep"      , "cep_002"},
                            {"tel1"     , "cli_012"},
                            {"tel2"     , "cli_013"},
                            {"dtcad"    , "dat_001_1"},
                            {"saldo"    , "saldo_atual"},
                            {"limite"   , "limite_credito"},
                            {"email"    , "email"},
                            {"tipo"     , "tipo_pessoa"},
                            {"sexo"     , "sexo"},
                            {"status"   , "sit_001" }
                        };

                        int i = 1;
                        foreach (DataRow cliente in clientes)
                        {
                            string codean = ConfigReader.GetConfigValue("Clientes", "cli_remover_zeros_esquerda") == "true"  
                                 ? cliente["codigo"].ToString().TrimStart('0')
                                 : cliente["codigo"].ToString();

                            string fant = Funcoes.TiraAcento(cliente["fantasia"].ToString().Replace(";", ""));

                            string endereco;
                            string numero;

                            if (ConfigReader.GetConfigValue("Clientes", "usa_campo_num") == "true")
                            {
                                endereco = Funcoes.TiraAcento(cliente["endereco"].ToString());
                                numero   = Funcoes.TiraAcento(cliente["numero"].ToString());
                            }
                            else
                            {
                                string[] end    = Endereco(Funcoes.TiraAcento(cliente["endereco"].ToString()));
                                endereco        = end[0];
                                numero          = end[1];
                            }

                            string comp     = Funcoes.TiraAcento(cliente["complemento"].ToString().Replace(";", ""));
                            string bairro   = Funcoes.TiraAcento(cliente["bairro"].ToString().Replace(";", ""));
                            string cidade   = Funcoes.TiraAcento(cliente["cidade"].ToString().Replace(";", ""));
                            string cidibge  = IbgeRet(cidade).ToString();
                            string uf       = cliente["uf"].ToString();
                            string cep      = Regex.Replace(cliente["cep"].ToString(), @"[^\d]+", "");
                            string cnpj     = Regex.Replace( cliente["cnpj_cpf"].ToString(), @"[^\d]+", "");
                            string rgie     = Regex.Replace(cliente["rg_ie"].ToString(), @"[^\d]+", "");
                            string sit_ie   = cnpj.Length == 14 ? (rgie.Length == 0 ? "N" : "C") : "N";
                            string razao    = cliente["razao_social"].ToString().Length == 0 ? fant : Funcoes.TiraAcento(cliente["fantasia"].ToString());
                            string fone1    = Regex.Replace(cliente["fone1"].ToString(), @"[^\d]+", "");
                            string fone2    = Regex.Replace(cliente["fone2"].ToString(), @"[^\d]+", "");
                            string email    = cliente["email"].ToString();
                            string tipo     = cnpj.Length == 14 ? "J" : "F";
                            string dt       = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                            clientesFormatado.Add(new Dictionary<string, dynamic>()
                            {
                                {campos["id_cli"]   , i },
                                {campos["id_emp"]   , 1 },
                                {campos["razao"]    , razao },
                                {campos["fant"]     , fant},
                                {campos["cnpj"]     , cnpj },
                                {campos["rgie"]     , rgie },
                                {campos["sit_ie"]   , sit_ie },
                                {campos["endereco"] , endereco },
                                {campos["numero"]   , numero },
                                {campos["bairro"]   , bairro },
                                {campos["cidade"]   , cidade },
                                {campos["cidibge"]  , cidibge },
                                {campos["uf"]       , uf },
                                {campos["comple"]   , comp },
                                {campos["cep"]      , cep },
                                {campos["tel1"]     , fone1 },
                                {campos["tel2"]     , fone2 },
                                {campos["dtcad"]    , dt },
                                {campos["saldo"]    , 0.00 },
                                {campos["limite"]   , 0.00 },
                                {campos["email"]    , email },
                                {campos["tipo"]     , tipo },
                                {campos["sexo"]     , "N" },
                                {campos["status"]   , 4 },
                            });

                            i++;
                        }

                        clientesDB.TiraAcentoBD();
                        clientesDB.LimpaTudoAntes();
                        clientesDB.InsertMultiplos(clientesFormatado);

                        ConnectionPG.Commit();
                    }catch(Exception err)
                    {
                        ConnectionPG.Rollback();
                        throw err;
                    }
                });
            }catch(NpgsqlException err)
            {
                throw err;
            }catch(Exception err)
            {
                throw err;
            }
        }
        public async static Task PreparaFornecedores(DataRowCollection fornecedores)
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        FornecedorPGDAO fornecedoresDB = new FornecedorPGDAO();
                        List<Dictionary<string, dynamic>> fornecedoresFormatado = new List<Dictionary<string, dynamic>>();

                        ConnectionPG.BeginTransaction();

                        int i = 1;
                        foreach (DataRow fornecedor in fornecedores)
                        {
                            string codean = ConfigReader.GetConfigValue("Clientes", "cli_remover_zeros_esquerda") == "true"  
                                 ? fornecedor["codigo"].ToString().TrimStart('0')
                                 : fornecedor["codigo"].ToString();

                            string fant = Funcoes.TiraAcento(fornecedor["fantasia"].ToString().Replace(";", ""));

                            string endereco;
                            string numero;

                            if (ConfigReader.GetConfigValue("Fornecedores", "usa_campo_num") == "true")
                            {
                                endereco = Funcoes.TiraAcento(fornecedor["endereco"].ToString());
                                numero   = Funcoes.TiraAcento(fornecedor["numero"].ToString());
                            }
                            else
                            {
                                string[] end    = Endereco(Funcoes.TiraAcento(fornecedor["endereco"].ToString()));
                                endereco        = end[0];
                                numero          = end[1];
                            }

                            string comp     = Funcoes.TiraAcento(fornecedor["complemento"].ToString().Replace(";", ""));
                            string bairro   = Funcoes.TiraAcento(fornecedor["bairro"].ToString().Replace(";", ""));
                            string cidade   = Funcoes.TiraAcento(fornecedor["cidade"].ToString().Replace(";", ""));
                            string cidibge  = IbgeRet(cidade).ToString();
                            string uf       = fornecedor["uf"].ToString();
                            string cep      = Regex.Replace(fornecedor["cep"].ToString(), @"[^\d]+", "");
                            string cnpj     = Regex.Replace( fornecedor["cnpj_cpf"].ToString(), @"[^\d]+", "");
                            string rgie     = Regex.Replace(fornecedor["rg_ie"].ToString(), @"[^\d]+", "");
                            string sit_ie   = cnpj.Length == 14 ? (rgie.Length == 0 ? "N" : "C") : "N";
                            string razao    = fornecedor["razao_social"].ToString().Length == 0 ? fant : Funcoes.TiraAcento(fornecedor["fantasia"].ToString());
                            string fone1    = Regex.Replace(fornecedor["fone1"].ToString(), @"[^\d]+", "");
                            string fone2    = Regex.Replace(fornecedor["fone2"].ToString(), @"[^\d]+", "");
                            string email    = fornecedor["email"].ToString();
                            string tipo     = cnpj.Length == 14 ? "J" : "F";
                            string dt       = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                            fornecedoresFormatado.Add(new Dictionary<string, dynamic>()
                            {
                                {"id_fornecedor"        , i++},
                                {"nome_fantasia"        , fant},
                                {"razao_social"         , razao},
                                {"cnpj"                 , cnpj},
                                {"inscricao_estadual"   , rgie},
                                {"id_usuario_cadastro"  , 1},
                                {"id_empresa"           , 1},
                                {"endereco_logradouro"  , endereco},
                                {"endereco_numero"      , numero},
                                {"endereco_bairro"      , bairro},
                                {"endereco_cidade"      , cidade},
                                {"endereco_uf"          , uf},
                                {"endereco_cep"         , cep},
                                {"endereco_complemento" , comp},
                                {"telefone1"            , fone1},
                                {"telefone2"            , fone2},
                                {"email"                , email},
                                {"data_cadastro"        , dt},
                                {"tipo_pessoa"          , tipo},
                                {"id_situacao"          , 4},
                                {"id_cidade"            , cidibge},
                            }); 
                        }

                        fornecedoresDB.TiraAcentoBD();
                        fornecedoresDB.LimpaTudoAntes();
                        fornecedoresDB.InsertMultiplos(fornecedoresFormatado);

                        ConnectionPG.Commit();
                    }catch(Exception err)
                    {
                        ConnectionPG.Rollback();
                        throw err;
                    }
                });
            }catch(NpgsqlException err)
            {
                throw err;
            }catch(Exception err)
            {
                throw err;
            }
        }

        private static void ValidaLinha(DataRow linha)
        {
            string sqlProd = "select " + 
                "  produto.Codigo," + 
                "  produto.Codigo_Fabricante1 as 'Codigo_1', " + 
                "  produto.Nome," + 
                "  produto.Codigo_Fabricante2 as 'Codigo_2', " + 
                "  Iif((select pm.Nome from Marca as pm where pm.Ide = produto.Marca) is null , 'PADRAO' , (select pm.Nome from Marca as pm where pm.Ide = produto.Marca)) AS Marca," + 
                "  UnidadeMedida.Codigo," + 
                "  Qtde as Estoque," + 
                "  isnull((select  top 1 cast(pp.Preco AS NUMERIC(15,2)) from ProdutoPreco as pp where pp.Produto__Codigo = produto.Codigo and " + 
                "pp.TabelaPreco__Ide = '1D05193A-5045-4592-AA17-E2C1EA4D9260'),0) as custo, " + 
                "  isnull((select top 1 cast(pp1.Preco AS NUMERIC(15,2)) from ProdutoPreco as pp1 where pp1.Produto__Codigo = produto.Codigo and " + 
                "pp1.TabelaPreco__Ide = '11627049-F321-42DE-A3ED-4101BADDBC32'),0) as venda," + "" + "  produto.NCM," + 
                "produto.Margem," + 
                "Iif((select pc.Nome from Classes as pc where pc.Codigo = produto.Classe) is null , 'PADRAO' , (select pc.Nome from Classes as pc where pc.Codigo = produto.Classe)) AS Classe," + 
                "Iif((select psb.Nome from Subclasses as psb where psb.Codigo = produto.Subclasse) is null , 'PADRAO' , (select psb.Nome from Subclasses as psb where psb.Codigo = produto.Subclasse)) AS Subclasse," + 
                "Iif((select pCest.Codigo from Cest as pCest where pCest.Ide = produto.CEST) is null , '' , (select pCest.Codigo from CEST as pCest where pCest.Ide = produto.CEST)) AS Cest," + 
                "subquery.Cfop__Codigo," + 
                "subquery.csosn," + 
                "subquery.PisCofins," + 
                "produto.Inativo " + 
                "from produto" + 
                "inner join UnidadeMedida" + 
                "on produto.Unidade_Venda__Ide=UnidadeMedida.Ide" + 
                "inner join Estoque_Atual" + 
                "on Estoque_Atual.Produto=produto.codigo" +
                "INNER JOIN (SELECT" + 
                "    cio.ClasseImposto__Ide AS ClasseImposto" + 
                "   ,cio.Cfop__Codigo" + 
                "   ,cio.IcmsCst AS csosn" + 
                "   ,cio.PisCofinsTipo PisCofins" + 
                "  FROM ClasseImpostoOperacao AS cio" + 
                "  WHERE cio.Ide IN (SELECT ciou.ClasseImpostoOperacao__Ide" + 
                "    FROM ClasseImpostoOperacaoUf ciou" + 
                "    WHERE ciou.ClasseImpostoOperacao__Ide = cio.Ide" + 
                "    AND ciou.Uf = 'GO')" + 
                "  AND cio.Operacao__Codigo = 500) AS subquery" + 
                "  ON subquery.ClasseImposto = produto.ClasseImposto__Ide" + 
                "order by cast(produto.codigo as INT)";
        }
    }
}
