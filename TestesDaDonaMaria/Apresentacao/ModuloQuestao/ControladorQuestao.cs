using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Apresentacao.Compartilhado;
using TestesDaDonaMaria.Dominio;
using TestesDaDonaMaria.Infra;

namespace TestesDaDonaMaria.Apresentacao.ModuloQuestao
{
    public class ControladorQuestao : ControladorBase
    {
        private RepositorioQuestao repositorioQuestao;
        private RepositorioMateria repositorioMateria;
        private RepositorioDisciplina repositorioDisciplina;
        private ListagemQuestoesControl listagemQuestao;


        public ControladorQuestao(RepositorioQuestao repositorioQuestao, RepositorioDisciplina repositorioDisciplina, RepositorioMateria repositorioMateria)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioDisciplina = repositorioDisciplina;
        }

        public override void Editar()
        {

            Questao questaoSelecionada = listagemQuestao.ObtemQuestaoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma questao primeiro",
                "Edição de questões", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroQuestoesForm tela = new TelaCadastroQuestoesForm(repositorioDisciplina, repositorioMateria);

            tela.Questao = questaoSelecionada;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioQuestao.Editar(tela.Questao);
                CarregarQuestoes();
            }
        }

        public override void Excluir()
        {

            Questao questaoSelecionada = listagemQuestao.ObtemQuestaoSelecionada();

            if (questaoSelecionada == null)
            {
                MessageBox.Show("Selecione uma questão primeiro",
                "Exclusão de Questões", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a questão?",
                "Exclusão de Questões", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioQuestao.Excluir(questaoSelecionada);
                CarregarQuestoes();
            }
        }

        public override void Inserir()
        {
            TelaCadastroQuestoesForm tela = new TelaCadastroQuestoesForm(repositorioDisciplina, repositorioMateria);
            tela.Questao = new Questao();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioQuestao.Inserir(tela.Questao);

                CarregarQuestoes();
            }
        }

        private void CarregarQuestoes()
        {
            var questoes = repositorioQuestao.ObterRegistros();

            listagemQuestao.AtualizarRegistros(questoes);
        }

        public override UserControl ObtemListagem()
        {
            if (listagemQuestao == null)
                listagemQuestao = new ListagemQuestoesControl();

            CarregarQuestoes();

            return listagemQuestao;
        }
    }
    
}
