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
    public partial class NDF : Form
    {

        string defaultNewEntryErrorCaption = "Entry error";
        string defaultNewEntryErrorMessage = "The new entry has invalid data";
        string defaultEntryConfirmationCaption = "Confirmed";
        string defaultEntryConfirmationMessage = "Registry saved";
        Dictionary<string, string[,]> languageAffectedElements;

        FormIntroducedDataSupervisionMethods supervisionMethods = new FormIntroducedDataSupervisionMethods();
        FormsDBInteractionMethods interactionMethods = new FormsDBInteractionMethods();
        FormDBInteractionAuxMethods auxMethods = new FormDBInteractionAuxMethods();
        FormsDBInteractionMethods.Languages selectedLanguage;


        public NDF(FormsDBInteractionMethods.Languages chosenLanguage)
        {


            selectedLanguage = chosenLanguage;
           

            InitializeComponent();
            selectedLanguage = chosenLanguage;
        }

        private void NDF_Load(object sender, EventArgs e)
        {

            languageAffectedElements = interactionMethods.RecoverAffectedLanguageElements(FormsDBInteractionMethods.Forms.NDF, selectedLanguage);
            defaultNewEntryErrorCaption = languageAffectedElements["NDF_MBCaption_EntryError"][0, 1];
            defaultNewEntryErrorMessage = languageAffectedElements["NDF_MBMessage_EntryError"][0, 1];
            defaultEntryConfirmationCaption = languageAffectedElements["NDF_MBCaption_Confirmed"][0,1];
            defaultEntryConfirmationMessage = languageAffectedElements["NDF_MBMessage_Confirmed"][0,1];
        }

        private void NDF_B_Save_Click(object sender, EventArgs e)
        {
            long entryId = interactionMethods.AddDriverFromForm(NDF_TB_DriverDNI, NDF_TB_DriverTlf, NDF_TB_DriverEmail);

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

        private void NDF_B_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            sender = DialogResult.Cancel;
        }

        private void NDF_TB_DriverDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void NDF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                NDF_B_Save_Click(sender, e);
            }
        }
    }
}
