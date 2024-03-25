using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace DoAnXinViec
{
    class Utility
    {
        public static void SetItemFromRow<T>(T item, DataRow row)
        where T : new()
        {
            foreach (DataColumn c in row.Table.Columns)
            {
                PropertyInfo p = item.GetType().GetProperty(c.ColumnName);

                if (p != null && row[c] != DBNull.Value)
                {                  
                        p.SetValue(item, row[c], null);
                }
            }
        }
        public static List<SqlParameter> GetParameters<T>(T obj, string[] prop)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            List<SqlParameter> parameters = new List<SqlParameter>();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];
                if ((prop.Length==0) || (!prop.Contains(property.Name)))
                    parameters.Add(new SqlParameter("@" + property.Name, property.GetValue(obj)));
            }
            return parameters;
        }

        public static string GenerateInsertSql(string tableName, List<SqlParameter> parameters)
        {
            string columns = string.Join(", ", parameters.Select(p => p.ParameterName.Substring(1)));
            string parametersList = string.Join(", ", parameters.Select(p => p.ParameterName)); 
            return $"INSERT INTO {tableName} ({columns}) VALUES ({parametersList})";
        }
        public static string GenerateUpdateSql(string tableName, List<SqlParameter> parameters, string condition)
        {
            string setClause = string.Join(", ", parameters.Select(p => $"{p.ParameterName.Substring(1)} = {p.ParameterName}"));
            return $"UPDATE {tableName} SET {setClause} WHERE {condition}"; 
        }
        public static string GenerateDeleteSql(string tableName, string conditionColumn)
        {
            string sqlStr = $"DELETE FROM {tableName} WHERE {conditionColumn} = @ConditionValue";
            return sqlStr;
        }
    }
}
