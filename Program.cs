using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Users
            clsUser.Users.Add(new clsUser
            {
                UserID = 1,
                Username = "student1",
                Password = "123",
                IsActive = true,
                RoleID = 1
            });

            clsUser.Users.Add(new clsUser
            {
                UserID = 2,
                Username = "teacher1",
                Password = "123",
                IsActive = true,
                RoleID = 2
            });

            clsUser.Users.Add(new clsUser
            {
                UserID = 3,
                Username = "admin1",
                Password = "123",
                IsActive = true,
                RoleID = 3
            });

            // Students
            clsStudent.Students.Add(new clsStudent
            {
                UserID = 1,
                FirstName = "Ali",
                LastName = "Hassan",
                Age = 20,
                Gender = "Male"
            });

            // Teachers
            clsTeacher.Teachers.Add(new clsTeacher
            {
                UserID = 2,
                FirstName = "Sara",
                LastName = "Ahmed",
                Age = 35,
                Gender = "Female"
            });

            var resultUser = clsUser.LoginAsAdmin("admin1", "123");
            if (resultUser != null)
            {
                Console.WriteLine("Admin: " + resultUser.Username);
            }
            else
            {
                Console.WriteLine("Invalid admin credentials.");
            }

            clsStudent student = new clsStudent();
            var resultStudent = student.Login("student1", "1234");

            if (resultStudent != null)
            {
                var s = (clsStudent)resultStudent;
                Console.WriteLine("Student: " + s.FullName);
            }
            else
            {
                Console.WriteLine("Invalid student credentials.");
            }

                clsTeacher teacher = new clsTeacher();
            var resultTeacher = teacher.Login("teacher1", "123");

            if (resultTeacher != null)
            {
                var t = (clsTeacher)resultTeacher;
                Console.WriteLine("Teacher: " + t.FullName);
            }
            else
            {
                Console.WriteLine("Invalid teacher credentials.");
            }


            Console.ReadKey();

        }
    }
}
