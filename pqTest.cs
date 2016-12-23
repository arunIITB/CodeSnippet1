using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Mischel.Collections;

namespace pqTest
{
    enum AlarmEventType
    {
        Test,
        Trouble,
        Alert,
        Fire,
        Panic
    };

    class AlarmEvent
    {
        private AlarmEventType etype;
        private string msg;
        public AlarmEvent(AlarmEventType type, string message)
        {
            etype = type;
            msg = message;
        }

        public AlarmEventType EventType
        {
            get { return etype; }
        }

        public string Message
        {
            get { return msg; }
        }
    }

    class pqTest
    {
        static void Main(string[] args)
        {
            PriorityQueue<AlarmEvent, AlarmEventType> pq = 
                new PriorityQueue<AlarmEvent, AlarmEventType>();

            // Add a bunch of events to the queue
            pq.Enqueue(new AlarmEvent(AlarmEventType.Test, "Testing 1"), AlarmEventType.Test);
            pq.Enqueue(new AlarmEvent(AlarmEventType.Fire, "Fire alarm 1"), AlarmEventType.Fire);
            pq.Enqueue(new AlarmEvent(AlarmEventType.Trouble, "Battery low"), AlarmEventType.Trouble);
            pq.Enqueue(new AlarmEvent(AlarmEventType.Panic, "I've fallen and I can't get up!"), AlarmEventType.Panic);
            pq.Enqueue(new AlarmEvent(AlarmEventType.Test, "Another test."), AlarmEventType.Test);
            pq.Enqueue(new AlarmEvent(AlarmEventType.Alert, "Oops, I forgot the reset code."), AlarmEventType.Alert);

            Console.WriteLine("The queue contains {0} events", pq.Count);

            // Now remove the items in priority order
            Console.WriteLine();
            while (pq.Count > 0)
            {
                PriorityQueueItem<AlarmEvent, AlarmEventType> item = pq.Dequeue();
                Console.WriteLine("{0}: {1}", item.Priority, item.Value.Message);
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIMGrundyNumber
{
    public class GrundyCharacter
    {
        private int _number;
        private bool _dash;
        public int Number {
            get { return _number; }
            set
            {
                if(value == 0)
                {
                    isItDash = true;
                    
                }

                _number = value;
            }
        }


        public bool isItDash {
            get { return _dash; }
            set
            {
                if(Number == 0)
                {
                    _dash = true;
                }
                else
                {
                    _dash = value;
                }
            }
        }

        public override bool Equals(object obj)
        {
            var temp = obj as GrundyCharacter;
            if(temp == null)
            {
                return false;
            }

            return temp.Number == Number && temp.isItDash == isItDash;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode() ^ isItDash.GetHashCode();
        }

        public override string ToString()
        {
            if(isItDash)
            {
                return Number + "'";
            }
            else
            {
                return Number.ToString();
            }
        }

    }


    public class GrundyTuples
    {

         public GrundyTuples()
        {
            GrundyCharactes = new List<GrundyCharacter>();
        }
         public List<GrundyCharacter> GrundyCharactes { get; set; }


        public override bool Equals(object obj)
        {
            var temp = obj as GrundyTuples;

            if(temp == null || temp.GrundyCharactes.Count() != GrundyCharactes.Count())
            {
                return false;
            }

            foreach(var item in temp.GrundyCharactes)
            {
                if(!GrundyCharactes.Contains(item))
                {
                    return false;
                }
            }

            return true;

        }

        public override int GetHashCode()
        {
            int temp=0;

            foreach(var item in GrundyCharactes)
            {
                temp = temp ^ item.GetHashCode();
            }

            return temp;
        }

        public override string ToString()
        {
            var result = string.Empty;

            GrundyCharactes.ForEach(x => result = result + x+",");
            return result;
        }



    }


    class Program
    {
        public static Dictionary<GrundyTuples, int> dict = new Dictionary<GrundyTuples, int>();
        static void Main(string[] args)
        {

            int g = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                var asdfsadf = new GrundyTuples();
                for (int j = 1; j <= i; j++)
                {
                    asdfsadf.GrundyCharactes.Add(new GrundyCharacter() { Number = 0, isItDash = true });
                }
                dict.Add(asdfsadf, 0);
            }



            for (int a0 = 0; a0 < g; a0++)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                string[] p_temp = Console.ReadLine().Split(' ');
                var p = Array.ConvertAll(p_temp, Int32.Parse).ToList();

                var tuple2 = new GrundyTuples();

                foreach (var p1 in p)
                {
                    var someNumber = new GrundyCharacter() { Number = p1, isItDash = false };
                    tuple2.GrundyCharactes.Add(someNumber);
                }
                var a = CalculateValueOf(tuple2);

               if ( a ==0)
                {
                    Console.WriteLine("L");
                }
               else
                {
                    Console.WriteLine("W");
                }
            }


           

        }


        public static int CalculateValueOf(GrundyTuples tuple1)
        {
            if(dict.ContainsKey(tuple1))
            {
                return dict[tuple1];
            }
            else
            {
                var list = new List<GrundyTuples>();


                foreach(var item in tuple1.GrundyCharactes)
                {
                    if(!item.isItDash)
                    {
                        var tempgrundy = new GrundyTuples();
                        var tempItem = new GrundyCharacter() { Number = item.Number, isItDash = true };
                        tempgrundy.GrundyCharactes.Add(tempItem);
                        tempgrundy.GrundyCharactes.AddRange(tuple1.GrundyCharactes.Where(x => !object.ReferenceEquals(x,item)));
                      //  tempgrundy.GrundyCharactes= tempgrundy.GrundyCharactes.Distinct().ToList();
                        list.Add(tempgrundy);
                    }
                }

                list = list.Distinct().ToList();


                foreach (var item in tuple1.GrundyCharactes)
                {
                    if (item.Number > 0)
                    {

                        var num = item.Number - 1;
                       
                        do
                        {
                            var tempgrundy = new GrundyTuples();
                            var tempItem12 = new GrundyCharacter() { Number = num, isItDash = item.isItDash };
                            tempgrundy.GrundyCharactes.Add(tempItem12);
                            tempgrundy.GrundyCharactes.AddRange(tuple1.GrundyCharactes.Where(x => !object.ReferenceEquals(x,item)));                                                 
                            list.Add(tempgrundy);
                            num--;
                        } while (num >= 0);
                        //list.Add(tempgrundy);

                    }
                }

                list = list.Distinct().ToList();

                var listResult = new List<int>();


                foreach(var item in list)
                {
                    listResult.Add(CalculateValueOf(item));
                }

                for(int i=0; i < 1000; i ++)
                {
                    if(!listResult.Contains(i))
                    {
                        dict[tuple1] = i;
                        return i;
                    }

                }


            }

            return -1;


        }
    }
}
