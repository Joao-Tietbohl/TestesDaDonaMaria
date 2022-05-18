using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDaDonaMaria.Dominio
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull();

        }
    }
}
