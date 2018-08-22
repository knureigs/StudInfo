using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace StudInfo
{
    /// <summary>
    /// Класс, реализующий доступ к базам данных.
    /// </summary>
    public static class DBProvider
    {
        /// <summary>
        /// Сохранение в отдельной БД обработанных данных стипендиального рейтинга.
        /// </summary>
        /// <param name="path">Путь к файлу БД.</param>
        /// <param name="students">Коллекция экземпляров класса Student.</param>
        public static void CreateRatingDB(string path, IReadOnlyList<Student> students)
        {
            string connectionString = string.Format("data source={0};New=True;UseUTF16Encoding=True", path);
            SQLiteConnection connect = new SQLiteConnection(connectionString);

            try
            {
                connect.Open();
                
                string sqlCreateTable = "CREATE TABLE Rating(Surname TEXT, FName TEXT, SName TEXT, Rate TEXT, StudGroup TEXT, Addition TEXT)";
                SQLiteCommand cmdCreate = new SQLiteCommand(sqlCreateTable, connect);
                cmdCreate.ExecuteNonQuery();

                foreach (Student student in students)
                {
                    string sqlInsert = "INSERT INTO Rating VALUES(@surname,@fname,@sname,@rate,@group,@addition)";
                    SQLiteCommand cmdInsert = new SQLiteCommand(sqlInsert, connect);
                    cmdInsert.Parameters.AddWithValue("@surname", student.Surname);
                    cmdInsert.Parameters.AddWithValue("@fname", student.FName);
                    cmdInsert.Parameters.AddWithValue("@sname", student.SName);
                    cmdInsert.Parameters.AddWithValue("@rate", student.Rate);
                    cmdInsert.Parameters.AddWithValue("@group", student.Group);
                    cmdInsert.Parameters.AddWithValue("@addition", student.Addition);

                    cmdInsert.ExecuteNonQuery();
                }
            }
            catch (Exception error)
            {
                //Console.WriteLine(error.Message.ToString());
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// Возвращает коллекцию объектов, описывающих студентов по данным стипендиального рейтинга.
        /// </summary>
        /// <param name="path">Путь к файлу БД.</param>
        /// <returns>Коллекция экземпляров класса Student.</returns>
        //public static IReadOnlyList<Student> GetStudents(string path)
        public static List<Student> GetStudents(string path)
        {
            List<Student> students = new List<Student>();

            string connectionString = string.Format("data source={0};New=True;UseUTF16Encoding=True", path);
            SQLiteConnection connect = new SQLiteConnection(connectionString);
            try
            {
                connect.Open();

                string sqlSelect = "SELECT * FROM Rating";
                SQLiteCommand cmdSelect = new SQLiteCommand(sqlSelect, connect);

                using (SQLiteDataReader dr = cmdSelect.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Student student = new Student(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
                        students.Add(student);
                    }
                }
            }
            catch (Exception error)
            {
                //Console.WriteLine(error.Message.ToString());
            }
            finally
            {
                connect.Close();
            }

            //return students.AsReadOnly();
            return students;
        }
    }
}
