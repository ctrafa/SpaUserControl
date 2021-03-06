﻿using SpaUserControl.Common.Resources;

namespace SpaUserControl.Common.Validation
{
    public class PasswordAssertionConcern
    {
        public static void AssertIsValid(string password)
        {
            AssertionConcern.AssertArgumentNotNull(password, Errors.InvalidUserPassword);
        }

        public static string Encrypt(string password)
        {
            password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881";
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));
            var sbString = new System.Text.StringBuilder();
            foreach (byte t in data)
                sbString.Append(t.ToString("x2"));
            return sbString.ToString();
        }
    }
}
