using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace autostation_v_0._1
{
   public class ClassDataBase
    {

       #region ExecuteNonQuery
       public int ExecuteNonQuery(ref ClassSetupProgram setupProgram, string sSql, int where)
       {
           int n = 0;
           try
           {
               using (MySqlConnection con = new MySqlConnection(setupProgram.connectionToDBString))
               {
                   
                   con.Open();
                   using (MySqlCommand sqlCommand = con.CreateCommand())
                   {
                       sqlCommand.CommandText = sSql;
                       n = sqlCommand.ExecuteNonQuery();

                   }
                   con.Close();
               }
           }
           catch (Exception ex)
           {
               n = 0;
             
           }
           return n;
       }
       #endregion 
       
       #region Execute

       protected T GetObject<T>(params object[] args)
       {
           return (T)Activator.CreateInstance(typeof(T), args);
       }

       public void Execute<T>(ref ClassSetupProgram setupProgram, string sSql, ref List<T> listResult)
       {
           string result="";
           try
           {
                string databaseName = setupProgram.connectionToDBString;
                MySqlConnection con =  new MySqlConnection(databaseName);
                   con.Open();
                   MySqlCommand command = new MySqlCommand(sSql, con);
                   MySqlDataReader dataReader = command.ExecuteReader();
                  
                   if (dataReader.HasRows)
                   {
                       while (dataReader.Read())
                       {
                           result = "";
                           for (int i = 0; i < dataReader.FieldCount; i++)
                           {
                               result += dataReader.GetString(i) + "|";
                           }
                           if (result.Count() > 2) result = result.Remove(result.Count() - 1);
                           if (result != "") listResult.Add(GetObject<T>(result));
                       }
                   }
                   con.Close();
           }
           catch (Exception ex)
           {
              
           }
       }
       #endregion 

    }
}
