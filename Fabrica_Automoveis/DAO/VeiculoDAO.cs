using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using Fabrica_Automoveis.DTO;

namespace Fabrica_Automoveis.DAO
{
    class VeiculoDAO
    {
        public static void Insert()
        {

        }

        public static void Update(VeiculoDTO veiculo, string tipo)
        {
            var tabela = "";
            var tipo_id = "";
            SQLiteDataAdapter da = null;
            switch (tipo)
            {
                case "Caminhonete":
                    tabela = "SIHOSP.caminhonete";
                    tipo_id = "id_caminhonete";
                    break;

                case "Carro Passeio":
                    tabela = "SIHOSP.carro";
                    tipo_id = "id_carro";
                    break;
                case "Moto":
                    tabela = "SIHOSP.moto";
                    tipo_id = "id_moto";
                    break;
            }

            try
            {
                
                
                var sqlUpdate = "UPDATE " + tabela + " SET " +
                    "nome = '" + veiculo.Nome.ToString() + 
                    "', modelo = '" + veiculo.Modelo.ToString() + "'" +
                    ", ano = '" + veiculo.Ano.ToString() + 
                    "' WHERE " + tipo_id + " = " + veiculo.Id_veiculo + " ";
                
                var retorno = BDOracle.executaComandoCommit(sqlUpdate);

                MessageBox.Show("Veículo alterado com sucesso");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }

        public static List<VeiculoDAO> GetAll()
        {
            return new List<VeiculoDAO>();
        }
        public static void Delete(Int32 id, string tipo)
        {
            var tabela = "";
            var tipo_id = "";
            SQLiteDataAdapter da = null;
            switch (tipo)
            {
                case "Caminhonete":
                    tabela = "SIHOSP.caminhonete";
                    tipo_id = "id_caminhonete";
                    break;

                case "Carro Passeio":
                    tabela = "SIHOSP.carro";
                    tipo_id = "id_carro";
                    break;
                case "Moto":
                    tabela = "SIHOSP.moto";
                    tipo_id = "id_moto";
                    break;
            }
            try
            {
                
                var sqlDelete = "DELETE FROM " + tabela + 
                    " WHERE " + tipo_id + " = " + id + " ";
                var retorno = BDOracle.executaComandoCommit(sqlDelete);

                MessageBox.Show("Veículo excluído com sucesso");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }
    }
}
