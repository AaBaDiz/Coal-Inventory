using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AppBehaviour;


namespace Dashboard
{
    public class FormsBehaviour
    {
        public enum DataGridCurrentTable
        {
            Empty = 0,
            AllCoal = 1,
            AllEntries = 2,
            SearchedTruckEntry = 3,
            AllAuthorized = 4,
            SearchedTruckAuthorized = 5
            
        }

        FormsDBInteractionMethods interactionMethods = new FormsDBInteractionMethods();

        /// STATIC METHODS ///
        /// Dialogs
        public static int ConfigureOpenFileDialog(OpenFileDialog fileDialog, string formId)
        {
            int result = -1; //1 if everything was successful
            string initialDirectory;
            string filter;
            int filterIndex;
            bool restoreDirectory;

            switch (formId)
            {
                case "NTF":
                    initialDirectory = "C:\\";
                    filter = "(*.png;*.jpg)|*.png;*.jpg";
                    //filter = "(*.png;*.jpg)|*.png;*.jpg|(*.*)|*.*";

                    filterIndex = 1;
                    restoreDirectory = true;

                    _AssignOptionsToOpenFileDielog(fileDialog, initialDirectory, filter, filterIndex, restoreDirectory);

                    result = 1;
                    break;
                case "NEF":
                    initialDirectory = "C:\\";
                    filter = "(*.png;*.jpg)|*.png;*.jpg";
                    //filter = "(*.png;*.jpg)|*.png;*.jpg|(*.*)|*.*";

                    filterIndex = 1;
                    restoreDirectory = true;

                    _AssignOptionsToOpenFileDielog(fileDialog, initialDirectory, filter, filterIndex, restoreDirectory);

                    result = 1;
                    break;

                default:
                    break;
            }

            return result;

        }

        public static void ConfigureMessageBoxPopUp(string message, string caption, MessageBoxButtons boxButtons, MessageBoxIcon boxIcon, MessageBoxDefaultButton boxDefaultButtons)
        {
            MessageBox.Show(message, caption, boxButtons, boxIcon, boxDefaultButtons);
        }

        public static FormsDBInteractionMethods.Languages ConvertLanguageStringToEnum(string originalString)
        {
            FormsDBInteractionMethods.Languages result;
            switch (originalString) {
                case "English":
                    result = FormsDBInteractionMethods.Languages.English;
                    break;
                case "Spanish":
                    result = FormsDBInteractionMethods.Languages.Spanish;
                    break;
                default:
                    result = FormsDBInteractionMethods.Languages.Error;
                    break;
            }

            return result;
        }
        
        /// Images
        public static Bitmap UploadImageToForm(string path)
        {
            FormDBInteractionAuxMethods auxMethods = new FormDBInteractionAuxMethods();

            Bitmap image = auxMethods.GenerateNotLockedCopyImage(path);               

            return image;
        }
               
        public static void DisplayImageAtPictureBox (PictureBox displayPlace, Bitmap image) {

            displayPlace.Image.Dispose();
            displayPlace.Image = null;

            Bitmap resizedImage = new Bitmap(image, displayPlace.Size);
            displayPlace.Image = resizedImage;

        }



        private static void _AssignOptionsToOpenFileDielog(OpenFileDialog fileDialog, string initialDirectory, string filter, int filterIndex, bool restoreDirectory)
        {
            fileDialog.InitialDirectory = initialDirectory;
            fileDialog.Filter = filter;
            fileDialog.FilterIndex = filterIndex;
            fileDialog.RestoreDirectory = restoreDirectory;
        }

 



    }
}
