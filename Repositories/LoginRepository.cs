using RegistrationLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationLogin.Repositories
{
    public class LoginRepository
    {
            String ConnectionString = @"Server=LAPTOP-8R2JSJSS\SQLEXPRESS01; Initial Catalog=RegistrationLoginDB; Integrated Security=SSPI;TrustServerCertificate=True;";


            public SqlConnection GetConnection()
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                return con;
            }

            public void CreateLogin(Login model)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[SP_CREATELOGIN]";
                SqlParameter[] myparams = new SqlParameter[2];
                myparams[0] = new SqlParameter("UserName", System.Data.SqlDbType.NVarChar, 50);
                myparams[0].Value = model.UserName;
                cmd.Parameters.Add(myparams[0]);
                myparams[1] = new SqlParameter("Password", System.Data.SqlDbType.NVarChar, 50);
                myparams[1].Value = model.Password;
                cmd.Parameters.Add(myparams[1]);

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
            public List<LoginVM> ListLogin(int userid)
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_GETSINGLEORALLLOGIN";

                LoginVM model = new LoginVM();

                List<LoginVM> lst = new List<LoginVM>();
                try
                {
                    using (SqlConnection conn = GetConnection())
                    {
                        cmd.Parameters.Add(new SqlParameter("@userid", SqlDbType.Int));
                        cmd.Parameters[0].Value = userid;
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {

                            while (rd.Read())
                            {
                                model.userid = Convert.ToInt32(rd["userid"]);
                                model.UserName = rd["UserName"].ToString();
                                model.Password = rd["Password"].ToString();
                                
                                lst.Add(model);
                                model = new LoginVM();


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
            public void EditLogin(Login model)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[SP_EDITLOGIN]";
                SqlParameter[] myparams = new SqlParameter[3];
                myparams[0] = new SqlParameter("@userid", System.Data.SqlDbType.Int);
                myparams[0].Value = model.userid;
                cmd.Parameters.Add(myparams[0]);
                myparams[1] = new SqlParameter("UserName", System.Data.SqlDbType.NVarChar, 50);
                myparams[1].Value = model.UserName;
                cmd.Parameters.Add(myparams[1]);
                myparams[2] = new SqlParameter("Password", System.Data.SqlDbType.NVarChar, 50);
                myparams[2].Value = model.Password;
                cmd.Parameters.Add(myparams[2]);


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

