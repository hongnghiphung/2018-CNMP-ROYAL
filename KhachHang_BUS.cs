using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MODEL;
using DATA;

namespace BUS
{
    public class KhachHang_BUS
    {
        KetNoiSQL K= new KetNoiSQL();
        KhachHang_MODEL KH = new KhachHang_MODEL();
        public DataTable DS_KhachHang()
        {
            string sql = "SELECT MA_KHACH_HANG, HO_TEN, GIOI_TINH ,NGAY_SINH, SO_DIEN_THOAI, SCMND, DIEM_TICH_LUY, EMAIL, DIA_CHI FROM KHACH_HANG WHERE MA_KHACH_HANG !='KH000'";
            DataTable DSKH = K.Tai_Du_lieu(sql);
            return DSKH;
        }


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
        public void Xoa_KhachHang(KhachHang_MODEL KH)
        {
            string sql = "DELETE FROM KHACH_HANG WHERE MA_KHACH_HANG='" + KH.MA_KHACH_HANG1 + "'";
            K.Thao_Tac_Du_Lieu(sql);
        }


        public void Them_KhachHang(KhachHang_MODEL KH)
        {
            string NGAY_SINH = string.Format("{0:MM/dd/yyyy}", KH.NGAY_SINH1);
            string sql = "INSERT INTO KHACH_HANG VALUES('" + KH.MA_KHACH_HANG1 + "',N'" + KH.HO_TEN1 + "',N'" + KH.GIOI_TINH1 + "','" + NGAY_SINH + "','" + KH.SO_DIEN_THOAI1 + "','" + KH.SCMND1 + "','" + KH.DIEM_TICH_LUY1 + "','" + KH.EMAIL1 + "',N'" + KH.DIA_CHI1 + "','" + KH.ANH1 + "')";
            K.Thao_Tac_Du_Lieu(sql);
        }
       
        public void Sua_KhachHang(KhachHang_MODEL KH)
        {
            string NGAY_SINH = string.Format("{0:MM/dd/yyyy}", KH.NGAY_SINH1);
            string sql = "UPDATE KHACH_HANG SET HO_TEN=N'" + KH.HO_TEN1 + "',GIOI_TINH=N'" + KH.GIOI_TINH1 + "',NGAY_SINH='" + NGAY_SINH + "',SO_DIEN_THOAI='" + KH.SO_DIEN_THOAI1 + "',SCMND='" + KH.SCMND1 + "',DIEM_TICH_LUY='" + KH.DIEM_TICH_LUY1 + "',EMAIL='" + KH.EMAIL1 + "',DIA_CHI=N'" + KH.DIA_CHI1 + "',ANH='" + KH.ANH1 + "'WHERE MA_KHACH_HANG='" + KH.MA_KHACH_HANG1 + "'";
            K.Thao_Tac_Du_Lieu(sql);
        }
        public void Sua_DiemKhachHang(KhachHang_MODEL KH)
        {
            string NGAY_SINH = string.Format("{0:MM/dd/yyyy}", KH.NGAY_SINH1);
            string sql = "UPDATE KHACH_HANG SET DIEM_TICH_LUY='" + KH.DIEM_TICH_LUY1 + "' WHERE MA_KHACH_HANG='" + KH.MA_KHACH_HANG1 + "'";
            K.Thao_Tac_Du_Lieu(sql);
        }
        public DataTable Tim_Kiem_Ten(string A)
        {
            string sql = "SELECT MA_KHACH_HANG, HO_TEN, GIOI_TINH ,NGAY_SINH, SO_DIEN_THOAI, SCMND, DIEM_TICH_LUY, EMAIL, DIA_CHI FROM KHACH_HANG WHERE HO_TEN LIKE N'%" + A + "%' AND MA_KHACH_HANG != 'KH000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Tim_Kiem_Ma(string A)
        {
            string sql = "SELECT MA_KHACH_HANG, HO_TEN, GIOI_TINH ,NGAY_SINH, SO_DIEN_THOAI, SCMND, DIEM_TICH_LUY, EMAIL, DIA_CHI FROM KHACH_HANG WHERE MA_KHACH_HANG LIKE '%__" + A + "%' AND MA_KHACH_HANG != 'KH000'";// Bỏ hai kí tự đầu
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Tim_Kiem_DiaChi(string A)
        {
            string sql = "SELECT MA_KHACH_HANG, HO_TEN, GIOI_TINH ,NGAY_SINH, SO_DIEN_THOAI, SCMND, DIEM_TICH_LUY, EMAIL, DIA_CHI FROM KHACH_HANG WHERE DIA_CHI LIKE N'%" + A + "%' AND MA_KHACH_HANG != 'KH000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Tim_Kiem_Ma_Day_Du(string A)
        {
            string sql = "SELECT MA_KHACH_HANG, HO_TEN, GIOI_TINH ,NGAY_SINH, SO_DIEN_THOAI, SCMND, DIEM_TICH_LUY, EMAIL, DIA_CHI FROM KHACH_HANG WHERE MA_KHACH_HANG ='" + A + "' AND MA_KHACH_HANG != 'KH000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Lay_Diem_Tich_Luy(int A)
        {
            string sql = "SELECT MA_KHACH_HANG, HO_TEN, GIOI_TINH ,NGAY_SINH, SO_DIEN_THOAI, SCMND, DIEM_TICH_LUY, EMAIL, DIA_CHI FROM KHACH_HANG WHERE MA_KHACH_HANG !='KH000' AND DIEM_TICH_LUY >=" + A + "";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
    }
}
