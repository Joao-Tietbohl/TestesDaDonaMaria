using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Apresentacao.Compartilhado;
using TestesDaDonaMaria.Apresentacao.ModuloDisciplina;
using TestesDaDonaMaria.Dominio;
using TestesDaDonaMaria.Infra;

namespace TestesDaDonaMaria.Apresentacao.ModuloDisciplina
{
    public class ControladorDisciplina : ControladorBase
    {

        private RepositorioDisciplina repositorioDisciplina;
        private ListagemDisciplinasControl listagemDisciplinas;

        public ControladorDisciplina(RepositorioDisciplina repositorioDisciplina)
        {
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Editar()
        {
            Disciplina disciplinaSelecionada = listagemDisciplinas.ObtemDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroDisciplinaForm tela = new TelaCadastroDisciplinaForm();

            tela.Disciplina = disciplinaSelecionada;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioDisciplina.Editar(tela.Disciplina);
                CarregarDisciplinas();
            }
        }

        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = listagemDisciplinas.ObtemDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Exclusão de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a disciplina?",
                "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioDisciplina.Excluir(disciplinaSelecionada);
                CarregarDisciplinas();
            }
        }

        public override void Inserir()
        {
            TelaCadastroDisciplinaForm tela = new TelaCadastroDisciplinaForm();
            tela.Disciplina = new Disciplina();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioDisciplina.Inserir(tela.Disciplina);

                CarregarDisciplinas();
            }
        }

        private void CarregarDisciplinas()
        {
            var disciplinas = repositorioDisciplina.ObterRegistros();

            listagemDisciplinas.AtualizarRegistros(disciplinas);
        }

        public override UserControl ObtemListagem()
        {
            if (listagemDisciplinas == null)
                listagemDisciplinas = new ListagemDisciplinasControl();

            CarregarDisciplinas();

            return listagemDisciplinas;
        }
    }
}
