using System.Globalization;

namespace BUS
{
    public class ExtendBus
    {
        //Format tiền sang vnđ
        public string FormatMoney(decimal money)
        {
            var cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
            return money.ToString("#,### VNĐ", cul.NumberFormat);
        }
    }
}
