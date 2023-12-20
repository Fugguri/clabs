using System.Collections.Generic;
// using System.Data.SQLite;

namespace Lab5.Serializers;

// public class SQLiteObjectSerializer<T>
// {
//     private readonly string connectionString;

//     public SQLiteObjectSerializer(string dbFilePath)
//     {
//         connectionString = $"Data Source={dbFilePath};Version=3;";
//         CreateDatabaseTable();
//     }

//     public void CreateDatabaseTable()
//     {
//         using (SQLiteConnection dbConnection = new SQLiteConnection(connectionString))
//         {
//             dbConnection.Open();

//             // Здесь ваш запрос SQL для создания таблицы
//             string query = @"CREATE TABLE IF NOT EXISTS Tasks (
//                 Title TEXT,
//                 Description TEXT,
//                 Deadline TEXT,
//                 Tags TEXT
//             );";
//             dbConnection.Execute(query);
//         }
//     }

//     public List<T> ReadDataFromDatabase()
//     {
//         using (var connection = new SQLiteConnection(connectionString))
//         {
//             connection.Open();
//             return connection.Query<T>("SELECT * FROM tasks").AsList();
//         }
//     }

//     public void WriteDataToDatabase(List<T> objects)
//     {
//         using (var connection = new SQLiteConnection(connectionString))
//         {
//             connection.Open();
//             connection.Execute("CREATE TABLE IF NOT EXISTS YourTableName (YourTableColumns);");

//             string insertDataQuery = "INSERT INTO Tasks (Title, Description, Deadline, Tags) VALUES (@Title, @Description, @Deadline, @Tags);";
//             connection.Execute(insertDataQuery, objects);
//         }
//     }
// }
