using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppBehaviour;


namespace Dashboard.Forms.New
{
    public partial class NEF : Form
    {
        private Bitmap entryPhoto;
        string defaultInputErrorFormatCaption = "Format not valid";
        string defaultInputErrorFormatMessage = "The selected file is not in a valid format";
        string defaultNewEntryErrorCaption = "Entry error";
        string defaultNewEntryErrorMessage = "The new entry has invalid data";
        string defaultDateTimeCustomFormat = "dd/MM/yyyy hh:mm:ss";
        string defaultEntryConfirmationCaption = "Confirmed";
        string defaultEntryConfirmationMessage = "Registry saved";


        Dictionary<string, string[,]> languageAffectedElements;
        string photoPath = "";
        bool isImageChanged = false;
        bool isEditForm;
        long editIdx;



        OpenFileDialog uploadImageOFD = new OpenFileDialog();
        FormIntroducedDataSupervisionMethods supervisionMethods = new FormIntroducedDataSupervisionMethods();
        FormsDBInteractionMethods interactionMethods = new FormsDBInteractionMethods();
        FormDBInteractionAuxMethods auxMethods = new FormDBInteractionAuxMethods();
        FormsDBInteractionMethods.Languages selectedLanguage;



        public NEF(bool isAnEditForm, FormsDBInteractionMethods.Languages chosenLanguage, long idx = -1)
        {
            isEditForm = isAnEditForm;
            editIdx = idx;
            selectedLanguage = chosenLanguage;


            InitializeComponent();
        }

        private void NEF_Load(object sender, EventArgs e)
        {


            FormsBehaviour.ConfigureOpenFileDialog(uploadImageOFD, "NEF");

            NEF_DTP_Date.Format = DateTimePickerFormat.Custom;
            NEF_DTP_Date.CustomFormat = defaultDateTimeCustomFormat;


            if (isEditForm)
            {
                interactionMethods.ChargeDataToEntryEditForm(editIdx, selectedLanguage, ref NEF_DTP_Date, ref NEF_ComboB_DriverDNI, ref NEF_ComboB_TruckPlate, ref NEF_TB_Weight, ref entryPhoto, ref photoPath);
                FormsBehaviour.DisplayImageAtPictureBox(NEF_PB_EntryPhoto, this.entryPhoto);

            }
            else
            {
                auxMethods.LoadDataToCombobox(NEF_ComboB_DriverDNI, FormDBInteractionAuxMethods.Table.Driver, "", "", -1, ("dni_driver"));
                auxMethods.LoadDataToCombobox(NEF_ComboB_TruckPlate, FormDBInteractionAuxMethods.Table.Truck,  "", "", -1, ("license_truck"));
            }

            languageAffectedElements = interactionMethods.RecoverAffectedLanguageElements(FormsDBInteractionMethods.Forms.NEF, selectedLanguage);
            interactionMethods.ChangeFormLanguage(this, languageAffectedElements, FormsDBInteractionMethods.Forms.NEF);
            defaultEntryConfirmationCaption = languageAffectedElements["NEF_MBCaption_Confirmed"][0, 1];
            defaultEntryConfirmationMessage = languageAffectedElements["NEF_MBMessage_Confirmed"][0, 1];
            defaultNewEntryErrorCaption = languageAffectedElements["NEF_MBCaption_EntryError"][0, 1];
            defaultNewEntryErrorMessage = languageAffectedElements["NEF_MBMessage_EntryError"][0, 1];

        }

        private void NEF_B_UploadImage_Click(object sender, EventArgs e)
        {
            if (uploadImageOFD.ShowDialog() == DialogResult.OK)
            {
                if (supervisionMethods.IsValidImage(uploadImageOFD.FileName))
                {
                    if(uploadImageOFD.FileName != photoPath)
                    {
                        photoPath = uploadImageOFD.FileName;
                        isImageChanged = true;
                        this.entryPhoto = FormsBehaviour.UploadImageToForm(uploadImageOFD.FileName);
                        FormsBehaviour.DisplayImageAtPictureBox(NEF_PB_EntryPhoto, this.entryPhoto);
                    }

                }
                else
                {
                    FormsBehaviour.ConfigureMessageBoxPopUp(defaultInputErrorFormatCaption, defaultInputErrorFormatMessage, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void NTF_B_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            sender = DialogResult.Cancel;
        }

        private void NEF_B_Save_Click(object sender, EventArgs e)
        {
            if (!isEditForm)
            {
                long entryId = interactionMethods.AddEntryFromForm(NEF_DTP_Date, NEF_ComboB_DriverDNI, NEF_ComboB_TruckPlate, NEF_PB_EntryPhoto, photoPath, entryPhoto, NEF_TB_Weight);

                if (entryId < 0)
                {
                    FormsBehaviour.ConfigureMessageBoxPopUp(defaultNewEntryErrorMessage, defaultNewEntryErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(defaultEntryConfirmationMessage, defaultEntryConfirmationCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                //Bitmap imageCopy = auxMethods.GenerateNotLockedCopyImage(photoPath);
                int codError = interactionMethods.UpdateEntry(editIdx, NEF_DTP_Date, NEF_ComboB_DriverDNI, NEF_ComboB_TruckPlate, NEF_PB_EntryPhoto, photoPath, entryPhoto, NEF_TB_Weight, isImageChanged);

                if (codError < 0)
                {
                    FormsBehaviour.ConfigureMessageBoxPopUp(defaultNewEntryErrorMessage, defaultNewEntryErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    codError = 0;
                }
                else
                {
                    MessageBox.Show(defaultEntryConfirmationMessage, defaultEntryConfirmationCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void NEF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                NEF_B_Save_Click(sender, e);
            }
        }
    }
}
