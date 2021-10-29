using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace FileDownloader
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Wrowadź adressy URL odzielone średnikiem (;) :");
            List<NetAdress> l = new List<NetAdress>(); // Adress list
            string input = Console.ReadLine();


            DirectoryAdress Dr = new DirectoryAdress();
            Console.WriteLine("Wprowadź adress zapisu dla pobranych plików:");
            Dr.Adress = Console.ReadLine();
            if (!Dr.IsValid)
            {
                Console.WriteLine("Sciezka zapisu nie poprawna: " + Dr.Adress);
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

            //start downloading files 
            DownloadMenager dm = new DownloadMenager();

            // List<FileDownloader> FL = new List<FileDownloader>();
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].IsInNetwork())
                {
                    string fileadress = Dr.Adress + l[i].FileName;
                    dm.AddTodownloadList(l[i].Adress, fileadress);
                    l.RemoveAt(i);
                }
            }

            //
            dm.WaitForAsync();


            Console.WriteLine("Nieprawidłowe adressy URL");
            for (int i = 0; i < l.Count; i++)
                if (!l[i].Error404)
                {
                    Console.WriteLine(l[i].Adress);
                    l.RemoveAt(i);
                }
            if (l.Count > 0) { 
            string check;
            Console.WriteLine("Czy spróbować pobrać zasoby jeszcze raz? t/n");
            check = Console.ReadLine();
                if (check == "t")
                {
                    foreach (var s in l) ;
                }
            }        
        }
    }
}
