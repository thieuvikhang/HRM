using System.Security.Cryptography;

namespace BUS
{
    public class ExtendBus
    {
        /// <summary>
        /// Format tiền sang dạng việt nam
        /// </summary>
        /// <param name="money">số tiền</param>
        /// <returns>chuổi đã được Format</returns>
        public string FormatMoney(decimal money) => money.ToString("#,###");

        /// <summary>
        /// Mã hóa mật khẩu theo MD5
        /// </summary>
        /// <param name="chuoi">Chuổi cần mã hóa</param>
        /// <returns>dữ liệu đã được mã hóa</returns>
        public string GetMd5(string chuoi)
        {
            var strMd5 = "";
            var mang = System.Text.Encoding.UTF8.GetBytes(chuoi);

            using (var myMd5 = new MD5CryptoServiceProvider())
            {
                mang = myMd5.ComputeHash(mang);
            }

            foreach (var b in mang)
            {
                strMd5 += b.ToString("X2");
            }
            return strMd5;
        }
    }
}