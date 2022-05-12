using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Dominio;

namespace TestesDaDonaMaria.Infra
{
    public class RepositorioDisciplina : RepositorioBase<Disciplina>
    {

        public RepositorioDisciplina(DataContext dataContext) : base(dataContext)
        {
            if (dataContext.Disciplinas.Count > 0)
                contador = dataContext.Disciplinas.Max(x => x.Numero);
        }

        public override List<Disciplina> ObterRegistros()
        {
            return dataContext.Disciplinas;
        }

        
    }
}
