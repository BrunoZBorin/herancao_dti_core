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
            
            var id = 0;

            try
            {
                var sqlInsert = $"INSERT INTO SIHOSP.caminhonete " +
                    $"( nome, modelo, ano) VALUES " +
                    $"( '{ cd.Nome}', '{ cd.Modelo}', '{ cd.Ano}')";

                var retorno = BDOracle.executaComandoCommitHandle(sqlInsert, "id_caminhonete", ref id);
                
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
                var sqlSelect = "SELECT * FROM SIHOSP.caminhonete";
                DataTable veiculos = BDOracle.getDataTable(sqlSelect);

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
