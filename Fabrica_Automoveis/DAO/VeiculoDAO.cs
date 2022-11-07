using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                    tabela = "caminhonete";
                    tipo_id = "id_caminhonete";
                    break;

                case "Carro Passeio":
                    tabela = "carro";
                    tipo_id = "id_carro";
                    break;
                case "Moto":
                    tabela = "moto";
                    tipo_id = "id_moto";
                    break;
            }

            try
            {
                var cmd = Conexao.dbCon().CreateCommand();
                cmd.CommandText = "UPDATE " + tabela + " SET nome = '" + veiculo.Nome.ToString() + "', modelo = '" + veiculo.Modelo.ToString() + "'" +
                    ", ano = '" + veiculo.Ano.ToString() + "' WHERE " + tipo_id + " = " + veiculo.Id_veiculo + " ";
                da = new SQLiteDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                Conexao.dbCon().Close();
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
                    tabela = "caminhonete";
                    tipo_id = "id_caminhonete";
                    break;

                case "Carro Passeio":
                    tabela = "carro";
                    tipo_id = "id_carro";
                    break;
                case "Moto":
                    tabela = "moto";
                    tipo_id = "id_moto";
                    break;
            }
            try
            {
                var cmd = Conexao.dbCon().CreateCommand();
                cmd.CommandText = "DELETE FROM " + tabela + " WHERE " + tipo_id + " = " + id + " ";
                da = new SQLiteDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                Conexao.dbCon().Close();
                MessageBox.Show("Veículo excluído com sucesso");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }
    }
}
