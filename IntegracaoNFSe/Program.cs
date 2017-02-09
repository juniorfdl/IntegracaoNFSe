using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegracaoNFSe
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:1234"))
            {
                System.Console.WriteLine("NFS-e");
                System.Console.WriteLine("http://localhost:1234");
                System.Console.ReadLine();
            }
        }
    }
}
