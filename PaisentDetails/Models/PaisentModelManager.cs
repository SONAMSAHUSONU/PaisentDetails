using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PaisentDetails.Models
{
    public class PaisentModelManager
    {

        

        public List<PaisentModel> GetPaisent()
        {
            List<PaisentModel> opaisentModel = new List<PaisentModel>();
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("SPGetPaisentDetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            PaisentModel paisentModel = new PaisentModel();
                            paisentModel.p_id = Convert.ToString(dr["p_id"]);
                            paisentModel.p_Fname = Convert.ToString(dr["p_Fname"]);
                            paisentModel.p_Lname = Convert.ToString(dr["p_Lname"]);
                            paisentModel.p_Mobile = Convert.ToString(dr["p_Mobile"]);
                            paisentModel.p_Age = Convert.ToString(dr["p_Age"]);
                            paisentModel.p_Email = Convert.ToString(dr["p_Email"]);
                           // paisentModel.BloodGroup=(dr["BloodGroup"]);

                            opaisentModel.Add(paisentModel);

                        }
                        dr.Close();


                    }
                    catch (Exception ex)
                    {
                        var excetion = ex;
                    }


                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }



                }
            }
            return opaisentModel;

        }

        public void InsertPaisent(PaisentModel paisentModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("SPInsertPaisentDetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@p_Fname", paisentModel.p_Fname);
                        cmd.Parameters.AddWithValue("@p_Lname", paisentModel.p_Lname);
                        cmd.Parameters.AddWithValue("@p_Mobile", paisentModel.p_Mobile);
                        cmd.Parameters.AddWithValue("@p_Age", paisentModel.p_Age);
                        cmd.Parameters.AddWithValue("@p_Email", paisentModel.p_Email);
                        cmd.Parameters.AddWithValue("@BloodGroup", paisentModel.BloodGroup);

                        cn.Open();
                        int count = cmd.ExecuteNonQuery();// if there data insert then here come  count one
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }

                }
            }

        }
        public void UpdatePaisent(PaisentModel paisentModel)
        {
            int count = 0;
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("SPUpdatePaisentDetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@p_id", paisentModel.p_id);
                        cmd.Parameters.AddWithValue("@p_Fname", paisentModel.p_Fname);
                        cmd.Parameters.AddWithValue("@p_Lname", paisentModel.p_Lname);
                        cmd.Parameters.AddWithValue("@p_Mobile", paisentModel.p_Mobile);
                        cmd.Parameters.AddWithValue("@p_Age", paisentModel.p_Age);
                        cmd.Parameters.AddWithValue("@p_Email", paisentModel.p_Email);
                        cmd.Parameters.AddWithValue("@BloodGroup", paisentModel.BloodGroup);

                        cn.Open();
                        count = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }

                }
            }
        }
        public void DeletePaisent(PaisentModel paisentModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("SPDeletePaisentDetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@p_id", paisentModel.p_id);
                        cn.Open();
                        int count = cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            {
            }
        }
        public PaisentModel SearchPaisent(PaisentModel OpaisentModel)
        {

            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSearchPaisentDetails", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@p_id", OpaisentModel.p_id);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            PaisentModel paisentModel = new PaisentModel();
                            paisentModel.p_id = Convert.ToString(dr["p_id"]);
                            paisentModel.p_Fname = Convert.ToString(dr["p_Fname"]);
                            paisentModel.p_Lname = Convert.ToString(dr["p_Lname"]);
                            paisentModel.p_Mobile = Convert.ToString(dr["p_Mobile"]);
                            paisentModel.p_Age = Convert.ToString(dr["p_Age"]);
                            paisentModel.p_Email = Convert.ToString(dr["p_Email"]);
                          //  paisentModel.BloodGroup = Convert.ToString(dr["BloodGroup"]);

                            return paisentModel;
                        }
                        dr.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return null;
        }
    }
}