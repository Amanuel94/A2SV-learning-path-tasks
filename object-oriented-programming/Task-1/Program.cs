// using Tasks;
namespace Tasks
{
     class Program
    {


        static void PrintShapeArea(Shape _Shape)
        {

            Console.WriteLine("======================================");
            Console.WriteLine($"The name of the shape is {_Shape.Name}");
            Console.WriteLine($"The area of the shape is {_Shape.CalculateArea()}");
            Console.WriteLine("======================================");
        }



        static void Main()
        {
            Circle _Circle = new Circle(1.0, "Circle");
            Rectangle _Rectangle = new Rectangle(2.0, 3.0, "Rectnagle");
            Triangle _Triangle = new Triangle(3.0, 6.0, "Triangle");

            PrintShapeArea(_Circle);
            PrintShapeArea(_Rectangle);
            PrintShapeArea(_Triangle);

        }

}
}
