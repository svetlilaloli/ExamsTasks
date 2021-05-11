using System.Collections.Generic;
using System.Text;

namespace Classroom
{
    public class Classroom
    {
        private readonly List<Student> students;

        public int Capacity { get; }
        public int Count => students.Count;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>(capacity);
        }

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            Student found = students.Find(s => s.FirstName == firstName && s.LastName == lastName);

            if (found != null)
            {
                students.Remove(found);
                return $"Dismissed student {found.FirstName} {found.LastName}";
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            var stSubject = students.FindAll(s => s.Subject == subject);
            if (stSubject.Count > 0)
            {
                StringBuilder result = new StringBuilder();
                result.Append($"Subject: {subject}\nStudents:");
                foreach (Student student in stSubject)
                {
                    result.Append($"\n{student.FirstName} {student.LastName}");
                }
                return result.ToString();
            }
            return "No students enrolled for the subject";
        }
        public int GetStudentsCount()
        {
            return Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            return students.Find(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
