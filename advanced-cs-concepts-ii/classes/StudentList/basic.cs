// contains basic functionalities for StudentList<T> class

using System.Collections;
using System.Linq;
using System.Text.Json;
namespace Tasks
{
    public partial class StudentList<T> : IEnumerable<T> where T : IStudent
    {
        public void AddStudent(T student) => _StudentList.Add(student);
        public void DisplayStudents(List<T> studentList)
        {
            const int padding = -20;
            Console.WriteLine($"{"Roll-No",padding + 10}{"Student name",padding}{"Age",padding}{"GPA",padding}");
            foreach (var student in studentList)
            {
                Console.WriteLine(student);
            }
        }
        public void DisplayStudents() => DisplayStudents(_StudentList);

        // search overloaded by type; if Targ is int, search is done with ID else if string done by name
        public List<T> Search<Targ>(Targ query, Verbose verobose = Verbose.Show)
        {
            List<T> matchingResults = new();
            try
            {
                matchingResults.AddRange(from student in _StudentList where student.Matches(query) select student);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine($"{typeof(Targ)} is not supported with search");
                throw new Exception(INVALID_INPUT_ERROR_MSG);
            }


            if((int)verobose == 1){
            Console.WriteLine($"{matchingResults.Count} results found for query:");
            if (matchingResults.Count > 0) DisplayStudents(matchingResults);
            }
            return matchingResults;
        }
    }
}