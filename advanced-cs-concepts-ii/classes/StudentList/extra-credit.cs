// contains functionalities mentioned for extra-credit for StudentList<T> class

using System.Collections;
using System.Linq;
using System.Text.Json;
namespace Tasks
{
    public partial class StudentList<T> : IEnumerable<T> where T : IStudent
    {
        public void UpdateStudent(int rollNo, string Name, int Age, double GPA)
        {
            T result = Search(rollNo, Verbose.None)[0];
            result.Name = Name;
            result.Age = Age;
            result.GPA = GPA;

            Console.WriteLine("Student data sucessfully updated");

        }

        public void SortStudentsByAge()
        {
            _StudentList.Sort((student1, student2) => student1.Age.CompareTo(student2.Age));
            ;
        }

        public void SortStudentsByName()
        {
            _StudentList.Sort((student1, student2) => student1.Name.CompareTo(student2.Name));

        }

        // can be implemented more efficiently
        public void RemoveStudent(int rollNo)
        {


            List<T> searchResult = Search(rollNo, Verbose.None);

            if (searchResult.Count > 0)
            {
                _StudentList.RemoveAll(student => student.RollNo == rollNo);
                Console.WriteLine("Student data successfully removed.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

    }
}