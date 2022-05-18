using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Dominio;

namespace TestesDaDonaMaria.Infra
{
    public class RepositorioQuestao : RepositorioBase<Questao>
    {

        public RepositorioQuestao(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Questoes.Count > 0)
                contador = dataContext.Questoes.Max(x => x.Numero);
        }
        public override List<Questao> ObterRegistros()
        {
            return dataContext.Questoes;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();
        }

        public List<Questao> SelecionarTodosPorMateria(List<Questao>registros ,Materia materia)
        {
            List<Questao> lista = new List<Questao>();

            foreach (var q in registros)
            {
                if (q.Materia == materia)
                    lista.Add(q);
            }

            return lista;
        }
    }
}
