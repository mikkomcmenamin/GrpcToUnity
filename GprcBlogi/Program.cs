using System;
using Grpc.Core;
using Grpcexample;

namespace GrpcUnityTutorial
{
    class Program
    {
        const int Port = 50051;
        
        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { UnityService.BindService(new UnityServiceImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            
            server.Start();
            
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
        
    }
}
