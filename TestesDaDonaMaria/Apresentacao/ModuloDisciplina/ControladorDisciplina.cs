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
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione um contato primeiro",
                "Edição de Contatos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroDisciplinaForm tela = new TelaCadastroDisciplinaForm();

            tela.Disciplina = disciplinaSelecionada.Clonar();

            tela.GravarRegistro = repositorioDisciplina.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }
        }

        private Disciplina ObtemDisciplinaSelecionada()
        {
            var numero = listagemDisciplinas.ObtemDisciplinaSelecionada().Numero;

            return repositorioDisciplina.SelecionarPorNumero(numero);
        }

        public override void Excluir()
        {
            Disciplina disciplinaSelecionada = ObtemDisciplinaSelecionada();

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

            tela.GravarRegistro = repositorioDisciplina.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDisciplinas();
            }
        }

       

        private void CarregarDisciplinas()
        {
            var disciplinas = repositorioDisciplina.SelecionarTodos();

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
