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
using UtilDLL;

namespace Fabrica_Automoveis.DAO
{
    class CarroPasseioDAO:VeiculoDAO
    {
        public static void Insert(CarroPasseioDTO cd)
        {
            var id = 1;
            try
            {
                string sqlSelect = "SELECT id_carro FROM SIHOSP.CARRO WHERE id_carro = (SELECT MAX(id_carro) FROM SIHOSP.CARRO)";
                DataTable veiculos = BDOracle.getDataTable(sqlSelect);
                
                if (veiculos.Rows.Count > 0)
                {
                    id = veiculos.Rows.Count;
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

            try
            {
                string sqlInsert = $"INSERT INTO SIHOSP.CARRO (id_carro, nome, modelo, ano) VALUES ({id}, '{ cd.Nome}', '{ cd.Modelo}', '{ cd.Ano}')";
               
                String retorno = BDOracle.executaComandoCommit(sqlInsert);

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
                string sqlSelect = "SELECT * FROM SIHOSP.carro";
                DataTable veiculos = BDOracle.getDataTable(sqlSelect);

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
