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
                txtTitulo.Text = materia.Titulo; 
                cbxDisciplina.SelectedItem = materia.Disciplina;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            materia.Titulo = txtTitulo.Text;
            materia.Disciplina = (Disciplina)cbxDisciplina.SelectedItem; 
            if (rbPrimeira.Checked == true)
                materia.Serie = Serie.Primeira;

            if (rbSegunda.Checked == true)
                materia.Serie = Serie.Segunda;

        }

       
    }
}
