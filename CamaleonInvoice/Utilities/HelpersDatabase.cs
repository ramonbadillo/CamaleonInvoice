using MySql.Data.MySqlClient;
using System;

public static class HelpersDatabase
{
    public static double GetDouble(MySqlDataReader Reader, string field)
    {
        double ReturnDouble = 0; ;
        if (Reader[field] != DBNull.Value)
        {
            ReturnDouble = Reader.GetDouble(field);
        }

        return ReturnDouble;
    }

    public static string GetDate(MySqlDataReader Reader, string field)
    {
        string ReturnString = "0001/01/01";
        if (Reader[field] != DBNull.Value)
        {
            ReturnString = Reader.GetDateTime(field).ToString("yyyy-MM-dd");
        }

        return ReturnString;
    }

    public static string GetTime(MySqlDataReader Reader, string field)
    {
        string ReturnString = "00:00:00";
        if (Reader[field] != DBNull.Value)
        {
            ReturnString = Reader.GetDateTime(field).ToString("HH:mm:ss");
        }

        return ReturnString;
    }

    public static string GetDateTime(MySqlDataReader Reader, string field)
    {
        string ReturnString = "0001/01/01 00:00:00";
        if (Reader[field] != DBNull.Value)
        {
            ReturnString = Reader.GetDateTime(field).ToString("yyyy/MM/dd HH:mm:ss");
        }

        return ReturnString;
    }

    public static string GetDateTimeSec(MySqlDataReader Reader, string field)
    {
        string ReturnString = "0001/01/01 00:00:00";
        if (Reader[field] != DBNull.Value)
        {
            ReturnString = Reader.GetDateTime(field).ToString("yyyy/MM/dd HH:mm:ss");
        }

        return ReturnString;
    }

    public static string GetTimeSpan(MySqlDataReader Reader, string field)
    {
        string ReturnString = "00:00:00";
        if (Reader[field] != DBNull.Value)
        {
            ReturnString = Reader.GetTimeSpan(field).ToString();
        }

        return ReturnString;
    }

    public static string GetString(MySqlDataReader Reader, string field)
    {
        string ReturnString = "";
        if (Reader[field] != DBNull.Value)
        {
            ReturnString = Truncate(Reader.GetString(field), 100);
        }

        return ReturnString;
    }

    public static string GetXML(MySqlDataReader Reader, string field)
    {
        string ReturnString = "";
        if (Reader[field] != DBNull.Value)
        {
            ReturnString = Reader.GetString(field);
        }

        return ReturnString;
    }

    public static decimal GetDecimal(MySqlDataReader Reader, string field)
    {
        decimal ReturnDecimal = 0M;
        if (Reader[field] != DBNull.Value)
        {
            ReturnDecimal = Reader.GetDecimal(field);
        }
        return ReturnDecimal;
    }

    public static int GetInt(MySqlDataReader Reader, string field)
    {
        int ReturnInt = 0;
        if (Reader[field] != DBNull.Value)
        {
            ReturnInt = Reader.GetInt32(field);
        }
        return ReturnInt;
    }

    public static int GetInt16(MySqlDataReader Reader, string field)
    {
        int ReturnInt = 0;
        if (Reader[field] != DBNull.Value)
        {
            ReturnInt = Reader.GetInt16(field);
        }
        return ReturnInt;
    }

    public static float GetFloat(MySqlDataReader Reader, string field)
    {
        float ReturnFloat = 0;
        if (Reader[field] != DBNull.Value)
        {
            ReturnFloat = Reader.GetFloat(field);
        }
        return ReturnFloat;
    }

    public static string Truncate(this string value, int maxLength, bool replaceTruncatedCharWithEllipsis = false)
    {
        if (replaceTruncatedCharWithEllipsis && maxLength <= 3)
            throw new ArgumentOutOfRangeException("maxLength",
                "maxLength should be greater than three when replacing with an ellipsis.");

        if (String.IsNullOrWhiteSpace(value))
            return String.Empty;

        if (replaceTruncatedCharWithEllipsis &&
            value.Length > maxLength)
        {
            return value.Substring(0, maxLength - 3) + "...";
        }

        return value.Substring(0, Math.Min(value.Length, maxLength));
    }

    public static string TrimSpacesBetweenString(string s)
    {
        var mystring = s.Split(new string[] { " " }, StringSplitOptions.None);
        string result = string.Empty;
        foreach (var mstr in mystring)
        {
            var ss = mstr.Trim();
            if (!string.IsNullOrEmpty(ss))
            {
                result = result + ss + " ";
            }
        }
        return result.Trim();
    }
}