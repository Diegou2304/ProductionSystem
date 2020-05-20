

namespace ProductionSystem.Web.Models
{
    using ProductionSystem.Web.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProduccionViewModel : Produccion
    {

        //Con esta informacion se puede acceder a los verdaderos datos
        public int PedidoId { get; set; }

        public int UserCi { get; set; }

        public int FaseId { get; set; }


    }
}
