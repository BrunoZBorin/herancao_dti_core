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
            var id = 0;
            
            try
            {
                var sqlInsert = $"INSERT INTO SIHOSP.moto " +
                    $"(nome, modelo, ano) VALUES " +
                    $"('{ cd.Nome}', '{ cd.Modelo}', '{ cd.Ano}')";

                var retorno = BDOracle.executaComandoCommitHandle(sqlInsert, "id_moto", ref id);

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
                var sqlSelect = "SELECT * FROM SIHOSP.moto";
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
