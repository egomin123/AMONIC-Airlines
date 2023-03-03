using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMONIC_Airlines.Classes
{
    public class ConnectToDB
    {
        public string ConnectionString { get; set; } = @"Persist Security Info=False;User ID=Last;Password=123123;Initial Catalog=Delfin;Data Source=LAPTOP-DOAF05I7";

        public void AddUser(User user)
        {
              if (CheckIfEmailIsNew(user.Email))
                {
                    string command = "USE Session1_12 " + $"EXEC [dbo].AddUser '{user.RoleID}','{user.Email}', '{user.Password}', '{user.FirstName}', '{user.LastName}', '{user.OfficeID}', '{user.Birthdate}', '{user.Active}'";
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                    {
                        conn.Open();
                        SqlCommand command1 = new SqlCommand(command, conn);
                        command1.ExecuteScalar();
                        conn.Close();
                    }
                    MessageBox.Show("Пользователь добавлен");
                }
                else
                {
                    MessageBox.Show("Пользователь с такой почтой уже существует");
                }
            
        }


        private bool CheckIfEmailIsNew(string email)
        {
            string command = "USE Session1_12 " + $"select* from Users WHERE Email = '{email}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<User> users = new List<User>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = reader.GetInt32(0);
                    users.Add(user);
                }
                reader.Close();
                conn.Close();
            }
            if (users.Count != 0)
                return false;
            else
                return true;
        }

        public List<User> GetUser()
        {
            // try
            // {
            string command = "USE Session1_12 " + $"select* from Users"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<User> users = new List<User>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = reader.GetInt32(0);
                    user.RoleID = reader.GetInt32(1);
                    user.Email = reader.GetString(2);
                    user.Password = reader.GetString(3);
                    user.FirstName = reader.GetString(4);
                    user.LastName = reader.GetString(5);
                    user.OfficeID = reader.GetInt32(6);
                    user.Birthdate = reader.GetDateTime(7);
                    user.Active = reader.GetBoolean(8);
                    if (user.RoleID == 1) user.Role = "administrator";
                    else if (user.RoleID == 2) user.Role = "office user";
                    if (user.OfficeID == 1) user.Office = "Abu dhabi";
                    else if (user.OfficeID == 3) user.Office = "Cairo";
                    else if (user.OfficeID == 4) user.Office = "Bahrain";
                    else if (user.OfficeID == 5) user.Office = "Doha";
                    else if (user.OfficeID == 6) user.Office = "Riyadh";

                    
                    users.Add(user);
                }
                reader.Close();
                conn.Close();
                return users;
            }
            //}
            //catch
            //{
            //    List<User> users = new List<User>();
            //    return users;
            //}
        }
        

        public List<User> GetUserWithOffice(int IDOffice)
        {
            // try
            // {
            string command = "USE Session1_12 " + $"select* from Users Where OfficeID = {IDOffice}"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            List<User> users = new List<User>();
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.ID = reader.GetInt32(0);
                    user.RoleID = reader.GetInt32(1);
                    user.Email = reader.GetString(2);
                    user.Password = reader.GetString(3);
                    user.FirstName = reader.GetString(4);
                    user.LastName = reader.GetString(5);
                    user.OfficeID = reader.GetInt32(6);
                    user.Birthdate = reader.GetDateTime(7);
                    user.Active = reader.GetBoolean(8);
                    if (user.RoleID == 1) user.Role = "administrator";
                    else if (user.RoleID == 2) user.Role = "office user";
                    if (user.OfficeID == 1) user.Office = "Abu dhabi";
                    else if (user.OfficeID == 3) user.Office = "Cairo";
                    else if (user.OfficeID == 4) user.Office = "Bahrain";
                    else if (user.OfficeID == 5) user.Office = "Doha";
                    else if (user.OfficeID == 6) user.Office = "Riyadh";


                    users.Add(user);
                }
                reader.Close();
                conn.Close();
                return users;
            }
            //}
            //catch
            //{
            //    List<User> users = new List<User>();
            //    return users;
            //}
        }

        public List<User> GetUsersByLogin(string UserLogin)
        {
           // try
           // {
                string command = "USE Session1_12 " + $"select* from Users WHERE Email = '{UserLogin}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
                List<User> users = new List<User>();
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                    while (reader.Read())
                    {
                        User user = new User();
                        user.ID = reader.GetInt32(0);
                        user.RoleID = reader.GetInt32(1);
                        user.Email = reader.GetString(2);
                        user.Password = reader.GetString(3);
                        user.FirstName = reader.GetString(4);
                        user.LastName = reader.GetString(5);
                        user.OfficeID = reader.GetInt32(6);
                        user.Birthdate = reader.GetDateTime(7);
                        user.Active = reader.GetBoolean(8);
                        users.Add(user);
                    }
                    reader.Close();
                    conn.Close();
                    return users;
                }
        }

        public void ChangeActive(User user)
        {

            string command = "USE Session1_12 " + $"EXEC [dbo].EditUser '{user.RoleID}','{user.Email}', '{user.Password}', '{user.FirstName}', '{user.LastName}', '{user.OfficeID}', '{user.Birthdate}', '{user.Active}', {user.ID}";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }

        }

        public void ChangeRole(User user)
        {

            string command = "USE Session1_12 " + $"EXEC [dbo].EditUser '{user.RoleID}','{user.Email}', '{user.Password}', '{user.FirstName}', '{user.LastName}', '{user.OfficeID}', '{user.Birthdate}', '{user.Active}', {user.ID}";
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command1 = new SqlCommand(command, conn);
                command1.ExecuteScalar();
                conn.Close();
            }

        }

        public User GetUsersForLogin(string UserLogin)
        {
            string command = "USE Session1_12 " + $"select* from Users WHERE Email = '{UserLogin}'"; //для многого where пишешь ещё AND и после название переменной = '{переменная}'
            using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                User user = new User();
                conn.Open();
                SqlDataReader reader = new SqlCommand(command, conn).ExecuteReader();
                while (reader.Read())
                {
                    user.ID = reader.GetInt32(0);
                    user.RoleID = reader.GetInt32(1);
                    user.Email = reader.GetString(2);
                    user.Password = reader.GetString(3);
                    user.FirstName = reader.GetString(4);
                    user.LastName = reader.GetString(5);
                    user.OfficeID = reader.GetInt32(6);
                    user.Birthdate = reader.GetDateTime(7);
                    user.Active = reader.GetBoolean(8);
                }
                reader.Close();
                conn.Close();
                return user;
            }
        }

        
    }
}
