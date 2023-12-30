using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

namespace MigradorRP.libs
{
    internal class DefaultModelVR
    {
        private NpgsqlConnection con;
        public string tabela;
        private DataTable queryData;


        public DefaultModelVR() { 
            Connect();
        }

        private void Connect()
        {
            try
            {
                string dbBase   = ConfigReader.sistema == "LeCheff" ? "RP" : "SOFTMOBILE";
                string host     = ConfigReader.GetConfigValue("PgDatabase","pgdbhost");
                string dbuser   = ConfigReader.GetConfigValue("PgDatabase","pgdbuser");
                string porta    = ConfigReader.GetConfigValue("PgDatabase","pgdbport");
                string password = ConfigReader.GetConfigValue("PgDatabase", "pgdbpwd");

                con = new NpgsqlConnection("Server=" + host + ";Port=" + porta + ";User Id=" + dbuser + ";Password=" + password + ";Database=" + dbBase + ";");
                con.Open();
                TiraAcentoBD(con);

            }catch(NpgsqlException e)
            {
                throw e;
            }catch(Exception e)
            {
                throw e;
            }
        }

        public void TiraAcentoBD(NpgsqlConnection conect)
        {
            string[] cAcento = { "Á", "À", "Ã", "Â", "É", "Ê", "È", "Í", "Ì", "Î", "Ó", "Ò", "Ô", "Õ", "Ú", "Ù", "Ç", "''" };
            string[] sAcento = { "A", "A", "A", "A", "E", "E", "E", "I", "I", "I", "O", "O", "O", "O", "U", "U", "C", "" };
            NpgsqlCommand cmd ;
            for (int i = 0; i < cAcento.Length; i++)
            {
                string addDados = String.Format("Update cidades set cid_002=replace(cid_002,'{0}','{1}')", cAcento[i].ToString().ToUpper(), sAcento[i].ToString().ToUpper());
                cmd = new NpgsqlCommand(addDados, conect);
                cmd.ExecuteNonQuery();
            }
        }

        private int ExecuteNonQuery(string query)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                return (int)cmd.ExecuteScalar();

            }
            catch (NpgsqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private DataTable ExecuteQuery(string query)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);

                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;

            }
            catch (NpgsqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public DefaultModelVR GetQuery(string where = "", string order = "") {
            try
            {
                string query = string.Format("SELECT * FROM {0} ", tabela);
                if (!string.IsNullOrEmpty(where))
                {
                    
                    query = string.Concat(query, string.Format(" WHERE {0}", where));
                }

                if (!string.IsNullOrEmpty(order))
                {

                    query = string.Concat(query, string.Format(" ORDER BY {0}", order));
                }

                queryData = ExecuteQuery(query);
                
                return this;
            }
            catch (NpgsqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public DataRowCollection ReadAsCollection()
        {
            return queryData.Rows;
        }

        public DataTable ReadAsDataTable()
        {
            return queryData;
        }

        private void InsertMultiplos(List<Dictionary<string,dynamic>> parametros)
        {
            try
            {
                string query = PrepareInsertMultiplo(parametros);
                ExecuteNonQuery(query);
            }catch(NpgsqlException e)
            {
                throw e;
            }catch(Exception e)
            {
                throw e;
            }
        }

        public int Insert(Dictionary<string, dynamic> parametros)
        {
            try
            {
                string query = PrepareInsert(parametros);
                return ExecuteNonQuery(query);

            }
            catch (NpgsqlException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Dictionary<string, dynamic> parametros, string where = "")
        {
            if (string.IsNullOrEmpty(where))
            {
                throw new Exception("UPDATE sem WHERE no banco de dados");
            }

            string query = PrepareUpdate(parametros, where);
            ExecuteNonQuery(query);
        }

        public Dictionary<string, string>PrepareParams(Dictionary<string, dynamic> parametros)
        {
            Dictionary<string, string> newParams = new Dictionary<string, string>();

            foreach(KeyValuePair<string, dynamic> el in parametros){
                if(el.Value == null)
                {
                    newParams.Add(el.Key, "null");
                    continue;
                }
                newParams.Add(el.Key, "'" + el.Value.ToString(CultureInfo.InvariantCulture) + "'");
            }

            return newParams;
        }
        
        public string PrepareInsertMultiplo(List<Dictionary<string, dynamic>> parametros)
        {
            try
            {
                List<Dictionary<string, string>> dados = new List<Dictionary<string, string>>();
                foreach(Dictionary<string, dynamic> el in parametros)
                {
                    dados.Add(PrepareParams(el)); 
                }
                string[] campos = dados[0].Keys.ToArray();
                string[] valores = { };

                foreach (Dictionary<string, string> item_insert in dados)
                {
                    Array.Resize(ref valores, valores.Length + 1);
                    valores[valores.Length - 1] = "(" + string.Join(",", item_insert.Values) + ")";
                }

                string query = $"INSERT INTO {tabela} ";
                query += $"({string.Join(",", campos)}) VALUES {string.Join(",", valores)}";

                return query;

            }catch(Exception e)
            {
                throw e;
            }
        }

        public string PrepareInsert(Dictionary<string, dynamic> parametros)
        {
            try
            {

                Dictionary<string, string> dados = new Dictionary<string, string>();

                dados = PrepareParams(parametros);

                string campos = string.Join(",", dados.Keys.ToArray());
                string valores = string.Join(",", dados.Values.ToArray());

                string query = $"INSERT INTO {tabela} ";
                query += $"({campos}) VALUES ({valores});";

                return query;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string PrepareUpdate(Dictionary<string, dynamic> parametros, string where = "")
        {
            try
            {
                Dictionary<string, string> dados = new Dictionary<string, string>();

                dados = PrepareParams(parametros);
                string[] valores = { };

                foreach (KeyValuePair<string, string> el in dados){
                    Array.Resize(ref valores, valores.Length + 1);
                    valores[valores.Length - 1] = $"{el.Key}={el.Value}";
                }
                string campos = string.Join(",", dados.Keys.ToArray());

                string query = $"UPDATE {tabela} SET";
                query += $" {string.Join(", ", valores)}";

                if (!string.IsNullOrEmpty(where))
                {
                    query = string.Concat(query,$" WHERE {where}") ;
                }

                return query;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void CloseConnection()
        {
            con.Close();
        }

        // FUNÇÕES UTEIS PARA O BANCO

        public string[] Endereco(string text)
        {
            string[] gAddress = new string[2];
            int numberOfHyphens = 0;
            int x = 0;
            int y = 0;

            if(string.IsNullOrEmpty( text ) ) {
                gAddress[0] = text;
                gAddress[1] = "S/N";
                
                return gAddress;
            }

            foreach (char c in text)
            {
                x++;
                if (c == ',')
                {
                    numberOfHyphens++;
                    y = x;
                }
            }

            if (numberOfHyphens == 0)
            {

                gAddress[0] = text.Trim().ToUpper();
                gAddress[1] = "S/N";
            }
            else
            {
                string endnum = text.Substring(y, text.Length - y);
                gAddress[0] = text.Substring(0, y - 1).ToUpper();
                gAddress[1] = endnum.Trim().ToUpper();
            }

            return gAddress;

        }

    }
}
