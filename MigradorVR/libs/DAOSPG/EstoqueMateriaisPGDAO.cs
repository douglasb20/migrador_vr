using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigradorRP.libs
{
    internal class EstoqueMateriaisPGDAO : DefaultModelPG
    {
        public EstoqueMateriaisPGDAO()
        {
            this.tabela = "setor_estoque_material";
        }
    }
}
