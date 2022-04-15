using System;
using System.Data.SqlClient;

namespace OO_H14
{
    public class Program
    {
        static void Main(string[] args)
        {
            r:
            Console.WriteLine("Tervetuloa, mitä haluaisit tehdä?");
            Console.WriteLine("1. Näytä tiedot ");
            Console.WriteLine("2. Lisää uusi lääkäri ");
            Console.WriteLine("3. Poista lääkäri ");
            Console.WriteLine("4. Muuta tietoja ");

            string toiminto = Console.ReadLine();
            Int32.Parse(toiminto);

            Console.WriteLine(toiminto);

            //Printataan tiedot
            if (toiminto == "1")
            {
                {

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


                    }
                }
            }

            //Lisää uusi lääkäri
            else if (toiminto == "2")
            {
                Console.WriteLine("Syötä uuden lääkärin nimi: ");
                string uusiNimi = Console.ReadLine();

                Console.WriteLine("Syötä puhelinnumero");
                string uusiPuhelinNro = Console.ReadLine();

                string yhteysMerkkijono = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Hammaslaakari; Integrated Security=true;";
                using (SqlConnection sqlConnection = new SqlConnection(yhteysMerkkijono))
                {
                    try
                    {

                        string lisays = "INSERT INTO Laakari (Nimi, PuhelinNro) VALUES (@uusiNimi, uusiPuhelinNro)";
                        SqlCommand sqlCommand = new SqlCommand(lisays, sqlConnection);
                        

                        SqlParameter sqlParameter = new SqlParameter
                        {
                            ParameterName = "@LaaNimi",
                            Value = "Hessu Sr. Hopo",
                            SqlDbType = System.Data.SqlDbType.NVarChar
                        };
                        sqlCommand.Parameters.Add(sqlParameter);

                        sqlParameter = new SqlParameter
                        {
                            ParameterName = "@LaaPuhelin",
                            Value = "040 5556991",
                            SqlDbType = System.Data.SqlDbType.NVarChar
                        };
                        sqlCommand.Parameters.Add(sqlParameter);
                        sqlCommand.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }
            }


            //Poista lääkäri
            else if (toiminto == "3")
            {

            }

            //Muokkaa tietoja
            else if (toiminto == "4")
            {

            }

            Console.WriteLine("Haluatko tehdä jotain muuta?");
           string alkuun= Console.ReadLine().ToUpper();
            if (alkuun.StartsWith("K"))
            {
                goto r;
            }

            //Tulosta tiedot
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

                }

            }*/


        }   
    }
}
