using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2009M1HelloUWP.Utils
{
	public class ConectionHelper
	{
		private static String DatabaseServer = "localhost";
		private static String DatabaseName = "t2009m_student_manager";
		private static String DatabaseUsername = "root";
		private static String DatabasePasswrod = "";
		private static String ConectionString =
			$"Server={DatabaseServer};" +
			$"Database={DatabaseName};" +
			$"Uid={DatabaseUsername};" +
			$"Pwd={DatabasePasswrod};";
		private static MySqlConnection conection;

		public static MySqlConnection GetConection()
		{
			if (conection == null
				|| conection.State == System.Data.ConnectionState.Closed)
			{
				conection = new MySqlConnection(ConectionString);

			}
			return conection;
		}

        internal static IDisposable GetConnection()
        {
            throw new NotImplementedException();
        }
    }
}
