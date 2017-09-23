﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split(' ');  //Вводим 2 числа в строку через пробел
            double dl = Convert.ToDouble(str[0]);  // dl - длина стороны квадрата 
            double r = Convert.ToDouble(str[1]);   // r - радиус круга
            double k, s, a, s1;
            if (r <= (dl / 2))  //Возможны 3 случая: круг лежит внутри квадрата, квадрат лежит внутри круга, круг и квадрат пересекаются, образуя 4 сегмента круга
                s = (Math.PI) * (r * r);  //1 случай: если круг лежит внутри квадрата, то козёл съест площадь травы размером с круг, т. е. PI*r*r 
            else if (r >= (dl * Math.Sqrt(2) / 2))
                s = dl * dl;  //2 случай: если квадрат лежит внутри круга, то козёл съест площадь травы размером с квадрат, т. е. dl*dl
            else                 //3 случай: если круг и квадрат пересекаются, то козёл съест травы размером с площадь круга минус 4 сегмента круга, образуемые при пересечении с квадратом
            {
                k = Math.Sqrt(r * r - (dl * dl) / 4);  //Рассмотрим один из сегментов круга. Проведём перп-ляр из центра круга к одной из сторон квадрата (он попадёт в центр стороны квадрата). Далее соединим центр круга с точками пересечения квадрата и круга, тем самым получив тр-ник, который вместе с сегментом образует сектор. k - половина основания этого равнобедренного тр-ка, один из катетов прямоугольного тр-ка. Найдём k по т. Пифагора
                a = Math.Atan(2*k/dl);  // a - половина угла, опирающегося на сегмент. Тангенс этого угла получим, разделив k на половину стороны квадрата (перп-ляр, проведённый из центра круга к одной из сторон квадрата. Угол a получим в радианах, найдя арктангенс от приведённых вычислений
                s1 = (r*r/2)*(2*a-Math.Sin(2*a));  // s1 - площадь одного сегмента, 2a - угол, опирающийся на сегмент. По данной формуле мы можем найти площадь сегмента через угол в радианах 
                s = Math.PI * r * r - 4 * s1;  // Искомую площадь съеденной травы найдём как площадь круга минус 4 площади сегмента (4*s1) 
            }
            Console.WriteLine("{0:F3}", s);  // Выводим найденный результат с точностью до трёх знаков после точки
        }
    }
}
