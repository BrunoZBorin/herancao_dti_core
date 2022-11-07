using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using Fabrica_Automoveis.DTO;

namespace Fabrica_Automoveis.DAO
{
    class CarroPasseioDAO:VeiculoDAO
    {
        public static void Insert(CarroPasseioDTO cd)
        {
            var id = 1;
            try
            {
                var cmd = Conexao.dbCon().CreateCommand();
                cmd.CommandText = "SELECT id_carro FROM carro WHERE id_carro = (SELECT MAX(id_carro) FROM carro)";
                SQLiteDataAdapter dados = new SQLiteDataAdapter(cmd.CommandText, Conexao.dbCon());
                DataTable veiculo = new DataTable();

                dados.Fill(veiculo);

                if (veiculo.Rows.Count > 0)
                {
                    id = veiculo.Rows[0].Field<int>("id_carro");
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

                cmd.CommandText = "INSERT INTO carro (id_carro, nome, modelo, ano) VALUES (@id_veiculo, @nome, @modelo, @ano)";
                cmd.Parameters.AddWithValue("@id_veiculo", id);
                cmd.Parameters.AddWithValue("@nome", cd.Nome);
                cmd.Parameters.AddWithValue("@modelo", cd.Modelo);
                cmd.Parameters.AddWithValue("@ano", cd.Ano);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deu certo");
                Conexao.dbCon().Close();
                MessageBox.Show("Carro Passeio salvo com sucesso");
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
                //cmd.CommandText = "SELECT * FROM carro";
                //SQLiteDataAdapter dados = new SQLiteDataAdapter(cmd.CommandText, Conexao.dbCon());
                string sqlSelect = "SELECT * FROM carro";
                DataTable veiculos = BDOracle.getDataTable(sqlSelect);

                //dados.Fill(veiculos);


                list = (from DataRow dr in veiculos.Rows
                        select new VeiculoDTO()
                        {
                            Id_veiculo = Convert.ToInt32(dr["id_carro"]),
                            Nome = dr["nome"].ToString(),
                            Modelo = dr["modelo"].ToString(),
                            Ano = dr["ano"].ToString(),
                            Tipo = "Carro Passeio"
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
