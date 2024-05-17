using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudentPortal.DataAccessLayer
{
    public class StudentDBLayer
    {
        private string myConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<Student> GetAllStudents()
        {
            List<Student> studentList = new List<Student>();

            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                SqlCommand selectCommend = new SqlCommand("GetAllStudents", connection);
                connection.Open();

                SqlDataReader reader = selectCommend.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Age = Convert.ToInt32(reader["Age"]);
                    student.Email = reader["Email"].ToString();
                    student.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
                    student.Address = reader["Address"].ToString();
                    switch (reader["Gender"].ToString().ToUpper())
                    {
                        case "M":
                            student.Gender = "Male";
                            break;
                        case "F":
                            student.Gender = "Female";
                            break;
                    }
                    student.Standard = Convert.ToInt32(reader["Standard"]);
                    student.Course = reader["CourseName"].ToString();
                    student.Password = reader["Password"].ToString();

                    studentList.Add(student);
                }
                reader.Close();
            }
            return studentList;
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                SqlCommand insertCommand = new SqlCommand("AddStudentData", connection);
                insertCommand.CommandType = CommandType.StoredProcedure;
                insertCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                insertCommand.Parameters.AddWithValue("@LastName", student.LastName);
                insertCommand.Parameters.AddWithValue("@Age", student.Age);
                insertCommand.Parameters.AddWithValue("@Email", student.Email);
                insertCommand.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt64(student.PhoneNumber));
                insertCommand.Parameters.AddWithValue("@Address", student.Address);
                insertCommand.Parameters.AddWithValue("@Gender", student.Gender);
                insertCommand.Parameters.AddWithValue("@Standard", student.Standard);
                insertCommand.Parameters.AddWithValue("@CourseId", Convert.ToInt32(student.Course));
                insertCommand.Parameters.AddWithValue("@Password", student.Password);

                connection.Open();
                insertCommand.ExecuteNonQuery();
            }
        }

        public void EditStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                SqlCommand updateCommand = new SqlCommand("UpdateStudentData", connection);
                updateCommand.CommandType = CommandType.StoredProcedure;
                updateCommand.Parameters.AddWithValue("@Id", student.Id);
                updateCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                updateCommand.Parameters.AddWithValue("@LastName", student.LastName);
                updateCommand.Parameters.AddWithValue("@Age", student.Age);
                updateCommand.Parameters.AddWithValue("@Email", student.Email);
                updateCommand.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                updateCommand.Parameters.AddWithValue("@Address", student.Address);
                updateCommand.Parameters.AddWithValue("@Gender", student.Gender);
                updateCommand.Parameters.AddWithValue("@Standard", student.Standard);
                updateCommand.Parameters.AddWithValue("@CourseId", student.Course);
                updateCommand.Parameters.AddWithValue("@Password", student.Password);
                connection.Open();
                updateCommand.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int Id)
        {
            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                SqlCommand deleteCommand = new SqlCommand("DeleteStudentData", connection);
                deleteCommand.CommandType = CommandType.StoredProcedure;
                deleteCommand.Parameters.AddWithValue("@Id", Id);
                connection.Open();
                deleteCommand.ExecuteNonQuery();
            }
        }

        public List<Student> GetStudentsWithSearch(string searchParam)
        {
            List<Student> studentList = new List<Student>();

            using (SqlConnection connection = new SqlConnection(myConnectionString))
            {
                SqlCommand selectCommend = new SqlCommand("SearchByName", connection);
                selectCommend.CommandType = CommandType.StoredProcedure;
                selectCommend.Parameters.AddWithValue("@search", searchParam);
                connection.Open();

                SqlDataReader reader = selectCommend.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Age = Convert.ToInt32(reader["Age"]);
                    student.Email = reader["Email"].ToString();
                    student.PhoneNumber = Convert.ToDouble(reader["PhoneNumber"]);
                    student.Address = reader["Address"].ToString();
                    switch (reader["Gender"].ToString().ToUpper())
                    {
                        case "M":
                            student.Gender = "Male";
                            break;
                        case "F":
                            student.Gender = "Female";
                            break;
                    }
                    student.Standard = Convert.ToInt32(reader["Standard"]);
                    student.Course = reader["CourseName"].ToString();
                    student.Password = reader["Password"].ToString();

                    studentList.Add(student);
                }
                reader.Close();
            }
            return studentList;
        }
    }
}