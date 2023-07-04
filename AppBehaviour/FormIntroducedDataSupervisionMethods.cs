using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net.Mail;
using System.IO;
using System.Text.RegularExpressions;

namespace AppBehaviour
{
    public class FormIntroducedDataSupervisionMethods
    {
        int varCharDefaultLenght = 50;
        int varCharMaxLenght = 5000;

        public bool IsValidImage(string filePath)
        {
            try
            {
                Image.FromFile(filePath);

                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool IsValidString(string value, bool isMaxLenghtAllowed)
        {
            bool isValid = true;
            var regexItem = new Regex(@"^[a-zA-Z0-9_]*$");

            Type valueType = value.GetType();

            if (isValid && !(valueType.Equals(typeof(string))))
            {
                isValid = false;
            }


            if (isValid && !regexItem.IsMatch(value)) {
                isValid = false;
            }

            if (isMaxLenghtAllowed)
            {
                if (isValid && value.Length > varCharMaxLenght)
                {
                    isValid = false;
                }
            }
            else
            {
                if (isValid && value.Length > this.varCharDefaultLenght)
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public bool IsValidLong(long value)
        {
            bool isValid = true;

            Type valueType = value.GetType();

            if (isValid && !(valueType.Equals(typeof(long))))
            {
                isValid = false;
            }

            if (isValid && value > long.MaxValue)
            {
                isValid = false;
            }

            return isValid;
        }

        public bool IsValidEmail(string value)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            
            bool isValid = true;

            if (!regex.IsMatch(value))
            {
                isValid = false;
            }

            return isValid;
        }

        public bool IsValidDNI(string value)
        {
            Regex nifRegex = new Regex(@"^\d{8}[A-HJ-NP-TV-Z]$|^[KLMXYZ]\d{7}[A-HJ-NP-TV-Z]$|^ES\d{7}[A-HJ-NP-TV-Z]$");
            Regex dniRegex = new Regex(@"^\d{8}[A-HJ-NP-TV-Z]$");
            Regex nieRefex = new Regex(@"^[XYZ]\d{7}[A-HJ-NP-TV-Z]$");

            bool isValid = false;

            if(nifRegex.IsMatch(value) || dniRegex.IsMatch(value) || nieRefex.IsMatch(value))
            {
                isValid = true;
            }

            return isValid;
        }

        public bool IsCorrectlyWrittenNumber (string value)
        {
            bool isCorrect = true;

            Dictionary<string, int> sensitiveCharacters = new Dictionary<string, int>()
            {
                {".", 0 },
                {",", 0 }
            };

            foreach (char letter in value ) {
                if (letter.ToString() == ".")
                {
                    sensitiveCharacters["."]++;

                    if (sensitiveCharacters["."] > 0)
                    {
                        isCorrect = false;
                        break;
                    }
                }

                if (letter.ToString() == ",")
                {
                    sensitiveCharacters[","]++;

                    if(sensitiveCharacters[","] > 1)
                    {
                        isCorrect = false;
                        break;
                    }
                }

            }

            return isCorrect;

        }

        public bool IsValidDecimal(Decimal value)
        {
            bool isValid = true;

            if(value > Decimal.MaxValue)
            {
                isValid = false;
            }

            if(value <= 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public bool IsValidEuropeanLicenseString(string value)
        {
            Regex europeanPlateRegex = new Regex(@"^[A-Z]{1,2}\d{1,4}[A-Z0-9]{1,2}$");
            Regex spanishPlateRegex = new Regex(@"^\d{4}[A-Z]{3}$");

            bool isValid = false;

            if (europeanPlateRegex.IsMatch(value) || spanishPlateRegex.IsMatch(value))
            {
                isValid = true;
            }

            return isValid;
        }

        public bool IsEmptyString (string value)
        {
            if(value==null || value.Length <= 0)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool IsEmptyImage (Image value)
        {
            bool isEmpty = false;

            if (value == null)
            {
                isEmpty = true;
            }

            return isEmpty;
        }

        public bool TrySaveImage(string filePath, Bitmap image, string originalPath = "")
        {
            bool alreadyExisted = false;

            try
            {
                Bitmap newImage = new Bitmap(filePath);
                alreadyExisted = true;

            } catch
            {

                image.Save(filePath);
            }

            return alreadyExisted;
        }
    }
}
