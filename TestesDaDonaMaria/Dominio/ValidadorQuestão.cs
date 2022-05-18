using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDaDonaMaria.Dominio
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.Enunciado)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Materia)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Alternativas.Count)
                .NotEmpty()
                .NotNull()
                .GreaterThan(1)
                .WithMessage("Questão deve ter pelo menos 2 alternativas cadastradas");
        }
    }
}
