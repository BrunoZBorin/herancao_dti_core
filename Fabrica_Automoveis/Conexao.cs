using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica_Automoveis
{
    
    class Conexao
    {
        private static SQLiteConnection conn;

        public static SQLiteConnection dbCon()
        {
            conn = new SQLiteConnection("Data Source=C:\\git\\db.sdb");
            conn.Open();
            return conn;
        }

        public void conectar()
        {
            conn.Open();
        }
        public void desconectar()
        {
            conn.Close();
        }

    }
}
