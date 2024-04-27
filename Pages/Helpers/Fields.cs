using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Helpers
{
    /// <summary>
    /// Промежуточный класс для хранения значений полей.
    /// </summary>
    public static class Fields
    {
        public static string firstName;
        public static string lastName;
        public static string middleName;
        public static string birthDate;
        public static string phoneNumber;

        public static void GenerateFields()
        {
            firstName = FieldGenerator.GenerateRandomString(10);
            lastName = FieldGenerator.GenerateRandomString(10);
            middleName = FieldGenerator.GenerateRandomString(10);
            birthDate = FieldGenerator.GenerateRandomBirthDate();
            phoneNumber = FieldGenerator.GenerateRandomPhoneNumber();
        }
    }
}
