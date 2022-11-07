using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fabrica_Automoveis.DTO;
using Fabrica_Automoveis.DAO;

namespace Fabrica_Automoveis
{
    public partial class CadastroVeiculos : Form
    {
        public bool update = false;
        public CadastroVeiculos()
        {
            InitializeComponent();
        }

        public void GetValuesFromListaVeiculos(DataGridViewRow row)
        {
            IdTextBox.Text = row.Cells[0].Value.ToString();
            textBox1.Text = row.Cells[1].Value.ToString();
            textBox2.Text = row.Cells[2].Value.ToString();
            textBox3.Text = row.Cells[3].Value.ToString();
            tipoVeiculo.Text = row.Cells[4].Value.ToString();
            update = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string tipo = tipoVeiculo.Text;

            if (update)
            {
                VeiculoDTO veiculo = new VeiculoDTO();
                veiculo.Nome = textBox1.Text;
                veiculo.Modelo = textBox2.Text;
                veiculo.Ano = textBox3.Text;
                veiculo.Id_veiculo = Convert.ToInt32(IdTextBox.Text);

                VeiculoDAO.Update(veiculo, tipo);
            }
            else
            {

                switch (tipo)
                {
                    case "Caminhonete":
                        CaminhoneteDTO cm = new CaminhoneteDTO();

                        cm.Nome = textBox1.Text;
                        cm.Modelo = textBox2.Text;
                        cm.Ano = textBox3.Text;

                        CaminhoneteDAO.Insert(cm);
                        break;
                    case "Carro Passeio":
                        CarroPasseioDTO cp = new CarroPasseioDTO();

                        cp.Nome = textBox1.Text;
                        cp.Modelo = textBox2.Text;
                        cp.Ano = textBox3.Text;

                        CarroPasseioDAO.Insert(cp);
                        break;
                    case "Moto":
                        MotoDTO mt = new MotoDTO();

                        mt.Nome = textBox1.Text;
                        mt.Modelo = textBox2.Text;
                        mt.Ano = textBox3.Text;

                        MotoDAO.Insert(mt);
                        break;
                }

            }

            ListaVeiculos listaVeiculos = new ListaVeiculos();

            listaVeiculos.carregaGrid();
            this.Close();
            listaVeiculos.Show();
        }
    }
}
