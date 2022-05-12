using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Dominio;

namespace TestesDaDonaMaria.Infra
{
    public abstract class RepositorioBase<T> where T : EntidadeBase<T>
    {
        protected DataContext dataContext;

        protected int contador = 0;

        public RepositorioBase(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public abstract List<T> ObterRegistros();



        public void Inserir(T novoRegistro)
        {

            novoRegistro.Numero = ++contador;

            var registros = ObterRegistros();

            registros.Add(novoRegistro);


        }

        public void Editar(T registro)
        {
            var registros = ObterRegistros();

            foreach (var item in registros)
            {
                if (item.Numero == registro.Numero)
                {
                    item.Atualizar(registro);
                    break;
                }
            }
        }



        public void Excluir(T registro)
        {

            var registros = ObterRegistros();

            registros.Remove(registro);

        }

        public virtual List<T> SelecionarTodos()
        {
            return ObterRegistros().ToList();
        }

        public virtual T SelecionarPorNumero(int numero)
        {
            return ObterRegistros()
                .FirstOrDefault(x => x.Numero == numero);
        }
    }

}
