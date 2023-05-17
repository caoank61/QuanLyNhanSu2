using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace QuanLyNhanSu
{
    public static class Helper
    {
        public static string ComputeSha256Hash(string rawData)
        {
            var bytes = Encoding.UTF8.GetBytes(rawData);
            using (var sha256Hash = SHA256.Create())
            {
                var hashBytes = sha256Hash.ComputeHash(bytes);
                var hashString = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                return hashString;
            }
        }
    }
}