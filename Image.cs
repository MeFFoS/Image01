using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Image01
{
    class Image
    {
        public const int NUMBER_OF_PIXELS_IN_ROW = 80;

        public static List<PointF>[] Figure = new List<PointF>[]
        {
            new List<PointF>(){new PointF(0.5f, 0.1f),new PointF(0.3f, 0.2f),new PointF(0.3f, 0.4f),new PointF(0.5f, 0.1f) },
            new List<PointF>(){new PointF(0.5f, 0.1f),new PointF(0.7f, 0.2f),new PointF(0.7f, 0.4f),new PointF(0.5f, 0.1f) },
            new List<PointF>(){new PointF(0.5f, 0.1f),new PointF(0.7f, 0.4f),new PointF(0.3f, 0.4f),new PointF(0.5f, 0.1f) },
            new List<PointF>(){new PointF(0.7f, 0.4f),new PointF(0.3f, 0.4f),new PointF(0.5f, 0.6f),new PointF(0.7f, 0.4f) },
        };
        public static Color[,] InitPixels(Color color)
        {
            int N = NUMBER_OF_PIXELS_IN_ROW + 1;
            Color[,] array = new Color[N, N];
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    array[i, j] = color;
            return array;
        }
        public static Color[,] DDAOtsech(Color[,] pixels, Color color, List<PointF>[] points, float x0 = 0, float y0 = 0, float x1 = 1, float y1 = 1)
        {
            y0 = 1 - y0;
            y1 = 1 - y1;
            for (int i = 0; i < points.Length; i++)
            {
                var pointFirst = points[i][0];
                for (int j = 1; j < points[i].Count; j++)
                {
                    var pointSecond = points[i][j];
                    if (PointInArea(ref pointFirst, ref pointSecond, x0, y0, x1, y1))
                    {
                        float dx = pointSecond.X - pointFirst.X;
                        float dy = pointSecond.Y - pointFirst.Y;
                        int L = (int)(Math.Max(Math.Abs(dx), Math.Abs(dy)) * NUMBER_OF_PIXELS_IN_ROW) + 1;
                        dx /= L;
                        dy /= L;
                        for (int k = 0; k < L; k++)
                        {
                            pixels[(int)Math.Round(pointFirst.X * NUMBER_OF_PIXELS_IN_ROW), (int)Math.Round((1 - pointFirst.Y) * NUMBER_OF_PIXELS_IN_ROW)] = color;
                            pointFirst.X += dx;
                            pointFirst.Y += dy;
                        }
                    }
                    pointFirst = points[i][j];
                }
            }
            return DrawBorder(pixels, Color.Green, x0, y0, x1, y1);
        }
        public static Color[,] BresenhamOtsech(Color[,] pixels, Color color, List<PointF>[] points, float x0 = 0, float y0 = 0, float x1 = 1, float y1 = 1)
        {
            y0 = 1 - y0;
            y1 = 1 - y1;
            for (int i = 0; i < points.Length; i++)
            {
                var pointFirst = points[i][0];
                for (int j = 1; j < points[i].Count; j++)
                {
                    var pointSecond = points[i][j];
                    if (PointInArea(ref pointFirst, ref pointSecond, x0, y0, x1, y1))
                    {
                        var steep = Math.Abs(pointSecond.Y - pointFirst.Y) > Math.Abs(pointSecond.X - pointFirst.X);
                        if (steep)
                        {
                            pointFirst = new PointF(pointFirst.Y, pointFirst.X);
                            pointSecond = new PointF(pointSecond.Y, pointSecond.X);
                        }
                        if (pointFirst.X > pointSecond.X)
                            Swap(ref pointFirst,ref pointSecond);

                        pointFirst.X *= NUMBER_OF_PIXELS_IN_ROW;
                        pointFirst.Y *= NUMBER_OF_PIXELS_IN_ROW;
                        pointSecond.X *= NUMBER_OF_PIXELS_IN_ROW;
                        pointSecond.Y *= NUMBER_OF_PIXELS_IN_ROW;

                        int dx = (int)Math.Round(pointSecond.X - pointFirst.X);
                        int dy = (int)Math.Abs(Math.Round(pointSecond.Y - pointFirst.Y));
                        int error = dx / 2;
                        int ystep = (pointFirst.Y < pointSecond.Y) ? 1 : -1;
                        int y = (int)Math.Round(pointFirst.Y);
                        for (int x = (int)Math.Round(pointFirst.X); x <= pointSecond.X; x++)
                        {
                            int tx = x, ty = y;
                            if (steep)
                            { tx = y; ty = x; }
                            pixels[tx , NUMBER_OF_PIXELS_IN_ROW - ty] = color;

                            error -= dy;
                            if (error < 0)
                            {
                                y += ystep;
                                error += dx;
                            }
                        }
                    }

                    pointFirst = points[i][j];
                }
            }

            return DrawBorder(pixels, Color.Green, x0, y0, x1, y1);
        }

        public static Color[,] DDARaster(Color[,] pixels, Color color, List<PointF>[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                var pointFirst = points[i][0];
                for (int j = 1; j < points[i].Count; j++)
                {
                    var pointSecond = points[i][j];
                    float dx = pointSecond.X - pointFirst.X;
                    float dy = pointSecond.Y - pointFirst.Y;
                    int L = (int)(Math.Max(Math.Abs(dx), Math.Abs(dy)) * NUMBER_OF_PIXELS_IN_ROW) + 1;
                    dx /= L;
                    dy /= L;
                    for (int k = 0; k < L; k++)
                    {
                        pixels[(int)Math.Round(pointFirst.X * NUMBER_OF_PIXELS_IN_ROW), (int)Math.Round((1 - pointFirst.Y) * NUMBER_OF_PIXELS_IN_ROW)] = color;
                        pointFirst.X += dx;
                        pointFirst.Y += dy;
                    }
                    pointFirst = points[i][j];
                }
            }
            return pixels;
        }
        public static Color[,] BresenhamRaster(Color[,] pixels, Color color, List<PointF>[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                var pointFirst = points[i][0];
                for (int j = 1; j < points[i].Count; j++)
                {
                    var pointSecond = points[i][j];
                        var steep = Math.Abs(pointSecond.Y - pointFirst.Y) > Math.Abs(pointSecond.X - pointFirst.X);
                        if (steep)
                        {
                            pointFirst = new PointF(pointFirst.Y, pointFirst.X);
                            pointSecond = new PointF(pointSecond.Y, pointSecond.X);
                        }
                        if (pointFirst.X > pointSecond.X)
                            Swap(ref pointFirst, ref pointSecond);

                        pointFirst.X *= NUMBER_OF_PIXELS_IN_ROW;
                        pointFirst.Y *= NUMBER_OF_PIXELS_IN_ROW;
                        pointSecond.X *= NUMBER_OF_PIXELS_IN_ROW;
                        pointSecond.Y *= NUMBER_OF_PIXELS_IN_ROW;

                        int dx = (int)Math.Round(pointSecond.X - pointFirst.X);
                        int dy = (int)Math.Abs(Math.Round(pointSecond.Y - pointFirst.Y));
                        int error = dx / 2;
                        int ystep = (pointFirst.Y < pointSecond.Y) ? 1 : -1;
                        int y = (int)Math.Round(pointFirst.Y);
                        for (int x = (int)Math.Round(pointFirst.X); x <= pointSecond.X; x++)
                        {
                            int tx = x, ty = y;
                            if (steep)
                            { tx = y; ty = x; }
                            pixels[tx, NUMBER_OF_PIXELS_IN_ROW - ty] = color;

                            error -= dy;
                            if (error < 0)
                            {
                                y += ystep;
                                error += dx;
                            }
                        }

                    pointFirst = points[i][j];
                }
            }
            return pixels;
        }
        public static void Draw(Color[,] pixels, PictureBox picture)
        {
            int N = NUMBER_OF_PIXELS_IN_ROW + 1;
            float width = Math.Min(picture.Width, picture.Height);
            Bitmap bitmap = new Bitmap((int)width, (int)width);
            Graphics graphics = Graphics.FromImage(bitmap);
            width /= N;
            float wi = 0, wj = 0;
            for (float i = 0; i < N; i++)
            {
                wj = 0;
                for (float j = 0; j < N; j++)
                {
                    graphics.FillRectangle(new SolidBrush(pixels[(int)i, (int)j]), wi, wj, wi + width, wj + width);
                    wj += width;
                }
                wi += width;
            }
            graphics = DrawGrid(graphics, Color.Black, width, N);

            picture.Image = bitmap;
        }
        private static Graphics DrawGrid(Graphics graphics, Color color, float width, int N)
        {
            Pen pen = new Pen(color);
            float wi = 0;
            float GgidWidth = width * N;
            for (float i = 0; i < N; i++)
            {
                graphics.DrawLine(pen, wi, 0, wi, GgidWidth);
                graphics.DrawLine(pen, 0, wi, GgidWidth, wi);
                wi += width;
            }
            return graphics;
        }
        private static Color[,] DrawBorder(Color[,] pixels, Color color, float xMin, float yMin, float xMax, float yMax)
        {
            MinMaxXY(ref xMin, ref yMin, ref xMax, ref yMax);
            int xb = (int)Math.Round(xMin * NUMBER_OF_PIXELS_IN_ROW);
            int yb = (int)Math.Round((1 - yMax) * NUMBER_OF_PIXELS_IN_ROW);
            int xe = (int)Math.Round(xMax * NUMBER_OF_PIXELS_IN_ROW);
            int ye = (int)Math.Round((1 - yMin) * NUMBER_OF_PIXELS_IN_ROW);
            for (int x = xb; x < xe + 1; x++)
            {
                pixels[x, yb] = color;
                pixels[x, ye] = color;
            }
            for (int y = yb+1; y < ye; y++)
            {
                pixels[xb, y] = color;
                pixels[xe, y] = color;
            }

            return pixels;
        }
        private static bool PointInArea(ref PointF pointFirst, ref PointF pointSecond, float xMin, float yMin, float xMax, float yMax)
        {
            MinMaxXY(ref xMin, ref yMin, ref xMax, ref yMax);
            int codePF = CodePointInArea(pointFirst, xMin, yMin, xMax, yMax);
            int codePS = CodePointInArea(pointSecond, xMin, yMin, xMax, yMax);
            if ((codePF | codePS) == 0)
                return true;
            if ((codePF & codePS) != 0)
                return false;

            float k = (pointSecond.Y - pointFirst.Y) / (pointSecond.X - pointFirst.X);
            float b = pointSecond.Y - k * pointSecond.X;

            pointFirst = FunctionPointInArea(ref pointFirst, k, b, xMin, yMin, xMax, yMax);
            pointSecond = FunctionPointInArea(ref pointSecond, k, b, xMin, yMin, xMax, yMax);

            return true;
        }
        private static int CodePointInArea(PointF point, float xMin, float yMin, float xMax, float yMax)
        {
            return 
                (point.X < xMin ? 8 : 0) +
                (point.X > xMax ? 4 : 0) +
                (point.Y < yMin ? 3 : 0) +
                (point.Y > yMax ? 1 : 0);
        }
        private static PointF FunctionPointInArea(ref PointF point, float k, float b, float xMin, float yMin, float xMax, float yMax)
        {
            if (point.X > xMax)
            { point.X = xMax; point.Y = k * xMax + b; }
            if (point.X < xMin)
            { point.X = xMin; point.Y = k * xMin + b; }
            if (point.Y > yMax)
            { point.Y = yMax; point.X = (yMax - b) / k; }
            if (point.Y < yMin)
            { point.Y = yMin; point.X = (yMin - b) / k; };
            return point;
        }
        private static void MinMaxXY(ref float xMin, ref float yMin, ref float xMax, ref float yMax)
        {
            if (xMax < xMin)
                Swap(ref xMax,ref xMin);
            if (yMax < yMin)
                Swap(ref yMax, ref yMin);
        }
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}
