using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fabrica_Automoveis.DTO;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using DAO;

namespace Fabrica_Automoveis.DAO
{
    class MotoDAO:VeiculoDAO
    {
        public static void Insert(MotoDTO cd)
        {
            var id = 1;
            try
            {
                //var cmd = Conexao.dbCon().CreateCommand();
                //cmd.CommandText = "SELECT id_moto FROM moto WHERE id_moto = (SELECT MAX(id_moto) FROM moto)";
                //SQLiteDataAdapter dados = new SQLiteDataAdapter(cmd.CommandText, Conexao.dbCon());
                string sqlSelect = "SELECT * FROM moto";
                DataTable veiculos = BDOracle.getDataTable(sqlSelect);

                //dados.Fill(veiculo);

                if (veiculos.Rows.Count > 0)
                {
                    id = veiculos.Rows[0].Field<int>("id_moto");
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

                cmd.CommandText = "INSERT INTO moto (id_moto, nome, modelo, ano) VALUES (@id_veiculo, @nome, @modelo, @ano)";
                cmd.Parameters.AddWithValue("@id_veiculo", id);
                cmd.Parameters.AddWithValue("@nome", cd.Nome);
                cmd.Parameters.AddWithValue("@modelo", cd.Modelo);
                cmd.Parameters.AddWithValue("@ano", cd.Ano);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deu certo");
                Conexao.dbCon().Close();
                MessageBox.Show("Moto salva com sucesso");
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
                //cmd.CommandText = "SELECT * FROM moto";
                //SQLiteDataAdapter dados = new SQLiteDataAdapter(cmd.CommandText, Conexao.dbCon());
                //DataTable veiculos = new DataTable();
                string sqlSelect = "SELECT * FROM moto";
                DataTable veiculos = BDOracle.getDataTable(sqlSelect);

                //dados.Fill(veiculos);


                list = (from DataRow dr in veiculos.Rows
                        select new VeiculoDTO()
                        {
                            Id_veiculo = Convert.ToInt32(dr["id_moto"]),
                            Nome = dr["nome"].ToString(),
                            Modelo = dr["modelo"].ToString(),
                            Ano = dr["ano"].ToString(),
                            Tipo = "Moto"
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
