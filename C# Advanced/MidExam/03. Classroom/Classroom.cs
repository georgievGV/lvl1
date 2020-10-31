using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        List<Student> students;

        public Classroom(int capacity)
        {
            Capacity = capacity;
            this.students = new List<Student>();
        }

        public int Capacity { get; set; }

        public int Count { get { return this.students.Count; } }

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (this.students.Exists(x => x.FirstName == firstName && x.LastName == lastName))
            {
                Student dismissedOne = this.students.First(x => x.FirstName == firstName && x.LastName == lastName);
                this.students.Remove(dismissedOne);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> orderedBySubject = this.students.Where(x => x.Subject == subject).ToList();
            if (orderedBySubject.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Subject: {subject}");
            result.AppendLine("Students:");
            foreach (var student in orderedBySubject)
            {
                result.AppendLine($"{student.FirstName} {student.LastName}");
            }

            return result.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        {
            return Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student theOne = this.students.FirstOrDefault(x => x.FirstName == firstName
            && x.LastName == lastName);
            return theOne;
        }
    }
}
