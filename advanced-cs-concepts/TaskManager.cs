using System.Linq;
namespace Tasks
{
    public class TaskManager
    {
        List<Tasks.Task> TaskList { get; set; }

        public TaskManager()
        {
            TaskList = new List<Tasks.Task>();
        }

        public void AddTask(Tasks.Task task) => TaskList.Add(task);

        public void Filter(int query)
        {
            List<Tasks.Task> matchingResults = TaskList.Where(task => task.taskCategory == (Tasks.Task.TaskCategory)query).ToList();
            Console.WriteLine($"{matchingResults.Count()} matching results found:");
            DisplayTasks(matchingResults);
        }

        public void DisplayTasks(List<Tasks.Task> taskList)
        {
            Console.WriteLine("Name\tDescription\tCategory\tCompleted");
            taskList.ForEach(task => Console.WriteLine(task.Show()));
        }
        public void DisplayTasks() => DisplayTasks(TaskList);
        public void UpdateTask(string oldTaskName, Tasks.Task newTask)
        {
            Tasks.Task oldTask = TaskList[SelectTask(oldTaskName)];
            for (int i = 0; i < TaskList.Count(); i++)
            {
                if (TaskList[i] == oldTask)
                {
                    TaskList[i] = newTask;
                }
            }
        }

        public async Task<List<Tasks.Task>> ReadCSV(string FilePath)
        {
            List<Tasks.Task> tasksFromFile = new List<Tasks.Task>();
            try{
            using (StreamReader reader = new StreamReader(FilePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string? line = await reader.ReadLineAsync();
                        string[] values;

                        if(line is not null)
                            values = line.Split('\t');
                        else
                            throw new ArgumentOutOfRangeException();

                        string taskName = values[0];
                        string Description = values[1];
                        Tasks.Task.TaskCategory taskCategory = (Tasks.Task.TaskCategory)Int32.Parse(values[2]);
                        bool IsCompleted = (values[3].ToLower().Equals("true")) ? true : false;

                        Tasks.Task readTask = new Tasks.Task() { Name = taskName, Description = Description, taskCategory = taskCategory, IsCompleted = IsCompleted };
                        tasksFromFile.Add(readTask);

                    }
                }
            }catch(ArgumentOutOfRangeException){
                Console.WriteLine("Invalid format detected in csv file. Aborting Operation");
            }catch(NullReferenceException){
                Console.WriteLine("Error occured while reading csv. Aborting operation");
            }catch(FileNotFoundException){
                Console.WriteLine("Could not locate file from FilePath. Aborting operation");
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return tasksFromFile;            

        }

        public async Task<int> WriteCSV(string FilePath)
        {
            int tasksWritten = 0;
            try{
            using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    foreach (var task in TaskList)
                    {
                        await writer.WriteLineAsync(task.ToString());
                        tasksWritten++;
                    }
                }
            
            }catch(NullReferenceException){
                Console.WriteLine("Error occured while reading csv. Aborting operation");
            }catch(FileNotFoundException){
                Console.WriteLine("Could not locate file from FilePath. Aborting operation");
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return tasksWritten;
        }

        public int SelectTask(string name){
            for (int i = 0; i < TaskList.Count; i++)
            {
             if(TaskList[i].Name == name){
                return i;
             } 
            }
            return -1;
        }     
        public void DeleteTask(string TaskName){
            int index = SelectTask(TaskName);
            if(index != -1){
                TaskList.RemoveAt(index);
            }
            else{
                Console.WriteLine("Task not found.");
            }

        }

        public void MergeTasks(List<Tasks.Task> tasks, bool overwrite = false){
            if(overwrite){
                TaskList.Clear();
            }
            TaskList.AddRange(tasks);
        }
        
    }
}