using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Shift_Management_Sytem.Validation
{
    public static class RegexValidation
    {
        // Method to validate email using regex
        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Method to validate contact number using regex (simple phone number validation)
        public static bool IsValidContactNumber(string contactNumber)
        {
            string phonePattern = @"^\+?[0-9]{10,15}$"; // Allows for country code
            return Regex.IsMatch(contactNumber, phonePattern);
        }

        // Method to validate if text is not empty or null
        public static bool IsValidText(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }

        // Method to set error messages using ErrorProvider
        public static void SetError(Control control, string message, ErrorProvider errorProvider)
        {
            errorProvider.SetError(control, message);
        }

        // Method to clear errors
        public static void ClearError(Control control, ErrorProvider errorProvider)
        {
            errorProvider.SetError(control, string.Empty);
        }
    }
}
