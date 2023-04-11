using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigradorRP.libs.DAOSPG
{
    static class ConnectionPG
    {
        public static NpgsqlConnection con;
        private static NpgsqlTransaction transaction;
        public static void Connect()
        {
            string dbBase = ConfigReader.sistema == "LeCheff" ? "RP" : "SOFTMOBILE";
            string host = ConfigReader.GetConfigValue("PgDatabase", "pgdbhost");
            string dbuser = ConfigReader.GetConfigValue("PgDatabase", "pgdbuser");
            string porta = ConfigReader.GetConfigValue("PgDatabase", "pgdbport");
            string password = ConfigReader.GetConfigValue("PgDatabase", "pgdbpwd");


            con = new NpgsqlConnection("Server=" + host + ";Port=" + porta + ";User Id=" + dbuser + ";Password=" + password + ";Database=" + dbBase + ";");
            con.Open();

        }

        public static void ReConnect()
        {
            con.Close();
            Connect();
        }

        public static void BeginTransaction() { transaction = con.BeginTransaction(); }
        public static void Commit() { transaction.Commit(); }

        public static void Rollback() { transaction.Rollback(); }
    }
}
