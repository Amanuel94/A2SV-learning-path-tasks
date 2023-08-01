namespace Tasks{

    public class StudentGradeCalculator{

        private Dictionary<string, Dictionary<string, decimal>> _studentData;

        public StudentGradeCalculator(){
            _studentData = new Dictionary<string, Dictionary<string, decimal>>();
            
        }

        // checks if the input is valid based on the type of input
        private void CheckInvalidInput<T>(string input, decimal? upperBound = null){
            if(string.IsNullOrEmpty(input)){
                throw new Exception("Input cannot be empty.");
            }

            if(typeof(T) == typeof(decimal) || typeof(T) == typeof(Int32)){
                if(upperBound == null){
                    throw new Exception("Upper bound cannot be null");
                }
                decimal output;
                if (decimal.TryParse(input, out output)){
                    if (!(output >= 0 && output <= upperBound)){
                        throw new Exception($"The Input cannot be greater than {upperBound} and lower than 0.");
                    }
    
                }
                else{
                    throw new Exception("Input needs to be a number.");
                }
            }
        }

        // a method to continously prompt the user when there is an invalid input
        private T DisplayPrompt<T>(string prompt, decimal? upperBound = null){
            Console.Write($"{prompt}: ");
            string variable = Console.ReadLine().Trim();
            try{
                CheckInvalidInput<T>(variable, upperBound);
            }
            catch(Exception error){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message);
                Console.ResetColor();
                return DisplayPrompt<T>(prompt, upperBound);
            }

            return (T)Convert.ChangeType(variable, typeof(T));
        }

        public void EnterGrades(){

            // if invalid input is entered, keep prompting the user to enter a valid input
            string _studentName = DisplayPrompt<string>("Please enter a valid student name");
            Dictionary<string, decimal> _allGrades = new Dictionary<string, decimal>();

            int _nCourses = DisplayPrompt<int>($"Please enter the number of the courses {_studentName} is taking", 10);    
            do{
                string courseName = DisplayPrompt<string>($"Enter the name of the course {_studentName} taking");
                decimal courseGrade = DisplayPrompt<decimal>($"Enter {_studentName}'s grade on \"{courseName}\": ", 100) ;              
                _allGrades[courseName] = courseGrade;
                _nCourses--;
            }
            while(_nCourses > 0);
            _studentData[_studentName] = _allGrades;
        }

        private decimal CalculateAverageGrade(Dictionary<string, decimal> grades){
            decimal sumOfGrades = 0;
            foreach (var grade in grades)
            {
                sumOfGrades+=grade.Value;
            }
            return sumOfGrades/grades.Count;    
        }

        public void DisplayStudentGrade(){
            
            foreach (var _studentDatum in _studentData)
            {
                
                Console.WriteLine($"Name of the student: {_studentDatum.Key}");
                Console.WriteLine($"Courses\t|\tGrade");
                foreach (var grade in _studentDatum.Value){
                    Console.WriteLine($"{grade.Key}\t|\t{grade.Value}");
                }
                Console.WriteLine($"Avrage Grade: {this.CalculateAverageGrade(_studentDatum.Value)}");
               Console.WriteLine("========================================================="); 
            }
        }



    }

}