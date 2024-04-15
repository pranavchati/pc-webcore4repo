using PC_WebApp4.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PC_WebApp4.Services
{
    public class CourseService
    {
        //private static string db_source = "pc-dbserver.database.windows.net";
        //private static string db_user  = "sqluser";
        //private static string db_password = "Welcome@az4321";
        //private static string db_database = "PC-WebApp2DB";

        private SqlConnection GetConnection(string connection_string)
        {

            //var builder = new SqlConnectionStringBuilder();
            //builder.DataSource = db_source;
            //builder.UserID = db_user;
            //    builder.Password = db_password;
            //builder.InitialCatalog = db_database;
            return new SqlConnection(connection_string);

        
        }

        public IEnumerable<Course> GetCourses(string connection_string) { 
        
        List<Course> _lst = new List<Course>();
            string _statement = "Select CourseId, CourseName, Rating from Course";
            SqlConnection _connection = GetConnection(connection_string);
            _connection.Open();
            SqlCommand _sqlcommand = new SqlCommand(_statement, _connection);
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read()) 
                {
                    Course _course = new Course()
                    {
                        CourseID = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)

                    };
                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }

    }
}
