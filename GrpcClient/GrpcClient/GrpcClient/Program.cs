using Grpc.Net.Client;
using GrpcClient.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("press any key to cont ...");
            Console.ReadLine();

            using (var channel = GrpcChannel.ForAddress("https://localhost:5001"))
            {
                var client = new Greeter.GreeterClient(channel);

                for (int i = 0; i < 9999999; i++)
                {
                    var mes = new MessageData()
                    {
                        ID = i,
                        MesContent = "thainh_" + i,
                        Note = string.Empty
                    };

                    var idx = 0;

                    while (idx < 10)
                    {
                        try
                        {
                            var reply = await client.SayHelloAsync(new HelloRequest { Name = "thainh_" + i });
                            Console.WriteLine($"Name: {reply.Message}");
                            await Task.Delay(1000);
                            break;
                        }
                        catch (Exception)
                        {
                            idx++;
                            await Task.Delay(1000);

                        }

                    }

                }

                Console.ReadLine();
            }


        }
    }
}
