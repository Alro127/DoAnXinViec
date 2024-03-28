using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace DoAnXinViec
{
    class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.connStr);
        public bool ThucThi(string sqlStr, List<SqlParameter> parameters)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlStr, conn);
                cmd.Parameters.AddRange(parameters.ToArray());
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
            return false;
        }
        public DataTable Load(string sqlStr)
        {
            DataTable datatable = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                adapter.Fill(datatable);
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            finally
            {
                conn.Close();
            }
            return datatable;
        }

        public bool CheckExist(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sqlStr, conn);
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.Close(); }
            return false;
        }
        public string CheckLogin(TaiKhoan taiKhoan)
        {
            string user = null;
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT Id FROM TaiKhoan WHERE Id = @Id AND MatKhau = @Matkhau AND Quyen = @Quyen", conn);
                command.Parameters.AddWithValue("@Id", taiKhoan.TenTK);
                command.Parameters.AddWithValue("@Matkhau", taiKhoan.MatKhau);
                command.Parameters.AddWithValue("@Quyen", taiKhoan.Quyen);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user = reader.GetString(0);
                        break;
                    }
                    reader.Close();
                }
                else
                {
                    user = "Tài khoản hoặc mật khẩu không đúng!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return user;
        }
    }
}
