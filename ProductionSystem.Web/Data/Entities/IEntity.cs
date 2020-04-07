using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionSystem.Web.Data.Entities
{
    //para poner obligar por defecto a las entidades a tener id y asi manejar los repositorios
    //TODO : agregar la interfaz a todas las entidaddes
    public interface IEntity
    {

        int Id { get; set; }

    }
}
