/*
Author: Yuvaraj J
Description: Electronics shopping site
Modified by:Yuvaraj J
Modified at:31/03/2022 7:00 PM
*/

using MySql.Data.MySqlClient;
using MySql.Data;
using System;

namespace MySQLConnectionExample
{
    class Program
    {
        static void Main(string[] args)
        {

            string connStr = "server=localhost;user=root;database=shopping;port=3306;password=1999";

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@employeeID";
                    param1.SqlDbType = SqlDbType.Int;
                    param1.Value = int.Parse(args[0].ToString());
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "select * from shopping.login where Username=@Uvaraja";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.ToString());
            }
            conn.Close();
            Console.WriteLine("Connection Closed. Press any key to exit...");
            Console.Read();
        }
    }
}