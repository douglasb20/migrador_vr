using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
