using generic.app.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.Infrastructure.Entities
{
    public class Employees : BaseEntity
    {
        public int Id { get; set; }
        public int Cedula { get; set; }
        public string Nombres { get; set; }
        public bool Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Salario { get; set; }
        public bool Vacuna { get; set; }       
        
    }
}
