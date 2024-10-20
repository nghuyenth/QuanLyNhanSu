﻿using System;
using System.Data.SqlClient;
using Nhom3_QuanLyNhanSu.Entities;
namespace Nhom3_QuanLyNhanSu.Models
{
    public class LoginModel:ConnectSQLEx
    {
        public NhanVienLogin login(string username,string password) {
            NhanVienLogin nv = null;
            try
            {
               
                SqlParameter manv=new SqlParameter("@MANV",username);
                SqlParameter matkhau=new SqlParameter("@MATKHAU",password);
                SqlDataReader read =Reader("SpLogin", System.Data.CommandType.StoredProcedure,manv,matkhau);

                while (read.Read()) { 
                    nv=new  NhanVienLogin();
                    nv.MaNV = read[0].ToString();
                    nv.Ho = read[1].ToString();
                    nv.Ten = read[2].ToString();
                    int laAdminValue = Convert.ToInt32(read[3]);
                    nv.LaAdmin = (laAdminValue == 1 || laAdminValue == 2 || laAdminValue == 3) ? laAdminValue : 0;
                }
                read.Dispose();

               
            }
            catch { }

            con.Close();
            return nv;
        }
    }
}
