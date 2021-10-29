using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
struct TaskHelper
{
    public Task ts;
    public FileDownloader.FileDownloader fl;
}
namespace FileDownloader
{
 public class DownloadMenager
    {
        private List<TaskHelper> FL = new ();

        public bool AddTodownloadList(string DownloadAdress,  string FileAdress )
        {
            TaskHelper th;
            th.fl = new();
            th.ts = th.fl.DownloadFile(DownloadAdress, FileAdress);
            FL.Add(th);
            return true;
        }

        public bool WaitForAsync()
        {
            bool InWork = false;
            do
            {
                InWork = false;
                foreach (var s in FL)
                {
                    if (!s.ts.IsCompleted)
                    {
                        InWork = true;
                    }
                }
            }
            while (InWork);
            return true;
        }
    }
}
