using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {

        public static int Search(List<int> list, int v, int start, int end)
        {
            var mid = start +(end - start) / 2; 

            if(list[mid] == v)
            {
                return mid;
            }

            if( list[mid] > v)
            {
                return Search(list, v, start, mid - 1);
            }
            else
            {
                return Search(list, v, mid+1, end);
            }

           
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public override bool Equals(object obj)
            {
                var temp = obj as Point;

                if(temp == null)
                {
                    return false;
                }

                return temp.X == X && temp.Y == Y;
            }


            public Point(int x_,int y_)
            {
                X = x_;
                Y = y_;
            }

            public static bool operator ==(Point a, Point b)
            {
                if(object.ReferenceEquals(a, null) && object.ReferenceEquals(b , null))
                {
                    return true;
                }
                else
                {
                    if(object.ReferenceEquals(a, null) || object.ReferenceEquals(b ,null))
                    {
                        return false;
                    }

                }

                return a.Equals(b);
            }

            public static bool operator !=(Point a, Point b)
            {
                return !(a.Equals(b));
            }

        }

        static void Main1(string[] args)
        {
            var input1 = Console.ReadLine().Split(' ');
            var m = Convert.ToInt32(input1[0]);
            var n = Convert.ToInt32(input1[1]);
            var h = Convert.ToInt32(input1[2]);

            var array = new int[m,n];
            var Visitedarray = new bool[m, n];

            for (int i=0;i<m;i++)
            {
                var input2 = Console.ReadLine().Split(' ');

                for(int j=0;j<n;j++)
                {
                    array[i, j] = Convert.ToInt32(input2[j]);
                }

            }


            var reached = false;
            var finalPoint = new Point(m - 1, n - 1);

            Queue<Point> queue = new Queue<Point>();

            queue.Enqueue(new Point(0, 0));


            while(queue.Any())
            {
                var currentItem = queue.Dequeue();



                if(Visitedarray[currentItem.X,currentItem.Y])
                {
                    continue;
                }

                Visitedarray[currentItem.X, currentItem.Y] = true;

                if (currentItem.X < m-1)
                {
                    var tempPoint = new Point(currentItem.X + 1, currentItem.Y);
                    if(tempPoint == finalPoint)
                    {
                        reached = true;
                        break;
                    }
                    if(array[tempPoint.X,tempPoint.Y] >= h)
                    queue.Enqueue(tempPoint);

                }

                if (currentItem.Y < n - 1)
                {
                    var tempPoint = new Point(currentItem.X, currentItem.Y+1);
                    if (tempPoint == finalPoint)
                    {
                        reached = true;
                        break;
                    }
                    if (array[tempPoint.X, tempPoint.Y] >= h)
                        queue.Enqueue(tempPoint);

                }

                if (currentItem.X > 0)
                {
                    var tempPoint = new Point(currentItem.X - 1, currentItem.Y);
                    if (tempPoint == finalPoint)
                    {
                        reached = true;
                        break;
                    }
                    if (array[tempPoint.X, tempPoint.Y] >= h)
                        queue.Enqueue(tempPoint);

                }

                if (currentItem.Y > 0)
                {
                    var tempPoint = new Point(currentItem.X, currentItem.Y-1);
                    if (tempPoint == finalPoint)
                    {
                        reached = true;
                        break;
                    }
                    if (array[tempPoint.X, tempPoint.Y] >= h)
                        queue.Enqueue(tempPoint);

                }


            }

            if(reached)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }





        }

        static void Main(string[] args)
        {

            var input1 = Console.ReadLine().Split(' ');
            var m = Convert.ToInt32(input1[0]);
            var n = Convert.ToInt32(input1[1]);

            var array = new char[m, n];


            for(int i=0;i<m;i++)
            {
                var input2 = Console.ReadLine();
                for(int j=0;j<n;j++)
                {
                    array[i, j] = input2[j];
                }
            }

            var testCases = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < testCases; i++)
            {

                var input3 = Console.ReadLine().Split(' ');
                var x = Convert.ToInt32(input3[0]);
                var y = Convert.ToInt32(input3[1]);
                var Visitedarray = new bool[m, n];



                var count = 0;
                var reached = false;
                var finalChar = 'F';

                Queue<Point> queue = new Queue<Point>();

                queue.Enqueue(new Point(x, y));


                while (queue.Any())
                {
                    var currentItem = queue.Dequeue();



                    if (Visitedarray[currentItem.X, currentItem.Y])
                    {
                        continue;
                    }

                    Visitedarray[currentItem.X, currentItem.Y] = true;

                    if (array[currentItem.X, currentItem.Y] == 'B' && currentItem.X != x && currentItem.Y !=y)
                    {
                        continue;
                    }

                    count++;


                    if (currentItem.X < m - 1)
                    {
                        var tempPoint = new Point(currentItem.X + 1, currentItem.Y);
                        if (array[tempPoint.X, tempPoint.Y] == finalChar)
                        {
                            reached = true;
                            break;
                        }
                        if(array[tempPoint.X, tempPoint.Y] == '.')
                        queue.Enqueue(tempPoint);

                    }

                    if (currentItem.Y < n - 1)
                    {
                        var tempPoint = new Point(currentItem.X, currentItem.Y + 1);
                        if (array[tempPoint.X, tempPoint.Y] == finalChar)
                        {
                            reached = true;
                            break;
                        }
                        if (array[tempPoint.X, tempPoint.Y] == '.')
                            queue.Enqueue(tempPoint);

                    }

                    if (currentItem.X > 0)
                    {
                        var tempPoint = new Point(currentItem.X - 1, currentItem.Y);
                        if (array[tempPoint.X, tempPoint.Y] == finalChar)
                        {
                            reached = true;
                            break;
                        }
                        if (array[tempPoint.X, tempPoint.Y] == '.')
                            queue.Enqueue(tempPoint);

                    }

                    if (currentItem.Y > 0)
                    {
                        var tempPoint = new Point(currentItem.X, currentItem.Y - 1);

                        if (array[tempPoint.X, tempPoint.Y] == finalChar)
                        {
                            reached = true;
                            break;
                        }
                        if (array[tempPoint.X, tempPoint.Y] == '.')
                            queue.Enqueue(tempPoint);

                    }


                }

                Console.WriteLine(count);

            }

            }



        }
}
