using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Apresentacao.Compartilhado;
using TestesDaDonaMaria.Dominio;
using TestesDaDonaMaria.Infra;

namespace TestesDaDonaMaria.Apresentacao.ModuloMateria
{
    public class ControladorMateria : ControladorBase
    {
        private RepositorioDisciplina repositorioDisciplina;
        private RepositorioMateria repositorioMateria;
        private ListagemMateriaControl listagemMaterias;

        public ControladorMateria(RepositorioMateria repositorioMateria, RepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;
        }


        public override void Editar()
        {
            Materia materiaSelecionada = listagemMaterias.ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Edição de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm(repositorioDisciplina);

            tela.Materia = materiaSelecionada;

           tela.GravarRegistro = repositorioMateria.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
               
                CarregarMaterias();
            }
        }

        private void CarregarMaterias()
        {
            var materias = repositorioMateria.ObterRegistros();

            listagemMaterias.AtualizarRegistros(materias);
        }

        public override void Excluir()
        {
            Materia materiaSelecionada = listagemMaterias.ObtemMateriaSelecionada();

            if (materiaSelecionada == null)
            {
                MessageBox.Show("Selecione uma matéria primeiro",
                "Exclusão de Matérias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a matéria?",
                "Exclusão de Materias", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioMateria.Excluir(materiaSelecionada);
                CarregarMaterias();
            }
        }

        public override void Inserir()
        {
            TelaCadastroMateriaForm tela = new TelaCadastroMateriaForm(repositorioDisciplina);
           
            tela.Materia = new Materia();

            tela.GravarRegistro = repositorioMateria.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                if(tela.Materia.Disciplina != null)
                AtualizarDisciplina(tela.Materia);

                CarregarMaterias();
            }
        }

        private void AtualizarDisciplina(Materia materia)
        {
            materia.Disciplina.Materias.Add(materia);
        }

        public override UserControl ObtemListagem()
        {

            if (listagemMaterias == null)
                listagemMaterias = new ListagemMateriaControl();

            CarregarMaterias();

            return listagemMaterias;
        }

      
    }
}
