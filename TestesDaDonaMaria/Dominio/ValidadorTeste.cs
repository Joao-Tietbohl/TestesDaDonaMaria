using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDaDonaMaria.Dominio
{
    public class ValidadorTeste : AbstractValidator<Teste>
    {
        public ValidadorTeste()
        {
            RuleFor(x => x.Disciplina)
               .NotEmpty().NotNull();

            RuleFor(x => x.Titulo)
                .NotEmpty().NotNull();

            RuleFor(x => x.DataGeracao)
                .NotEmpty().NotNull();

            RuleFor(x => x.listaQuestoes.Count)
                .GreaterThan(0)
                .WithMessage("Quantidade de questões não pode ser menor que zero");
        }
    }
}
