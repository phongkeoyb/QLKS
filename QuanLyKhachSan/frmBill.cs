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
    public partial class frmBill : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection conn;
        public frmBill()
        {
            InitializeComponent();
        }

        private void frmBill_Load(object sender, EventArgs e)
        {
            conn = ConnectionDatabase.getInstance();
            ConnectionDatabase.openConnectionStage();
            loadData();
        }

        void loadData()
        {
            string sqlThuePhong = "SELECT * from hoadon";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlThuePhong, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            gridControl1.DataSource = dataSet.Tables[0];
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        {
            string sqlThuePhong = "SELECT * from hoadon where MaHD like '%" + txtMaHoaDon.Text + "%' or MaThuePhong like '%" + txtMaHoaDon.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(sqlThuePhong, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            gridControl1.DataSource = dataSet.Tables[0];
        }
    }
}