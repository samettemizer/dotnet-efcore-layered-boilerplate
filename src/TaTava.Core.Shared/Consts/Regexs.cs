namespace TaTava.Consts
{
    public static class Regexs
    {
        public const string OnlyStringRegex = @"^[a-zA-ZğüşöçıİĞÜŞÖÇ]+(([',. -][a-zA-Z ])?[a-zA-ZğüşöçıİĞÜŞÖÇ]*)*$";
        public const string OnlyNumberRegex = @"^[0-9]+$";
        public const string CellPhoneNumberRegex = @"(5|5)[0-9][0-9][0-9]([0-9]){6}";
        public const string PhoneNumberRegex = @"\d{1,10}";
        public const string SecurePasswordRegex = @"^(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
        public const string SecurePinRegex = @"^\d{4}";
        public const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public const string IdentityRegex = @"^[1-9]{1}[0-9]{9}[02468]{1}$";
        public const string BirthDateRegex = @"/^([1-9]|[12][0-9]|3[01])(\/?\.?\-?\s?)(0[1-9]|1[12])(\/?\.?\-?\s?)(19[0-9][0-9]|20[0][0-9]|20[1][0-8])$/";
    }
}