﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DatabaseBehaviour;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace AppBehaviour
{
    
    public class FormsDBInteractionMethods
    {
        public enum Languages
        {
            Error = 0,
            English = 1,
            Spanish = 2
        }

        public enum Forms
        {
            MMF = 0,
            ESF = 1,
            NDF = 2,
            NEF = 3,
            NTF = 4
        }

        public DatabaseInteractionMethods interactionMethods;
        private FormDBInteractionAuxMethods auxMethods;
        private FormIntroducedDataSupervisionMethods supervisionMethods;
        

        public FormsDBInteractionMethods ()
        {
            this.interactionMethods = new DatabaseInteractionMethods();
            this.auxMethods = new FormDBInteractionAuxMethods();
            this.supervisionMethods = new FormIntroducedDataSupervisionMethods();
        }

        public long AddTruckFromForm(TextBox licensePlateTB, PictureBox truckPhotoPB, Bitmap truckPhotoBM, string photoSourcePath, TextBox weightTB, TextBox descriptionTB)
        {
            int errorDetector = 0;
            bool isInvalidEntry = false;
            string licensePlate = "";
            string description = null;
            string photoPath = "";
            decimal weight = 0;
            long idNewEntry = -1;

            errorDetector = auxMethods.ConvertTextboxTextToLicensePlateString(licensePlateTB, false, false, ref licensePlate);
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref licensePlateTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            } else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref licensePlateTB, true);
                errorDetector = 0;
            }

            errorDetector = auxMethods.ConvertTextboxTextToDecimal(weightTB, false, ref weight);
            if (errorDetector <= 0) {
                auxMethods.ChangeTextboxColorByInputValue(ref weightTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            } else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref weightTB, true);
                errorDetector = 0;
            }

            errorDetector = auxMethods.ConvertTextboxTextToString(descriptionTB, true, true, ref description);
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref descriptionTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            } else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref descriptionTB, true);
                errorDetector = 0;
            }

            if (supervisionMethods.IsEmptyImage((Image)truckPhotoBM) == true)
            {
                auxMethods.ChangePictureboxColorByInputValue(ref truckPhotoPB, false);
                isInvalidEntry = true;
            } else
            {
                auxMethods.ChangePictureboxColorByInputValue(ref truckPhotoPB, true);
            }



            if (!isInvalidEntry)
            {
                idNewEntry = interactionMethods.AddTruckToDatabase(licensePlate, "ERROR", auxMethods.ConvertDecimalToString(weight), description);

                if(idNewEntry > 0)
                {
                    truckPhotoBM.Dispose();
                    truckPhotoBM = null;

                    auxMethods.SaveImageIntoDirectory(idNewEntry, FormDBInteractionAuxMethods.ImageType.Truck, false, ref photoPath, photoSourcePath);


                    interactionMethods.UpdateTruckAtDatabase(licensePlate, photoPath, auxMethods.ConvertDecimalToString(weight), description, "id_truck", idNewEntry.ToString());
                } 
                
            }

            return idNewEntry;
        }

        public void AddAuthorizedTruck(long truckId, CheckBox isAuthorizedCB)
        {
            if(isAuthorizedCB.Checked)
            {
                this.interactionMethods.AddAuthorizedToDatabase(truckId);
            }            
        }

        public long AddEntryFromForm(DateTimePicker dateTimePicker, ComboBox driverID, ComboBox truckId, PictureBox entryPhotoPB, string photoSourcePath, Bitmap entryPhotoBM, TextBox weightTB)
        {
            int errorDetector = 0;
            long idNewEntry = 0;
            bool isInvalidEntry = false;
            string driverIdStr = "";
            string truckIdStr = "";
            string photoPath = "";
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader;
            decimal weight = 0;


            if(driverID.SelectedItem == null || supervisionMethods.IsEmptyString(driverID.SelectedItem.ToString()))
            {
                isInvalidEntry = true;
                auxMethods.ChangeComboboxColorByInputValue(ref driverID, false);
            } else
            {
                dataReader = interactionMethods.SelectDriverFromDatabase("dni_driver", driverID.SelectedItem.ToString(), ref sqlCommand, "id_driver");

                while(dataReader.Read())
                {
                    driverIdStr = dataReader[0].ToString();
                }

                dataReader.Close();
                sqlCommand.Connection.Close();
                auxMethods.ChangeComboboxColorByInputValue(ref driverID, true);
            }

            if(truckId.SelectedItem == null || supervisionMethods.IsEmptyString(truckId.SelectedItem.ToString()))
            {
                isInvalidEntry = true;
                auxMethods.ChangeComboboxColorByInputValue(ref truckId, false);
            }
            else
            {
                dataReader = interactionMethods.SelectTruckFromDatabase("license_truck", truckId.SelectedItem.ToString(), ref sqlCommand, "id_truck");

                while (dataReader.Read())
                {
                    truckIdStr = dataReader[0].ToString();
                }
                dataReader.Close();
                sqlCommand.Connection.Close();
                auxMethods.ChangeComboboxColorByInputValue(ref truckId, true);
            }


            errorDetector = auxMethods.ConvertTextboxTextToDecimal(weightTB, false, ref weight);
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref weightTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            }
            else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref weightTB, true);
                errorDetector = 0;
            }      

            if (supervisionMethods.IsEmptyImage((Image)entryPhotoBM) == true)
            {
                auxMethods.ChangePictureboxColorByInputValue(ref entryPhotoPB, false);
                isInvalidEntry = true;
            }
            else
            {
                auxMethods.ChangePictureboxColorByInputValue(ref entryPhotoPB, true);
            }

            if (!isInvalidEntry)
            {
                
                idNewEntry = interactionMethods.AddEntryToDatabase(dateTimePicker.Value, truckIdStr, driverIdStr, "ERROR", auxMethods.ConvertDecimalToString(weight));

                if (idNewEntry > 0)
                {
                    auxMethods.SaveImageIntoDirectory(idNewEntry, FormDBInteractionAuxMethods.ImageType.Entry, false, ref photoPath, photoSourcePath);
                    interactionMethods.UpdateEntryAtDatabase(dateTimePicker.Value, truckIdStr, driverIdStr, photoPath, auxMethods.ConvertDecimalToString(weight), "id_entry", idNewEntry.ToString());
                }

            } else
            {
                idNewEntry = -1;
            }

            return idNewEntry;
        }

        public long AddDriverFromForm(TextBox dniTB, TextBox tlfTB, TextBox emailTB)
        {
            int errorDetector = 0;
            bool isInvalidEntry = false;
            string dni = null;
            long tlf = -1;
            string email = null;
            long idNewEntry = -1;

            errorDetector = auxMethods.ConvertTextboxTextToString(dniTB, false, false, ref dni);
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref dniTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            }
            else
            {
                if (!supervisionMethods.IsValidDNI(dni))
                {
                    auxMethods.ChangeTextboxColorByInputValue(ref dniTB, false);
                    isInvalidEntry = true;
                } else
                {
                    auxMethods.ChangeTextboxColorByInputValue(ref dniTB, true);
                }

                errorDetector = 0;
            }

            errorDetector = auxMethods.ConvertTextboxTextToLong(tlfTB, true, ref tlf);
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref tlfTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            }
            else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref tlfTB, true);
                errorDetector = 0;
            }




            errorDetector = auxMethods.ConvertTextboxTextToEmailString(emailTB, false, true, ref email);
            if(!supervisionMethods.IsEmptyString(email) && !supervisionMethods.IsValidEmail(email))
            {
                errorDetector = -1;
            }
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref emailTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            }
            else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref emailTB, true);
                errorDetector = 0;
            }


            if (!isInvalidEntry)
            {
                idNewEntry = interactionMethods.AddDriverToDatabase(dni, tlf, email);

            }

            return idNewEntry;
        }

        public void ChargeDataToTruckEditForm(long truckId, ref CheckBox authorized, ref TextBox license, ref TextBox weight, ref TextBox description, ref Bitmap image, ref string path)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReaderTruck = null;
            SqlDataReader sqlDataReaderAuthorized = null;
            sqlDataReaderTruck = interactionMethods.SelectTruckFromDatabase("id_truck", auxMethods.ConvertDecimalToString(truckId), ref sqlCommand, ("*"));

            while(sqlDataReaderTruck.Read())
            {
                license.Text = sqlDataReaderTruck[1].ToString();
                path = sqlDataReaderTruck[2].ToString();
                image = auxMethods.GenerateNotLockedCopyImage(path);
                weight.Text = sqlDataReaderTruck[3].ToString();
                description.Text = sqlDataReaderTruck[4].ToString();
            }

            sqlDataReaderTruck.Close();
            sqlCommand.Connection.Close();


            sqlDataReaderAuthorized = interactionMethods.SelectAuthorizedFromDatabase("id_truck", auxMethods.ConvertDecimalToString(truckId), ref sqlCommand, ("*"));

            if(sqlDataReaderAuthorized.HasRows)
            {
                sqlDataReaderAuthorized.Close();
                authorized.Checked = true;
            } else
            {
                authorized.Checked = false;
            }


            sqlCommand.Connection.Close();
        }

        public void ChargeDataToEntryEditForm(long entryId, Languages language, ref DateTimePicker dateTime, ref ComboBox driver, ref ComboBox license, ref TextBox weight, ref Bitmap image, ref string filePath)
        {
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader sqlDataReader = null;
            sqlDataReader = interactionMethods.SelectEntriesFromDatabase("id_entry", auxMethods.ConvertDecimalToString(entryId), ref sqlCommand, "d", false, ("*"));
            long selectedIdx;

            while (sqlDataReader.Read())
            {
                
                auxMethods.LoadDataToCombobox(driver, FormDBInteractionAuxMethods.Table.Driver,  "", "", Convert.ToInt64(sqlDataReader[3].ToString()), new string[] { "id_driver", "dni_driver"});
                auxMethods.LoadDataToCombobox(license, FormDBInteractionAuxMethods.Table.TruckEdit, "", "", Convert.ToInt64(sqlDataReader[2].ToString()), new string[] { "id_truck", "license_truck" });
                
                dateTime.Value = DateTime.Parse(sqlDataReader[1].ToString());
                weight.Text = sqlDataReader[5].ToString();
                filePath = sqlDataReader[4].ToString();
                image = auxMethods.GenerateNotLockedCopyImage(filePath);
            }

            sqlDataReader.Close();
            sqlCommand.Connection.Close();
        }

        public int UpdateTruckEntry(long index, TextBox licensePlateTB, PictureBox truckPhotoPB, Bitmap truckPhotoBM, string imagePath, TextBox weightTB, TextBox descriptionTB, bool isImageChanged = false)
        {
            int errorDetector = 0;
            bool isInvalidEntry = false;
            string licensePlate = "";
            string description = null;
            string photoPath = "";
            decimal weight = 0;
            int codError = -1;

            errorDetector = auxMethods.ConvertTextboxTextToLicensePlateString(licensePlateTB, false, false, ref licensePlate);
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref licensePlateTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            }
            else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref licensePlateTB, true);
                errorDetector = 0;
            }

            errorDetector = auxMethods.ConvertTextboxTextToDecimal(weightTB, false, ref weight);
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref weightTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            }
            else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref weightTB, true);
                errorDetector = 0;
            }

            errorDetector = auxMethods.ConvertTextboxTextToString(descriptionTB, true, true, ref description);
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref descriptionTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            }
            else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref descriptionTB, true);
                errorDetector = 0;
            }

            if (supervisionMethods.IsEmptyImage((Image)truckPhotoBM) == true)
            {
                auxMethods.ChangePictureboxColorByInputValue(ref truckPhotoPB, false);
                isInvalidEntry = true;
            }
            else
            {
                auxMethods.ChangePictureboxColorByInputValue(ref truckPhotoPB, true);
            }



            if (!isInvalidEntry)
            {
                codError = 1;
                truckPhotoPB.Image.Dispose();
                truckPhotoPB.Image = null;

                if (isImageChanged)
                {
                    auxMethods.OverwriteImageAtDirectory(index, FormDBInteractionAuxMethods.ImageType.Truck, false, ref photoPath, imagePath);
                    interactionMethods.UpdateTruckAtDatabase(licensePlate, photoPath, auxMethods.ConvertDecimalToString(weight), description, "id_truck", index.ToString());

                } else
                {
                    interactionMethods.UpdateTruckAtDatabase(licensePlate, imagePath, auxMethods.ConvertDecimalToString(weight), description, "id_truck", index.ToString());

                }
            } 

            return codError;
        }

        public void UpdateAuthorized(long idxTruck, CheckBox isAuthorizedCB)
        {
            this.interactionMethods.UpdateAuthorizedAtDatabase(auxMethods.ConvertDecimalToString(idxTruck), isAuthorizedCB.Checked);
        }

        public int UpdateEntry(long index, DateTimePicker dateTime, ComboBox driverID, ComboBox truckId, PictureBox entryPhotoPB, string photoSourcePath, Bitmap entryPhotoBM, TextBox weightTB, bool isImageChanged = false)
        {
            int errorDetector = 0;
            int codError = 0;
            bool isInvalidEntry = false;
            string driverIdStr = "";
            string truckIdStr = "";
            string photoPath = photoSourcePath;
            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader dataReader = null;
            decimal weight = 0;


            if (driverID.SelectedItem == null || supervisionMethods.IsEmptyString(driverID.SelectedItem.ToString()))
            {
                isInvalidEntry = true;
                auxMethods.ChangeComboboxColorByInputValue(ref driverID, false);
            }
            else
            {
                dataReader = interactionMethods.SelectDriverFromDatabase("dni_driver", driverID.SelectedItem.ToString(), ref sqlCommand, "id_driver");

                while (dataReader.Read())
                {
                    driverIdStr = dataReader[0].ToString();
                }

                dataReader.Close();
                sqlCommand.Connection.Close();
                auxMethods.ChangeComboboxColorByInputValue(ref driverID, true);
            }

            if (truckId.SelectedItem == null || supervisionMethods.IsEmptyString(truckId.SelectedItem.ToString()))
            {
                isInvalidEntry = true;
                auxMethods.ChangeComboboxColorByInputValue(ref truckId, false);
            }
            else
            {
                dataReader = interactionMethods.SelectTruckFromDatabase("license_truck", truckId.SelectedItem.ToString(), ref sqlCommand, "id_truck");

                while (dataReader.Read())
                {
                    truckIdStr = dataReader[0].ToString();
                }
                dataReader.Close();
                sqlCommand.Connection.Close();
                auxMethods.ChangeComboboxColorByInputValue(ref truckId, true);
            }


            errorDetector = auxMethods.ConvertTextboxTextToDecimal(weightTB, false, ref weight);
            if (errorDetector <= 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref weightTB, false);
                isInvalidEntry = true;
                errorDetector = 0;
            }
            else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref weightTB, true);
                errorDetector = 0;
            }

            if (supervisionMethods.IsEmptyImage((Image)entryPhotoBM) == true)
            {
                auxMethods.ChangePictureboxColorByInputValue(ref entryPhotoPB, false);
                isInvalidEntry = true;
            }
            else
            {
                auxMethods.ChangePictureboxColorByInputValue(ref entryPhotoPB, true);
            }

            if (!isInvalidEntry)
            {
                codError = 1;
                entryPhotoPB.Image.Dispose();
                entryPhotoPB.Image = null;

                if (isImageChanged)
                {
                    auxMethods.OverwriteImageAtDirectory(index, FormDBInteractionAuxMethods.ImageType.Entry, false, ref photoPath, photoSourcePath);
                    interactionMethods.UpdateEntryAtDatabase(dateTime.Value, truckIdStr, driverIdStr, photoPath, auxMethods.ConvertDecimalToString(weight), "id_entry", index.ToString());
                }
                else
                {
                    interactionMethods.UpdateEntryAtDatabase(dateTime.Value, truckIdStr, driverIdStr, photoPath, auxMethods.ConvertDecimalToString(weight), "id_entry", index.ToString());

                }
            }
            else
            {
                codError = -1;
            }

            return codError;
        }

        public long SearchAtDatabase(FormDBInteractionAuxMethods.Table searchedTable, ComboBox fieldCondition, TextBox valueCondition, ref long[] multipleResults, ref DataTable resultTable, params string[] fields)
        {
            int errorDetector = 0;
            bool isValidSearch = true;
            long idx = -1;
            string fieldConditionStr = "";
            string valueConditionStr = "";
            SqlDataReader dataReader = null;

            if(fieldCondition.SelectedItem == null ||supervisionMethods.IsEmptyString(fieldCondition.SelectedItem.ToString())) {
                errorDetector = -1;
                isValidSearch = false;
            } else
            {
                if(!supervisionMethods.IsValidString(fieldCondition.SelectedItem.ToString(), true))
                {
                    errorDetector = -1;
                    isValidSearch = false;

                }
            }
            if(errorDetector < 0)
            {
                auxMethods.ChangeComboboxColorByInputValue(ref fieldCondition, false);
                errorDetector = 0;
            } else
            {
                auxMethods.ChangeComboboxColorByInputValue(ref fieldCondition, true);
                fieldConditionStr = fieldCondition.SelectedItem.ToString();
            }


            if (valueCondition.Text == null || supervisionMethods.IsEmptyString(valueCondition.Text)) {
                errorDetector = -1;
                isValidSearch = false;

            }
            else
            {
                if (!supervisionMethods.IsValidString(valueCondition.Text, true))
                {
                    errorDetector = -1;
                    isValidSearch = false;

                }
            }
            if (errorDetector < 0)
            {
                auxMethods.ChangeTextboxColorByInputValue(ref valueCondition, false);
                errorDetector = 0;
            } else
            {
                auxMethods.ChangeTextboxColorByInputValue(ref valueCondition, true);
                valueConditionStr = valueCondition.Text.ToUpper();
                errorDetector = 0;
            }

            if(isValidSearch)
            {
                SqlCommand sqlCommand = new SqlCommand();
                switch(searchedTable)
                {
                    case FormDBInteractionAuxMethods.Table.EntryFields:

                        //dataReader = interactionMethods.SelectEntriesFromDatabase(fieldConditionStr, valueConditionStr, ref sqlCommand, "d", false, "*");

                        string[,] tablesAndOnFields = new string[,]
                        {
                            {"Truck", "id_truck"},
                            {"Driver", "id_driver"}
                        };

                        switch(fieldConditionStr)
                        {
                            case "id_entry":
                            case "date_entry":
                            case "weight_entry":
                                fieldConditionStr = "Entry." + fieldConditionStr;
                            break;
                            case "license_truck":
                            case "weight_truck":
                            case "description_truck":
                                fieldConditionStr = "Truck." + fieldConditionStr;
                                break;
                            case "dni_driver":
                            case "tlf_driver":
                            case "email_driver":
                                fieldConditionStr = "Driver." + fieldConditionStr;
                                break;

                        }
                
                        sqlCommand = interactionMethods.ConstructInnerJoinCommand("Entry", fieldConditionStr, valueConditionStr, tablesAndOnFields, new string[] { "id_entry", "date_entry", "weight_entry", "license_truck", "weight_truck", "description_truck", "dni_driver", "tlf_driver", "email_driver" });
                        dataReader = interactionMethods.TrySelectQuery(sqlCommand);
                        break;
                    case FormDBInteractionAuxMethods.Table.TruckFields:
                        dataReader = interactionMethods.SelectTruckFromDatabase(fieldConditionStr, valueConditionStr, ref sqlCommand, ("id_truck"));

                        break;
                    default:
                        break;
                }

                if(dataReader != null && dataReader.HasRows)
                {
                    dataReader.Close();
                    sqlCommand.Connection.Close();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable();
                    dataAdapter.Fill(dt);
                    int searchInt; 

                    switch(searchedTable)
                    {
                        case FormDBInteractionAuxMethods.Table.TruckFields:
                            searchInt = dt.Rows.Count - 1;
                            idx = Convert.ToInt64(dt.Rows[searchInt][dt.Columns[0]].ToString());
                            break;
                        case FormDBInteractionAuxMethods.Table.EntryFields:
                            multipleResults = new long[dt.Rows.Count];

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                multipleResults[i] = Convert.ToInt64(dt.Rows[i][dt.Columns[0]].ToString());
                            }

                            resultTable = auxMethods.GenerateDataTable(dt, FormDBInteractionAuxMethods.Table.Entry);
                            searchInt = dt.Rows.Count - 1;
                            idx = Convert.ToInt64(dt.Rows[searchInt][dt.Columns[0]].ToString());
                            break;
                    }



                }
            }


            return idx;


        }

        public bool DisplayDataAtTable(ref DataGridView dataTable, FormDBInteractionAuxMethods.Table searchedTable, string fieldCondition, string valueCondition, params string[] fields)
        {
            bool allCorrect = false;
            SqlDataReader dataReader = null;
            SqlDataAdapter dataAdapter;
            DataSet ds = new DataSet();
            string fieldConditionStr = "";

            SqlCommand sqlCommand = new SqlCommand();
            string[,] tablesAndOnFields;

            switch (searchedTable)
            {
                case FormDBInteractionAuxMethods.Table.Entry:
                    dataReader = interactionMethods.SelectEntriesFromDatabase(fieldCondition, valueCondition, ref sqlCommand, "d", false, fields);

                    tablesAndOnFields = new string[,]
                    {
                        {"Truck", "id_truck"},
                        {"Driver", "id_driver"}
                    };

                    fieldConditionStr = String.Format("Entry.{0}", fieldCondition);
                    sqlCommand = interactionMethods.ConstructInnerJoinCommand("Entry", fieldConditionStr, valueCondition, tablesAndOnFields, new string[] {"Entry.id_entry", "Entry.date_entry", "Entry.weight_entry", "Truck.license_truck", "Truck.weight_truck", "Truck.description_truck", "Driver.dni_driver", "Driver.tlf_driver", "Driver.email_driver" });


                    break;

                case FormDBInteractionAuxMethods.Table.Authorized:
                    dataReader = interactionMethods.SelectAuthorizedFromDatabase(fieldCondition, valueCondition, ref sqlCommand, "*");

                    tablesAndOnFields = new string[,]
                    {
                        {"Truck", "id_truck"},
                    };
                    fieldConditionStr = String.Format("Authorized.{0}", fieldCondition);
                    sqlCommand = interactionMethods.ConstructInnerJoinCommand("Authorized", fieldConditionStr, valueCondition, tablesAndOnFields, new string[] {"Truck.license_truck", "Truck.weight_truck", "Truck.description_truck" });
                    break;

                case FormDBInteractionAuxMethods.Table.Coal:
                    dataReader = interactionMethods.SelectEntriesFromDatabase(fieldCondition, valueCondition, ref sqlCommand, "date_entry", false, fields);

                    break;
                default:
                    break;
            }
            

            if (dataReader != null)
            {
                dataReader.Close();
                dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable originalTable = new DataTable();
                DataTable adaptedTable = new DataTable();
                dataAdapter.Fill(originalTable);
                sqlCommand.Connection.Close();

                switch(searchedTable)
                {
                    case FormDBInteractionAuxMethods.Table.Coal:
                        adaptedTable = auxMethods.GenerateDataTable(originalTable, FormDBInteractionAuxMethods.Table.Coal);

                        dataTable.DataSource = adaptedTable;
                        allCorrect = true;

                        break;
                    case FormDBInteractionAuxMethods.Table.Entry:
                        adaptedTable = auxMethods.GenerateDataTable(originalTable, FormDBInteractionAuxMethods.Table.Entry);

                        dataTable.DataSource = adaptedTable;
                        allCorrect = true;
                        break;
                    case FormDBInteractionAuxMethods.Table.Authorized:
                        adaptedTable = auxMethods.GenerateDataTable(originalTable, FormDBInteractionAuxMethods.Table.Authorized);

                        dataTable.DataSource = adaptedTable;
                        allCorrect = true;
                        break;
                    default:
                        dataTable.DataSource = originalTable;
                        allCorrect = true;
                        break;
                }

            }

                return allCorrect;
        }

        public Dictionary<string, string[,]> RecoverAffectedLanguageElements(Forms form, Languages language)
        {
            string languageStr = "";
            string formStr = "";
            SqlCommand command = new SqlCommand();
            Dictionary<string, string[,]> resultDict = new Dictionary<string, string[,]>();
            SqlDataReader dataReader = null;

            switch (language) {
                case Languages.English:
                    languageStr = "English";
                    break;
                case Languages.Spanish:
                    languageStr = "Spanish";
                    break;
                default:
                    break;
            }

            switch (form)
            {
                case Forms.MMF:
                    formStr = "MMF";
                    break;
                case Forms.ESF:
                    formStr = "ESF";
                    break;
                case Forms.NDF:
                    formStr = "NDF";
                    break;
                case Forms.NEF:
                    formStr = "NEF";
                    break;
                case Forms.NTF:
                    formStr = "NTF";
                    break;
                default:
                    break;
            }


            dataReader = interactionMethods.SelectLanguageFromDatabase("name_language", formStr + "%", ref command, false, new string[] {"name_language", "type_language", languageStr});

            if(dataReader != null)
            {
                while (dataReader.Read())
                {
                    string[,] value = new string[1, 2] {{dataReader[1].ToString(), dataReader[2].ToString()}};
                    resultDict.Add(dataReader[0].ToString(), value);
                }
            }

            dataReader.Close();
            command.Connection.Close();

            return resultDict;
        }

        public void ChangeFormLanguage(Control mainControl, Dictionary<string, string[,]> dict, Forms form)
        {
            Control.ControlCollection controls = mainControl.Controls;

            foreach (Control control in controls)
            {
                foreach(KeyValuePair<string, string[,]> entry in dict)
                {
                    if (mainControl.Name == entry.Key)
                    {
                        mainControl.Text = entry.Value[0, 1];
                    }

                    if(control is MenuStrip menu)
                    {
                        foreach (ToolStripMenuItem item in menu.Items)
                        {
                            if(item.HasDropDownItems)
                            {
                                foreach (ToolStripMenuItem innerItem in item.DropDownItems)
                                {
                                    if (innerItem.HasDropDownItems)
                                    {
                                        foreach (ToolStripMenuItem innestItem in innerItem.DropDownItems)
                                        {
                                            string innestItemName = innestItem.Name;
                                            if (innestItemName == entry.Key)
                                            {
                                                innestItem.Text = entry.Value[0, 1];
                                            }
                                        }
                                    }

                                    string innerItemName = innerItem.Name;
                                    if (innerItemName == entry.Key)
                                    {
                                        innerItem.Text = entry.Value[0, 1];
                                    }
                                }
                            }


                            string controlName = item.Name;

                            if (controlName == entry.Key)
                            {
                                item.Text = entry.Value[0, 1];
                            }
                        }
                    }

                    if(control is TextBox textBox)
                    {
                        string controlName = textBox.Name;

                        if (controlName == entry.Key)
                        {
                            textBox.Text = entry.Value[0, 1];
                        }
                    }

                    if (control is Label label)
                    {
                        string controlName = label.Name;

                        if (controlName == entry.Key)
                        {
                            label.Text = entry.Value[0, 1];
                        }
                    }

                    if (control is Button btn)
                    {
                        string controlName = btn.Name;

                        if (controlName == entry.Key)
                        {
                            btn.Text = entry.Value[0, 1];
                        }
                    }

                    if (control is Form)
                    {

                        if (control.Name == entry.Key)
                        {
                            control.Text = entry.Value[0, 1];
                        }
                    }

                }
            }



        }

        public string GetTextAtDesiredLanguage(string nameId, Languages chosenLanguage)
        {
            string result = "";
            SqlCommand command = new SqlCommand();
            SqlDataReader dataReader = null;
            string language = "";

            switch (chosenLanguage) {
                case Languages.English:
                    language = "English";
                    break;
                case Languages.Spanish:
                    language = "Spanish";
                    break;
                default:
                    break;             

            }


            dataReader = interactionMethods.SelectLanguageFromDatabase("name_language", nameId, ref command, true, new string[] { language } );

            if(dataReader != null)
            {
                while(dataReader.Read())
                {
                    result = dataReader[0].ToString();
                }
            }

            dataReader.Close();
            command.Connection.Close();

            return result;
        }
    }
}