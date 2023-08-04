namespace Tasks
{




    public class Task
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TaskCategory taskCategory { get; set; }
        public bool IsCompleted;

        public override string ToString()
        {
            return $"{Name}\t{Description}\t{(int)taskCategory}\t{IsCompleted}";
        }
        public string Show()
        {
            return $"{Name}\t{Description}\t{taskCategory}\t{IsCompleted}";
        }

        public enum TaskCategory
        {
            Personal = 0,
            School = 1,
            Work = 2,
            Errands = 3,
            Other = 4

        }
    }



}

