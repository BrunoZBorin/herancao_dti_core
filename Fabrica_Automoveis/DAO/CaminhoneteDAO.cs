using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using BO;
using DAO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fabrica_Automoveis.DTO;

namespace Fabrica_Automoveis.DAO
{
    internal class CaminhoneteDAO: VeiculoDAO
    {
        public static void Insert(CaminhoneteDTO cd)
        {
            var id = 1;
            try
            {
                //var cmd = Conexao.dbCon().CreateCommand();
                //cmd.CommandText = "SELECT id_caminhonete FROM caminhonete WHERE id_caminhonete = (SELECT MAX(id_caminhonete) FROM caminhonete)";
                //SQLiteDataAdapter dados = new SQLiteDataAdapter(cmd.CommandText, Conexao.dbCon());
                string sqlInsert = "SELECT id_caminhonete FROM caminhonete WHERE id_caminhonete = (SELECT MAX(id_caminhonete) FROM caminhonete)";
                //DataTable veiculo = new DataTable();
                DataTable veiculo = BDOracle.getDataTable(sqlInsert);

                //dados.Fill(veiculo);

                if (veiculo.Rows.Count > 0)
                {
                    id = veiculo.Rows[0].Field<int>("id_caminhonete");
                    id += 1;
                    MessageBox.Show($"{id}");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

            try
            {
                var cmd = Conexao.dbCon().CreateCommand();

                cmd.CommandText = "INSERT INTO caminhonete (id_caminhonete, nome, modelo, ano) VALUES (@id_veiculo, @nome, @modelo, @ano)";
                cmd.Parameters.AddWithValue("@id_veiculo", id);
                cmd.Parameters.AddWithValue("@nome", cd.Nome);
                cmd.Parameters.AddWithValue("@modelo", cd.Modelo);
                cmd.Parameters.AddWithValue("@ano", cd.Ano);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deu certo");
                Conexao.dbCon().Close();
                MessageBox.Show("Caminhonete salva com sucesso");
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }

        public static List<VeiculoDTO> GetAll()
        {
            List<VeiculoDTO> list = new List<VeiculoDTO>();
            try
            {
                //var cmd = Conexao.dbCon().CreateCommand();
                //cmd.CommandText = "SELECT * FROM caminhonete";
                //SQLiteDataAdapter dados = new SQLiteDataAdapter(cmd.CommandText, Conexao.dbCon());
                string sqlSelect = "SELECT * FROM caminhonete";
                DataTable veiculos = BDOracle.getDataTable(sqlSelect);
                

                //dados.Fill(veiculos);


                list = (from DataRow dr in veiculos.Rows
                        select new VeiculoDTO()
                        {
                            Id_veiculo = Convert.ToInt32(dr["id_caminhonete"]),
                            Nome = dr["nome"].ToString(),
                            Modelo = dr["modelo"].ToString(),
                            Ano = dr["ano"].ToString(),
                            Tipo = "Caminhonete"
                        }).ToList();


            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }


            return list;
        }
    }
}
