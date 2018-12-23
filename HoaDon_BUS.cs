using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using MODEL;
using System.Data;
namespace BUS
{
   public class HoaDon_BUS
    {
       KetNoiSQL K = new KetNoiSQL();
       HoaDon_MODEL HD = new HoaDon_MODEL();
       public string GetMa(string sql)
       {
           DataTable tb = K.Tai_Du_lieu(sql);
           if (tb.Rows.Count > 0)
           {
               string str = tb.Rows[0][0].ToString();
               return str;
           }
             else
           {
               return "";
           }
       }
       public void Them_HoaDon(HoaDon_MODEL HD)
       {
           string NGAY_TAO = string.Format("{0:MM/dd/yyyy}", HD.NGAY_TAO1);
           string sql = "INSERT INTO HOA_DON VALUES('" + HD.MA_HOA_DON1 + "','" + HD.MA_NHAN_VIEN1 + "','" + HD.MA_KHACH_HANG1 + "','" + NGAY_TAO + "','" + HD.TONG_TIEN1 + "')";
           K.Thao_Tac_Du_Lieu(sql);
       }
       public void Them_HoaDon_KhongMaKH(HoaDon_MODEL HD)
       {
           string NGAY_TAO = string.Format("{0:MM/dd/yyyy}", HD.NGAY_TAO1);
           string sql = "INSERT INTO HOA_DON VALUES('" + HD.MA_HOA_DON1 + "','" + HD.MA_NHAN_VIEN1 + "',NULL,'" + NGAY_TAO + "','" + HD.TONG_TIEN1 + "')";
           K.Thao_Tac_Du_Lieu(sql);
       }
       public float Lay_Khoi_Luong(String A)
       {
           string sql = "SELECT KHOI_LUONG_NHAP FROM KHO_SAN_PHAM WHERE MA_SAN_PHAM='"+A+"'";
           DataTable tb = K.Tai_Du_lieu(sql);
           if(tb.Rows.Count>0)
           {
               return float.Parse(tb.Rows[0][0].ToString());
           }
           else
           {
               return 0;
           }
       }
       public DataTable Xuat_Hoa_Don(string A)
       {
           string sql = "SELECT KH.TEN_SAN_PHAM , CT.KHOI_LUONG, KH.GIA_BAN_RA, CT.THANH_TIEN FROM KHO_SAN_PHAM KH, CHI_TIET_HOA_DON CT WHERE CT.MA_HOA_DON ='" + A + "' AND CT.MA_SAN_PHAM=KH.MA_SAN_PHAM";
           DataTable tb = K.Tai_Du_lieu(sql);
           return tb;
       }
    }
}
