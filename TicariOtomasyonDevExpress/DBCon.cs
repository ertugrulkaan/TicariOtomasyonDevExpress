using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicariOtomasyonDevExpress
{
    class DBCon
    {

        public SqlConnection DB()
        {
            SqlConnection constr = new SqlConnection(@"Data Source=DESKTOP-674NP11\SQLEXPRESS;Initial Catalog=TicariOtomasyon;Integrated Security=True");
            constr.Open();
            return constr;
        }
    }
}
