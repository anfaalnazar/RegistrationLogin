using RegistrationLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationLogin.Repositories
{
    public class RegistrationRepository
    {
        String ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=RegistrationLoginDB; Integrated Security=SSPI;TrustServerCertificate=True;";


        public SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            return con;
        }

        public int CreateRegistration(Registration model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[SP_CREATEREGISTRATION]";
            SqlParameter[] myparams = new SqlParameter[8];
            myparams[0] = new SqlParameter("firstname", System.Data.SqlDbType.NVarChar, 50);
            myparams[0].Value = model.firstname;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("lastname", System.Data.SqlDbType.NVarChar, 50);
            myparams[1].Value = model.lastname;
            cmd.Parameters.Add(myparams[1]);
            myparams[2] = new SqlParameter("age", System.Data.SqlDbType.Int);
            myparams[2].Value = model.age;
            cmd.Parameters.Add(myparams[2]);
            myparams[3] = new SqlParameter("email", System.Data.SqlDbType.NVarChar, 50);
            myparams[3].Value = model.email;
            cmd.Parameters.Add(myparams[3]);
            myparams[4] = new SqlParameter("phone", System.Data.SqlDbType.Int);
            myparams[4].Value = model.phone;
            cmd.Parameters.Add(myparams[4]);
            myparams[5] = new SqlParameter("username", System.Data.SqlDbType.NVarChar, 50);
            myparams[5].Value = model.username;
            cmd.Parameters.Add(myparams[5]);
            myparams[6] = new SqlParameter("password", System.Data.SqlDbType.NVarChar, 50);
            myparams[6].Value = model.password;
            cmd.Parameters.Add(myparams[6]);
            myparams[7] = new SqlParameter("confirmpassword", System.Data.SqlDbType.NVarChar, 50);
            myparams[7].Value = model.confirmpassword;
            cmd.Parameters.Add(myparams[7]);

            int status = 0;
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Connection = conn;
                    conn.Open();
                    
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            status = Convert.ToInt32(rd["id"]);
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return status;
        }
        public int IsUserNameExists(string username)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[SP_IsUserNameExists]";
            SqlParameter[] myparams = new SqlParameter[1];
            myparams[0] = new SqlParameter("username", System.Data.SqlDbType.NVarChar, 50);
            myparams[0].Value = username;
            cmd.Parameters.Add(myparams[0]);
            int status = 0;
            try
            {
                using (SqlConnection conn = GetConnection())

                {
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            status = Convert.ToInt32(rd["id"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return status;
        }
        public List<RegistrationVM> ListRegistration(int id)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_GETSINGLEORALLREGISTRATION";

            RegistrationVM model = new RegistrationVM();

            List<RegistrationVM> lst = new List<RegistrationVM>();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters[0].Value = id;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {

                        while (rd.Read())
                        {
                            model.id = Convert.ToInt32(rd["id"]);
                            model.firstname = rd["firstname"].ToString();
                            model.lastname = rd["lastname"].ToString();
                            model.age = Convert.ToInt32(rd["age"]);
                            model.email = rd["email"].ToString();
                            model.phone = Convert.ToInt32(rd["phone"]);
                            model.username = rd["username"].ToString();
                            model.password = rd["password"].ToString();
                            model.confirmpassword = rd["confirmpassword"].ToString();
                            lst.Add(model);
                            model = new RegistrationVM();


                        }

                    }

                }
                return lst;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return lst;
        }
       
        public void EditRegistration(Registration model)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_EDITREGISTRATION]";
            SqlParameter[] myparams = new SqlParameter[9];
            myparams[0] = new SqlParameter("@id", System.Data.SqlDbType.Int);
            myparams[0].Value = model.id;
            cmd.Parameters.Add(myparams[0]);
            myparams[1] = new SqlParameter("firstname", System.Data.SqlDbType.NVarChar, 50);
            myparams[1].Value = model.firstname;
            cmd.Parameters.Add(myparams[1]);
            myparams[2] = new SqlParameter("lastname", System.Data.SqlDbType.NVarChar, 50);
            myparams[2].Value = model.lastname;
            cmd.Parameters.Add(myparams[2]);
            myparams[3] = new SqlParameter("age", System.Data.SqlDbType.Int);
            myparams[3].Value = model.age;
            cmd.Parameters.Add(myparams[3]);
            myparams[4] = new SqlParameter("email", System.Data.SqlDbType.NVarChar, 50);
            myparams[4].Value = model.email;
            cmd.Parameters.Add(myparams[4]);
            myparams[5] = new SqlParameter("phone", System.Data.SqlDbType.Int);
            myparams[5].Value = model.phone;
            cmd.Parameters.Add(myparams[5]);
            myparams[6] = new SqlParameter("username", System.Data.SqlDbType.NVarChar, 50);
            myparams[6].Value = model.username;
            cmd.Parameters.Add(myparams[6]);
            myparams[7] = new SqlParameter("password", System.Data.SqlDbType.NVarChar, 50);
            myparams[7].Value = model.password;
            cmd.Parameters.Add(myparams[7]);
            myparams[8] = new SqlParameter("confirmpassword", System.Data.SqlDbType.NVarChar, 50);
            myparams[8].Value = model.confirmpassword;
            cmd.Parameters.Add(myparams[8]);
            try
            {
                using (SqlConnection conn = GetConnection())

                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

        }
        
    }
}
