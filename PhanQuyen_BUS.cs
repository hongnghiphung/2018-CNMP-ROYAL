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
    public class PhanQuyen_BUS
    {
        KetNoiSQL K = new KetNoiSQL();
        TrangThai_MODEL TT = new TrangThai_MODEL();
        public DataTable Tat_Ca_Tai_khoan()
        {
            string sql = " SELECT TK.MA_NHAN_VIEN, TK.TEN_TAI_KHOAN, NV.TEN_NHAN_VIEN, NV.GIOI_TINH,NV.NGAY_SINH,NV.TEN_BO_PHAN,NV.SO_DIEN_THOAI,NV.DIA_CHI, TK.MAT_KHAU FROM  NHAN_VIEN NV, TAI_KHOAN TK WHERE NV.MA_NHAN_VIEN=TK.MA_NHAN_VIEN AND NV.MA_NHAN_VIEN !='NV000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Danh_Sach_Chuc_Nang()
        {
            string sql = "SELECT MA_CHUC_NANG FROM CHUC_NANG";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public  DataTable Trang_Thai(string A)
        {
            string sql = "SELECT CN.TEN_CHUC_NANG, TT.TRANG_THAI FROM CHUC_NANG CN, TRANG_THAI TT WHERE TT.TEN_TAI_KHOAN='"+A+"' AND CN.MA_CHUC_NANG=TT.MA_CHUC_NANG ";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
         public string Ma_Chuc_Nang(string A)
        {
            string sql = "SELECT  MA_CHUC_NANG FROM CHUC_NANG WHERE TEN_CHUC_NANG=N'" + A + "'";
            DataTable tb = K.Tai_Du_lieu(sql);

            string s = tb.Rows[0][0].ToString();
            return s;
        }

        public void Them_Trang_Thai(TrangThai_MODEL TT)
        {

            string A = Convert.ToString(TT.TRANG_THAI1);
            string sql = "INSERT INTO TRANG_THAI VALUES('" + TT.TEN_TAI_KHOAN1 + "','" + TT.MA_CHUC_NANG1 + "', '"+ A +"' )";
            K.Thao_Tac_Du_Lieu(sql);
        }

        public void Cap_Nhat_Trang_Thai(TrangThai_MODEL TT)
        {
            string A = Convert.ToString(TT.TRANG_THAI1);
            string sql = "UPDATE TRANG_THAI SET TRANG_THAI='" + A + "' WHERE TEN_TAI_KHOAN='" + TT.TEN_TAI_KHOAN1 + "' AND MA_CHUC_NANG='" + TT.MA_CHUC_NANG1 + "'";
            K.Thao_Tac_Du_Lieu(sql);
        }

        public DataTable Tim_Kiem_Theo_MaNV(string A)
        {
            string sql = "SELECT TK.MA_NHAN_VIEN, TK.TEN_TAI_KHOAN, NV.TEN_NHAN_VIEN, NV.GIOI_TINH,NV.NGAY_SINH,NV.TEN_BO_PHAN,NV.SO_DIEN_THOAI,NV.DIA_CHI, TK.MAT_KHAU FROM  NHAN_VIEN NV, TAI_KHOAN TK WHERE NV.MA_NHAN_VIEN=TK.MA_NHAN_VIEN AND NV.MA_NHAN_VIEN !='NV000' AND NV.MA_NHAN_VIEN LIKE '%__" + A + "%'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Tim_Kiem_Theo_TenNV(string A)
        {
            string sql = "SELECT TK.MA_NHAN_VIEN, TK.TEN_TAI_KHOAN, NV.TEN_NHAN_VIEN, NV.GIOI_TINH,NV.NGAY_SINH,NV.TEN_BO_PHAN,NV.SO_DIEN_THOAI,NV.DIA_CHI, TK.MAT_KHAU FROM  NHAN_VIEN NV, TAI_KHOAN TK WHERE NV.MA_NHAN_VIEN=TK.MA_NHAN_VIEN AND NV.MA_NHAN_VIEN !='NV000' AND NV.TEN_NHAN_VIEN LIKE N'%" + A + "%'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Tim_Kiem_Theo_TenTK(string A)
        {
            string sql = "SELECT TK.MA_NHAN_VIEN, TK.TEN_TAI_KHOAN, NV.TEN_NHAN_VIEN, NV.GIOI_TINH,NV.NGAY_SINH,NV.TEN_BO_PHAN,NV.SO_DIEN_THOAI,NV.DIA_CHI, TK.MAT_KHAU FROM  NHAN_VIEN NV, TAI_KHOAN TK WHERE NV.MA_NHAN_VIEN=TK.MA_NHAN_VIEN AND NV.MA_NHAN_VIEN !='NV000' AND TK.TEN_TAI_KHOAN LIKE '%" + A + "%'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
    }
}
