using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigradorRP.libs
{
    internal class UnidadesPGDAO : DefaultModelPG
    {
        public UnidadesPGDAO()
        {
            this.tabela = "unidades";
        }
    }
}
