using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Apresentacao.Compartilhado;
using TestesDaDonaMaria.Dominio;
using TestesDaDonaMaria.Infra;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;



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

            tela.GravarRegistro = repositorioTeste.Editar;

            DialogResult resultado = tela.ShowDialog();

           if (resultado == DialogResult.OK)
            {
               
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

            tela.GravarRegistro = repositorioTeste.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {

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

        private static PdfPCell CriarCelula(string texto)
        {
            var celula = new PdfPCell(new Phrase("Código"));

            return celula;
        }

        public void GerarPdf()
        {
            Teste testeSelecionado = listagemTestes.ObtemTesteSelecionado();

            string nomeArquivo = @"C:\Users\João Pedro\Desktop\PdfPrograma";

            FileStream arquivoPdf = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPdf = PdfWriter.GetInstance(doc, arquivoPdf);

            doc.Open();
            string dados = "";

            Paragraph paragrafoTitulo = new Paragraph(dados);

            paragrafoTitulo.Alignment = Element.ALIGN_LEFT;
            paragrafoTitulo.Add(testeSelecionado.Titulo + "\n");
            paragrafoTitulo.Add("Disciplina: " + testeSelecionado.Disciplina + "\n");
            paragrafoTitulo.Add("Matéria: " + testeSelecionado.Materia + "\n");
            paragrafoTitulo.Add("Data: " + testeSelecionado.DataGeracao.ToShortDateString() + "\n");
            paragrafoTitulo.Add("Nome do Aluno: " + "\n\n\n");

            Paragraph paragrafoQuestoes = new Paragraph(dados);
            paragrafoQuestoes.Alignment = Element.ALIGN_LEFT;

            var questoes = testeSelecionado.listaQuestoes;

            int i = 1;
            foreach (var questao in questoes)
            {
                CriarCelula(questao.Enunciado);
                paragrafoQuestoes.Add(i.ToString() + ") " + questao.Enunciado.ToString() + "\n");
                foreach (var alternativa in questao.Alternativas)
                {
                    paragrafoQuestoes.Add(alternativa.ToString() + "\n");

                }
                i++;
            }

            doc.Open();
            doc.Add(paragrafoTitulo);
            doc.Add(paragrafoQuestoes);
            doc.Close();

            MessageBox.Show("PDF criado com sucesso.",
            "Geração de PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        public void Duplicar()
        {
            Teste testeSelecionado = listagemTestes.ObtemTesteSelecionado();

            if (testeSelecionado == null)
            {
                MessageBox.Show("Selecione um teste primeiro",
                "Duplicação de Testes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Teste testeDuplicado = new Teste();
            CopiaTeste(testeSelecionado, testeDuplicado);

            TelaCadastroTestesForm tela = new TelaCadastroTestesForm(repositorioMateria, repositorioQuestao, repositorioDisciplina);
            tela.Teste = testeDuplicado;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTestes();
            }

        }


        private static void CopiaTeste(Teste testeSelecionado, Teste testeDuplicado)
        {
            testeDuplicado.Titulo = testeSelecionado.Titulo;
            testeDuplicado.Disciplina = testeSelecionado.Disciplina;
            testeDuplicado.Materia = testeSelecionado.Materia;
            testeDuplicado.DataGeracao = testeSelecionado.DataGeracao;
            testeDuplicado.QuantidadeQuestoes = testeSelecionado.QuantidadeQuestoes;
        }
    }
}
