using System;


namespace ServerTest2
{
    //exit codes to return on status
    class Program
    {
       //[STAThread]
        public static int Main(string[] args)
        {
            Console.WriteLine(".Net Core OPC UA Testing Server");
            bool autoAccept = false;

            MyRefServer server = new MyRefServer(autoAccept);
            server.Run();

            return (int)MyRefServer.ExitCode;
        }
    }
}
