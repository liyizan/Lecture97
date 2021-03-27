using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lecture97
{
    class AccessData
    {
        public async static void InitializeDatabase()
        {
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS CharecterTable (uid INTEGER PRIMARY KEY, " +
                    "Charecter_name NVARCHAR(50),"+
                    "e_lement NVARCHAR(50),"+
                    "phone_number NVARCHAR(50) NULL)";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }
        public static void Adddata(string Charecter_name,string e_lement,string phone_number)
        {
            using(SqliteConnection db =
                new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO CharecterTable VALUES (NULL,@Charecter_name,@e_lement,@phone_number)";
                insertCommand.Parameters.AddWithValue("@Charecter_name",Charecter_name);
                insertCommand.Parameters.AddWithValue("@e_lement", e_lement);
                insertCommand.Parameters.AddWithValue("@phone_number", phone_number);
                insertCommand.ExecuteReader();
                db.Close();
            }
        }
        
        public static List<String> GetData()
        {
            List<String> entries = new List<string>();
            using (SqliteConnection db =
               new SqliteConnection($"Filename=sqliteSample.db"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT Charecter_name,e_lement,phone_number from CharecterTable", db);

                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                    entries.Add(query.GetString(1));
                    entries.Add(query.GetString(2));
                }
                db.Close();
            }
            return entries;
        }
    }
}
