using System.Security.Cryptography;
using System.Text;
namespace CarRental.Utilities
{
    public class Function
    {

        public static int _AdminId = 0;
        public static string _AdminPhone = string.Empty;
        public static string _AdminEmail = string.Empty;
        public static string _AdminUsername = string.Empty;
        public static string _AdminName = string.Empty;
        public static string _AdminAvatar = string.Empty;
        //Customer
        public static int _IdCustomer = 0;
        public static string _IdCard = string.Empty;
        public static string _Phone = string.Empty;
        public static string _Username = string.Empty;
        public static string _Name = string.Empty;

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

        public static bool AdminIsLogin()
        {
            if (Function._AdminId == 0 || string.IsNullOrEmpty(Function._AdminName) ||string.IsNullOrEmpty(Function._AdminUsername))
            {
                return false;
            }
            return true;
        }

        public static bool IsLogin()
        {
            if( Function._IdCustomer == 0 || string.IsNullOrEmpty(Function._IdCard) || string.IsNullOrEmpty(Function._Username) || string.IsNullOrEmpty(Function._Name))
            {
                return false;
            }
            return true;
        }
    }
}