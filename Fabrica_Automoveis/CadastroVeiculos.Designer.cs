
namespace Fabrica_Automoveis
{
    partial class CadastroVeiculos
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.tipoVeiculo = new System.Windows.Forms.ComboBox();
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(61, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(299, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(61, 186);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(299, 20);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(61, 250);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(299, 20);
            this.textBox3.TabIndex = 2;
            // 
            // tipoVeiculo
            // 
            this.tipoVeiculo.FormattingEnabled = true;
            this.tipoVeiculo.Items.AddRange(new object[] {
            "Caminhonete",
            "Carro Passeio",
            "Moto"});
            this.tipoVeiculo.Location = new System.Drawing.Point(61, 70);
            this.tipoVeiculo.Name = "tipoVeiculo";
            this.tipoVeiculo.Size = new System.Drawing.Size(299, 21);
            this.tipoVeiculo.TabIndex = 3;
            // 
            // IdTextBox
            // 
            this.IdTextBox.Enabled = false;
            this.IdTextBox.Location = new System.Drawing.Point(61, 12);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(100, 20);
            this.IdTextBox.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 44);
            this.button1.TabIndex = 5;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // CadastroVeiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.tipoVeiculo);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "CadastroVeiculos";
            this.Text = "CadastroVeiculos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox tipoVeiculo;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.Button button1;
    }
}