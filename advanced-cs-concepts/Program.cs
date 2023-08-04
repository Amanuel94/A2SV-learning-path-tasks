using Tasks;
static class Program
    {


        private static void CheckInvalidInput<T>(string input, decimal? upperBound = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("Input cannot be empty.");
            }

            if (typeof(T) == typeof(decimal) || typeof(T) == typeof(Int32))
            {
                if (upperBound == null)
                {
                    throw new Exception("Upper bound cannot be null");
                }
                decimal output;
                if (decimal.TryParse(input, out output))
                {
                    if (!(output >= 0 && output <= upperBound))
                    {
                        throw new Exception($"The Input cannot be greater than {upperBound} and lower than 0.");
                    }

                }
                else
                {
                    throw new Exception("Input needs to be a number.");
                }
            }
        }

        // a method to continously prompt the user when there is an invalid input
        private static T DisplayPrompt<T>(string prompt, decimal? upperBound = null)
        {
            Console.Write($"{prompt}: ");
            string variable = Console.ReadLine().Trim();
            try
            {
                CheckInvalidInput<T>(variable, upperBound);
            }
            catch (Exception error)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.Message);
                Console.ResetColor();
                return DisplayPrompt<T>(prompt, upperBound);
            }

            return (T)Convert.ChangeType(variable, typeof(T));
        }



        static async System.Threading.Tasks.Task Main()
        {

            TaskManager MyTaskManager = new TaskManager();
            while(true){
                string prompt = "What do you want to do?"+
                                "\n\t 1. Add Task" +
                                "\n\t 2. Remove Task" +
                                "\n\t 3. Save Created Task to File" +
                                "\n\t 4. Read Tasks from File" +
                                "\n\t 5. Filter Tasks by Category" +
                                "\n\t 6. Update a task" +
                                "\n\t 7. Display your tasks" +
                                "\n\t 0. Exit\n";
                int choice = DisplayPrompt<int>(prompt, 7);

                switch (choice){

                    case 1: 
                            CreateTask(MyTaskManager);
                            break;
                    case 2: RemoveTask(MyTaskManager);
                            break;
                    case 3: await SaveTask(MyTaskManager);
                            break;
                    case 4: await ReadTask(MyTaskManager);
                            break;
                    case 5: FilterTasks(MyTaskManager);
                            break;
                    case 6: UpdateTask(MyTaskManager);
                            break;
                    case 7: MyTaskManager.DisplayTasks();
                            break;
                    case 0: Environment.Exit(0); 
                            break;
                }
            }


        }
        

        private static void UpdateTask(TaskManager myTaskManager){
            string prompt;
            prompt= "Enter the name of the task (name can not be modified)";
            string Name = DisplayPrompt<string>(prompt);
            prompt = "Choose the (new)type of the task"+
                                "\n\t 0. Personal" +
                                "\n\t 1. School" +
                                "\n\t 2. Work" +
                                "\n\t 3. Errands" +
                                "\n\t 4. Other\n"+
                    "Choose a number between 0 and 4";
                                ;

            int taskType = DisplayPrompt<int>(prompt, 4);
            prompt= "Enter the description of the task";
            string Description = DisplayPrompt<string>(prompt);

            prompt= "Is the task Completed? 1 for yes, 0 for no.";
            bool IsCompleted = DisplayPrompt<int>(prompt, 1)==1? true:false;

            myTaskManager.UpdateTask(Name, new Tasks.Task(){
                Name =Name,
                taskCategory = (Tasks.Task.TaskCategory)taskType,
                Description =Description,
                IsCompleted = false
            });
        }

        private static void CreateTask(TaskManager myTaskManager){
            string prompt;
            prompt= "Enter the name of the task";
            string Name = DisplayPrompt<string>(prompt);
            prompt = "Choose the type of the task"+
                                "\n\t 0. Personal" +
                                "\n\t 1. School" +
                                "\n\t 2. Work" +
                                "\n\t 3. Errands" +
                                "\n\t 4. Other\n"+
                    "Choose a number between 0 and 4";
                                ;

            int taskType = DisplayPrompt<int>(prompt, 4);
            prompt= "Enter the description of the task";
            string Description = DisplayPrompt<string>(prompt);

            myTaskManager.AddTask(new Tasks.Task(){
                Name =Name,
                taskCategory = (Tasks.Task.TaskCategory)taskType,
                Description =Description,
                IsCompleted = false
            });

        }


        private static void RemoveTask(TaskManager myTaskManager){
            string prompt;
            prompt= "Enter the name of the task";
            string TaskName = DisplayPrompt<string>(prompt);
            myTaskManager.DeleteTask(TaskName);
            
        }

        private static async Task<int> SaveTask(TaskManager myTaskManager){
            string prompt = "Enter the name of the csv you want to save the tasks to";
            string FilePath = DisplayPrompt<string>(prompt);
            int tasksWritten = await myTaskManager.WriteCSV($"{FilePath}.csv");
            Console.WriteLine($"{tasksWritten} tasks written to file");
            return 0;

        }

        private static async Task<int> ReadTask(TaskManager myTaskManager){
                string prompt = "Enter the name of the csv you want to read the tasks from";
                string FilePath = DisplayPrompt<string>(prompt);
                List<Tasks.Task> taskRead = await myTaskManager.ReadCSV($"{FilePath}.csv");
                
                prompt = $"{taskRead.Count()} tasks read from file. What do you want to do with these tasks" +
                                "\n\t 0. Overwrite current task list" +
                                "\n\t 1.Append to current task list";
                int choice = DisplayPrompt<int>(prompt, 1);
                if (choice == 1)
                    myTaskManager.MergeTasks(taskRead);
                else myTaskManager.MergeTasks(taskRead, true);
                return 0;
}

        private static void FilterTasks(TaskManager myTaskManager){
           string prompt = "Choose the type of the task you want to filter"+
                                "\n\t 0. Personal" +
                                "\n\t 1. School" +
                                "\n\t 2. Work" +
                                "\n\t 3. Errands" +
                                "\n\t 4. Other"+
                    "Choose a number between 0 and 4";
                                ;

            int taskType = DisplayPrompt<int>(prompt, 4);
            myTaskManager.Filter(taskType); 
        }
    
    }
