using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigradorRP.libs.DAOSVR
{
    internal class ClientesVRDAO : DefaultModelVR
    {
        public ClientesVRDAO()
        {
            this.tabela = "clientes";
        }
    }
}
