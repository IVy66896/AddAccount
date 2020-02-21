using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //DataTable dt = NPOIHelper.ReadExcelAsTableNPOI("niis.xls");
            var text = File.ReadAllText("aaa.txt",Encoding.UTF8);
            var ary = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for(int i=0;i<ary.Length;i++)
            {
                var iAry = ary[i].Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                //continue;

                SqlConnection db = new SqlConnection("Data Source=10.10.5.212;Initial Catalog=NIIS_User;User Id=hygip;Password=hyweb;");

                SqlCommand cmd = new SqlCommand("dbo.tttt", db);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LoginName", iAry[0]);
                cmd.Parameters.AddWithValue("@LoginPassword", iAry[1]);
                cmd.Parameters.AddWithValue("@UserName", iAry[2]);
                cmd.Parameters.AddWithValue("@RocID", iAry[3]);
                cmd.Parameters.AddWithValue("@PhoneNumber", iAry[4]);
                cmd.Parameters.AddWithValue("@Email", iAry[5]);
                cmd.Parameters.AddWithValue("@OrgID", iAry[6]);
                cmd.Parameters.AddWithValue("@RoleIDs", iAry[7]);

                //SqlParameter retValParam = cmd.Parameters.AddWithValue("", "");
                //retValParam.Direction = ParameterDirection.Output;

                try
                {
                    db.Open();
                    cmd.ExecuteNonQuery();
                    //Console.Write("取得的輸出資料: " + retValParam.Value);
                }
                catch (Exception ex)
                {
                    throw ex.GetBaseException();
                }
                finally
                {
                    db.Close();
                }
            }


            MessageBox.Show(text);
        }
    }
}
