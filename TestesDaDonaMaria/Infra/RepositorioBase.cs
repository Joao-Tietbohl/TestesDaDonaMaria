using FluentValidation;
using FluentValidation.Results;
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

        public abstract AbstractValidator<T> ObterValidador();

        public virtual ValidationResult Inserir(T novoRegistro)
        {

            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(novoRegistro);

            if (resultadoValidacao.IsValid)
            {
                novoRegistro.Numero = ++contador;

                var registros = ObterRegistros();

                registros.Add(novoRegistro);
            }

            return resultadoValidacao;
        }

        public ValidationResult Editar(T registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid)
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
            
            return resultadoValidacao;

        }

        public ValidationResult Excluir(T registro)
        {
            var resultadoValidacao = new ValidationResult();

            var registros = ObterRegistros();

            if (registros.Remove(registro) == false)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));

            return resultadoValidacao;
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
