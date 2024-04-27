using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Helpers
{
    public static class FieldGenerator
    {
        private const string Chars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private const string Nums = "0123456789";
        private static Random _random = new Random();

        public static string _firstName;

        private static string _lastName;

        private static string _middleName;

        private static string _birhDate;

        private static string _phoneNumber;




        public static string GenerateRandomString(int length)
        {
            var stringBuilder = new StringBuilder(length);
            stringBuilder.Append(Chars[_random.Next(Chars.Length)]);
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append(char.ToLower(Chars[_random.Next(Chars.Length)]));
            }
            _firstName  = stringBuilder.ToString();
            return stringBuilder.ToString();
        }

        public static string GenerateRandomPhoneNumber()
        {
            var stringBuilder = new StringBuilder(10);
            stringBuilder.Append("9");
            for (int i = 0; i < 9; i++)
            {
                stringBuilder.Append(Nums[_random.Next(Nums.Length)]);
            }
            return stringBuilder.ToString();
        }

        public static string GenerateRandomBirthDate()
        {
            var day = _random.Next(10, 29);
            var month = _random.Next(10, 13);
            var year = _random.Next(1950, 2000);

            return $"{day}.{month}.{year}";
        }
    }
}
