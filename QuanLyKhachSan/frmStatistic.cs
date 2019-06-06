using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace QuanLyKhachSan
{
    public partial class frmStatistic : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn;
        public frmStatistic()
        {
            InitializeComponent();
        }

        private void edtLuaChon_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void frmStatistic_Load(object sender, EventArgs e)
        {
            conn = ConnectionDatabase.getInstance();
            ConnectionDatabase.openConnectionStage();

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            gvThongKe.Columns.Clear();
            string loaiThongKe = edtLuaChon.Text;
            string tungay = edtTuNgay.Text;
            string denngay = edtDenNgay.Text;
            if (tungay.Equals(""))
            {
                XtraMessageBox.Show("Chưa chọn ngày bắt đầu", "Thông báo");
            }
            else
            {
                if (denngay.Equals(""))
                {
                    thongKe(loaiThongKe, tungay);
                }
                else
                {
                    int thoigian = (int)((Convert.ToDateTime(denngay) - Convert.ToDateTime(tungay)).TotalSeconds);
                    if (thoigian <= 0)
                    {
                        XtraMessageBox.Show("Đến ngày phải nhỏ hơn ngày bắt đầu", "Thông báo");
                    }
                    else
                    {
                        thongKe(loaiThongKe, tungay, denngay);
                    }
                }
            }
        }
        void thongKe(string loaiThongKe, string tungay)
        {
            switch (loaiThongKe)
            {
                case "Dịch vụ":
                    string sqlDichVu = "select tendv as 'Tên dịch vụ', gia as 'Giá', sum(soluong) as 'Số lượng', sum(soluong*gia) as 'Thành tiền' from " +
                        "sudungdv inner join dichvu on sudungdv.madv= dichvu.madv where ngaysd >= '" + tungay + "' group by dichvu.madv,TenDV,gia";
                    SqlDataAdapter adapterDV = new SqlDataAdapter(sqlDichVu, conn);
                    DataSet dataDV = new DataSet();
                    adapterDV.Fill(dataDV);
                    gridThongKe.DataSource = dataDV.Tables[0];
                    break;
                case "Phòng":
                    DateTime hientai = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:ss"));
                    string sqlPhong = "select loaiphong.TenLoai as 'Loại phòng', sum(thuephong.tiendv) as 'Tiền dịch vụ', sum(tienphong) as 'Tiền phòng',sum(tiendv+tienphong) as 'Tổng cộng'  from phong inner join loaiphong on phong.maloai = loaiphong.maloai " +
                    "inner join thuephong on thuephong.maphong = phong.maphong where thuephong.ngaythue >= '" + tungay + "' and ngaytra <= '" + hientai + "' group by loaiphong.maloai, loaiphong.TenLoai";
                    SqlDataAdapter adapterPhong = new SqlDataAdapter(sqlPhong, conn);
                    DataSet dataPhong = new DataSet();
                    adapterPhong.Fill(dataPhong);
                    gridThongKe.DataSource = dataPhong.Tables[0];
                    break;
                default:
                    XtraMessageBox.Show("Cập nhật sau", "Thông báo");
                    break;
            }
        }

        void thongKe(string loaiThongKe, string tungay, string denngay)
        {
            switch (loaiThongKe)
            {
                case "Dịch vụ":
                    string sqlDichVu = "select tendv as 'Tên dịch vụ', gia as 'Giá', sum(soluong) as 'Số lượng', sum(soluong*gia) as 'Thành tiền' from " +
                        "sudungdv inner join dichvu on sudungdv.madv= dichvu.madv where ngaysd >= '" + tungay + "' and ngaysd <= '" + denngay + "' group by dichvu.madv,TenDV,gia";
                    SqlDataAdapter adapterDV = new SqlDataAdapter(sqlDichVu, conn);
                    DataSet dataDV = new DataSet();
                    adapterDV.Fill(dataDV);
                    gridThongKe.DataSource = dataDV.Tables[0];
                    break;
                case "Phòng":
                    DateTime hientai = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy HH:ss"));
                    string sqlPhong = "select loaiphong.TenLoai as 'Loại phòng', sum(thuephong.tiendv) as 'Tiền dịch vụ', sum(tienphong) as 'Tiền phòng',sum(tiendv+tienphong) as 'Tổng cộng'  from phong inner join loaiphong on phong.maloai = loaiphong.maloai " +
                    "inner join thuephong on thuephong.maphong = phong.maphong where thuephong.ngaythue >= '" + tungay + "' and ngaytra <= '" + denngay + "' group by loaiphong.maloai, loaiphong.TenLoai";
                    SqlDataAdapter adapterPhong = new SqlDataAdapter(sqlPhong, conn);
                    DataSet dataPhong = new DataSet();
                    adapterPhong.Fill(dataPhong);
                    gridThongKe.DataSource = dataPhong.Tables[0];
                    break;
            }
        }
    }
}