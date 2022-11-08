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
                string sqlSelect = "SELECT * FROM SIHOSP.moto";
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
                string sqlInsert = $"INSERT INTO SIHOSP.moto (id_moto, nome, modelo, ano) VALUES ({id}, '{ cd.Nome}', '{ cd.Modelo}', '{ cd.Ano}')";

                String retorno = BDOracle.executaComandoCommit(sqlInsert);

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
                string sqlSelect = "SELECT * FROM SIHOSP.moto";
                DataTable veiculos = BDOracle.getDataTable(sqlSelect);

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
