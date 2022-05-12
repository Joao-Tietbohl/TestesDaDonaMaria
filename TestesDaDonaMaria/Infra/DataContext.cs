using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDaDonaMaria.Dominio;

namespace TestesDaDonaMaria.Infra
{
    public class DataContext
    {
        private readonly Serializador serializador;

        public DataContext()
        {
            Questoes = new List<Questao>();
            Disciplinas = new List<Disciplina>();
            Materias = new List<Materia>();

        }

        public DataContext(Serializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        public List<Questao> Questoes { get; set; }
        public List<Disciplina> Disciplinas { get; set; }
        public List <Materia> Materias { get; set; }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            if (ctx.Questoes.Any())
                this.Questoes.AddRange(ctx.Questoes);

            if (ctx.Disciplinas.Any())
                this.Disciplinas.AddRange(ctx.Disciplinas);

            if (ctx.Materias.Any())
                this.Materias.AddRange(ctx.Materias);

           
        }
    }
}
