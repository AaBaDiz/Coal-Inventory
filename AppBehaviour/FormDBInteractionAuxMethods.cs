using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Windows;
using System.Drawing;
using System.Globalization;
using DatabaseBehaviour;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace AppBehaviour
{
    public class FormDBInteractionAuxMethods
    {
        public enum ImageType
        {
            Entry = 0,
            Truck = 1
        }

        public enum Table
        {
            Authorized = 0,
            Driver = 1,
            Entry = 2,
            Language = 3,
            Truck = 4,
            AuthorizedFields = 5,
            DriverFields = 6,
            EntryFields = 7,
            LanguageFields = 8,
            TruckFields = 9,
            Coal = 10,
            EntriesResult = 11,
            TruckEdit = 12
        }

        public enum Rounding
        {
            Truncate = 0,
            RoundUp = 1,
            RoundDown = 2
        }

        private FormIntroducedDataSupervisionMethods supervisionMethods = new FormIntroducedDataSupervisionMethods();
        private DatabaseInteractionMethods interactionMethods = new DatabaseInteractionMethods();


        public int ConvertTextboxTextToLong(TextBox txtBox, bool canBeEmpty, ref long resultVariable)
        {
            int result = 0;
            string text = txtBox.Text;

            if (canBeEmpty && supervisionMethods.IsEmptyString(text))
            {
                result = 1;
            }
            else
            {
                if (!canBeEmpty && supervisionMethods.IsEmptyString(text))
                {
                    result = -1;
                }

                if (result >= 0)
                {
                    try
                    {
                        if (supervisionMethods.IsValidLong(Convert.ToInt64(text)))
                        {
                            resultVariable = Convert.ToInt64(text);
                            result = 1;

                        }
                        else
                        {
                            result = -1;
                        }

                    }
                    catch
                    {
                        result = -1;
                    }
                }
            }

            return result;
        }

        public int ConvertTextboxTextToDecimal(TextBox txtBox, bool canBeEmpty, ref decimal resultVariable)
        {
            int result = 0;
            string text = txtBox.Text;

            if (!canBeEmpty && supervisionMethods.IsEmptyString(text))
            {
                result = -1;
            }

            if (result >= 0)
            {
                try
                {
                    if (supervisionMethods.IsCorrectlyWrittenNumber(text) && supervisionMethods.IsValidDecimal(Convert.ToDecimal(text)))
                    {



                        resultVariable = Decimal.Parse(text);
                        result = 1;

                    }
                    else
                    {
                        result = -1;
                    }

                }
                catch
                {
                    result = -1;
                }
            }

            return result;
        }

        public int ConvertTextboxTextToString(TextBox txtBox, bool isMaxLenghtAllowed, bool canBeEmpty, ref string resultVariable)
        {
            int result = 0;

            if (canBeEmpty && supervisionMethods.IsEmptyString(txtBox.Text))
            {
                result = 1;
                resultVariable = null;
            }
            else
            {
                if (!canBeEmpty && supervisionMethods.IsEmptyString(txtBox.Text))
                {
                    result = -1;
                }

                if (result >= 0)
                {
                    if (supervisionMethods.IsValidString(txtBox.Text, isMaxLenghtAllowed))
                    {
                        resultVariable = txtBox.Text;
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                    }
                }
            }


            return result;
        }

        public int ConvertTextboxTextToLicensePlateString(TextBox txtBox, bool isMaxLenghtAllowed, bool canBeEmpty, ref string resultVariable)
        {
            {
                int result = 0;

                if (canBeEmpty && supervisionMethods.IsEmptyString(txtBox.Text))
                {
                    result = 1;
                    resultVariable = null;
                }
                else
                {
                    if (!canBeEmpty && supervisionMethods.IsEmptyString(txtBox.Text))
                    {
                        result = -1;
                    }

                    if (result >= 0)
                    {
                        if (supervisionMethods.IsValidEuropeanLicenseString(txtBox.Text))
                        {
                            resultVariable = txtBox.Text;
                            result = 1;
                        }
                        else
                        {
                            result = -1;
                        }
                    }
                }


                return result;
            }
        }

        public int ConvertTextboxTextToEmailString(TextBox txtBox, bool isMaxLenghtAllowed, bool canBeEmpty, ref string resultVariable)
        {
            int result = 0;

            if (canBeEmpty && supervisionMethods.IsEmptyString(txtBox.Text))
            {
                result = 1;
                resultVariable = null;
            }
            else
            {
                if (!canBeEmpty && supervisionMethods.IsEmptyString(txtBox.Text))
                {
                    result = -1;
                }

                if (result >= 0)
                {
                    if (supervisionMethods.IsValidEmail(txtBox.Text))
                    {
                        resultVariable = txtBox.Text;
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                    }
                }
            }


            return result;
        }

        public string ConvertDecimalToString(decimal value)
        {
            NumberFormatInfo formatInfo = new NumberFormatInfo();
            formatInfo.NumberDecimalSeparator = ".";
            string weightString = value.ToString(formatInfo);
            return weightString;
        }

        public int SaveImageIntoDirectory(long imageId, ImageType type, bool canBeEmpty, ref string path, string sourceImagePath)
        {
            int result = 0;

            Bitmap bitmap = new Bitmap(sourceImagePath);

            if (bitmap == null && !canBeEmpty)
            {
                result = -1;
            }
            else
            {
                if (bitmap == null && canBeEmpty)
                {
                    path = "";
                    result = 1;
                }
                else
                {
                    path = _SaveImageAux(ref bitmap, type, imageId); 
                    result = 1;
                }
            }



            return result;
        }

        public void ChangeTextboxColorByInputValue(ref TextBox textBox, bool isValidInputData)
        {
            if (isValidInputData)
            {
                textBox.BackColor = Color.LightGreen;
            }
            else
            {
                textBox.BackColor = Color.LightCoral;
            }
        }

        public void ChangePictureboxColorByInputValue(ref PictureBox pictureBox, bool isValidImage)
        {
            if (isValidImage)
            {
                pictureBox.BackColor = Color.LightGreen;
            }
            else
            {
                pictureBox.BackColor = Color.LightCoral;
            }
        }

        public void ChangeComboboxColorByInputValue(ref ComboBox comboBox, bool isValidInputData)
        {
            if (isValidInputData)
            {
                comboBox.BackColor = Color.LightGreen;
            }
            else
            {
                comboBox.BackColor = Color.LightCoral;
            }
        }
        //Check if directory exists and create one if not. True when is created, false if already existed
        private void _CheckAndCreateDirectory(string filePath)
        {

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

        }

        private string _SaveImageAux(ref Bitmap bitmap, ImageType type, long imageId)
        {
            Image image = (Image)bitmap;
            string appFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Carboneria Inventario\\";
            string filePath = "";
            string fileExtension = "";

            switch (type)
            {
                case ImageType.Entry:
                    filePath = appFilePath + "Entries\\";
                    fileExtension = new ImageFormatConverter().ConvertToString(image.RawFormat);

                    if(!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    filePath = filePath + "E" + imageId.ToString() + "." + fileExtension;

                    supervisionMethods.TrySaveImage(filePath, bitmap);


                    break;
                case ImageType.Truck:
                    filePath = appFilePath + "Trucks\\";
;
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    fileExtension = new ImageFormatConverter().ConvertToString(image.RawFormat);
                    filePath = filePath + "T" + imageId.ToString() + "." + fileExtension;

                    supervisionMethods.TrySaveImage(filePath, bitmap);
                    break;
                default:
                    break;
            }

            return filePath;
        }

        public int LoadDataToCombobox(ComboBox comboBx, Table tableName, string fieldCondition, string valueCondition, long idSelectedItem = -1, params string[] fields)
        {
            SqlDataReader dataReader = null;
            SqlCommand sqlCommand = new SqlCommand();
            int codeError = 0;

            switch (tableName)
            {
                case Table.Authorized:
                    dataReader = interactionMethods.SelectAuthorizedFromDatabase(fieldCondition, valueCondition, ref sqlCommand, fields);
                    break;
                case Table.Driver:
                    dataReader = interactionMethods.SelectDriverFromDatabase(fieldCondition, valueCondition, ref sqlCommand, fields);
                    break;
                case Table.Entry:
                    dataReader = interactionMethods.SelectEntriesFromDatabase(fieldCondition, valueCondition, ref sqlCommand, "d", false, fields);
                    break;
                case Table.Language:
                    dataReader = interactionMethods.SelectLanguageFromDatabase(fieldCondition, valueCondition, ref sqlCommand, false, fields);
                    break;
                case Table.Truck:
                    string[,] tablesAndOnFields = new string[,] {
                            {"Truck", "id_truck"}
                    };

                    sqlCommand = interactionMethods.ConstructInnerJoinCommand("Authorized", fieldCondition, valueCondition, tablesAndOnFields, fields);

                    dataReader = interactionMethods.TrySelectQuery(sqlCommand);

                    break;
                case Table.EntryFields:
                    dataReader = interactionMethods.SelectFieldsFromTable("Entry", ref sqlCommand);
                    break;
                case Table.TruckFields:
                    dataReader = interactionMethods.SelectFieldsFromTable("Truck", ref sqlCommand);
                    break;
                case Table.LanguageFields:
                    dataReader = interactionMethods.SelectFieldsFromTable("Language", ref sqlCommand);
                    break;
                case Table.TruckEdit:
                    dataReader = interactionMethods.SelectTruckFromDatabase(fieldCondition, valueCondition, ref sqlCommand, fields);
                    break;
                default:
                    codeError = -1;
                    break;
            }

            if (dataReader == null)
            {
                codeError = -1;
                sqlCommand.Connection.Close();
            }
            else
            {
                if (tableName == Table.EntryFields || tableName == Table.TruckFields || tableName == Table.LanguageFields)
                {

                    while (dataReader.Read())
                    {
                        string value = dataReader[0].ToString();

                        switch (value)
                        {                            
                            case "license_truck":
                            case "dni_driver":
                            case "id_entry":
                            case "English":
                            case "Spanish":
                                if (comboBx.FindString(value) < 0)
                                {
                                    comboBx.Items.Add(value);
                                }

                                break;
                            default:
                                break;
                        }

                    }

                    if (idSelectedItem > -1)
                    {
                        comboBx.SelectedIndex = Convert.ToInt32(idSelectedItem);
                    }

                    dataReader.Close();
                    sqlCommand.Connection.Close();

                }
                else
                {
                    while (dataReader.Read())
                    {

                        string itemValue = "";

                        if (idSelectedItem > 0)
                        {
                            string currentId = dataReader[fields[0]].ToString();
                            itemValue = dataReader[fields[1]].ToString();

                            if (currentId == idSelectedItem.ToString())
                            {
                                comboBx.Items.Add(itemValue);
                                comboBx.SelectedItem = itemValue;

                            }
                            else
                            {
                                comboBx.Items.Add(itemValue);

                            }

                        }
                        else
                        {
                            foreach (string field in fields)
                            {
                                itemValue += dataReader[field];
                            }

                            comboBx.Items.Add(itemValue);
                        }

                    }

                    codeError = 1;

                    dataReader.Close();
                    sqlCommand.Connection.Close();
                }


            }

            return codeError;
        }

        public string[,] CreateByHourInterval(int firstHour, int lastHour, int minutesInterval)
        {
            DateTime currentDate = DateTime.MinValue;

            string[,] resultArr = null;

            if (minutesInterval == 0)
            {
                return resultArr;
            }
            else
            {
                currentDate = currentDate.AddHours(firstHour);
                currentDate = currentDate.AddMinutes(0);

                resultArr = new string[((lastHour / (minutesInterval / 60)) + (lastHour % (minutesInterval / 60))), 2];
                if (lastHour == 24)
                {
                    lastHour = 23;
                }

                for (int i = 0; i < resultArr.GetLength(0); i++)
                {


                    resultArr[i, 0] = currentDate.ToString("HH:mm");
                    if (currentDate.Hour == lastHour)
                    {
                        currentDate = currentDate.AddMinutes(minutesInterval - 1);
                        resultArr[i, 1] = currentDate.ToString("HH:mm");
                    }
                    else
                    {

                        currentDate = currentDate.AddMinutes(minutesInterval - 1);
                        resultArr[i, 1] = currentDate.ToString("HH:mm");
                        currentDate = currentDate.AddMinutes(1);

                    }

                }

                return resultArr;
            }
        }

        public int SearchHourInHourInterval(string[,] hourIntervalsArr, string desiredHour)
        {
            int result = -1;
            DateTime searchedHour = DateTime.Parse(desiredHour);
            searchedHour = DateTime.Parse(searchedHour.ToString("HH:mm"));

            for (int i = 0; i < hourIntervalsArr.GetLength(0); i++)
            {
                DateTime initHour = DateTime.Parse(hourIntervalsArr[i, 0]);
                initHour = DateTime.Parse(initHour.ToString("HH:mm"));
                DateTime lastHour = DateTime.Parse(hourIntervalsArr[i, 1]);
                lastHour = DateTime.Parse(lastHour.ToString("HH:mm"));


                if (TimeSpan.Compare(initHour.TimeOfDay, searchedHour.TimeOfDay) <= 0 && TimeSpan.Compare(lastHour.TimeOfDay, searchedHour.TimeOfDay) >= 0)
                {
                    result = i;
                }
            }

            return result;
        }

        public void InitiateColumn(DataTable table, string nameColumn, string defaultValue, int numRows = 0)
        {
            if (numRows > 0)
            {
                for (int i = 0; i < numRows; i++)
                {
                    DataRow newRow = table.NewRow();
                    newRow[nameColumn] = defaultValue;

                    table.Rows.Add(newRow);
                }
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {
                    row[nameColumn] = defaultValue;
                }
            }

        }

        public DataTable GenerateDataTable(DataTable originalTable, Table dataTableType)
        {
            DataTable adaptedTable = new DataTable();

            switch (dataTableType)
            {
                case Table.Coal:
                    DateTime currentColDate = new DateTime();
                    DateTime currentDate = new DateTime();

                    string[,] hoursInterval = CreateByHourInterval(0, 24, 60);

                    DataColumn hourColumn = new DataColumn();
                    hourColumn.ColumnName = "Hours";
                    adaptedTable.Columns.Add(hourColumn);

                    for (int i = 0; i < hoursInterval.GetLength(0); i++)
                    {
                        DataRow dataRow = adaptedTable.NewRow();

                        dataRow["Hours"] = String.Format("{0} - {1}", hoursInterval[i, 0], hoursInterval[i, 1]);

                        adaptedTable.Rows.Add(dataRow);
                    }

                    for (int i = 0; i < originalTable.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            currentDate = DateTime.Parse(originalTable.Rows[i]["date_entry"].ToString());
                            currentColDate = currentDate;

                            DataColumn newColumn = new DataColumn();
                            newColumn.ColumnName = currentDate.ToString("dd/MM/yyyy");
                            adaptedTable.Columns.Add(newColumn);
                            InitiateColumn(adaptedTable, newColumn.ColumnName, "0");


                            decimal currentWeight = Convert.ToDecimal(originalTable.Rows[i]["weight_entry"]);
                            int rowIdx = SearchHourInHourInterval(hoursInterval, currentDate.ToString("HH:mm"));

                            decimal newWeight = Convert.ToDecimal(adaptedTable.Rows[rowIdx][newColumn.ColumnName].ToString()) + currentWeight;
                            adaptedTable.Rows[rowIdx][newColumn.ColumnName] = newWeight;

                        }
                        else
                        {
                            currentDate = DateTime.Parse(originalTable.Rows[i]["date_entry"].ToString());

                            if (currentColDate.Date == currentDate.Date)
                            {
                                decimal currentWeight = Convert.ToDecimal(originalTable.Rows[i]["weight_entry"]);
                                int rowIdx = SearchHourInHourInterval(hoursInterval, currentDate.ToString("HH:mm"));
                                decimal newWeight = Convert.ToDecimal(adaptedTable.Rows[rowIdx][currentDate.Date.ToString("dd/MM/yyyy")].ToString()) + currentWeight;
                                adaptedTable.Rows[rowIdx][currentDate.Date.ToString("dd/MM/yyyy")] = newWeight;
                            }
                            else
                            {
                                DataColumn newColumn = new DataColumn();
                                newColumn.ColumnName = currentDate.ToString("dd/MM/yyyy");

                                if (!adaptedTable.Columns.Contains(newColumn.ColumnName))
                                {
                                    adaptedTable.Columns.Add(newColumn);
                                    InitiateColumn(adaptedTable, newColumn.ColumnName, "0", 0);
                                }


                                decimal currentWeight = Convert.ToDecimal(originalTable.Rows[i]["weight_entry"]);
                                int rowIdx = SearchHourInHourInterval(hoursInterval, currentDate.ToString("HH:mm"));
                                string alreadySavedWeight = adaptedTable.Rows[rowIdx][currentDate.Date.ToString("dd/MM/yyyy")].ToString();
                                decimal newWeight = Convert.ToDecimal(alreadySavedWeight);
                                newWeight += currentWeight;
                                adaptedTable.Rows[rowIdx][currentDate.Date.ToString("dd/MM/yyyy")] = newWeight;
                            }

                        }
                    }
                    break;

                case Table.Authorized:

                    foreach (DataColumn column in originalTable.Columns)
                    {
                        switch (column.ColumnName)
                        {
                            case "weight_truck":
                                adaptedTable.Columns.Add(column.ColumnName, typeof(string));
                                break;
                            default:
                                DataColumn newColumn = new DataColumn(column.ColumnName, column.DataType);
                                adaptedTable.Columns.Add(newColumn);
                                break;
                        }
                    }

                    for (int i = 0; i < originalTable.Rows.Count; i++)
                    {
                        DataRow newDataRow = adaptedTable.NewRow();

                        foreach (DataColumn column in adaptedTable.Columns)
                        {
                            switch (column.ColumnName)
                            {
                                case "weight_truck":
                                    Decimal weight = Convert.ToDecimal(originalTable.Rows[i]["weight_truck"]);
                                    string roundingUsed = ConvertDecimalForTable(ref weight, 3, Rounding.Truncate);
                                    string newWeight = String.Format("({0}) {1}", roundingUsed, weight);
                                    newDataRow["weight_truck"] = newWeight;
                                    break;
                                default:
                                    var value = originalTable.Rows[i][column.ColumnName];
                                    newDataRow[column.ColumnName] = value;
                                    break;
                            }
                        }

                        adaptedTable.Rows.Add(newDataRow);
                    }

                    break;
                case Table.Entry:
                    //adaptedTable = originalTable.Copy();

                    foreach (DataColumn column in originalTable.Columns)
                    {
                        switch (column.ColumnName)
                        {
                            case "weight_entry":
                            case "weight_truck":
                                adaptedTable.Columns.Add(column.ColumnName, typeof(string));
                                break;
                            default:
                                DataColumn newColumn = new DataColumn(column.ColumnName, column.DataType);
                                adaptedTable.Columns.Add(newColumn);
                                break;
                        }
                    }

                    for (int i = 0; i < originalTable.Rows.Count; i++)
                    {
                        DataRow newDataRow = adaptedTable.NewRow();

                        foreach (DataColumn column in adaptedTable.Columns)
                        {
                            switch (column.ColumnName)
                            {
                                case "weight_entry":
                                    Decimal weight = Convert.ToDecimal(originalTable.Rows[i]["weight_entry"]);
                                    string roundingUsed = ConvertDecimalForTable(ref weight, 3, Rounding.Truncate);
                                    string newWeight = String.Format("({0}) {1}", roundingUsed, weight);
                                    newDataRow["weight_entry"] = newWeight;
                                    break;
                                case "weight_truck":
                                    weight = Convert.ToDecimal(originalTable.Rows[i]["weight_truck"]);
                                    roundingUsed = ConvertDecimalForTable(ref weight, 3, Rounding.Truncate);
                                    newWeight = String.Format("({0}) {1}", roundingUsed, weight);
                                    newDataRow["weight_truck"] = newWeight;
                                    break;
                                default:
                                    var value = originalTable.Rows[i][column.ColumnName];
                                    newDataRow[column.ColumnName] = value;
                                    break;
                            }
                        }

                        adaptedTable.Rows.Add(newDataRow);
                    }

                    break;

                case Table.EntriesResult:


                    break;
                default:
                    break;
            }

            return adaptedTable;
        }

        public string ConvertDecimalForTable(ref Decimal weight, int numDecimals, Rounding roundingMethod)
        {
            string roundMethodStr = "";
            switch (roundingMethod)
            {
                case Rounding.RoundDown:
                    roundMethodStr = "Round down";
                    weight = Math.Floor(weight);
                    break;
                case Rounding.RoundUp:
                    roundMethodStr = "Round up";
                    weight = Math.Ceiling(weight);
                    break;
                case Rounding.Truncate:
                    roundMethodStr = "Truncate";
                    weight = Decimal.Round(weight, numDecimals);
                    break;
                default:
                    break;
            }

            return roundMethodStr;
        }

        public Bitmap GenerateNotLockedCopyImage(string filePath)
        {
            Byte[] bytes = File.ReadAllBytes(filePath);
            Bitmap resultImage;
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                resultImage = new Bitmap(stream);
                stream.Close();
            }

            return resultImage;
        }

        public int OverwriteImageAtDirectory(long imageId, ImageType type, bool canBeEmpty, ref string destinyPath, string sourceImagePath)
        {
            int result = 0;

            Bitmap bitmap = GenerateNotLockedCopyImage(sourceImagePath);

            if (bitmap == null && !canBeEmpty)
            {
                result = -1;
            }
            else
            {
                if (bitmap == null && canBeEmpty)
                {
                    destinyPath = "";
                    result = 1;
                }
                else
                {
                    bitmap.Dispose();
                    bitmap = null;

                    destinyPath = _OverWriteImageAux(type, imageId, sourceImagePath);
                    result = 1;
                }
            }


            return result;
        }

        public string _OverWriteImageAux(ImageType type, long imageId, string sourceImagePath)
        {

            string appFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Carboneria Inventario\\";
            string filePath = "";
            string fileExtension = "";
            Bitmap bitmap = new Bitmap(sourceImagePath);
            Image image = (Image)bitmap;
            switch (type)
            {
                case ImageType.Entry:

                    filePath = appFilePath + "Entries\\";

                    fileExtension = new ImageFormatConverter().ConvertToString(image.RawFormat);

                    filePath = filePath + "E" + imageId.ToString() + "." + fileExtension;

                    if (File.Exists(filePath))
                    {
                        //Image existingImage = Image.FromFile(filePath);
                        //existingImage.Dispose();
                        File.Delete(filePath);

                    }

                    supervisionMethods.TrySaveImage(filePath, bitmap); 


                    break;
                case ImageType.Truck:
                    filePath = appFilePath + "Trucks\\";
                    fileExtension = new ImageFormatConverter().ConvertToString(image.RawFormat);
                    filePath = filePath + "T" + imageId.ToString() + "." + fileExtension;

                    if (File.Exists(filePath))
                    {
                        //var fileStream = new FileStream(filePath, FileMode.Open);
                        File.Delete(filePath);

                    }
                    supervisionMethods.TrySaveImage(filePath, bitmap);
                    break;
                default:
                    break;
            }

            return filePath;
        }
    }
}