using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FootballTeam.Models
{
    public class PlayersBesiktas
    {
        #region Fields
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

        #endregion

        #region List
        public List<PlayersBesiktas> List()
        {

            List<PlayersBesiktas> Players = new List<PlayersBesiktas>();

            using (Database db = new Database("data source=desktop-9f7c59u\\mssqlserv; database=FootbalDb; integrated security=SSPI"))
            {
                Players = db.List("SELECT * FROM Besiktas", (SqlDataReader reader) =>
                {
                    PlayersBesiktas player = new PlayersBesiktas();

                    player.PlayerID = Convert.ToInt32(reader["PlayerID"]);
                    player.Name = reader["Name"].ToString();
                    player.Surname = reader["Surname"].ToString();
                    player.Position = reader["Position"].ToString();
                    player.Age = Convert.ToInt32(reader["Age"]);
                    return player;
                });

            }
            return Players;
        }
        #endregion

        #region Create/Edit/Delete
        public void InsertBesiktas(string Name, string Surname, string Position, int Age)
        {
            using (Database db = new Database("data source=desktop-9f7c59u\\mssqlserv; database=FootbalDb; integrated security=SSPI"))
            {
                // Listenin eleman sayısını al
                int count = List().Count;

                // Yeni bir PlayerID değeri hesapla
                int newPlayerID = count + 1;

                // Yeni oyuncuyu ekle
                db.executeNonQuery("INSERT INTO Besiktas (PlayerID, Name, Surname, Position, Age) VALUES (" + newPlayerID + ",'" + Name + "', '" + Surname + "', '" + Position + "', " + Age + ")");
            }
        }
        public void DeleteBesiktas(int PlayerID)
        {
            try
            {
                using (Database db = new Database("data source=desktop-9f7c59u\\mssqlserv; database=FootbalDb; integrated security=SSPI"))
                {
                    db.executeNonQuery("Delete from Besiktas where PlayerID = " + PlayerID);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
        }

        public void UpdateBesiktas(int PlayerID, string newName, string row, int? newAge = null)
        {
            using (Database db = new Database("data source=desktop-9f7c59u\\mssqlserv; database=FootbalDb; integrated security=SSPI"))
            {
                if (row == "Age")
                {
                    db.executeNonQuery("Update Besiktas Set " + row + " = " + newAge + " where PlayerID = " + PlayerID);
                }
                else
                {
                    db.executeNonQuery("Update Besiktas Set " + row + " = '" + newName + "' where PlayerID = " + PlayerID);
                }
            }
        }

        #endregion


    }
}
