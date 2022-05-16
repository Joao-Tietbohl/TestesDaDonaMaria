using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Dominio;
using TestesDaDonaMaria.Infra;

namespace TestesDaDonaMaria.Apresentacao.ModuloTeste
{
    public partial class TelaCadastroTestesForm : Form
    {
        private Teste teste;
        private RepositorioMateria repositorioMateria;
        private RepositorioDisciplina repositorioDisciplina;
        private RepositorioQuestao repositorioQuestao;

        public TelaCadastroTestesForm(RepositorioMateria repositorioMateria, RepositorioQuestao repositorioQuestao,RepositorioDisciplina repositorioDisciplina)
        {
            InitializeComponent();

            this.repositorioQuestao = repositorioQuestao;
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;


            InicializarCbxDisciplina(repositorioDisciplina);
           

        }

        public Teste Teste
        {
            get
            {
                return teste;
            }
            set
            {

                teste = value;
              //  dtpData = teste.DataGeracao.ToString();
                txtNumero.Text = teste.Numero.ToString();
                txtQtdQuestoes.Text = teste.QuantidadeQuestoes.ToString();
                txtTitulo.Text = teste.Titulo;
            }
        }

        private void InicializarCbxDisciplina(RepositorioDisciplina repositorioDisciplina)
        {
            cbxDisciplina.Items.Clear();

            foreach (var d in repositorioDisciplina.SelecionarTodos())
            {
                cbxDisciplina.Items.Add(d);
            }

        }

        private void btnSortear_Click(object sender, EventArgs e)
        {
            int qtdQuestoes = Convert.ToInt32(txtQtdQuestoes.Text);
            int cont = 0;

            var random = new Random();

           //   List<Questao> questoesProva = new List<Questao>();

            List<int> indexNumeros = new List<int>();

            Materia materia = (Materia)cbxMateria.SelectedItem;

            List<Questao> questoesFiltroMateria = repositorioQuestao.SelecionarTodosPorMateria(repositorioQuestao.SelecionarTodos(), materia);

            while (cont < qtdQuestoes)
            {

                int index = random.Next(questoesFiltroMateria.Count);
               
                if (!indexNumeros.Contains(index))
                {

                    indexNumeros.Add(index);

                    listQuestoes.Items.Add(questoesFiltroMateria[index]);

                    //questoesProva.Add(repositorioQuestao.SelecionarTodos()[index]);

                    cont++;
                }

            }

           // GerarGabarito(questoesProva);
        }

        private void GerarGabarito(List<Questao> questoesProva)
        {
            foreach (var q in questoesProva)
            {
                
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            teste.QuantidadeQuestoes = Convert.ToInt32(txtQtdQuestoes.Text);
            teste.Disciplina = (Disciplina)cbxDisciplina.SelectedItem;
            teste.Materia = (Materia)cbxMateria.SelectedItem;
            teste.DataGeracao = Convert.ToDateTime(dtpData.Text);
            teste.Titulo = txtTitulo.Text;
        }

       
        private void cbxDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxMateria.Enabled = true;
            Disciplina disciplina = (Disciplina)cbxDisciplina.SelectedItem;
            InicializarCbxMateria(repositorioMateria, disciplina);
        }

        private void InicializarCbxMateria(RepositorioMateria repositorioMateria, Disciplina disciplina)
        {
            cbxMateria.Items.Clear();

            foreach (var m in repositorioMateria.SelecionarTodos())
            {
                if(m.Disciplina == disciplina)
                cbxMateria.Items.Add(m);
            }
        }
    }
}
