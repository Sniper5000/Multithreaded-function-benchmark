using System;
using System.Threading;

namespace Function_Benchmark
{
    class Program
    {
        //You can remove this after replacing the placeholder methods
        public static Random RAN = new Random(); //we have initialized our randomizer... [our Pseudo Random Generator]
        public static int BDMG = 2;
        public static int SPD = 5;
        //

        public static ulong Marks = 1000; //default = 1000 | Execute a method for X amount of times.
        public static int Cores = 1; //default = 1 | Executes the amount of threads desired. Great for benchmarking multiple methods in different threads!
        public static bool IndependentThreads; //default = false | if true, will allow you to execute different methods in the ThreadB to ThreadH, if false it will execute the method in ThreadA
        public static bool Awaiting; //All threads must start at the same time!
        public static bool BenchEnded; //Will be true after finalizing the benchmark!
        public static int RemainingCores; //Will be set to 0 after all cores finished!
        static void Main(string[] args)
        {
            BenchEnded = false;
            Console.WriteLine("Please input times to execute both functions | recommended less than 10M");
            var DATA1 = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Please input the amount of cores to execute both functions | recommended 1");
            var DATA2 = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Execute different functions in each Thread? [Y or N]");
            var DATA3 = Console.ReadLine();

            Cores = Convert.ToInt32(DATA2);
            Marks = Convert.ToUInt64(DATA1);
            if (DATA3.ToLower() == "y")
            {
                IndependentThreads = true;
            }
            else
            {
                IndependentThreads = false;
            }
            if (Marks > 1000000000)
            {
                Marks = 1000;
                Console.WriteLine("");
                Console.WriteLine("You exceeded the amount of Marks allowed! Marks set to " + Marks);
                Console.WriteLine("");
            }


            if (Marks == 0)
            {
                Marks = 1000; //Defaulted
            }

            if (IndependentThreads)
            {
                if (Cores > 1)
                {
                    Thread A0 = new Thread(ThreadB);
                    A0.Start();
                }
                if (Cores > 2)
                {
                    Thread A1 = new Thread(ThreadC);
                    A1.Start();
                }
                if (Cores > 3)
                {
                    Thread A2 = new Thread(ThreadD);
                    A2.Start();
                }
                if (Cores > 4)
                {
                    Thread A3 = new Thread(ThreadE);
                    A3.Start();
                }
                if (Cores > 5)
                {
                    Thread A4 = new Thread(ThreadF);
                    A4.Start();
                }
                if (Cores > 6)
                {
                    Thread A5 = new Thread(ThreadG);
                    A5.Start();
                }
                if (Cores > 7)
                {
                    Thread A6 = new Thread(ThreadH);
                    A6.Start();
                }
            }
            else
            {
                Awaiting = true;
                for (int i = 1; i < Cores; i++)
                {
                    Thread A0 = new Thread(() => ThreadA(i));
                    A0.Start();

                    while (!A0.IsAlive)
                    {
                        //Do Nothing
                    }
                    Console.WriteLine($"Thread {i} was executed successfully");
                }
            }



            //Start Test

            Awaiting = false;

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {

                DamageC(BDMG, SPD, 3);  //Thread 0 | add the function to test on Thread 0 here
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread 0 : {watch.ElapsedMilliseconds} ms");
            RemainingCores--;

            while(RemainingCores > 0)
            {
                //Do Nothing
            }

            BenchEnded = true;
            Thread D = new Thread(ReadCMD);
            D.Start();
        }

        //You may replace this with your method(s) to test || Don't forget to replace the called method(s) from ThreadB to ThreadH for "Independent mode" or ThreadA for executing the same method in all All threads!
        public static void DamageC(int BaseDMG, int Speed, int Modifier)
        {

            int DAT;
            DAT = RAN.Next(BaseDMG + Speed, BaseDMG + Speed + Modifier);

        }
        public static void DamageM(int BaseDMG, int Speed, float Modifier)
        {

            Modifier += 1;
            int DAT;
            DAT = RAN.Next(BaseDMG + Speed, (int)MathF.Round((float)BaseDMG + (float)Speed * Modifier));

        }
        //

        static void ThreadA(int N)
        {
            while (Awaiting)
            {
                //Do Nothing
            }
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {
                DamageC(BDMG, SPD, 3); //Target to test
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread {N} : {watch.ElapsedMilliseconds} ms");
        } //add the function to test on All threads here

        //From B to H for independent method execution.. you can add a different method to each thread independently here.
        static void ThreadB()
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {
                DamageC(BDMG, SPD, 3);
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread 1 : {watch.ElapsedMilliseconds} ms");
        }

        static void ThreadC()
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {
                DamageM(BDMG, SPD, 1.30f);
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread 2 : {watch.ElapsedMilliseconds} ms");
        }

        static void ThreadD()
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {
                DamageM(BDMG, SPD, 1.30f);
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread 3 : {watch.ElapsedMilliseconds} ms");
        }

        static void ThreadE()
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {
                DamageC(BDMG, SPD, 3);
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread 4 : {watch.ElapsedMilliseconds} ms");
        }

        static void ThreadF()
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {
                DamageM(BDMG, SPD, 1.30f);
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread 5 : {watch.ElapsedMilliseconds} ms");
        }

        static void ThreadG()
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {
                DamageC(BDMG, SPD, 3);
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread 6 : {watch.ElapsedMilliseconds} ms");
        }

        static void ThreadH()
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {
                DamageM(BDMG, SPD, 1.30f);
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread 7 : {watch.ElapsedMilliseconds} ms");
        }
        //Not enough Threads? you can expand this





        // Repeats the commands
        public static void Rebuild()
        {
            BenchEnded = false;
            Console.WriteLine("Please input times to execute both functions | recommended less than 10M");
            var DATA1 = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Please input the amount of cores to execute both functions | recommended 1");
            var DATA2 = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Execute different functions in each Thread? [Y or N]");
            var DATA3 = Console.ReadLine();

            Cores = Convert.ToInt32(DATA2);
            Marks = Convert.ToUInt64(DATA1);
            if (DATA3.ToLower() == "y")
            {
                IndependentThreads = true;
            }
            else
            {
                IndependentThreads = false;
            }
            if (Marks > 1000000000)
            {
                Marks = 1000;
                Console.WriteLine("");
                Console.WriteLine("You exceeded the amount of Marks allowed! Marks set to " + Marks);
                Console.WriteLine("");
            }

          

            if (Marks == 0)
            {
                Marks = 1000; //Defaulted
            }

            if (IndependentThreads)
            {
                if (Cores > 1)
                {
                    Thread A0 = new Thread(ThreadB);
                    A0.Start();
                }
                if (Cores > 2)
                {
                    Thread A1 = new Thread(ThreadC);
                    A1.Start();
                }
                if (Cores > 3)
                {
                    Thread A2 = new Thread(ThreadD);
                    A2.Start();
                }
                if (Cores > 4)
                {
                    Thread A3 = new Thread(ThreadE);
                    A3.Start();
                }
                if (Cores > 5)
                {
                    Thread A4 = new Thread(ThreadF);
                    A4.Start();
                }
                if (Cores > 6)
                {
                    Thread A5 = new Thread(ThreadG);
                    A5.Start();
                }
                if (Cores > 7)
                {
                    Thread A6 = new Thread(ThreadH);
                    A6.Start();
                }
            }
            else
            {
                Awaiting = true;
                for (int i = 1; i < Cores; i++)
                {
                    Thread A0 = new Thread(() => ThreadA(i));
                    A0.Start();

                    while (!A0.IsAlive)
                    {
                        //Do Nothing
                    }
                    Console.WriteLine($"Thread {i} was executed successfully");
                }
            }



            //Start Test

            Awaiting = false;

            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            for (ulong i = 0; i < Marks; i++)
            {

                DamageC(BDMG, SPD, 3);  //Thread 0 | add the function to test on Thread 0 here
            }
            watch.Stop();
            Console.WriteLine($"Execution Time For Thread 0 : {watch.ElapsedMilliseconds} ms");
            RemainingCores--;

            while (RemainingCores > 0)
            {
                //Do Nothing
            }

            BenchEnded = true;
            Thread D = new Thread(ReadCMD);
            D.Start();

        }

        //Can be disabled for more accurate results
        static void ReadCMD()
        {
            while (BenchEnded)
            {
                Thread.Sleep(100);
                string CMD = Console.ReadLine();

                if (CMD.ToLower() == "repeat" || CMD.ToLower() == "rebuild" || CMD.ToLower() == "retry")
                {
                    Console.WriteLine("" + Environment.NewLine + Environment.NewLine);
                    Rebuild();
                    Thread.Sleep(2000);
                }

                if (CMD.ToLower() == "exit" || CMD.ToLower() == "stop" || CMD.ToLower() == "abort")
                {
                    Console.WriteLine("Ready to close");
                    break;
                }


            }
            Console.WriteLine("");
        }
    }
}
