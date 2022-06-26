using System.Data.SQLite;

namespace WinVerCollector
{
    internal class Database
    {
        // Database access configurations.
        private static readonly string _databaseFileName = "DeviceInfo.db";

        public static void Collect()
        {
            if (!File.Exists(_databaseFileName))
            {
                Display.WriteErrorLine(Properties.Resources.ErrorMessageDatabaseNotFound);
                CreateDatabase();
            }

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {_databaseFileName}"))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    // No transaction is used for a single write.
                    command.CommandText = "INSERT OR REPLACE INTO DeviceInfo VALUES(@p_HostName, @p_ProductName, @p_Version, @p_UserName, @p_LastUpdate)";
                    command.Parameters.Add(new SQLiteParameter("@p_HostName", DeviceInfo.GetHostName()));
                    command.Parameters.Add(new SQLiteParameter("@p_ProductName", DeviceInfo.GetProductName()));
                    command.Parameters.Add(new SQLiteParameter("@p_Version", DeviceInfo.GetVersion()));
                    command.Parameters.Add(new SQLiteParameter("@p_UserName", DeviceInfo.GetUserName()));
                    command.Parameters.Add(new SQLiteParameter("@p_LastUpdate", DateTime.Now.ToString()));
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public static void Output()
        {
            if (!File.Exists(_databaseFileName))
            {
                Display.WriteErrorLine(Properties.Resources.ErrorMessageDatabaseNotFound);
                return;
            }

            using (StreamWriter swCsv = new StreamWriter("DeviceInfo.csv", false, System.Text.Encoding.UTF8))
            {
                using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {_databaseFileName}"))
                {
                    connection.Open();
                    using (SQLiteCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM DeviceInfo";
                        using (var executeReader = command.ExecuteReader())
                        {
                            swCsv.WriteLine($"\"{Properties.Resources.StringHostName}\",\"{Properties.Resources.StringProductName}\",\"{Properties.Resources.StringVersion}\",\"{Properties.Resources.StringUserName}\",\"{Properties.Resources.StringLastUpdate}\"");
                            while (executeReader.Read())
                            {
                                swCsv.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"", executeReader["HostName"], executeReader["ProductName"], executeReader["Version"], executeReader["UserName"], executeReader["LastUpdate"]));
                            }
                        }
                    }
                    connection.Close();
                }
                swCsv.Close();
            }
        }

        public static void Show()
        {
            if (!File.Exists(_databaseFileName))
            {
                Display.WriteErrorLine(Properties.Resources.ErrorMessageDatabaseNotFound);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {_databaseFileName}"))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM DeviceInfo";
                    using (var executeReader = command.ExecuteReader())
                    {
                        Display.WriteLine("----------------------------------------------------------------------------------------------------");
                        Display.WriteLine($"\"{Properties.Resources.StringHostName}\",\"{Properties.Resources.StringProductName}\",\"{Properties.Resources.StringVersion}\",\"{Properties.Resources.StringUserName}\",\"{Properties.Resources.StringLastUpdate}\"");
                        while (executeReader.Read())
                        {
                            Display.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"", executeReader["HostName"], executeReader["ProductName"], executeReader["Version"], executeReader["UserName"], executeReader["LastUpdate"]));
                        }
                        Display.WriteLine("----------------------------------------------------------------------------------------------------");
                    }
                }
                connection.Close();
            }
        }

        public static void Clean()
        {
            if (!File.Exists(_databaseFileName))
            {
                Display.WriteErrorLine(Properties.Resources.ErrorMessageDatabaseNotFound);
                return;
            }

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {_databaseFileName}"))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "VACUUM";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private static void CreateDatabase()
        {
            SQLiteConnection.CreateFile(_databaseFileName);

            using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {_databaseFileName}"))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS DeviceInfo(HostName TEXT PRIMARY KEY, ProductName TEXT, Version TEXT, UserName TEXT, LastUpdate TEXT)";
                    command.ExecuteNonQuery();
                }
                connection.Close();

                Display.WriteLine(Properties.Resources.MessageCreateDatabase);
            }
        }
    }
}
