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
   public class ChamCong_BUS
    {
       KetNoiSQL K = new KetNoiSQL();
       GioLam_MODEL G = new GioLam_MODEL();
       public DataTable Danh_Sach_Ngay_Lam(string A, string M, string Y)
       {
           string sql ="SELECT MA_GIO_LAM, NGAY_LAM,GIO_LAM FROM GIO_LAM WHERE MA_NHAN_VIEN='"+A+"' AND MONTH(NGAY_LAM)='"+M+"' AND YEAR(NGAY_LAM)='"+Y+"'";
           DataTable tb= K.Tai_Du_lieu(sql);
           return tb;
       }
       public void Them_GioLam(GioLam_MODEL G)
       {
           string NGAY_LAM = string.Format("{0:MM/dd/yyyy}", G.NGAY_LAM1);
           string sql = "INSERT INTO GIO_LAM VALUES('" + G.MA_NHAN_VIEN1 + "','" + G.MA_GIO_LAM1 + "','" + NGAY_LAM + "','" + G.GIO_LAM1 + "')";
           K.Thao_Tac_Du_Lieu(sql);
       }
       public string Tong_Gio_Lam(string A,string M, string Y)
       {
           string sql = "SELECT SUM(GIO_LAM) FROM GIO_LAM WHERE MA_NHAN_VIEN='" + A + "' AND MONTH(NGAY_LAM)='" + M + "' AND YEAR(NGAY_LAM)='" + Y + "'";
           DataTable tb= K.Tai_Du_lieu(sql);
           string GL = tb.Rows[0][0].ToString();
           return GL;
       }
       public void Sua_Cham_Cong(GioLam_MODEL G)
       {
           string sql = "UPDATE GIO_LAM SET GIO_LAM='" + G.GIO_LAM1 + "' WHERE MA_GIO_LAM='" + G.MA_GIO_LAM1 + "' AND MA_NHAN_VIEN='"+G.MA_NHAN_VIEN1+"'";
           K.Thao_Tac_Du_Lieu(sql);
       }

       public DataTable Lay_Ngay(string A)
       {
           string sql = "SElECT NGAY_LAM FROM GIO_LAM WHERE MA_NHAN_VIEN ='"+A+"'";
           DataTable tb = K.Tai_Du_lieu(sql);
           return tb;
       }
       public String Lay_Ma_Gio(string A ,string B)
       {
           
           string sql = "SELECT  TOP 1 MA_GIO_LAM   FROM GIO_LAM WHERE MA_NHAN_VIEN ='"+A+"' AND SUBSTRING(MA_GIO_LAM,4,8)='"+B+"' ORDER BY MA_GIO_LAM DESC";
           DataTable tb = K.Tai_Du_lieu(sql);
          if(tb.Rows.Count>0)
          {
              return tb.Rows[0][0].ToString();
          }
          else
          {
              return "";
          }
       }
    }
}
