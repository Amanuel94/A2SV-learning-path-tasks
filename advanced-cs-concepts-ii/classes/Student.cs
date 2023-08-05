using System.Text;
using System.Text.Json.Serialization;

namespace Tasks
{
    public class Student : IStudent
    {

        // a static variable for auto-increment
        static int counter = 1;

        // properties are made public for serialization demonstration
        public string Name { get; set; }
        public int Age { get; set; }

        private readonly int rollNo;
        public int RollNo{
            get{
                return rollNo;
            }
        }
        public double GPA{get; set;}

        public Student(string Name, int age, double gpa)
        {
            this.Name = Name;
            this.Age = age;
            this.rollNo = counter++;
            this.GPA = gpa;
        }

    [JsonConstructor]
        public Student(string Name, int age, double gpa, int RollNo)
        {
            this.Name = Name;
            this.Age = age;
            this.rollNo = RollNo;
            this.GPA = gpa;
        }

        public override string ToString()
        {
            const int padding = -20;
            return $"{rollNo, padding+10}{Name,padding}{Age, padding}{GPA, padding}";
        }
        public bool Matches<Targ>(Targ query)
        {
            // if query is int, the match is automatically done with the student id
            // else is done with the student name
            return query switch
            {
                int intValue when typeof(Targ) == typeof(int) => intValue == rollNo,
                string strValue when typeof(Targ) == typeof(string) => strValue == Name,
                _ => throw new NotSupportedException($"Matching for type {typeof(Targ)} is not supported."),
            };
        }



    }
}