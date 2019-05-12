using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace BlackJackTounamentClasses
{
    public class CSQLConnector
    {
        /// <summary>
        /// Parametrized query to add round data to database.
        /// </summary>
        /// <param name="Info">Information to store as a ;-separated string.</param>
        public static void BJEventToSQL(string Info)
        {
            string[] InfoList = Info.Split(';');
            using(SqlConnection c = new SqlConnection())
            {
                c.ConnectionString = "Server=[localhost];Database=[BlackJackRecords];Trusted_Connection=true";

                string CommandText = "INSERT INTO dbo.RoundData(Name, Time, PlayerCards, DealerCards, PlayerCards2, Doubled, Bet, PlayerCoins)" +
                                     "VALUES(@Name, @Time, @PlayerCards, @DealerCards, @PlayerCards2, @Doubled, @Bet, @PlayerCoins)";

                SqlCommand command = new SqlCommand(CommandText, c);
                command.Parameters.AddWithValue("@Name", Info[0]);
                command.Parameters.AddWithValue("@Time", Info[1]);
                command.Parameters.AddWithValue("@PlayerCards", Info[2]);
                command.Parameters.AddWithValue("@DealerCards", Info[3]);
                command.Parameters.AddWithValue("@PlayerCards2", Info[4]);
                command.Parameters.AddWithValue("@Doubled", Info[5]);
                command.Parameters.AddWithValue("@Bet", Info[6]);
                command.Parameters.AddWithValue("@PlayerCoins", Info[7]);

                try
                {
                    c.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Records Inserted Successfully");
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                }
                finally
                {
                    c.Close();
                }
            }
        }
    }
}
