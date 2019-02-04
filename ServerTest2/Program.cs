using System;

namespace ServerTest2
{  
    class Program
    {
       [STAThread]
        public static int Main(string[] args)
        {
            Console.WriteLine(".Net Core OPC UA Testing Server");
            MyRefServer server = new MyRefServer();
            server.Run();
            return (int)MyRefServer.ExitCode;
        }
    }
}
