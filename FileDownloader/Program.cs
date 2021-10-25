using System;
using System.Collections.Generic;
using System.Threading;

namespace FileDownloader
{
    class Program
    {
        static void Main(string[] args)
        {


            FileDownloader fd = new FileDownloader();
            fd.DownloadFile("https://drive.google.com/uc?export=download&id=1TaF4TdHgPdHtyciBDCmhz_x_MO6hP8J8","1.txt");

            while (!fd.DownloadCompleted)
            Thread.Sleep(1000);


            return;
            Console.WriteLine("Wrowadź adressy URL odzielone średnikiem (;) :");
            List<NetAdress> l = new List<NetAdress>(); // Adress list
            string input = Console.ReadLine();


            DirectionAdress Dr = new DirectionAdress();
            Console.WriteLine("Wprowadź adress zapisu dla pobranych plików:");
            Dr.Adress = Console.ReadLine();
            if (!Dr.IsValid)
            {
                Console.WriteLine("Directory location is not valid: " + Dr.Adress);
                return;
            }

            {
                //Cut adress into chunks separated by ; and push them into list
                string[] subs = input.GetUntilOrEmpty();
                foreach (var sub in subs)
                {
                    NetAdress temp = new NetAdress();
                    temp.Adress = sub;
                    l.Add(temp);
                }
            }

            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine(l[i].Adress + " --is it valid adress " + l[i].IsValid + "  can you connect: " + l[i].IsInNetwork());
                if (l[i].IsInNetwork())
                {
                    //FileDownloader fd = new FileDownloader();
                   // var success = fd.DownloadFile(l[i].Adress, Dr.Adress, 1500);

                   // Console.WriteLine("Done  - success: " + success);
                    l.RemoveAt(i);
                }

            }

            Console.WriteLine("Invalid or unreachable URL adresses:");
            foreach (var s in l)
                Console.WriteLine(s.Adress);
        }
    }
}
