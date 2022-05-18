namespace TestesDaDonaMaria.Apresentacao.ModuloTeste
{
    partial class TelaCadastroTestesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQtdQuestoes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxDisciplina = new System.Windows.Forms.ComboBox();
            this.listQuestoes = new System.Windows.Forms.ListBox();
            this.btnSortear = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxMateria = new System.Windows.Forms.ComboBox();
            this.dtpData = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número: ";
            // 
            // txtNumero
            // 
            this.txtNumero.Enabled = false;
            this.txtNumero.Location = new System.Drawing.Point(95, 34);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(132, 23);
            this.txtNumero.TabIndex = 1;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(95, 77);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(212, 23);
            this.txtTitulo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Título:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data: ";
            // 
            // txtQtdQuestoes
            // 
            this.txtQtdQuestoes.Location = new System.Drawing.Point(111, 245);
            this.txtQtdQuestoes.Name = "txtQtdQuestoes";
            this.txtQtdQuestoes.Size = new System.Drawing.Size(100, 23);
            this.txtQtdQuestoes.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Quantidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "de Questões:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Disciplina:";
            // 
            // cbxDisciplina
            // 
            this.cbxDisciplina.DisplayMember = "Nome";
            this.cbxDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDisciplina.FormattingEnabled = true;
            this.cbxDisciplina.Location = new System.Drawing.Point(95, 159);
            this.cbxDisciplina.Name = "cbxDisciplina";
            this.cbxDisciplina.Size = new System.Drawing.Size(159, 23);
            this.cbxDisciplina.TabIndex = 10;
            this.cbxDisciplina.SelectedIndexChanged += new System.EventHandler(this.cbxDisciplina_SelectedIndexChanged);
            // 
            // listQuestoes
            // 
            this.listQuestoes.DisplayMember = "Enunciado";
            this.listQuestoes.FormattingEnabled = true;
            this.listQuestoes.ItemHeight = 15;
            this.listQuestoes.Location = new System.Drawing.Point(17, 315);
            this.listQuestoes.Name = "listQuestoes";
            this.listQuestoes.Size = new System.Drawing.Size(327, 199);
            this.listQuestoes.TabIndex = 11;
            // 
            // btnSortear
            // 
            this.btnSortear.Location = new System.Drawing.Point(17, 546);
            this.btnSortear.Name = "btnSortear";
            this.btnSortear.Size = new System.Drawing.Size(109, 23);
            this.btnSortear.TabIndex = 12;
            this.btnSortear.Text = "Sortear Questões";
            this.btnSortear.UseVisualStyleBackColor = true;
            this.btnSortear.Click += new System.EventHandler(this.btnSortear_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnGravar.Location = new System.Drawing.Point(152, 546);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 13;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(258, 546);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Materia: ";
            // 
            // cbxMateria
            // 
            this.cbxMateria.DisplayMember = "Titulo";
            this.cbxMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMateria.FormattingEnabled = true;
            this.cbxMateria.Location = new System.Drawing.Point(95, 202);
            this.cbxMateria.Name = "cbxMateria";
            this.cbxMateria.Size = new System.Drawing.Size(159, 23);
            this.cbxMateria.TabIndex = 16;
            // 
            // dtpData
            // 
            this.dtpData.Enabled = false;
            this.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpData.Location = new System.Drawing.Point(95, 118);
            this.dtpData.Name = "dtpData";
            this.dtpData.Size = new System.Drawing.Size(116, 23);
            this.dtpData.TabIndex = 17;
            // 
            // TelaCadastroTestesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 581);
            this.Controls.Add(this.dtpData);
            this.Controls.Add(this.cbxMateria);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnSortear);
            this.Controls.Add(this.listQuestoes);
            this.Controls.Add(this.cbxDisciplina);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtQtdQuestoes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.label1);
            this.Name = "TelaCadastroTestesForm";
            this.Text = "Cadastro de Testes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQtdQuestoes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxDisciplina;
        private System.Windows.Forms.ListBox listQuestoes;
        private System.Windows.Forms.Button btnSortear;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxMateria;
        private System.Windows.Forms.DateTimePicker dtpData;
    }
}