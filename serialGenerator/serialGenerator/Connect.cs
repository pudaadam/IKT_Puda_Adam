using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace serialGenerator
{
    internal class Connect
    {
        public MySqlConnection connection;


        string db;
        string srv;
        string usr;
        string pass;


        string connectionString;

        public Connect()
        {
            srv = "localhost";
            db = "serials";
            usr = "root";
            pass = "";

            connectionString = "SERVER=" + srv + ";" + "DATABASE=" + db + ";" + "UID=" + usr + ";" + "PASSWORD=" + pass + ";"+ "SslMode=None;";

            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Sikeres kapcsolódás!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void querySelect()
        {
            string qry = "SELECT `id`, `razon`, `active` FROM `serial` ORDER BY `id` ASC;";
            MySqlCommand cmd = new MySqlCommand(qry, connection);

            MySqlDataReader datareaderSelect = cmd.ExecuteReader();

            datareaderSelect.Read();

            do
            {
                Console.Write(datareaderSelect.GetValue(0).ToString()+"-");
                Console.WriteLine(datareaderSelect.GetValue(1).ToString()+"-");
                Console.WriteLine(datareaderSelect.GetValue(2).ToString());
            }
            while (datareaderSelect.Read()==true);

            datareaderSelect.Close();
           
        }


    }
}
