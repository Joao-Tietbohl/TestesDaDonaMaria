using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDaDonaMaria.Dominio
{
    public class ValidadorMateria : AbstractValidator<Materia>
    {
        public ValidadorMateria()
        {
       
            RuleFor(x => x.Disciplina)
            .NotEmpty().NotNull();

   
            RuleFor(x => x.Serie)
            .NotEmpty().NotNull();

           RuleFor(x => x.Nome)
           .NotEmpty().NotNull();
            
        }
    }
}
