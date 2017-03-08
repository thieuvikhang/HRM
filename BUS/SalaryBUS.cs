using DAL;

namespace BUS
{
    class SalaryBUS
    {
        HRMModelDataContext aHRM = new HRMModelDataContext();
        //Tính tiền bảo hiểm của nhân viên
        public decimal siPrice(float SIPayRate, decimal basicPay)
        {
            return (basicPay * (int)SIPayRate)/100;
        }
        //Tính lương cơ bản của tháng
        public decimal BasicSalary(decimal basicPay, int standardWorkday, int absentDay)
        {
            return (basicPay / standardWorkday)* (standardWorkday - absentDay);
        }
        //Tính lương thực lãnh
        public decimal RealPay(decimal basicSalary, decimal allowance, decimal siPrice)
        {
            return basicSalary + allowance - siPrice;
        }
    }
}
