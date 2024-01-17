using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Connection
    {
        private string stringConnection = @"Data Source=DESKTOP-C7KLCA4\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True";
        private string stringConnection2 = @"Data Source=DESKTOP-C7KLCA4\SQLEXPRESS;Initial Catalog=QLSV;User ID="+ F_Dangnhap.mssv +";Password=" + F_Dangnhap.matkhau;
        private SqlConnection conn;
        private DataTable dt;
        private SqlCommand cmd;
        private string string1;
        private SqlDataReader reader;

        public bool CheckConnection()
        {
            try
            {
                conn = new SqlConnection(Check());
                conn.Open();
                MessageBox.Show("Đăng nhập thành công");
                return true;
            }
            catch 
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                return false;
            }
            finally 
            {
                conn.Close();
            }
        }

        private string Check()
        {
            if(string.IsNullOrEmpty(F_Dangnhap.mssv) && string.IsNullOrEmpty(F_Dangnhap.matkhau))
            {
                return stringConnection;
            }
            else
            {
                return stringConnection2;
            }    
        }
        public DataTable SelectData(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                conn = new SqlConnection(Check());
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if(lstPara != null)
                {
                    foreach (var para in lstPara)
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }
                }    
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch
            {
                MessageBox.Show("Loi Datatable");
                return null;
            }
            finally
            { 
                conn.Close(); 
            }
        }

        public DataRow SelectRow(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                conn = new SqlConnection(Check());
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstPara != null)
                {
                    foreach (var para in lstPara)
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt.Rows[0];
            }
            catch
            {
                MessageBox.Show("Loi Datatable");
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public int Execute(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                conn = new SqlConnection(Check());
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstPara != null)
                {
                    foreach (var para in lstPara)
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }
                }
                var rs = cmd.ExecuteNonQuery();
                return (int)rs;
            }
            catch
            {
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }

        public int ExecuteS(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                conn = new SqlConnection(Check());
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstPara != null)
                {
                    foreach (var para in lstPara)
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }
                }
                var rs = cmd.ExecuteScalar();
                return (int)rs;
            }
            catch
            {
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }

        public int ADDMIN(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                conn = new SqlConnection(stringConnection);
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstPara != null)
                {
                    foreach (var para in lstPara)
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }
                }
                var rs = cmd.ExecuteScalar();
                return (int)rs;
            }
            catch
            {
                MessageBox.Show("Lỗi Execute");
                return -100;
            }
            finally
            {
                conn.Close();
            }
        }
        public DataTable AddmintData(string sql, List<CustomParameter> lstPara = null)
        {
            try
            {
                conn = new SqlConnection(stringConnection);
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (lstPara != null)
                {
                    foreach (var para in lstPara)
                    {
                        cmd.Parameters.AddWithValue(para.key, para.value);
                    }
                }
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch
            {
                MessageBox.Show("Loi Datatable");
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
