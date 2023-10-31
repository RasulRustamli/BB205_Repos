namespace Open_Closed
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Circle circle = new Circle();
            circle.Radius = 5;
            AreaCalculate areaCalculate = new AreaCalculate();
            Console.WriteLine(areaCalculate.AreaCalculator(circle));
        }
    }
}