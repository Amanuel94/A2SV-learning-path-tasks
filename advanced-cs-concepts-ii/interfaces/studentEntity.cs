namespace Tasks{
public interface IStudent{

    public string Name{get; set;}
    public int Age{get; set;}
    public double GPA{get; set;}
    public int RollNo{get;}
    public bool Matches<Targ>(Targ query);
}
}