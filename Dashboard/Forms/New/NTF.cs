using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dashboard;
using AppBehaviour;

namespace Dashboard.Forms.New
{
    public partial class NTF : Form
    {
        private Bitmap truckPhoto;
        string defaultInputErrorFormatCaption = "Format not valid";
        string defaultInputErrorFormatMessage = "The selected file is not in a valid format";
        string defaultNewEntryErrorCaption = "Entry error";
        string defaultNewEntryErrorMessage = "The new truck entry has invalid data";
        string defaultEntryConfirmationCaption = "Confirmed";
        string defaultEntryConfirmationMessage = "Registry saved";
        Dictionary<string, string[,]> languageAffectedElements;

        bool isEditForm;
        long editIdx;
        string filePath;
        bool isImageChanged = false;

        OpenFileDialog uploadImageOFD = new OpenFileDialog();
        FormIntroducedDataSupervisionMethods supervisionMethods = new FormIntroducedDataSupervisionMethods();
        FormsDBInteractionMethods interactionMethods = new FormsDBInteractionMethods();
        FormDBInteractionAuxMethods auxMethods = new FormDBInteractionAuxMethods();

        FormsDBInteractionMethods.Languages selectedLanguage;

        public NTF(bool isAnEditForm, FormsDBInteractionMethods.Languages chosenLanguage, long idx = -1)
        {
            isEditForm = isAnEditForm;
            editIdx = idx;
            selectedLanguage = chosenLanguage;


            InitializeComponent();
        }

        private void NTF_B_UploadImage_Click(object sender, EventArgs e)
        {
            if(uploadImageOFD.ShowDialog() == DialogResult.OK)
            {
                if (supervisionMethods.IsValidImage(uploadImageOFD.FileName))
                {
                    if(uploadImageOFD.FileName != filePath)
                    {
                        filePath = uploadImageOFD.FileName;
                        this.truckPhoto = FormsBehaviour.UploadImageToForm(uploadImageOFD.FileName);
                        FormsBehaviour.DisplayImageAtPictureBox(NTF_PB_VehiclePhoto, this.truckPhoto);
                        isImageChanged = true;
                    }

                } else {
                    FormsBehaviour.ConfigureMessageBoxPopUp(defaultInputErrorFormatCaption, defaultInputErrorFormatMessage, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void NTF_Load(object sender, EventArgs e)
        {

            FormsBehaviour.ConfigureOpenFileDialog(uploadImageOFD, "NTF");

            if(isEditForm)
            {
                
                interactionMethods.ChargeDataToTruckEditForm(editIdx, ref NTF_CheckB_Authorized, ref NTF_TB_LicensePlate, ref NTF_TB_Weight, ref NTF_TB_Description, ref truckPhoto, ref filePath);
                FormsBehaviour.DisplayImageAtPictureBox(NTF_PB_VehiclePhoto, this.truckPhoto);


            }

            languageAffectedElements = interactionMethods.RecoverAffectedLanguageElements(FormsDBInteractionMethods.Forms.NTF, selectedLanguage);
            interactionMethods.ChangeFormLanguage(this, languageAffectedElements, FormsDBInteractionMethods.Forms.NTF);
            defaultEntryConfirmationCaption = languageAffectedElements["NTF_MBCaption_Confirmed"][0, 1];
            defaultEntryConfirmationMessage = languageAffectedElements["NTF_MBMessage_Confirmed"][0, 1];
            defaultNewEntryErrorCaption = languageAffectedElements["NTF_MBCaption_EntryError"][0, 1];
            defaultNewEntryErrorMessage = languageAffectedElements["NTF_MBMessage_EntryError"][0, 1];
        }

        private void NTF_B_Save_Click(object sender, EventArgs e)
        {
            if(!isEditForm)
            {
                long truckId = interactionMethods.AddTruckFromForm(NTF_TB_LicensePlate, NTF_PB_VehiclePhoto, truckPhoto, filePath, NTF_TB_Weight, NTF_TB_Description);

                if (truckId < 0)
                {
                    FormsBehaviour.ConfigureMessageBoxPopUp(defaultNewEntryErrorMessage, defaultNewEntryErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    interactionMethods.AddAuthorizedTruck(truckId, NTF_CheckB_Authorized);
                    MessageBox.Show(defaultEntryConfirmationMessage, defaultEntryConfirmationCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            } else
            {
                //Bitmap imageCopy = auxMethods.GenerateNotLockedCopyImage(photoPath);
                int codError = interactionMethods.UpdateTruckEntry(editIdx, NTF_TB_LicensePlate, NTF_PB_VehiclePhoto, truckPhoto, filePath, NTF_TB_Weight, NTF_TB_Description, isImageChanged);
    
                if (codError < 0)
                {
                    FormsBehaviour.ConfigureMessageBoxPopUp(defaultNewEntryErrorMessage, defaultNewEntryErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    codError = 0;
                }
                else
                {
                    interactionMethods.UpdateAuthorized(editIdx, NTF_CheckB_Authorized);
                    MessageBox.Show(defaultEntryConfirmationMessage, defaultEntryConfirmationCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
            }

            
        }

        private void NTF_B_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            sender = DialogResult.Cancel;
        }

        private void NTF_PB_VehiclePhoto_Click(object sender, EventArgs e)
        {

        }

        private void NTF_L_VehiclePhoto_Click(object sender, EventArgs e)
        {

        }

        private void NTF_TB_Weight_TextChanged(object sender, EventArgs e)
        {

        }

        private void NTF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                NTF_B_Save_Click(sender, e);
            }
        }
    }
}
