using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        //МОДИФИКАТОР ДОСТУПА ПИШЕМ ДЛЯ КАЖДОГО ПОЛЯ
        public struct Point
        {
            public double X { get; set; }//св-ва синтаксическая констукция объединения
            public double Y { get; set; }

            public Point(double x, double y)//использование свойств для целевых переменных
            {
                X = x;
                Y = y;
            }
        }
        //метод 
        public class DistanceCalculator
        {
            public static double CalculateDistance(Point p1, Point p2)
            {
                return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            }
            //Формула для расчёта расстояния между двумя точками,
            //координаты которых (x1, y1) и (x2, y2),
            //имеет вид: расстояние между двумя точками = √[(x2 - x1)2 + (y2 - y1)2]
            //класс Math.Он является статическим, поэтому все его методы также являются статическими.
            //Sqrt(double value): возвращает квадратный корень числа value
        }
        static void Main()
        {
            Point p1 = new Point(2.0, 2.0);//координаты первой точки x1 y1
            Point p2 = new Point(7.0, 3.0);//координаты второй точки x2 y2
            double distance = DistanceCalculator.CalculateDistance(p1, p2);
            Console.WriteLine($"Distance: {distance}");//вывод расстояния между точками
        }
    }
}


/*static void Main(string[] args)
{
    Point point = new Point();
    //point.SetX(2);   
    //point.SetY(3);   
    //point.Print();

    point.X = 7;
    point.Y = 8;
    Console.WriteLine($"Properties X={point.X} Y= {point.Y}");

}*/
