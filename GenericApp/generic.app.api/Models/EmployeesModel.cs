using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace generic.app.api.Models
{
    public class EmployeesModel : EmployeesUpdateModel
    {
        /// <summary>
        /// Gets the edad a la fecha.
        /// </summary>
        /// <value>The edad a la fecha.</value>
        public string EdadALaFecha
        {
            get
            {
                int edad = DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Year - 1;
                int meses = DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Month - 1;
                int dias = DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Day - 1;

                string result = $"{edad} años {meses} mes(es) {dias} dia(s)";
                return result;
            }            
        }    

    }

    public class EmployeesCreateModel
    {
        /// <summary>
        /// Gets or sets the cedula.
        /// </summary>
        /// <value>The cedula.</value>
        public int Cedula { get; set; }
        /// <summary>
        /// Gets or sets the nombres.
        /// </summary>
        /// <value>The nombres.</value>
        public string Nombres { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EmployeesDto"/> is sexo.
        /// </summary>
        /// <value><c>true</c> if sexo; otherwise, <c>false</c>.</value>
        public bool Sexo { get; set; }
        /// <summary>
        /// Gets or sets the fecha nacimiento.
        /// </summary>
        /// <value>The fecha nacimiento.</value>
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// Gets or sets the salario.
        /// </summary>
        /// <value>The salario.</value>
        public int Salario { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="EmployeesDto"/> is vacuna.
        /// </summary>
        /// <value><c>true</c> if vacuna; otherwise, <c>false</c>.</value>
        public bool Vacuna { get; set; }
    }

    public class EmployeesUpdateModel : EmployeesCreateModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
    }

}
