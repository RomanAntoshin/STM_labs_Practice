using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Task6LINQ
{
    internal class LinqVsPLinq
    {
        public static void Run(out long sequential, out long parallel)
        {
            PointF[] square = new PointF[] { new PointF(0, 0), new PointF(0, 1), new PointF(1, 0), new PointF(1, 1) };
            Random rnd = new();
            double size = 1e8;
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            PointF[] points = new PointF[(int)size];
            for (int i = 0; i < size; i++)
            {
                points[i] = new PointF((float)rnd.NextDouble(), (float)rnd.NextDouble());
            }
            var part = points.SelectMany(p => square.Select(s => GetDistance(s, p))).Where(d => d < 0.5).Count();
            stopwatch.Stop();
            sequential = stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();
            part = points.AsParallel().SelectMany(p => square.Select(s => GetDistance(s, p))).Where(d => d < 0.5).Count();
            stopwatch.Stop();
            parallel = stopwatch.ElapsedMilliseconds;
        }
        private static double GetDistance(PointF a, PointF b)
        {
            double deltaX = b.X - a.X;
            double deltaY = b.Y - a.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
