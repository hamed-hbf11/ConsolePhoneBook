namespace phoneBookApp.Utility
{
    public static class PhoneValidator
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            if (phoneNumber.Length != 11)
                return false;

            if (!phoneNumber.All(char.IsDigit))
                return false;

            if (!phoneNumber.StartsWith("09"))
                return false;

            return true;
        }
    }
}

