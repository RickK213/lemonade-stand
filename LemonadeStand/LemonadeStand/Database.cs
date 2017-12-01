using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LemonadeStand
{
    public class Database
    {
        //member variables
        string connectionString = "Data Source=localhost;Initial Catalog=LemonadeStand;Integrated Security=True";

        //constructor
        public Database()
        {

        }
        
        //member methods

        //For future reference, this code was found here (Thanks David Merkel)
        //msdn.microsoft.com/en-us/library/86773566(v=vs.110).aspx
        public void SaveScoreToDatabase(string playerName, double playerScore)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("SampleTransaction");
                command.Connection = connection;
                command.Transaction = transaction;
                try
                {
                    command.CommandText =
                        $"INSERT into ls.High_Scores VALUES ('{playerName}', {playerScore})";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
            }
        }

        public void SavePlayerScores(List<Player> players)
        {
            foreach ( Player player in players )
            {
                SaveScoreToDatabase(player.name, player.totalProfit);
            }
        }

        //For future reference, this code was found here (and modified a lot):
        //quickstart.developerfusion.co.uk/quickstart/howto/doc/adoplus/sqldtreader.aspx
        public string GetLeaderboard()
        {

            SqlDataReader myDataReader = null;

            SqlConnection mySqlConnection = new SqlConnection(connectionString);
            SqlCommand mySqlCommand = new SqlCommand("SELECT TOP 5 Player_Name, Total_Profit FROM ls.High_Scores ORDER BY Total_Profit DESC;", mySqlConnection);
            mySqlConnection.Open();
            myDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection);

            List<string> playerNames = new List<string>();
            List<double> playerScores = new List<double>();
            while (myDataReader.Read())
            {
                playerNames.Add(myDataReader.GetString(0));
                playerScores.Add(myDataReader.GetDouble(1));
            }
            // Always call Close when done reading.
            myDataReader.Close();
            // Close the connection when done with it.
            mySqlConnection.Close();

            string leaderboard = "L E A D E R B O A R D\n";
            leaderboard += "=====================\n\n";
            for (int i=0; i < playerNames.Count; i++)
            {
                leaderboard += (i+1) + ": " + playerNames[i] + "\n   ";
                leaderboard += playerScores[i].ToString("C2") + "\n\n";
            }
            return leaderboard;
        }
    }
}
