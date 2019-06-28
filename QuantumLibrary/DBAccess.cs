using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace QuantumLibrary
{
    /// <summary>
    /// Summary description for DBAccess
    /// </summary>
    public class DBAccess
    {
        SqlConnection conn;
        SqlCommand cmd;

        public DBAccess(string commandText)
        {
            //connect to database
            conn = new SqlConnection(Data.ReadSetting("dbConnection"));
            conn.Open();
            
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "g." + commandText;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public void AddParameter(string parameterName, object value)
        {
            SqlParameter sp = new SqlParameter(parameterName, value);
            cmd.Parameters.Add(sp);
        }

        /// <summary>
        /// Used with different types such as custom table structures in SQL
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        /// <param name="typeName"></param>
        public void AddParameter(string parameterName, object value, string typeName)
        {
            SqlParameter sp = new SqlParameter(parameterName, value);
            sp.TypeName = typeName;
            cmd.Parameters.Add(sp);
        }

        public void AddParameter(string parameterName, object value, SqlDbType type, int size, ParameterDirection parameterDirection)
        {
            SqlParameter sp = new SqlParameter(parameterName, type, size, parameterDirection, true, 0, 0, "", DataRowVersion.Current, value);
            cmd.Parameters.Add(sp);
        }

        public object GetParameter(string parameterName)
        {
            return cmd.Parameters[parameterName].Value;
        }

        public DataSet ExecuteReader()
        {
            SqlDataReader dataReader = cmd.ExecuteReader();
            DataSet ds = convertDataReaderToDataSet(dataReader);
            CleanUp();
            return ds;
        }

        public object ExecuteNonQuery()
        {
            object returnValue = cmd.ExecuteNonQuery();

            CleanUp();
            return returnValue;
        }

        public object ExecuteScalar()
        {
            object returnValue = cmd.ExecuteScalar();

            CleanUp();
            return returnValue;
        }

        private void CleanUp()
        {
            conn.Close();
            cmd.Dispose();
        }






        public static DataSet convertDataReaderToDataSet(SqlDataReader reader)
        {
            DataSet dataSet = new DataSet();
            do
            {
                // Create new data table

                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    // A query returning records was executed

                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        // Create a column name that is unique in the data table
                        string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                        // Add the column definition to the data table
                        DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);

                        dataTable.Columns.Add(column);
                    }

                    dataSet.Tables.Add(dataTable);

                    // Fill the data table we just created

                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    // No records were returned

                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }
            while (reader.NextResult());
            return dataSet;
        }

    }
}