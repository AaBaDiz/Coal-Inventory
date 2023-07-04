using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppBehaviour;

namespace Dashboard.Forms.Edit
{
    public partial class ESF : Form
    {
        string defaultNewEntryErrorCaption = "Not found";
        string defaultNewEntryErrorMessage = "Searched registry not found";
        public BindingSource searchedIdx = new BindingSource();
        bool isAViewSearch;
        Dictionary<string, string[,]> languageAffectedElements;


        FormDBInteractionAuxMethods.Table chosenTable;
        Dashboard.Forms.New.NTF editTruckFrm;
        Dashboard.Forms.New.NEF editEntryFrm;


        FormIntroducedDataSupervisionMethods supervisionMethods = new FormIntroducedDataSupervisionMethods();
        FormsDBInteractionMethods interactionMethods = new FormsDBInteractionMethods();
        FormDBInteractionAuxMethods auxMethods = new FormDBInteractionAuxMethods();
        FormsDBInteractionMethods.Languages selectedLanguage;

        public ESF(FormDBInteractionAuxMethods.Table table, bool isViewSearch, FormsDBInteractionMethods.Languages chosenLanguage)
        {
            InitializeComponent();
            chosenTable = table;
            isAViewSearch = isViewSearch;
            selectedLanguage = chosenLanguage;
        }

        private void ESF_Load(object sender, EventArgs e)
        {

            switch (chosenTable)
            {
                case FormDBInteractionAuxMethods.Table.EntryFields:

                    auxMethods.LoadDataToCombobox(ESF_ComboB_Options, chosenTable, "", "", -1, "");
                    ESF_DGV_Table.Visible = true;

                    auxMethods.LoadDataToCombobox(ESF_ComboB_Options, chosenTable, "", "", -1, "");
                    ESF_ComboB_Options.SelectedIndex = 0;


                    break;
                case FormDBInteractionAuxMethods.Table.TruckFields:
                    auxMethods.LoadDataToCombobox(ESF_ComboB_Options, chosenTable, "", "", -1, "");
                    ESF_ComboB_Options.SelectedIndex = 0;
                    break;
                default:
                    this.Close();
                    break;
            }

            languageAffectedElements = interactionMethods.RecoverAffectedLanguageElements(FormsDBInteractionMethods.Forms.ESF, selectedLanguage);
            interactionMethods.ChangeFormLanguage(this, languageAffectedElements, FormsDBInteractionMethods.Forms.ESF);
            defaultNewEntryErrorCaption = languageAffectedElements["ESF_MBCaption_EntryError"][0, 1];
            defaultNewEntryErrorMessage = languageAffectedElements["ESF_MBMessage_EntryError"][0, 1];
        }

        private void ESF_B_Search_Click(object sender, EventArgs e)
        {
            long idx = 0;
            long[] arrIdx = null;
            DataTable table = null;
            switch (chosenTable)
            {
                case FormDBInteractionAuxMethods.Table.EntryFields:
                    idx = interactionMethods.SearchAtDatabase(chosenTable, ESF_ComboB_Options, ESF_TB_Search, ref arrIdx, ref table);

                    ESF_DGV_Table.DataSource = table;


                    break;
                case FormDBInteractionAuxMethods.Table.TruckFields:
                    idx = interactionMethods.SearchAtDatabase(chosenTable, ESF_ComboB_Options, ESF_TB_Search, ref arrIdx, ref table);
                    break;
                default:
                    this.Close();
                    break;
            }

            if (idx < 0)
            {
                FormsBehaviour.ConfigureMessageBoxPopUp(defaultNewEntryErrorMessage, defaultNewEntryErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                idx = 0;
            }
            else
            {
                if(isAViewSearch)
                {
                    searchedIdx.Add(idx);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }
                else
                {
                   
                    switch (chosenTable)
                    {
                        case FormDBInteractionAuxMethods.Table.EntryFields:
                            //editEntryFrm = new New.NEF(true, selectedLanguage, idx);
                            //editEntryFrm.ShowDialog();
                            break;
                        case FormDBInteractionAuxMethods.Table.TruckFields:
                            editTruckFrm = new New.NTF(true, selectedLanguage, idx);
                            editTruckFrm.ShowDialog();
                            //this.Close();
                            break;
                        default:
                            this.Close();
                            break;
                    }
                }




            }
        }

        private void ESF_ComboB_Options_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ESF_DGV_Table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ESF_DGV_Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(ESF_DGV_Table.DataSource != null && e.RowIndex >= 0)
            {
                string idxStr = ESF_DGV_Table[0, e.RowIndex].Value.ToString();
                long idx = Convert.ToInt64(idxStr);

                editEntryFrm = new New.NEF(true, selectedLanguage, idx);
                editEntryFrm.ShowDialog();

            }

        }

        private void ESF_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if(e.KeyCode == Keys.Enter)
            {
                ESF_B_Search_Click(sender, e);
            }
        }
    }
}
