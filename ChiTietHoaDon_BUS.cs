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
     public class ChiTietHoaDon_BUS
    {
         KetNoiSQL K = new KetNoiSQL();
         ChiTietHoaDon_MODEL CTHD = new ChiTietHoaDon_MODEL();
         public void Them_ChiTietHoaDon(ChiTietHoaDon_MODEL CTHD)
         {
             
             string sql = "INSERT INTO CHI_TIET_HOA_DON VALUES('" + CTHD.MA_HOA_DON1 + "','" + CTHD.MA_SAN_PHAM1 + "','" + CTHD.KHOI_LUONG1 + "','" + CTHD.DON_GIA1 + "','" + CTHD.THANH_TIEN1 + "')";
             K.Thao_Tac_Du_Lieu(sql);
         }
    }
}
