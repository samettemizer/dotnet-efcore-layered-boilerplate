using System;
using System.Text.RegularExpressions;
using TaTava.Consts;

namespace TaTava.Policies
{
    public static class Policy
    {
        public static void NullCheck(object obj, string paramName)
        {
            if (obj == null)
                throw new ArgumentNullException($"Beklenmeyen null değer: {paramName}");
        }

        public static void NewGuidCheck(Guid guid, string paramName)
        {
            if (guid == new Guid())
                throw new ArgumentNullException($"Beklenmeyen guid değer: {paramName}");
        }

        public static void NullOrWhiteSpaceCheck(string text, string paramName)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException($"Beklenmeyen null veya boş değer: {paramName}");
        }

        public static void ZeroCheck(int number, string paramName)
        {
            if (number <= default(int))
                throw new ArgumentException($"Beklenmeyen sıfır değeri: {paramName}");
        }

        public static void ZeroCheck(long number, string paramName)
        {
            if (number <= default(long))
                throw new ArgumentException($"Beklenmeyen sıfır değeri: {paramName}");
        }

        public static void ZeroCheck(double number, string paramName)
        {
            if (number <= default(double))
                throw new ArgumentException($"Beklenmeyen sıfır değeri: {paramName}");
        }

        public static void EmailCheck(string email)
        {
            if (!Regex.IsMatch(email, Regexs.EmailRegex))
                throw new ArgumentException($"Hatalı mail formatı: {email}");
        }

        public static void CellPhoneNumberCheck(long cellPhoneNumber)
        {
            if (!Regex.IsMatch(cellPhoneNumber.ToString(), Regexs.CellPhoneNumberRegex))
                throw new ArgumentException($"Hatalı cep telefonu formatı: {cellPhoneNumber}");
        }

    }
}