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
    
    public class TaiKhoan_BUS
    {
        KetNoiSQL K = new KetNoiSQL();
        TaiKhoan_MODEL TK= new TaiKhoan_MODEL();
        public DataTable Danh_Sach_Tai_Khoan(string A)
        {
            string sql = "SELECT TEN_TAI_KHOAN FROM TAI_KHOAN WHERE TEN_TAI_KHOAN ='"+A+"'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
     
        public DataTable Thong_Tin_Tai_Khoan(string A)
        {
            string sql="SELECT TK.MA_NHAN_VIEN , NV.TEN_NHAN_VIEN FROM TAI_KHOAN TK, NHAN_VIEN NV WHERE TK.TEN_TAI_KHOAN='"+A+"' AND TK.MA_NHAN_VIEN=NV.MA_NHAN_VIEN";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Dang_Nhap(string A, string B)
        {
            string sql = "SELECT TEN_TAI_KHOAN, MAT_KHAU FROM TAI_KHOAN WHERE TEN_TAI_KHOAN ='" + A + "' AND MAT_KHAU='" + B + "'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Danh_Sach_Chuc_Nang(string A)
        {
            string sql = "SELECT CN.TEN_CHUC_NANG,TT.TRANG_THAI FROM  CHUC_NANG CN, TRANG_THAI TT WHERE TT.TEN_TAI_KHOAN='" + A + "'  AND TT.MA_CHUC_NANG=CN.MA_CHUC_NANG";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;     
        }
        public void Doi_Mat_Khau(TaiKhoan_MODEL TK1 )
        {
            string sql = "UPDATE TAI_KHOAN SET MAT_KHAU=N'" + TK1.MAT_KHAU1 + "' WHERE TEN_TAI_KHOAN =N'" + TK1.TEN_TAI_KHOAN1 + "'";
            K.Thao_Tac_Du_Lieu(sql);
        }
        public void Them_Tai_Khoan(TaiKhoan_MODEL TK1)
        {
            string sql = "INSERT INTO TAI_KHOAN VALUES('" + TK1.MA_NHAN_VIEN1 + "','" + TK1.TEN_TAI_KHOAN1 + "','" + TK1.MAT_KHAU1 + "')";
            K.Thao_Tac_Du_Lieu(sql);
        }
    }
}
