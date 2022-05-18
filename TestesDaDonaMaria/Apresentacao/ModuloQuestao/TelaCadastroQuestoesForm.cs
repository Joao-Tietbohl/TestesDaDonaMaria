using System;
using System.Collections.Generic;
using System.ComponentModel;
using FluentValidation.Results;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Dominio;
using TestesDaDonaMaria.Infra;

namespace TestesDaDonaMaria.Apresentacao.ModuloQuestao
{
    public partial class TelaCadastroQuestoesForm : Form
    {
        private RepositorioDisciplina repositorioDisciplina;
        private RepositorioMateria repositorioMateria;
        private Questao questao;
        

        IDictionary<int, string> Letras = new Dictionary<int, string>();

        public Func<Questao, ValidationResult> GravarRegistro { get; set; }


        public TelaCadastroQuestoesForm(RepositorioDisciplina repositorioDisciplina, RepositorioMateria repositorioMateria)
        {
            InitializeComponent();

            this.repositorioMateria = repositorioMateria;
            this.repositorioDisciplina = repositorioDisciplina;

            InicializarCbxDisciplina(repositorioDisciplina);
            cbxMateria.Enabled = false;

            InicializarDicionario();

            questao = new Questao();

        }

        private void InicializarDicionario()
        {
            Letras.Add(0, "A");
            Letras.Add(1, "B");
            Letras.Add(2, "C");
            Letras.Add(3, "D");
            Letras.Add(4, "E");
        }

        public Questao Questao
        {
            get
            {
                return questao;
            }
            set
            {

                questao = value;
                txtEnunciado.Text = questao.Enunciado;
                cbxMateria.SelectedItem = questao.Materia;
                cbxDisciplina.SelectedItem = questao.Materia;
                foreach (var a in questao.Alternativas)
                {
                    lbAlternativas.Items.Add(a);
                }
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            questao.Enunciado = txtEnunciado.Text;
            questao.Materia = (Materia)cbxMateria.SelectedItem;


            var resultadoValidacao = GravarRegistro(questao);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro,
                       "Cadastro de Questoes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

                DialogResult = DialogResult.None;
            }
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nomeAlternativa = txtAlternativa.Text;
            bool alternativaCorreta = false;


            if (chbAlternativaCorreta.Checked == true)
            {
                alternativaCorreta = true;
                chbAlternativaCorreta.Enabled = false;
                chbAlternativaCorreta.Checked = false;
                
            }

            if (lbAlternativas.Items.Count == 4)
                btnAdicionar.Enabled = false;
          
            int qtdAlternativas = lbAlternativas.Items.Count;

            string letra = Letras[qtdAlternativas];


            Alternativa alternativa = new Alternativa(alternativaCorreta, nomeAlternativa, letra);
  
            lbAlternativas.Items.Add(alternativa);

            txtAlternativa.Clear();

            questao.Alternativas.Add(alternativa);

        }
    }
}
