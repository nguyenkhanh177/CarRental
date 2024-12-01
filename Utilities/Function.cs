using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization.Metadata;
namespace CarRental.Utilities
{
    public class Function
    {

        //Customer
        public static int _IdCustomer = 0;
        public static string _IdCard = string.Empty;
        public static string _Phone = string.Empty;
        public static string _Username = string.Empty;
        public static string _Password = string.Empty;
        public static string _Name = string.Empty;

        //Other
        public static string _Message = string.Empty;
        public static string _ReturnLink = string.Empty;
        public string TitleToAlias(string Title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(Title);
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBulder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBulder.Append(result[i].ToString("x2"));
            }
            return strBulder.ToString();
        }

        public static string MD5Password(string text)
        {
            string str = MD5Hash(text);
            for (int i = 0; i <= 5; i++)
            {
                str = MD5Hash(str + "_" + str);
            }
            return str;


        }

        public static bool IsLogin()
        {
            if( Function._IdCustomer == 0 || string.IsNullOrEmpty(Function._Phone) || string.IsNullOrEmpty(Function._IdCard) || string.IsNullOrEmpty(Function._Username) || string.IsNullOrEmpty(Function._Name))
            {
                return false;
            }
            return true;
        }
    }
}