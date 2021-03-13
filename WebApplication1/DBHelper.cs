using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication1
{
  public class DBHelper
  {
    string connect = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;

    public DataTable execQuery(string query)
    {
      DataTable table = new DataTable();
      try
      {
        using (SqlConnection connection = new SqlConnection(connect))
        {
          connection.Open();
          using (SqlCommand command = new SqlCommand())
          {
            command.Connection = connection;
            command.CommandText = query;
            command.CommandType = CommandType.StoredProcedure;
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
              adapter.SelectCommand = command;
              adapter.Fill(table);
            }
          }
        }
      }
      catch (SqlException e1)
      {
        throw e1;
      }
      catch (Exception e2)
      {
        throw e2;
      }
      return table;
    }


    public DataTable execQuery(string query, string[] listParam, object[] listValue)
    {
      DataTable table = new DataTable();
      int len = listParam.Length;

      try
      {
        using (SqlConnection connection = new SqlConnection(connect))
        {
          connection.Open();
          using (SqlCommand command = new SqlCommand())
          {
            command.Connection = connection;
            command.CommandText = query;
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter[] parameters = new SqlParameter[len];
            for (int i = 0; i < len; i++)
            {
              parameters[i] = new SqlParameter(listParam[i], listValue[i]);
            }
            command.Parameters.AddRange(parameters);

            using (SqlDataAdapter adapter = new SqlDataAdapter())
            {
              adapter.SelectCommand = command;
              adapter.Fill(table);
            }
          }
        }
      }
      catch (SqlException e1)
      {
        throw e1;
      }
      catch (Exception e2)
      {
        throw e2;
      }
      return table;
    }

    public bool execNonQuery(string query, string[] listParam, object[] listValue)
    {
      bool isExec = true;
      int len = listParam.Length;

      try
      {
        using (SqlConnection connection = new SqlConnection(connect))
        {
          connection.Open();
          using (SqlCommand command = new SqlCommand())
          {
            command.Connection = connection;
            command.CommandText = query;
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter[] parameters = new SqlParameter[len];
            for (int i = 0; i < len; i++)
            {
              parameters[i] = new SqlParameter(listParam[i], listValue[i]);
            }
            command.Parameters.AddRange(parameters);
            int res = command.ExecuteNonQuery();
            if (res < 0)
            {
              isExec = false;
            }
          }
        }
      }
      catch (SqlException e1)
      {
        throw e1;
      }
      catch (Exception e2)
      {
        throw e2;
      }
      return isExec;
    }
  }
}