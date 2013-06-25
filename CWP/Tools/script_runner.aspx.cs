using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.SqlClient;

namespace LFS.Tools
{
	public partial class script_runner : System.Web.UI.Page
	{

		private string ConnectionString;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!(Convert.ToBoolean(Session["sgLFS_APP_ADMIN"])))
			{
				throw new Exception("You are not authorized to view this page. Contact your system administrator.");
			}

			AppSettingsReader appSettingReader = new AppSettingsReader();
			ConnectionString = appSettingReader.GetValue("ConnectionString", typeof(System.String)).ToString();
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		protected void btnExecuteDll_Click(object sender, System.EventArgs e)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = script.Text;
			SqlCommand command = new SqlCommand(commandText, connection);
			
			connection.Open();
			command.ExecuteNonQuery();
			connection.Close();
		}

		protected void btnExecuteNonQuery_Click(object sender, System.EventArgs e)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = script.Text;
			SqlCommand command = new SqlCommand(commandText, connection);
			
			connection.Open();
			int rowsAffected = command.ExecuteNonQuery();
			connection.Close();

			results.Text = "";
			results.Text = "Records affected = " + rowsAffected.ToString();
		}

		protected void btnExecuteReader_Click(object sender, System.EventArgs e)
		{
			SqlConnection connection = new SqlConnection(ConnectionString);

			string commandText = script.Text;
			SqlCommand command = new SqlCommand(commandText, connection);
			
			connection.Open();
			SqlDataReader dr = command.ExecuteReader();
			results.Text = "";
			while (dr.Read())
			{
				for (int i=0; i<dr.FieldCount; i++)
				{
					if (i<dr.FieldCount-1)
						results.Text += dr[i].ToString() + " - ";
					else
						results.Text += dr[i].ToString();
				}
				results.Text += "\n";
			}
			dr.Close();
			connection.Close();	
		}

		protected void btnClear_Click(object sender, System.EventArgs e)
		{
			script.Text = "";
			results.Text = "";
		}


	}
}
