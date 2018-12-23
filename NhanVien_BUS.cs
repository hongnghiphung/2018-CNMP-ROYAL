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
    public class NhanVien_BUS
    {
        KetNoiSQL K = new KetNoiSQL();
        NhanVien_MODEL NV = new NhanVien_MODEL();
        public DataTable DS_NhanVien()
        {
            string sql = "SELECT MA_NHAN_VIEN,TEN_NHAN_VIEN,GIOI_TINH,NGAY_SINH,TEN_BO_PHAN,SO_DIEN_THOAI,SCMND,EMAIL,DIA_CHI,LUONG_CO_BAN FROM NHAN_VIEN WHERE MA_NHAN_VIEN !='NV000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable DS_NhanVien_ThuNgan()
        {
            string sql = "SELECT MA_NHAN_VIEN,TEN_NHAN_VIEN,GIOI_TINH,NGAY_SINH,TEN_BO_PHAN,SO_DIEN_THOAI,SCMND,EMAIL,DIA_CHI,LUONG_CO_BAN FROM NHAN_VIEN WHERE TEN_BO_PHAN =N'Thu ngân' AND MA_NHAN_VIEN !='NV000'";
            DataTable tb =K.Tai_Du_lieu(sql);
            return tb;

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
        public void Xoa_NhanVien(NhanVien_MODEL NV)
        {
            string sql = "DELETE FROM NHAN_VIEN WHERE MA_NHAN_VIEN='" + NV.MA_NHAN_VIEN1 + "'";
            K.Thao_Tac_Du_Lieu(sql);
        }


        public void Them_NhanVien(NhanVien_MODEL NV)
        {
            string NGAY_SINH = string.Format("{0:MM/dd/yyyy}", NV.NGAY_SINH1);
            string sql = "INSERT INTO NHAN_VIEN VALUES('" + NV.MA_NHAN_VIEN1 + "',N'" + NV.TEN_NHAN_VIEN1 + "',N'" + NV.GIOI_TINH1 + "','" + NGAY_SINH + "',N'" + NV.TEN_BO_PHAN1 + "','" + NV.SO_DIEN_THOAI1 + "','" + NV.SCMND1 + "','" + NV.EMAIL1 + "',N'" + NV.DIA_CHI1 + "','" + NV.LUONG_CO_BAN1 + "','"+ NV.ANH1 +"')";
            K.Thao_Tac_Du_Lieu(sql);
        }
        public void Sua_NhanVien(NhanVien_MODEL NV)
        {
            string NGAY_SINH = string.Format("{0:MM/dd/yyyy}",NV.NGAY_SINH1);
            string sql = "UPDATE NHAN_VIEN SET TEN_NHAN_VIEN=N'" + NV.TEN_NHAN_VIEN1 + "',GIOI_TINH=N'" + NV.GIOI_TINH1 + "',NGAY_SINH='" + NGAY_SINH + "',TEN_BO_PHAN=N'"+ NV.TEN_BO_PHAN1 +"',SO_DIEN_THOAI='" + NV.SO_DIEN_THOAI1 + "',SCMND='" + NV.SCMND1 + "',EMAIL='" + NV.EMAIL1 + "',DIA_CHI=N'" + NV.DIA_CHI1 + "',LUONG_CO_BAN='"+ NV.LUONG_CO_BAN1 +"',ANH='" + NV.ANH1 + "'WHERE MA_NHAN_VIEN='" + NV.MA_NHAN_VIEN1 + "'";
            K.Thao_Tac_Du_Lieu(sql);
        }
        public DataTable Tim_Kiem_Ten(string A)
        {
            string sql = "SELECT MA_NHAN_VIEN,TEN_NHAN_VIEN,GIOI_TINH,NGAY_SINH,TEN_BO_PHAN,SO_DIEN_THOAI,SCMND,EMAIL,DIA_CHI,LUONG_CO_BAN FROM NHAN_VIEN WHERE TEN_NHAN_VIEN LIKE N'%" + A + "%' AND MA_NHAN_VIEN !='NV000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Tim_Kiem_Ma(string A)
        {
            string sql = "SELECT MA_NHAN_VIEN,TEN_NHAN_VIEN,GIOI_TINH,NGAY_SINH,TEN_BO_PHAN,SO_DIEN_THOAI,SCMND,EMAIL,DIA_CHI,LUONG_CO_BAN FROM NHAN_VIEN WHERE MA_NHAN_VIEN LIKE '%__" + A + "%' AND MA_NHAN_VIEN !='NV000'";// Bỏ hai kí tự đầu
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Tim_Kiem_DiaChi(string A)
        {
            string sql = "SELECT MA_NHAN_VIEN,TEN_NHAN_VIEN,GIOI_TINH,NGAY_SINH,TEN_BO_PHAN,SO_DIEN_THOAI,SCMND,EMAIL,DIA_CHI,LUONG_CO_BAN FROM NHAN_VIEN WHERE DIA_CHI LIKE N'%" + A + "%' AND MA_NHAN_VIEN !='NV000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
        public DataTable Tim_Kiem_Ma_Day_Du(string A)
        {
            string sql = " SELECT MA_NHAN_VIEN,TEN_NHAN_VIEN,GIOI_TINH,NGAY_SINH,TEN_BO_PHAN,SO_DIEN_THOAI,SCMND,EMAIL,DIA_CHI,LUONG_CO_BAN FROM NHAN_VIEN WHERE MA_NHAN_VIEN ='" + A + "' AND TEN_BO_PHAN=N'Thu ngân' AND MA_NHAN_VIEN !='NV000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
    }
}
