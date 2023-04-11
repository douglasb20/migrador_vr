using System;
using System.Collections.Generic;
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
    }
}
