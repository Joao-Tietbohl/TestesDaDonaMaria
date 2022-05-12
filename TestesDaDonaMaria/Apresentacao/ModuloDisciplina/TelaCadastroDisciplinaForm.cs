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

namespace TestesDaDonaMaria.Apresentacao.ModuloDisciplina
{
    public partial class TelaCadastroDisciplinaForm : Form
    {
        private Disciplina disciplina;

        public TelaCadastroDisciplinaForm()
        {
            InitializeComponent();
        }

        public Disciplina Disciplina
        {
            get
            {
                return disciplina;
            }
            set
            {
                disciplina = value;
                txtNumero.Text = disciplina.Numero.ToString();
                txtNome.Text = disciplina.Nome;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            disciplina.Nome = txtNome.Text;

        }
    }
}
