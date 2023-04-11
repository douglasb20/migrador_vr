using System;

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
    }
}
