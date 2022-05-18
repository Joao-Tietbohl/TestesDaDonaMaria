using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Dominio;

namespace TestesDaDonaMaria.Infra
{
    public class RepositorioTeste : RepositorioBase<Teste>
    {
        public RepositorioTeste(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Testes.Count > 0)
                contador = dataContext.Materias.Max(x => x.Numero);
        }


        public override List<Teste> ObterRegistros()
        {
            return dataContext.Testes;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidadorTeste();
        }
    }
}
