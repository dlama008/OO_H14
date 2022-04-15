using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OO_H14
{
    class Laakari
    {
        public int Id { get; set; }
        public string Nimi { get; set; }
        public string Puhelinnumero { get; set; }

        public List<Laakari> TulostaTiedot(SqlConnection munYhteys)
        {
            List<Laakari> laakaris = new List<Laakari>();
            string yhteysMerkkijono = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Hammaslaakari;
                Integrated Security=true;";
            using (SqlConnection sqlConnection = new SqlConnection(yhteysMerkkijono))
            {
                try
                {
                    string kysely = "SELECT * FROM Laakari";
                    SqlCommand sqlCommand = new SqlCommand(kysely, sqlConnection);
                    sqlConnection.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            while (sqlDataReader.Read())
                            {
                                Console.WriteLine(string.Format("{0}, {1}, {2}",
                                   sqlDataReader[0], sqlDataReader[1], sqlDataReader[2]));
                            }
                        }
                        else
                            Console.WriteLine("Tyhjää täynnä voivoiii");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }

            } return laakaris;
            

        } 

       





        /*
        string yhteysMerkkijono = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Hammaslaakari;
                    Integrated Security=true;";
                    using (SqlConnection sqlConnection = new SqlConnection(yhteysMerkkijono))
                    {
                        try
                        {
                            string kysely = "SELECT * FROM Laakari";
        SqlCommand sqlCommand = new SqlCommand(kysely, sqlConnection);
        sqlConnection.Open();

                            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                            {
                                while (sqlDataReader.Read())
                                {
                                    Console.WriteLine(string.Format("{0}, {1}, {2}",
                                       sqlDataReader[0], sqlDataReader[1], sqlDataReader[2]));
                                }
                            }
                        }
                        catch (Exception ex)
    {
        Console.WriteLine(ex.Message);

    }*/

    }
}

