using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic.app.applicationCore.Dtos
{
    public class EmployeesDto 
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

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

    //public class EmployeesUpdateDto : EmployeesDto
    //{

    //}


}
