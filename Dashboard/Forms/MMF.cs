using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppBehaviour;

namespace Dashboard
{
    public partial class MMF : Form
    {

        Forms.New.NEF newEntryFrm;
        Forms.New.NTF newTruckFrm;
        Forms.New.NDF newDriverFrm;
        Forms.Edit.ESF newSearch;

        FormsDBInteractionMethods interactionMethods = new FormsDBInteractionMethods();
        FormDBInteractionAuxMethods auxMethods = new FormDBInteractionAuxMethods();
        FormsDBInteractionMethods.Languages selectedLanguage = FormsDBInteractionMethods.Languages.English;
        Dictionary<string, string[,]> languageAffectedElements;
        FormsBehaviour.DataGridCurrentTable currentGridTable = FormsBehaviour.DataGridCurrentTable.Empty;
        long idx = 0;

        public MMF()
        {
            Control.ControlCollection controlCollection = this.Controls;
            languageAffectedElements = interactionMethods.RecoverAffectedLanguageElements(FormsDBInteractionMethods.Forms.MMF, selectedLanguage);
            interactionMethods.ChangeFormLanguage(this, languageAffectedElements, FormsDBInteractionMethods.Forms.MMF);
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            auxMethods.LoadDataToCombobox(MMF_CB_Language, FormDBInteractionAuxMethods.Table.LanguageFields, "", "", 0, new string[] { "English", "Spanish" });
            selectedLanguage = FormsBehaviour.ConvertLanguageStringToEnum(MMF_CB_Language.SelectedItem.ToString());


            newEntryFrm = new Forms.New.NEF(false, selectedLanguage);
            newTruckFrm = new Forms.New.NTF(false, selectedLanguage);
            newDriverFrm = new Forms.New.NDF(selectedLanguage);

        }

        private void MMF_TSMI_NewDriver_Click(object sender, EventArgs e)
        {
            if (newDriverFrm.ShowDialog() == DialogResult.Cancel || newDriverFrm.ShowDialog() == DialogResult.OK)
            {
                newDriverFrm = new Forms.New.NDF(selectedLanguage);
            }
        }

        private void MMF_TSMI_NewEntry_Click(object sender, EventArgs e)
        {
            if (newEntryFrm.ShowDialog() == DialogResult.Cancel || newEntryFrm.ShowDialog() == DialogResult.OK)
            {
                newEntryFrm = new Forms.New.NEF(false, selectedLanguage);
            }
        }
    

        private void MMF_TSMI_NewTruck_Click(object sender, EventArgs e)
        {
            if (newTruckFrm.ShowDialog() == DialogResult.Cancel || newTruckFrm.ShowDialog() == DialogResult.OK)
            {
                newTruckFrm = new Forms.New.NTF(false, selectedLanguage);
            }
        }

        private void MMF_TSMI_EditEntry_Click(object sender, EventArgs e)
        {
            newSearch = new Forms.Edit.ESF(AppBehaviour.FormDBInteractionAuxMethods.Table.EntryFields, false, selectedLanguage);

            if (newSearch.ShowDialog() == DialogResult.Cancel || newSearch.ShowDialog() == DialogResult.OK)
            {
                newSearch = new Forms.Edit.ESF(AppBehaviour.FormDBInteractionAuxMethods.Table.EntryFields, false, selectedLanguage);
            }



        }

        private void MMF_TSMI_EditTruck_Click(object sender, EventArgs e)
        {
            newSearch = new Forms.Edit.ESF(AppBehaviour.FormDBInteractionAuxMethods.Table.TruckFields, false, selectedLanguage);

            if (newSearch.ShowDialog() == DialogResult.Cancel || newSearch.ShowDialog() == DialogResult.OK)
            {
                newSearch = new Forms.Edit.ESF(AppBehaviour.FormDBInteractionAuxMethods.Table.TruckFields, false, selectedLanguage);
            }

        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void truckToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void MMF_Activated(object sender, EventArgs e)
        {
            switch(currentGridTable)
            {
                case FormsBehaviour.DataGridCurrentTable.AllAuthorized:
                    interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Authorized, "", "", ("*"));
                    break;
                case FormsBehaviour.DataGridCurrentTable.AllCoal:
                    interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Coal, "", "", ("*"));
                    break;
                case FormsBehaviour.DataGridCurrentTable.AllEntries:
                    interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Entry, "", "", ("*"));
                    break;
                case FormsBehaviour.DataGridCurrentTable.SearchedTruckAuthorized:
                    interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Authorized, "id_truck", idx.ToString(), ("*"));
                    break;
                case FormsBehaviour.DataGridCurrentTable.SearchedTruckEntry:
                    interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Entry, "id_truck", idx.ToString(), ("*"));
                    break;
                default:
                    break;
            }
        }

        private void MMF_TSMI_ViewAuthorizeTruck_Click(object sender, EventArgs e)
        {
            newSearch = new Forms.Edit.ESF(FormDBInteractionAuxMethods.Table.TruckFields, true, selectedLanguage);

            if (newSearch.ShowDialog() == DialogResult.OK)
            {
                if (newSearch.searchedIdx.Count > 0)
                {
                    idx = Convert.ToInt64(newSearch.searchedIdx[0].ToString());

                    interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Authorized, "id_truck", idx.ToString(), ("*"));
                    currentGridTable = FormsBehaviour.DataGridCurrentTable.SearchedTruckAuthorized;

                }
            }
            newSearch = new Forms.Edit.ESF(FormDBInteractionAuxMethods.Table.TruckFields, true, selectedLanguage);
        }

        private void MMF_TSMI_ViewAuthorizedAll_Click(object sender, EventArgs e)
        {
            interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Authorized, "", "", ("*"));
            currentGridTable = FormsBehaviour.DataGridCurrentTable.AllAuthorized;


        }

        private void MMF_TSMI_ViewCoal_Click(object sender, EventArgs e)
        {
            interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Coal, "", "", ("*"));
            currentGridTable = FormsBehaviour.DataGridCurrentTable.AllCoal;


        }

        private void MMF_MS_Navbar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MMF_CB_Language_SelectedIndexChanged(object sender, EventArgs e)
        {


                selectedLanguage = FormsBehaviour.ConvertLanguageStringToEnum(MMF_CB_Language.SelectedItem.ToString());
                newEntryFrm = new Forms.New.NEF(false, selectedLanguage);
                newTruckFrm = new Forms.New.NTF(false, selectedLanguage);
                newDriverFrm = new Forms.New.NDF(selectedLanguage);

                languageAffectedElements = interactionMethods.RecoverAffectedLanguageElements(FormsDBInteractionMethods.Forms.MMF, selectedLanguage);
                interactionMethods.ChangeFormLanguage(this, languageAffectedElements, FormsDBInteractionMethods.Forms.MMF);



        }

        private void MMF_Shown(object sender, EventArgs e)
        {

        }

        private void MMF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void MMF_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void MMF_TSMI_ViewEntriesAll_Click(object sender, EventArgs e)
        {
            interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Entry, "", "", ("*"));
            currentGridTable = FormsBehaviour.DataGridCurrentTable.AllEntries;
        }

        private void MMF_TSMI_ViewEntriesTruck_Click(object sender, EventArgs e)
        {
            newSearch = new Forms.Edit.ESF(FormDBInteractionAuxMethods.Table.TruckFields, true, selectedLanguage);

            if (newSearch.ShowDialog() == DialogResult.OK)
            {
                if (newSearch.searchedIdx.Count > 0)
                {
                    idx = Convert.ToInt64(newSearch.searchedIdx[0].ToString());

                    interactionMethods.DisplayDataAtTable(ref MMF_DGV_Table, FormDBInteractionAuxMethods.Table.Entry, "id_truck", idx.ToString(), ("*"));
                    currentGridTable = FormsBehaviour.DataGridCurrentTable.SearchedTruckEntry;

                }
            }
            newSearch = new Forms.Edit.ESF(FormDBInteractionAuxMethods.Table.TruckFields, true, selectedLanguage);

        }
    }
}
