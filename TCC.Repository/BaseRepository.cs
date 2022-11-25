using System.Data.SqlClient;
using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace TCC.Repository
{
    public class BaseRepository
    {
        public string dbConnection = ConfigurationManager.AppSettings["DBmain"];
        protected string GetString(MySqlDataReader reader, string propriedade)
        {
            try
            {
                if (reader[propriedade] != DBNull.Value)
                    return reader[propriedade].ToString();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao recuperar valor string de {propriedade} | {ex}");
            }
        }
        protected int? GetIntNullable(MySqlDataReader reader, string propriedade)
        {
            try
            {
                if (reader[propriedade] != DBNull.Value)
                    return Convert.ToInt32(reader[propriedade].ToString());
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao recuperar valor int de {propriedade} | {ex}");
            }
        }

        protected decimal? GetDecimalNullable(MySqlDataReader reader, string propriedade)
        {
            try
            {
                if (reader[propriedade] != DBNull.Value)
                    return Convert.ToDecimal(reader[propriedade].ToString());
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao recuperar valor decimal de {propriedade} | {ex}");
            }
        }

        protected DateTime? GetDateTimeNullable(MySqlDataReader reader, string propriedade)
        {
            try
            {
                if (reader[propriedade] != DBNull.Value)
                    return Convert.ToDateTime(reader[propriedade].ToString());
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao recuperar valor DateTime de {propriedade} | {ex}");
            }
        }

        protected bool? GetBoolNullable(MySqlDataReader reader, string propriedade)
        {
            try
            {
                if (reader[propriedade] != DBNull.Value)
                    return Convert.ToBoolean(reader[propriedade].ToString());
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao recuperar valor bool de {propriedade} | {ex}");
            }
        }

        protected int GetInt(MySqlDataReader reader, string propriedade)
        {
            return Convert.ToInt32(GetString(reader, propriedade));
        }



        protected TimeSpan GetTimeSpan(MySqlDataReader reader, string propriedade)
        {
            return TimeSpan.Parse(GetString(reader, propriedade));
        }
        protected TimeSpan? GetTimeSpanNullable(MySqlDataReader reader, string propriedade)
        {
            try
            {
                if (reader[propriedade] != DBNull.Value)
                    return TimeSpan.Parse(reader[propriedade].ToString());
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Falha ao recuperar valor DateTime de {propriedade} | {ex}");
            }
        }

        protected DateTime GetDateTime(MySqlDataReader reader, string propriedade)
        {
            return Convert.ToDateTime(GetString(reader, propriedade));
        }

        protected bool GetBool(MySqlDataReader reader, string propriedade)
        {
            return Convert.ToBoolean(GetString(reader, propriedade));
        }

        protected decimal GetDecimal(MySqlDataReader reader, string propriedade)
        {
            return Convert.ToDecimal(GetString(reader, propriedade));
        }
    }
}



