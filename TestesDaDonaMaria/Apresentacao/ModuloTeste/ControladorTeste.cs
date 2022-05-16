using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Apresentacao.Compartilhado;
using TestesDaDonaMaria.Dominio;
using TestesDaDonaMaria.Infra;

namespace TestesDaDonaMaria.Apresentacao.ModuloTeste
{
    public class ControladorTeste : ControladorBase
    {
        private RepositorioTeste repositorioTeste;
        private RepositorioQuestao repositorioQuestao;
        private RepositorioMateria repositorioMateria;
        private RepositorioDisciplina repositorioDisciplina;
        private ListagemTestesControl listagemTestes;


        public ControladorTeste(RepositorioTeste repositorioTeste, RepositorioQuestao repositorioQuestao, RepositorioDisciplina repositorioDisciplina, RepositorioMateria repositorioMateria)
        {
            this.repositorioMateria = repositorioMateria;
            this.repositorioQuestao = repositorioQuestao;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioTeste = repositorioTeste;
        }

        public override void Editar()
        {

            Teste testeSelecionado = listagemTestes.ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Edição de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroTestesForm tela = new TelaCadastroTestesForm(repositorioMateria ,repositorioQuestao, repositorioDisciplina);

            tela.Teste = testeSelecionado;

            DialogResult resultado = tela.ShowDialog();

           if (resultado == DialogResult.OK)
            {
                repositorioTeste.Editar(tela.Teste);
                CarregarTestes();
            }
        }

        public override void Excluir()
        {

            Teste testeSelecionado = listagemTestes.ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Exclusão de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o teste?",
                "Exclusão de Testes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Excluir(testeSelecionado);
                CarregarTestes();
            }
        }

        public override void Inserir()
        {
            TelaCadastroTestesForm tela = new TelaCadastroTestesForm(repositorioMateria, repositorioQuestao, repositorioDisciplina);
            tela.Teste = new Teste();

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                repositorioTeste.Inserir(tela.Teste);

                CarregarTestes();
            }
        }

        private void CarregarTestes()
        {
            var testes = repositorioTeste.ObterRegistros();

            listagemTestes.AtualizarRegistros(testes);
        }

        public override UserControl ObtemListagem()
        {
            if (listagemTestes == null)
                listagemTestes = new ListagemTestesControl();

            CarregarTestes();

            return listagemTestes;
        }
    }
}
