using Fabrica_Automoveis.DAO;
using Fabrica_Automoveis.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fabrica_Automoveis
{
    public partial class ListaVeiculos : Form
    {
        int idRowSelected = 0;
        string tipoRowSelected = "";
        public ListaVeiculos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastroVeiculos cv = new CadastroVeiculos();

            this.Hide();

            cv.Show();
        }

        private void ListaVeiculos_Load(object sender, EventArgs e)
        {
            carregaGrid();
        }

        public void carregaGrid()
        {
            List<VeiculoDTO> veiculoList = new List<VeiculoDTO>();
            List<VeiculoDTO> list = new List<VeiculoDTO>();
            list = CarroPasseioDAO.GetAll();
            foreach (VeiculoDTO veiculo in list)
            {
                veiculoList.Add(veiculo);
            }

            list = CaminhoneteDAO.GetAll();
            foreach (VeiculoDTO veiculo in list)
            {
                veiculoList.Add(veiculo);
            }

            list = MotoDAO.GetAll();
            foreach (VeiculoDTO veiculo in list)
            {
                veiculoList.Add(veiculo);
            }

            dataGridView1.DataSource = veiculoList;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            idRowSelected = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            tipoRowSelected = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idRowSelected != 0)
            {
                VeiculoDAO.Delete(idRowSelected, tipoRowSelected);
                carregaGrid();
            }
            else
            {
                MessageBox.Show("Por favor selecione um veículo para exclusão");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            CadastroVeiculos cv = new CadastroVeiculos();
            cv.GetValuesFromListaVeiculos(row);
            this.Hide();
            cv.Show();
        }
    }
}
