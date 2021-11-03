using DocuSign.eSign.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2009M1HelloUWP.Entitis;
using T2009M1HelloUWP.Utils;

namespace T2009M1HelloUWP.Models
{
	public class StudenModel
	{

		private static string InsertCommand =
		"insert into students" +
		"username, full_name, password, email,)" +
		"values" +
		"(@username,@fullName, @password,@email)";
		private static string SelecCommand = "select*from students";

		public bool Save(Student student)
		{
			using (var conection = ConectionHelper.GetConnection())
			{
				conection.Dispose();
				var mysqlCommand = new MySqlCommand(InsertCommand, (MySqlConnection)conection);
				mysqlCommand.Parameters.AddWithValue("@username", student.Username);
				mysqlCommand.Parameters.AddWithValue("@password", student.Password);
				mysqlCommand.Parameters.AddWithValue("@fullname", student.Fullname);
				mysqlCommand.Parameters.AddWithValue("@email", student.Email);

				//thuc thi
				mysqlCommand.ExecuteNonQuery();
				Console.WriteLine("Lưu Sinh viên thanh công");
				return true;
			}
			return false;
		}

		public List<Student> FindAll()// có hay không có dữ liệu cũng trae về một list rỗng 
		{
			// tạo danh sách rỗng.
			List<Student> result = new List<Student>();
			using (var conection = ConectionHelper.GetConection())
			{
				//mở kết nối
				conection.Open();
				//tạo câu lệnh truy vấn từ kết nối ở trên.
				var mysqlCommand = new MySqlCommand(SelecCommand, conection);
				//thực thi, lấy dữ liệu trả về.
				var reader = mysqlCommand.ExecuteReader(); // resultset (java)
				while (reader.Read())
				{
					var username = reader.GetString("username");
					var password = reader.GetString("password");
					var fullname = reader.GetString("full_name");
					var email = reader.GetString("email");

					//tạo ra đối tượng student từ giá trị lấy về.
					var student = new Student
					{
						Username = username,
						Password = password,
						Fullname = fullname,
						Email = email,
					};
					//add vào danh sách trả về.
					result.Add(student);
				}
			}
			//trong trường hợp không có dữ liệu thì trả về danh sách rỗng.
			return result;
		}
	}
}