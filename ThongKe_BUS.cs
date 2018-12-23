using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using System.Data;

namespace BUS
{
   public class ThongKe_BUS
    {
        KetNoiSQL K = new KetNoiSQL();
        public string Ngay()
        {
            DateTime A = DateTime.Now;
            string Ngay = string.Format("{0:MM/dd/yyyy}", A);
            string sql = "SELECT SUM(TONG_TIEN) FROM HOA_DON WHERE NGAY_TAO='" + Ngay + "' ";
            DataTable B = K.Tai_Du_lieu(sql);

            if (B.Rows.Count > 0)
            {
                string str = B.Rows[0][0].ToString();

                return str;
            }
            else
            {
                string str = "000000";

                return str;

            }
        }


        public string Thang()
        {
            DateTime A = DateTime.Now;
            string Nam = string.Format("{0:yyyy}", A);
            string Thang1 = string.Format("{0:MM}", A);
            string sql = "SELECT SUM(TONG_TIEN) FROM HOA_DON WHERE  MONTH(NGAY_TAO)='" + Thang1 + "' AND YEAR(NGAY_TAO)='" + Nam + "' ";
            DataTable B = K.Tai_Du_lieu(sql);

            if (B.Rows.Count > 0)
            {
                string str = B.Rows[0][0].ToString();

                return str;
            }
            else
            {
                string str = "000000";

                return str;

            }
        }
    }
}
