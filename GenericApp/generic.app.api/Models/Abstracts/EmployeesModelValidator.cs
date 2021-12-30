using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace generic.app.api.Models.Abstracts
{
    public class EmployeesModelValidator
    {
    }

    public class EmployeesCreateModelValidator : AbstractValidator<EmployeesCreateModel>
    {
        public EmployeesCreateModelValidator()
        {
            RuleFor(x => x.Cedula)
                .NotNull()
                .NotEqual(0);

            RuleFor(x => x.Nombres)
               .NotEmpty()
               .NotNull()
               .MaximumLength(50);

            RuleFor(x => x.FechaNacimiento)
                .NotEmpty()
                .NotNull()
                .NotEqual(new DateTime());

            RuleFor(x => x.Salario)
                .NotNull()
                .NotEqual(0);
        }
    }

    public class EmployeesUodateModelValidator : AbstractValidator<EmployeesUpdateModel>
    {
        public EmployeesUodateModelValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEqual(0);
        }
    }

}
