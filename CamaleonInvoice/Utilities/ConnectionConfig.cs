using CamaleonInvoice.Properties;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

public static class ConnectionConfig
{
    public static readonly int CamaleonBuild = 133;
    public static readonly string CamaleonVersion = "6.36.360";
    public static string connectionString = "datasource = localhost; port = 3306; username = root; password = antonio; database= ;";

    public static bool GetDataBases(ComboBox comboBox1, string server, string port, string username, string password)
    {
        comboBox1.Items.Clear();

        bool ConectionMaked = false;
        string conectionString = "datasource = " + server + " ; Port = " + port + " ; User Id = " + username + " ; password = " + password + " ; SslMode = none; ";
        MySqlConnection connection = null;
        try
        {
            connection = new MySqlConnection(conectionString);
            connection.Close();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SHOW DATABASES;";
            MySqlDataReader reader;
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string row = "";
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row += reader.GetValue(i).ToString() + "";
                }
                comboBox1.Items.Add(row);
            }
            ConectionMaked = true;
        }
        catch (MySqlException e)
        {
            MessageBox.Show(e.Message);
        }
        finally
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        return ConectionMaked;
    }

    public static bool CheckCamaleonVersion()
    {
        bool RigthVersion = false;
        string CurrentVersion = "0";
        int CurrentBuild = 0;
        MySqlConnection connection = null;
        try
        {
            connection = new MySqlConnection();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT CamaleonVER, Camaleon_Build FROM it_tcompany";
            MySqlDataReader Reader;
            connection.Open();
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                CurrentVersion = Reader.GetString("CamaleonVER");
                CurrentBuild = Reader.GetInt32("Camaleon_Build");
            }
            connection.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("Call the administrator", "Connection Error");
        }
        finally
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        if (CamaleonVersion == CurrentVersion)
        {
            if (CamaleonBuild <= CurrentBuild)
            {
                RigthVersion = true;
            }
        }

        return RigthVersion;
    }

    public static void LoadConnStringSettings()
    {
        connectionString = "datasource = " + Settings.Default.localServer +
                                              "; port = " + Settings.Default.localPort +
                                              "; username = " + Settings.Default.localUser +
                                              "; password = " + Settings.Default.localPassword +
                                              "; database= " + Settings.Default.localDatabase +
                                               "; SslMode = none;";
    }
}