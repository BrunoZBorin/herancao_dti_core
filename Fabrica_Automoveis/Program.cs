using System;
using BO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;

namespace Fabrica_Automoveis
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CALogin.BOCALogin.setConexao("[famema.famema].teste");
            BOUsuario.CAambiente = BOCAAmbiente.getCAAmbiente(1);
            Application.Run(new ListaVeiculos());
        }
        /*public static void chamaForm()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CALogin.BOCALogin.setConexao("[famema.famema].teste");
            BOUsuario.CAambiente = new CAAmbiente();
            BOCAAmbiente.getCAAmbiente(1);
        }*/
    }
}
