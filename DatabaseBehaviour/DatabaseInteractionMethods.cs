using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace DatabaseBehaviour
{
    public class DatabaseInteractionMethods
    {
        private readonly SqlConnection conn = new SqlConnection(global::DatabaseBehaviour.Properties.Settings.Default.CarboneriaConnectionString);

        private string[] selectQueriesNames =
        {
            "selectAuthorized",
            "selectEntries",
            "selectLanguage",
            "selectTrucks",
            "selectDrivers",
            "selectFields"

        };

        string[] selectQueriesStrings =
        {
            "SELECT {0} FROM [dbo].[Authorized]",
            "SELECT {0} FROM [dbo].[Entry]",
            "SELECT {0} FROM [dbo].[Language]",
            "SELECT {0} FROM [dbo].[Truck]",
            "SELECT {0} FROM [dbo].[Driver]",
            "SELECT COLUMN_NAME FROM information_schema.columns WHERE table_name = '{0}'"
        };

        private string[] addQueriesNames = {
            "addAuthorized",
            "addDriver",
            "addEntry",
            "addTruck",

        };
        string[] addQueriesStrings = {
                "INSERT INTO [dbo].[Authorized] (id_truck) " +
                "VALUES ('{0}');" +
                "SELECT SCOPE_IDENTITY()",

                "INSERT INTO [dbo].[Driver] (dni_driver, tlf_driver, email_driver) " +
                "VALUES ('{0}', '{1}', '{2}');" +
                "SELECT SCOPE_IDENTITY()",

                "INSERT INTO [dbo].[Entry] (date_entry, id_truck, id_driver, photo_entry, weight_entry) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');" +
                "SELECT SCOPE_IDENTITY()",

                "INSERT INTO [dbo].[Truck] (license_truck, photo_truck, weight_truck, description_truck) " +
                "VALUES ('{0}', '{1}', '{2}', '{3}');" +
                "SELECT SCOPE_IDENTITY();"
        };

        private string[] updateQueriesNames = {
            "updateDriver",
            "updateEntry",
            "updateTruck"
        };
        string[] updateQueriesStrings =
        {
                "UPDATE [dbo].[Driver] " +
                "SET dni_driver = '{0}', tlf_client = '{1}', email_driver = '{2}' " +
                "WHERE {3}='{4}'",

                "UPDATE [dbo].[Entry] " +
                "SET date_entry = '{0}', id_truck = '{1}', id_driver = '{2}', photo_entry = '{3}', weight_entry = '{4}' " +
                "WHERE {5}='{6}'",

                "UPDATE [dbo].[Truck] " +
                "SET license_truck = '{0}', photo_truck = '{1}', weight_truck = '{2}', description_truck = '{3}' " +
                "WHERE {4}='{5}'"
        };

        private string[] removeQueriesNames = {
            "removeAuthorized"
        };
        string[] removeQueriesStrings =
{
                "DELETE FROM [dbo].[Authorized] " +
                "WHERE {0}='{1}'",
        };

        Dictionary<string, string> selectCommands = new Dictionary<string, string>();
        Dictionary<string, string> addCommands = new Dictionary<string, string>();
        Dictionary<string, string> updateCommands = new Dictionary<string, string>();
        Dictionary<string, string> removeCommands = new Dictionary<string, string>();

        public DatabaseInteractionMethods()
        {
            _InitializeDatabaseCommands();
        }




        private void _InitializeDatabaseCommands()
        {
            _ChargeQueries(this.selectQueriesNames, this.selectQueriesStrings, this.selectCommands);
            _ChargeQueries(this.addQueriesNames, this.addQueriesStrings, this.addCommands);
            _ChargeQueries(this.updateQueriesNames, this.updateQueriesStrings, this.updateCommands);
            _ChargeQueries(this.removeQueriesNames, this.removeQueriesStrings, this.removeCommands);

        }

        private SqlCommand _CreateCommand(string command, SqlConnection conn)
        {
            SqlCommand sqlCommand = new SqlCommand(command, conn);

            return sqlCommand;
        }

        private int _TryConnectOpen(SqlConnection connection)
        {
            int codError;

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                codError = 1;
            }
            catch
            {
                codError = -1;
            }

            return codError;
        }

        private long _TryQuery(SqlCommand command)
        {
            long id;

            if (_TryConnectOpen(command.Connection) == 1)
            {
                try
                {
                    id = Convert.ToInt64(command.ExecuteScalar());

                    command.Connection.Close();
                }
                catch
                {
                    id = -1;
                }
            }
            else
            {
                id = -1;
            }

            return id;
        }

        public SqlDataReader TrySelectQuery(SqlCommand command)
        {
            SqlDataReader dataReader;

            try
            {
                if (command.Connection.State != ConnectionState.Open)
                {
                    command.Connection.Open();
                }

                dataReader = command.ExecuteReader();
            }
            catch
            {
                dataReader = null;
            }

            return dataReader;
        }

        private string[] _ComposeQueries(string[] nameQueries, string[] stringQueries)
        {
            string[] result = new string[nameQueries.Length];
            for (int i = 0; i < nameQueries.Length; i++)
            {
                result[i] = nameQueries[i] + "|" + stringQueries[i];
            }

            return result;
        }

        private void _ChargeQueries(string[] nameQueries, string[] stringQueries, Dictionary<string, string> dictioCommands)
        {
            string[] composedQueries = _ComposeQueries(nameQueries, stringQueries);

            if (dictioCommands.Count != 0)
            {
                dictioCommands.Clear();
            }

            foreach (string composedQuery in composedQueries)
            {
                string[] half = composedQuery.Split('|');
                dictioCommands.Add(half[0], half[1]);
            }
        }

        private string _ConvertArrFieldNamesArrayToString(string[] fields)
        {
            string recoveredFields = "";

            for (int i = 0; i < fields.Length; i++)
            {

                if ((i + 1) == fields.Length)
                {
                    recoveredFields += fields[i];
                }
                else
                {
                    recoveredFields += fields[i] + ", ";
                }
            }

            return recoveredFields;
        }


        public long AddAuthorizedToDatabase(long idTruck)
        {
            string command = String.Format(this.addCommands[this.addQueriesNames[0]], idTruck);

            SqlCommand sqlCommand = _CreateCommand(command, this.conn);

            long id = _TryQuery(sqlCommand);

            return id;
        }

        public long AddDriverToDatabase(string dni, long tlf, string email)
        {
            string command = String.Format(this.addCommands[this.addQueriesNames[1]], dni, tlf, email);

            SqlCommand sqlCommand = _CreateCommand(command, this.conn);

            long id = _TryQuery(sqlCommand);


            return id;
        }

        public long AddEntryToDatabase(DateTime dateTime, string idTruck, string idDriver, string photoPath, string weight)
        {
            string command = this.addCommands[this.addQueriesNames[2].ToString()];

            command = String.Format(command, dateTime, idTruck, idDriver, photoPath, weight);

            SqlCommand sqlCommand = _CreateCommand(command, this.conn);

            long id = _TryQuery(sqlCommand);

            return id;
        }

        public long AddTruckToDatabase(string licensePlate, string photoPath, string weight, string description)
        {
            string command = this.addCommands[this.addQueriesNames[3].ToString()];



            command = String.Format(command, licensePlate, photoPath, weight, description);


            SqlCommand sqlCommand = _CreateCommand(command, this.conn);

            long id = _TryQuery(sqlCommand);

            return id;
        }

        public bool UpdateAuthorizedAtDatabase(string idxTruck, bool isAuthorized)
        {
            bool isAtDatabase = true;
            SqlDataReader dataReader = null;
            SqlCommand command = new SqlCommand();

            dataReader = SelectAuthorizedFromDatabase("id_truck", idxTruck, ref command, ("*"));

            if (isAuthorized)
            {
                if (!dataReader.HasRows)
                {
                    dataReader.Close();
                    command.Connection.Close();
                    AddAuthorizedToDatabase(Convert.ToInt64(idxTruck));
                }
            }
            else
            {
                if (dataReader.HasRows)
                {
                    dataReader.Close();
                    command.Connection.Close();
                    RemoveAuthorizedFromDatabase("id_truck", idxTruck);
                    isAtDatabase = false;
                }
            }

            return isAtDatabase;
        }

        public long UpdateDriverAtDatabase(string dni, string tlf, string email, string fieldCondition, string valueCondition)
        {
            string command = String.Format(this.updateCommands[this.updateQueriesNames[0]], dni, tlf, email, fieldCondition, valueCondition);

            SqlCommand sqlCommand = _CreateCommand(command, this.conn);

            long id = _TryQuery(sqlCommand);

            return id;
        }

        public long UpdateEntryAtDatabase(DateTime date, string idTruck, string idDriver, string photoPath, string weight, string fieldCondition, string valueCondition)
        {

            string command = String.Format(this.updateCommands[this.updateQueriesNames[1]], date, idTruck, idDriver, photoPath, weight, fieldCondition, valueCondition);

            SqlCommand sqlCommand = _CreateCommand(command, this.conn);

            long id = _TryQuery(sqlCommand);

            return id;
        }

        public long UpdateTruckAtDatabase(string licensePlate, string photoPath, string weight, string description, string fieldCondition, string valueCondition)
        {


            string command = String.Format(this.updateCommands[this.updateQueriesNames[2]], licensePlate, photoPath, weight, description, fieldCondition, valueCondition);

            SqlCommand sqlCommand = _CreateCommand(command, this.conn);

            long id = _TryQuery(sqlCommand);

            return id;
        }

        public long RemoveAuthorizedFromDatabase(string fieldCondition, string valueCondition)
        {
            string command = String.Format(this.removeCommands[this.removeQueriesNames[0]], fieldCondition, valueCondition);

            SqlCommand sqlCommand = _CreateCommand(command, this.conn);

            long id = _TryQuery(sqlCommand);

            return id;
        }

        //public SqlDataReader SelectLanguagesFromDatabase(string fieldCondition, string valueCondition, ref SqlCommand sqlCommand, params string[] fields)
        //{
        //    string recoveredFields = "";
        //    string command = "";
        //    SqlDataReader dataReader;

        //    recoveredFields = _ConvertArrFieldNamesArrayToString(fields);

        //    if (fieldCondition == "" || valueCondition == "")
        //    {
        //        command = String.Format(this.selectCommands[this.selectQueriesNames[2]], recoveredFields);
        //    }
        //    else
        //    {
        //        command = String.Format(this.selectCommands[this.selectQueriesNames[2]], recoveredFields);
        //        command += String.Format(" WHERE {0} = '{1}'", AaronBarreiraD, valueCondition);
        //    }

        //    sqlCommand = _CreateCommand(command, this.conn);

        //    dataReader = _TrySelectQuery(sqlCommand);

        //    return dataReader;
        //}

        public SqlDataReader SelectAuthorizedFromDatabase(string fieldCondition, string valueCondition, ref SqlCommand sqlCommand, params string[] fields)
        {
            string recoveredFields = "";
            string command = "";
            SqlDataReader dataReader;

            recoveredFields = _ConvertArrFieldNamesArrayToString(fields);

            if (fieldCondition == "" || valueCondition == "")
            {
                command = String.Format(this.selectCommands[this.selectQueriesNames[0]], recoveredFields);
            }
            else
            {
                command = String.Format(this.selectCommands[this.selectQueriesNames[0]], recoveredFields);
                command += String.Format(" WHERE {0} = '{1}'", fieldCondition, valueCondition);
            }

            sqlCommand = _CreateCommand(command, this.conn);

            dataReader = TrySelectQuery(sqlCommand);

            return dataReader;
        }

        public SqlDataReader SelectEntriesFromDatabase(string fieldCondition, string valueCondition, ref SqlCommand sqlCommand, string orderCondition = "d", bool isAscendant = false, params string[] fields)
        {
            string recoveredFields = "";
            string command = "";
            SqlDataReader dataReader;

            recoveredFields = _ConvertArrFieldNamesArrayToString(fields);

            if (fieldCondition == "" || valueCondition == "")
            {
                command = String.Format(this.selectCommands[this.selectQueriesNames[1]], recoveredFields);
            }
            else
            {
                command = String.Format(this.selectCommands[this.selectQueriesNames[1]], recoveredFields);
                command += String.Format(" WHERE {0} LIKE '%{1}%'", fieldCondition, valueCondition);
            }

            if (orderCondition != "d")
            {
                if (isAscendant)
                {
                    command += String.Format(" ORDER BY {0} {1}", orderCondition, "ASC");

                }
                else
                {
                    command += String.Format(" ORDER BY {0} {1}", orderCondition, "DESC");
                }
            }


            sqlCommand = _CreateCommand(command, this.conn);

            if (sqlCommand.Connection.State == ConnectionState.Open)
            {
                sqlCommand.Connection.Close();
            }

            dataReader = TrySelectQuery(sqlCommand);

            return dataReader;
        }

        public SqlDataReader SelectLanguageFromDatabase(string fieldCondition, string valueCondition, ref SqlCommand sqlCommand, bool isStrictSearch = false, params string[] fields)
        {
            string recoveredFields = "";
            string command = "";
            SqlDataReader dataReader;


            recoveredFields = _ConvertArrFieldNamesArrayToString(fields);

            if (fieldCondition == "" || valueCondition == "")
            {
                command = String.Format(this.selectCommands[this.selectQueriesNames[2]], recoveredFields);
            }
            else
            {
                if (isStrictSearch)
                {
                    command = String.Format(this.selectCommands[this.selectQueriesNames[2]], recoveredFields);
                    command += String.Format(" WHERE {0} = '{1}'", fieldCondition, valueCondition);
                }
                else
                {
                    command = String.Format(this.selectCommands[this.selectQueriesNames[2]], recoveredFields);
                    command += String.Format(" WHERE {0} LIKE '{1}'", fieldCondition, valueCondition);
                }

            }

            sqlCommand = _CreateCommand(command, this.conn);

            dataReader = TrySelectQuery(sqlCommand);

            return dataReader;
        }

        public SqlDataReader SelectTruckFromDatabase(string fieldCondition, string valueCondition, ref SqlCommand sqlCommand, params string[] fields)
        {
            string recoveredFields = "";
            string command = "";
            SqlDataReader dataReader;


            recoveredFields = _ConvertArrFieldNamesArrayToString(fields);

            if (fieldCondition == "" || valueCondition == "")
            {
                command = String.Format(this.selectCommands[this.selectQueriesNames[3]], recoveredFields);
            }
            else
            {
                command = String.Format(this.selectCommands[this.selectQueriesNames[3]], recoveredFields);
                command += String.Format(" WHERE {0} = '{1}'", fieldCondition, valueCondition);
            }

            sqlCommand = _CreateCommand(command, this.conn);

            dataReader = TrySelectQuery(sqlCommand);

            return dataReader;
        }

        public SqlDataReader SelectDriverFromDatabase(string fieldCondition, string valueCondition, ref SqlCommand sqlCommand, params string[] fields)
        {
            string recoveredFields = "";
            string command = "";
            SqlDataReader dataReader;


            recoveredFields = _ConvertArrFieldNamesArrayToString(fields);

            if (fieldCondition == "" || valueCondition == "")
            {
                command = String.Format(this.selectCommands[this.selectQueriesNames[4]], recoveredFields);
            }
            else
            {
                command = String.Format(this.selectCommands[this.selectQueriesNames[4]], recoveredFields);
                command += String.Format(" WHERE {0} = '{1}'", fieldCondition, valueCondition);
            }

            sqlCommand = _CreateCommand(command, this.conn);

            if (sqlCommand.Connection.State == ConnectionState.Open)
            {
                sqlCommand.Connection.Close();
            }

            dataReader = TrySelectQuery(sqlCommand);

            return dataReader;
        }

        public SqlDataReader SelectFieldsFromTable(string tableName, ref SqlCommand sqlCommand)
        {
            string command = "";
            SqlDataReader dataReader;

            switch (tableName)
            {
                case "Entry":
                    command = "SELECT COLUMN_NAME FROM information_schema.columns " +
                        "WHERE table_name = 'Entry' " +
                        "UNION " +
                        "SELECT COLUMN_NAME FROM information_schema.columns " +
                        "WHERE table_name = 'Driver' " +
                        "UNION " +
                        "SELECT COLUMN_NAME FROM information_schema.columns " +
                        "WHERE table_name = 'Truck'";
                    break;
                case "Authorized":
                    command = "SELECT COLUMN_NAME FROM information_schema.columns " +
                        "WHERE table_name = 'Truck'";
                    break;
                default:
                    command = String.Format(this.selectCommands[this.selectQueriesNames[5]], tableName);
                    break;

            }
            sqlCommand = _CreateCommand(command, this.conn);

            dataReader = TrySelectQuery(sqlCommand);

            return dataReader;
        }

        public SqlCommand ConstructInnerJoinCommand(string mainTable, string fieldCondition, string valueCondition, string[,] secondTablesAndOnFields, params string[] fields)
        {
            string fieldStr = _ConvertArrFieldNamesArrayToString(fields);
            string commandStr = String.Format("SELECT {0} FROM {1}", fieldStr, mainTable);
            SqlCommand sqlCommand;

            int arrLen = secondTablesAndOnFields.GetLength(0);
            for (int i = 0; i < arrLen; i++)
            {
                //commandStr += String.Format(" INNER JOIN {0} USING ({1})", secondTablesAndOnFields[i, 0], secondTablesAndOnFields[i, 1]);

                commandStr += String.Format(" INNER JOIN {0} ON {0}.{1} = {2}.{1}", secondTablesAndOnFields[i, 0], secondTablesAndOnFields[i, 1], mainTable);
            }

            if (fieldCondition != "" && valueCondition != "")
            {
                commandStr += String.Format(" WHERE {0}='{1}'", fieldCondition, valueCondition);
            }
            sqlCommand = new SqlCommand(commandStr, this.conn);
            return sqlCommand;

        }
    }
}
