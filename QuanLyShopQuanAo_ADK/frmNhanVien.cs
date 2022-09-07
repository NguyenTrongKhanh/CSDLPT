﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ThuVien;

namespace QuanLyShopQuanAo_ADK
{
    public partial class frmNhanVien : Form
    {
        ThuVien1 db;
        SqlDataAdapter ada_NhanVien;
        DataColumn[] primaryKey;
        public frmNhanVien()
        {
            InitializeComponent();
            db = new ThuVien1();
            ada_NhanVien = new SqlDataAdapter();
            primaryKey = new DataColumn[1];
        }
        public void Load_Data()
        {
            string MaCN = LoginInfo.MaCN.ToString();
            string strSQL = "SELECT * FROM dbo.NHANVIEN where MaCN = '" + MaCN + "'";
            ada_NhanVien = db.getDataAdapter(strSQL, "dbo.NhanVien");
            //Thêm khóa chính cho bảng tblKhoa
            primaryKey[0] = db.DSet.Tables["dbo.NhanVien"].Columns["MaNV"];
            db.DSet.Tables["dbo.NhanVien"].PrimaryKey = primaryKey;
            //Binding dữ liệu giữa DataSet và Textbox
            DataBinding(db.DSet.Tables["dbo.NhanVien"]);
        }

        public void LoadGridView_NhanVien()
        {
            grvNhanVien.AutoGenerateColumns = false;
            grvNhanVien.DataSource = db.DSet.Tables["dbo.NhanVien"];
            grvNhanVien.Columns[0].HeaderText = "Mã NV";
            grvNhanVien.Columns[1].HeaderText = "Tên NV";
            grvNhanVien.Columns[2].HeaderText = "Giới Tính";
            grvNhanVien.Columns[3].HeaderText = "Ngày Sinh";
            grvNhanVien.Columns[4].HeaderText = "Địa Chỉ";
            grvNhanVien.Columns[5].HeaderText = "SĐT";
            grvNhanVien.Columns[6].HeaderText = "Chức Vụ";
            grvNhanVien.Columns[7].HeaderText = "Chi Nhánh";
            grvNhanVien.Columns[0].Width = 40;
            grvNhanVien.Columns[1].Width = 180;
            grvNhanVien.Columns[2].Width = 55;
            grvNhanVien.Columns[3].Width = 90;
            grvNhanVien.Columns[4].Width = 190;
            grvNhanVien.Columns[5].Width = 110;
            grvNhanVien.Columns[6].Width = 175;
            grvNhanVien.Columns[7].Width = 60;
            grvNhanVien.EnableHeadersVisualStyles = false; //Bắt buộc phải có dòng này!
            grvNhanVien.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.Green;
            grvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            grvNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 13F, FontStyle.Bold, GraphicsUnit.Pixel);
        }

        public void DataBinding(DataTable pDataTable)
        {
            txtMaNV.DataBindings.Clear();
            Binding dataBinding1 = new Binding("Text", pDataTable, "MaNV", true, DataSourceUpdateMode.Never);
            txtMaNV.DataBindings.Add(dataBinding1);

            txtHoTen.DataBindings.Clear();
            Binding dataBinding2 = new Binding("Text", pDataTable, "TenNV", true, DataSourceUpdateMode.Never);
            txtHoTen.DataBindings.Add(dataBinding2);

            txtDiaChi.DataBindings.Clear();
            Binding dataBinding3 = new Binding("Text", pDataTable, "DiaChi", true, DataSourceUpdateMode.Never);
            txtDiaChi.DataBindings.Add(dataBinding3);

            txtSDT.DataBindings.Clear();
            Binding dataBinding4 = new Binding("Text", pDataTable, "SDT", true, DataSourceUpdateMode.Never);
            txtSDT.DataBindings.Add(dataBinding4);

            txtChucVu.DataBindings.Clear();
            Binding dataBinding5 = new Binding("Text", pDataTable, "ChucVu", true, DataSourceUpdateMode.Never);
            txtChucVu.DataBindings.Add(dataBinding5);

            txtChiNhanh.DataBindings.Clear();
            Binding dataBinding6 = new Binding("Text", pDataTable, "MaCN", true, DataSourceUpdateMode.Never);
            txtChiNhanh.DataBindings.Add(dataBinding6);

            txtGioiTinh.DataBindings.Clear();
            Binding dataBinding7 = new Binding("Text", pDataTable, "GioiTinh", true, DataSourceUpdateMode.Never);
            txtGioiTinh.DataBindings.Add(dataBinding7);

            mtxtNgaySinh.DataBindings.Clear();
            Binding dataBinding8 = new Binding("Text", pDataTable, "NgaySinh", true, DataSourceUpdateMode.Never, "", "dd-MM-yyyy");
            mtxtNgaySinh.DataBindings.Add(dataBinding8);

        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            Load_Data();
            lblEmpName.Text = LoginInfo.TenNhanVien.ToString();
            txtChiNhanh.Text = LoginInfo.MaCN.ToString();
            txtChiNhanh.Enabled = false;
            LoadGridView_NhanVien();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string strMaNV = txtMaNV.Text.Trim();
            string strTenNV = txtHoTen.Text.Trim();
            string strDiaChi = txtDiaChi.Text.Trim();
            string strSDT = txtSDT.Text.Trim();
            string strChucVu = txtChucVu.Text.Trim();
            string strGioiTinh = txtGioiTinh.Text.Trim();
            string strNgaySinh = DateTime.Parse(mtxtNgaySinh.Text).ToString("yyyy/MM/dd");
            string strChiNhanh = txtChiNhanh.Text.Trim();


            if (strGioiTinh == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblGioiTinh.Text);
                txtMaNV.Focus();
                return;
            }
            if (strNgaySinh == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblNgaySinh.Text);
                txtMaNV.Focus();
                return;
            }
            if (strChiNhanh == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblChiNhanh.Text);
                txtMaNV.Focus();
                return;
            }
            if (strMaNV == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblMaNV.Text);
                txtMaNV.Focus();
                return;
            }
            if (strTenNV == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblHoTen.Text);
                txtHoTen.Focus();
                return;
            }
            if (strDiaChi == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblDiaChi.Text);
                txtDiaChi.Focus();
                return;
            }
            if (strSDT == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblSDT.Text);
                txtSDT.Focus();
                return;
            }
            if (strChucVu == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblChucVu.Text);
                txtChucVu.Focus();
                return;
            }
            try
            {
                DataRow dr = db.DSet.Tables["dbo.NhanVien"].Rows.Find(strMaNV);
                if (dr != null)
                {
                    MessageBox.Show("Nhân Viên này đã tồn tại");
                    return;
                }
                DataRow newRow = db.DSet.Tables["dbo.NhanVien"].NewRow();
                newRow["MaNV"] = strMaNV;
                newRow["TenNV"] = strTenNV;
                newRow["DiaChi"] = strDiaChi;
                newRow["SDT"] = strSDT;
                newRow["ChucVu"] = strChucVu;
                newRow["GioiTinh"] = strGioiTinh;
                newRow["NgaySinh"] = strNgaySinh;
                newRow["MaCN"] = strChiNhanh;
                db.DSet.Tables["dbo.NhanVien"].Rows.Add(newRow);//add vô dataset
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_NhanVien);//reconcile với DataAdapter
                ada_NhanVien.Update(db.DSet, "dbo.NhanVien");
                MessageBox.Show("Thêm thành công");
            }
            catch
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string strMaNV = txtMaNV.Text.Trim();
            if (strMaNV == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblMaNV.Text);
                txtMaNV.Focus();
                return;
            }

            try
            {
                if (db.checkExist("dbo.NguoiDung", "MaNV", strMaNV))
                {
                    MessageBox.Show("Mã Nhân Viên này đã có người Dùng");
                    return;
                }
                DataRow dr = db.DSet.Tables["dbo.NhanVien"].Rows.Find(strMaNV);
                if (dr != null)
                {
                    dr.Delete(); //Xóa dòng dữ liệu vừa tìm được
                    //Cập nhật trong CSDL
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_NhanVien);
                    ada_NhanVien.Update(db.DSet, "dbo.NhanVien");
                    MessageBox.Show("Xóa thành công");
                }
                else
                    MessageBox.Show("Không tìm thấy mã nhân viên này");
            }
            catch
            {
                MessageBox.Show("Xóa không thành công");
            }
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            string strMaNV = txtMaNV.Text.Trim();
            string strTenNV = txtHoTen.Text.Trim();
            string strDiaChi = txtDiaChi.Text.Trim();
            string strSDT = txtSDT.Text.Trim();
            string strChucVu = txtChucVu.Text.Trim();
            string strGioiTinh = txtGioiTinh.Text.Trim();
            string strNgaySinh = DateTime.Parse(mtxtNgaySinh.Text).ToString("yyyy/MM/dd");
            string strChiNhanh = txtChiNhanh.Text.Trim();

            if (strGioiTinh == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblGioiTinh.Text);
                txtMaNV.Focus();
                return;
            }
            if (strNgaySinh == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblNgaySinh.Text);
                txtMaNV.Focus();
                return;
            }
            if (strChiNhanh == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblChiNhanh.Text);
                txtMaNV.Focus();
                return;
            }
            if (strMaNV == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblMaNV.Text);
                txtMaNV.Focus();
                return;
            }
            if (strTenNV == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblHoTen.Text);
                txtHoTen.Focus();
                return;
            }
            if (strDiaChi == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblDiaChi.Text);
                txtDiaChi.Focus();
                return;
            }
            if (strSDT == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblSDT.Text);
                txtSDT.Focus();
                return;
            }
            if (strChucVu == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập " + lblChucVu.Text);
                txtChucVu.Focus();
                return;
            }
            try
            {
                DataRow dr = db.DSet.Tables["dbo.NhanVien"].Rows.Find(strMaNV);
                if (dr != null)
                { //Cập nhật lại dữ liệu cho dòng vừa tìm được
                    dr["MaNV"] = strMaNV;
                    dr["TenNV"] = strTenNV;
                    dr["DiaChi"] = strDiaChi;
                    dr["SDT"] = strSDT;
                    dr["ChucVu"] = strChucVu;
                    dr["GioiTinh"] = strGioiTinh;
                    dr["NgaySinh"] = strNgaySinh;
                    dr["MaCN"] = strChiNhanh;
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(ada_NhanVien);
                    ada_NhanVien.Update(db.DSet, "dbo.NhanVien");
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                    MessageBox.Show("Không tìm thấy mã khoa này");
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void lblSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham obj = new frmSanPham();
            obj.Show();
            this.Hide();
        }

        private void lblKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang obj = new frmKhachHang();
            obj.Show();
            this.Hide();
        }

        private void lblHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon obj = new frmHoaDon();
            obj.Show();
            this.Hide();
        }

        private void lblThoat_Click(object sender, EventArgs e)
        {
            frmDangNhap obj = new frmDangNhap();
            obj.Show();
            this.Hide();
        }

        private void lblTrangChu_Click(object sender, EventArgs e)
        {
            frmHome obj = new frmHome();
            obj.Show();
            this.Hide();
        }

        private void lblThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe obj = new frmThongKe();
            obj.Show();
            this.Hide();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtChiNhanh.Clear();
            txtChucVu.Clear();
            txtDiaChi.Clear();
            txtGioiTinh.Clear();
            txtHoTen.Clear();
            txtMaNV.Clear();
            txtSDT.Clear();
            mtxtNgaySinh.Clear();
            txtHoTen.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
