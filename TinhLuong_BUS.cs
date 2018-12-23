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
    public class TinhLuong_BUS
    {
        KetNoiSQL K = new KetNoiSQL();
        
        public DataTable DS_Luong()
        {
            string sql = "SELECT MA_NHAN_VIEN,TEN_NHAN_VIEN,GIOI_TINH,NGAY_SINH,TEN_BO_PHAN,LUONG_CO_BAN FROM NHAN_VIEN WHERE MA_NHAN_VIEN != 'NV000'";
            DataTable tb = K.Tai_Du_lieu(sql);
            return tb;
        }
    }
}
