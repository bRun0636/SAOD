using System;
using System.Collections.Generic;
using System.Linq;

class BoxPlot
{
    public List<double> values;

    public BoxPlot(List<double> data)
    {
        if (data == null || data.Count == 0)
        {
            Console.WriteLine("ошибочка ребята");
        }

        values = data;
        values.Sort();
    }
    
    public double Min()
    {
        return values.First();
      
    }

    public double lq() // нижний квартиль
    {
        int n = values.Count;
        int index = (int)Math.Floor(0.25 * (n + 1)) - 1;
        return (values[index] + values[index + 1]) / 2.0;
    }

    public double Median()
    {
        int n = values.Count;
        if (n % 2 == 0)
        {
            int index1 = n / 2 - 1;                  // Если количество элементов четное, берется среднее значение двух центральных элементов.
            int index2 = n / 2;
            return (values[index1] + values[index2]) / 2.0;
        }
        else
        {
            return values[n / 2];
        }
    }

    public double Mean()
    {
        return values.Sum() / values.Count;       // sr znach
    }

    public double StdDev()
    {
        double mean = Mean();
        double sumSquaredDiff = values.Sum(x => Math.Pow(x - mean, 2));   // stan otkl 
        return Math.Sqrt(sumSquaredDiff / values.Count);
    }

    public double uq()
    {
        int n = values.Count;
        int index = (int)Math.Ceiling(0.75 * (n + 1)) - 1;              // up qwartil
        return (values[index] + values[index + 1]) / 2.0;
    }

    public double Max()
    {
        return values.Last();
    }

    public List<double> Outliers()//vibrosi
    {
        double iqr = uq() - lq();
        double lowerBound = lq() - 1.5 * iqr;         //Вычисляет нижнюю и верхнюю границы, и затем возвращает значения, выходящие за эти границы.
        double upperBound = uq() + 1.5 * iqr;

        return values.Where(x => x < lowerBound || x > upperBound).ToList();
    }
}

class Program
{
    static void Main()
    {
        List<double> data = new List<double> { 0.0855298042e+00, 1.4513241053e+00, 1.3237277269e+00, 1.0128350258e+00, 1.4122089148e+00, 6.5826654434e-01, 2.0795986652e+00, 1.0230206251e+00, 1.4231411219e+00, 1.1091691256e+00, 1.7714337111e+00, 1.3986129761e+00, 1.0640757084e+00, 1.4216910601e+00, 1.2402026653e+00 };
        BoxPlot boxPlot = new BoxPlot(data);

        Console.WriteLine($"Min: {boxPlot.Min()}");
        Console.WriteLine($"lq: {boxPlot.lq()}");
        Console.WriteLine($"Median: {boxPlot.Median()}");
        Console.WriteLine($"Mean: {boxPlot.Mean()}");
        Console.WriteLine($"StdDev: {boxPlot.StdDev()}");
        Console.WriteLine($"uq: {boxPlot.uq()}");
        Console.WriteLine($"Max: {boxPlot.Max()}");

        List<double> outliers = boxPlot.Outliers();
        Console.WriteLine($"Outliers: {string.Join(", ", outliers)}");
    }
}
