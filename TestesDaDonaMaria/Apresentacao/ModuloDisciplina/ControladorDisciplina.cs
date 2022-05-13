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

            string validacao = ValidarDisciplina(tela.Disciplina);

            if (validacao != "")
            {
                MessageBox.Show(validacao,
                "Cadastro de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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

            string validacao = ValidarExclusao(disciplinaSelecionada);

            if(validacao != "")
            {
                MessageBox.Show(validacao,
                "Exclusao de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private string ValidarExclusao(Disciplina disciplinaSelecionada)
        {
            string validacao = "";

            if (disciplinaSelecionada.Materias.Count != 0)
                validacao = "Não é possível excluir uma disciplina relacionada com " +
                    "uma matéria";

            return validacao;
        }

        public override void Inserir()
        {
            TelaCadastroDisciplinaForm tela = new TelaCadastroDisciplinaForm();
            tela.Disciplina = new Disciplina();

            DialogResult resultado = tela.ShowDialog();

            string validacao = ValidarDisciplina(tela.Disciplina);

            if (validacao != "")
            {
                MessageBox.Show(validacao,
                "Cadastro de Disciplinas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (resultado == DialogResult.OK)
            {
                repositorioDisciplina.Inserir(tela.Disciplina);

                CarregarDisciplinas();
            }
        }

        private string ValidarDisciplina(Disciplina disciplina)
        {
            string validacao = "";

            if (disciplina.Nome == "")
                validacao = "Disciplina deve ter nome";

            foreach (Disciplina d in repositorioDisciplina.SelecionarTodos())
            {
                if (disciplina.Nome == d.Nome)
                    validacao += "\nNome da disciplina deve ser único";
            }
            
            return validacao;
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
