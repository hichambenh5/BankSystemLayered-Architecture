using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace BANKSYSTEMWINDOWSFORMS
{
    public class ClsUtil
    {
        public static string ComputeHash(string input)
        {
            using(SHA256 sHA256 = SHA256.Create())
            {
                byte[] hashBytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("_", "").ToLower();
            }
           
        }
        public static bool CompureHash(string original, string hashdata)
        {
            return (ComputeHash(original) == hashdata);
        }
    }
}
