// See https://aka.ms/new-console-template for more information
using Tasks;
Student student1 = new("Bmanuel Tewodros1", 21, 4.1);
Student student2 = new("Amanuel Tewodros2", 21, 4.1);
Student student3 = new("Cmanuel Tewodros3", 23, 4.1);
Student student4 = new("Amanuel Tewodros4", 21, 4.1);
Student student5 = new("Amanuel Tewodros5", 12, 4.1);

StudentList<Student> list =  new();
list.AddStudent(student1);
list.AddStudent(student2);
list.AddStudent(student3);
list.AddStudent(student4);
list.AddStudent(student5);

// display
list.DisplayStudents();

// search by name and age;
Console.WriteLine(list.Search("Amanuel Tewodros1"));
Console.WriteLine(list.Search(2));

// serialization
await list.ToJsonAsync("serialized/student_list.json");
// deserialization
List<Student>? mylist = await list.DeserializeAsync<Student>("serialized/student_list.json");
list.DisplayStudents(mylist);

// update students
list.UpdateStudent(3, "Alula Kebde", 11, 4.0);

// sort students
list.SortStudentsByAge();
list.DisplayStudents();
list.SortStudentsByName();
list.DisplayStudents();

// remove student
list.RemoveStudent(3);
list.DisplayStudents();


