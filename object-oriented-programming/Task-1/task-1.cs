namespace Tasks{

    public class Shape{

        internal string Name{get; init;}
        protected Shape(string Name){
            this.Name = Name;
        }
        
        internal virtual double CalculateArea(){
            return 1;
        }
    }

    public class Circle: Shape{

        private double Radius;
        internal Circle(double Radius, string Name): base(Name){
            this.Radius = Radius;
        }
        internal override double CalculateArea()
        {
            return Math.PI*Radius*Radius;
        }
    }

    public class Rectangle: Shape{
        private double Width{get; init;}
        private double Height {get; init;}

        public Rectangle(double Height, double Width, string Name): base(Name){
            this.Width = Width;
            this.Height = Height;
        }
        internal override double CalculateArea()
        {
            return Width*Height;
        }

    }

    public class Triangle: Shape{
        private double Base {get; init;}
        private double Height{get; init;}

        public Triangle(double Base, double Height, string Name): base(Name){
            this.Base = Base;
            this.Height = Height;
        }

        internal override double CalculateArea()
        {
            return 0.5*Base*Height;
        }

    }


}