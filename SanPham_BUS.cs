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
    public class SanPham_BUS
    {
        KetNoiSQL K = new KetNoiSQL();
        KhoSanPham_MODEL SP = new KhoSanPham_MODEL();
        public DataTable DS_SanPham()
        {
            string sql = "SELECT MA_SAN_PHAM,TEN_SAN_PHAM,KHOI_LUONG_NHAP,GIA_NHAP_VAO,GIA_BAN_RA,NGAY_DONG_GOI,NGAY_HET_HAN,NHA_CUNG_CAP,NOI_XUAT_XU FROM KHO_SAN_PHAM WHERE MA_SAN_PHAM !='SP000'";
            DataTable DSSP = K.Tai_Du_lieu(sql);
            return DSSP;
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
        public void Xoa_SanPham(KhoSanPham_MODEL SP)
        {
            string sql = "DELETE FROM KHO_SAN_PHAM WHERE MA_SAN_PHAM='" + SP.MA_SAN_PHAM1 + "'";
            K.Thao_Tac_Du_Lieu(sql);
        }
        

        public void Them_SanPham(KhoSanPham_MODEL SP)
        {
            string NGAY_DONG_GOI = string.Format("{0:MM/dd/yyyy}", SP.NGAY_DONG_GOI1);
            string NGAY_HET_HAN = string.Format("{0:MM/dd/yyyy}", SP.NGAY_HET_HAN1);
            string sql = "INSERT INTO KHO_SAN_PHAM VALUES('" + SP.MA_SAN_PHAM1 + "',N'"+SP.TEN_SAN_PHAM1+"','"+SP.KHOI_LUONG_NHAP1+"','"+SP.GIA_NHAP_VAO1+"','"+SP.GIA_BAN_RA1+"','"+NGAY_DONG_GOI+"','"+NGAY_HET_HAN+"',N'"+SP.NHA_CUNG_CAP1+"',N'"+SP.NOI_XUAT_XU1+"','"+SP.ANH1+"')";
            K.Thao_Tac_Du_Lieu(sql);
        }
        public void Sua_SanPham(KhoSanPham_MODEL SP)
        {
            string NGAY_DONG_GOI = string.Format("{0:MM/dd/yyyy}", SP.NGAY_DONG_GOI1);
            string NGAY_HET_HAN = string.Format("{0:MM/dd/yyyy}", SP.NGAY_HET_HAN1);
            string sql = "UPDATE KHO_SAN_PHAM SET TEN_SAN_PHAM=N'" + SP.TEN_SAN_PHAM1 + "',KHOI_LUONG_NHAP='" + SP.KHOI_LUONG_NHAP1 + "',GIA_NHAP_VAO='" + SP.GIA_NHAP_VAO1 + "',GIA_BAN_RA='" + SP.GIA_BAN_RA1 + "',NGAY_DONG_GOI='" + NGAY_DONG_GOI + "',NGAY_HET_HAN='" + NGAY_HET_HAN + "',NHA_CUNG_CAP=N'" + SP.NHA_CUNG_CAP1 + "',NOI_XUAT_XU=N'" + SP.NOI_XUAT_XU1 + "',ANH='" + SP.ANH1 + "'WHERE MA_SAN_PHAM='" + SP.MA_SAN_PHAM1 + "'";
            K.Thao_Tac_Du_Lieu(sql);
        }

        public DataTable Tim_Kiem_Ten(string A)
        {
            string sql = "SELECT MA_SAN_PHAM,TEN_SAN_PHAM,KHOI_LUONG_NHAP,GIA_NHAP_VAO,GIA_BAN_RA,NGAY_DONG_GOI,NGAY_HET_HAN,NHA_CUNG_CAP,NOI_XUAT_XU FROM KHO_SAN_PHAM WHERE TEN_SAN_PHAM LIKE N'%" + A + "%'  AND MA_SAN_PHAM !='SP000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;  
        }

        public DataTable Tim_Kiem_Ma(string A)
        {
            string sql = "SELECT MA_SAN_PHAM,TEN_SAN_PHAM,KHOI_LUONG_NHAP,GIA_NHAP_VAO,GIA_BAN_RA,NGAY_DONG_GOI,NGAY_HET_HAN,NHA_CUNG_CAP,NOI_XUAT_XU FROM KHO_SAN_PHAM WHERE MA_SAN_PHAM LIKE '%__" + A + "%' AND MA_SAN_PHAM !='SP000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }

        public DataTable Tim_Kiem_XuatXu(string A)
        {
            string sql = "SELECT MA_SAN_PHAM,TEN_SAN_PHAM,KHOI_LUONG_NHAP,GIA_NHAP_VAO,GIA_BAN_RA,NGAY_DONG_GOI,NGAY_HET_HAN,NHA_CUNG_CAP,NOI_XUAT_XU FROM KHO_SAN_PHAM WHERE NOI_XUAT_XU LIKE N'%" + A + "%' AND MA_SAN_PHAM !='SP000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }

        public DataTable Kiem_Tra_Het_Han( DateTime A, DateTime B)
        {

            string TU_NGAY = string.Format("{0:MM/dd/yyyy}", A);
            string TOI_NGAY = string.Format("{0:MM/dd/yyyy}", B);
            string sql = "SELECT MA_SAN_PHAM,TEN_SAN_PHAM,GIA_NHAP_VAO,GIA_BAN_RA,NGAY_DONG_GOI,NGAY_HET_HAN,NHA_CUNG_CAP,NOI_XUAT_XU FROM KHO_SAN_PHAM WHERE NGAY_HET_HAN  BETWEEN '" + TU_NGAY + "' AND '" + TOI_NGAY + "'  AND MA_SAN_PHAM !='SP000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
    }
}
