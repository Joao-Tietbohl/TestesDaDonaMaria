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

/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using FluentValidation.Results;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDaDonaMaria.Dominio;*/

namespace TestesDaDonaMaria.Apresentacao.ModuloMateria
{
    public partial class TelaCadastroMateriaForm : Form
    {
        private Materia materia;
        private RepositorioDisciplina repositorioDisciplina;
        
        
        public TelaCadastroMateriaForm(RepositorioDisciplina repositorioDisciplina)
        {
            InitializeComponent();

            this.repositorioDisciplina = repositorioDisciplina;

            
                List<Disciplina> listaDisciplinas = repositorioDisciplina.SelecionarTodos();

                InicializarCbx(listaDisciplinas);
            
        }

        public Func<Materia, ValidationResult> GravarRegistro { get; set; }

        private void InicializarCbx(List<Disciplina> listaDisciplinas)
        {
            foreach (Disciplina d in listaDisciplinas)
                cbxDisciplina.Items.Add(d);
        }

        public Materia Materia
        {
            get
            {
                return materia;
            }
            set
            {
                materia = value;

                if (materia.Serie != null)
                {
                    if (materia.Serie == Serie.Primeira)
                        rbPrimeira.Checked = true;

                    if (materia.Serie == Serie.Segunda)
                        rbSegunda.Checked = true;
                }

                
                txtNumero.Text = materia.Numero.ToString();
                txtTitulo.Text = materia.Nome; 
                cbxDisciplina.SelectedItem = materia.Disciplina;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            materia.Nome = txtTitulo.Text;
            materia.Disciplina = (Disciplina)cbxDisciplina.SelectedItem; 
            if (rbPrimeira.Checked == true)
                materia.Serie = Serie.Primeira;

            if (rbSegunda.Checked == true)
                materia.Serie = Serie.Segunda;



            var resultadoValidacao = GravarRegistro(materia);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro,
                       "Cadastro de Materias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

                DialogResult = DialogResult.None;
            }
        }

    }
}
