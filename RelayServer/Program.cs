using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Relay;
using System.IO;
using System.Threading;

namespace RelayServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HybridConnectionListener listener = new HybridConnectionListener("Endpoint=sb://relayzs.servicebus.windows.net/;SharedAccessKeyName=sas;SharedAccessKey=WBhKG1Fb51sYz4I1Nsv/mZsLhnru+O08YQxeq+SyRfo=;EntityPath=hybirdconn1");
            listener.OpenAsync();
            Task<HybridConnectionStream> task =listener.AcceptConnectionAsync();
            while (!task.IsCompleted) { }
            HybridConnectionStream stream = task.Result;
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            String message=reader.ReadLine();
            Console.WriteLine(message);
            writer.WriteLine("Hello Client!");
            writer.Flush();
            reader.Close();
            writer.Close();

        }
    }
}
