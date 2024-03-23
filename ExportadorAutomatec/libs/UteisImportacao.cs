using MigradorRP.libs.DAOSPG;
using Npgsql;
using System;
using System.Data;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using OfficeOpenXml;

namespace MigradorRP.libs
{
    public static class UteisImportacao
    {

        // FUNÇÕES UTEIS PARA O BANCO

        public async static Task PreparaProdutos(DataTable dt, bool isCSV)
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {

                        DataRowCollection produtos = dt.Rows;
                        string filename;
                        
                        if (!isCSV)
                        {
                            filename = $"Produtos_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx";
                            WriteToExcel(Path.Combine(ConfigReader.saidaPath, filename), dt, "Produtos");
                            return;
                        }

                        int i = 1;
                        filename = $"Produtos_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}_CSV.csv";
                        File.WriteAllText(Path.Combine(ConfigReader.saidaPath, filename), "");
                        StringBuilder csv = new StringBuilder();
                        foreach (DataRow row in produtos)
                        {
                            dynamic[] linha = {
                                ++i,
                                row["refer"],
                                row["desc_pro"],
                                'N',
                                row["csosn"].ToString() == "500" ? "2" : "1",
                                row["ncm"],
                                row["unidade"],
                                row["custo"],
                                row["venda"],
                                row["margem"],
                                row["codbar"],
                                "",
                                row["categ"],
                                "",
                                "",
                                "",
                                "",
                                (ConfigReader.GetConfigValue("Produtos", "importa_quantidade") == "true" ? row["estoque"] : ""),
                                "",
                                "",
                                "",
                                "",
                                row["cest"],
                                "",
                                row["b_exporta_peso_balanca"].ToString()  == "true" ? "1" : "0",
                                "0",
                                "",
                                "",
                                "",
                                ConfigReader.sistema == "LeStore" ? row["refer"] : "",
                            };

                            string newLine = string.Join(";", linha);
                            csv.AppendLine(newLine);
                        }
                        File.WriteAllText(Path.Combine(ConfigReader.saidaPath, filename), csv.ToString());
                        
                        
                    }
                    catch (Exception err)
                    {
                        throw err;
                    }

                });
            }catch(Exception err)
            {
                throw err;
            }

        }

        public async static Task PreparaClientesFornecedores(DataTable dt, bool isCSV, string modo = "Clientes_Fornecedores")
        {
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        DataRowCollection clientes = dt.Rows;
                        string filename;
                        
                        if (!isCSV)
                        {
                            filename = $"{modo}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}.xlsx";
                            WriteToExcel(Path.Combine(ConfigReader.saidaPath, filename), dt, modo);
                            return;
                        }

                        filename = $"{modo}_{DateTime.Now.ToString("dd_MM_yyyy_HH_mm_ss")}_CSV.csv";
                        File.WriteAllText(Path.Combine(ConfigReader.saidaPath, filename), "");
                        StringBuilder csv = new StringBuilder();

                        int i = 1;
                        foreach (DataRow row in clientes)
                        {
                            dynamic[] linha = {
                                ++i,
                                row["razao"],
                                row["cnpj_cpf"].ToString(),
                                row["rg_ie"],
                                row["endereco"],
                                row["numero"],
                                row["comple"],
                                row["bairro"],
                                row["cidade"],
                                row["uf"],
                                row["cep"],
                                row["tel1"],
                                row["tel2"],
                                row["dt_nasc"],
                                row["tipo"],
                                row["cnpj_cpf"].ToString().Length > 11? "J" : "F",
                                row["fant"],
                                row["email"],
                                row["contato"],
                                row["obs"],
                                row["emailnfe"],
                                row["nome_contador"],
                                row["email_contador"]
                            };


                            string newLine = string.Join(";", linha);
                            csv.AppendLine(newLine);
                        }
                        File.WriteAllText(Path.Combine(ConfigReader.saidaPath, filename), csv.ToString());
                    }
                    catch(Exception err)
                    {
                        throw err;
                    }
                });
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

        private static void WriteToExcel(string path, DataTable dt, string sheetName)
        {

            // let's convert our object data to Datatable for a simplified logic.
            // Datatable is the easiest way to deal with complex datatypes for easy reading and formatting. 
            FileInfo filePath = new FileInfo(path);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPack = new ExcelPackage(filePath))
            {
                var ws = excelPack.Workbook.Worksheets.Add(sheetName);
                ws.Cells.LoadFromDataTable(dt, true);
                excelPack.Save();
            }
        }
    }
}
