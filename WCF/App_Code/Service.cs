using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	SqlConnection con = new SqlConnection(@"server=DESKTOP-8EGJO2M\SQLEXPRESS;database=Project;integrated security=true");
	public int checkbalance(int Acco_No,int Id)
    {
		int bal=0 ; 
		string s = "select Balance from BankAccount where Account_No=" + Acco_No + " and User_Id="+Id+"";
		SqlCommand cmd = new SqlCommand(s, con);
		con.Open();
		SqlDataReader dr = cmd.ExecuteReader();
		while (dr.Read())
        {
			bal = Convert.ToInt32(dr["Balance"].ToString());
		}
		con.Close();

		return bal;
    }

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
}
