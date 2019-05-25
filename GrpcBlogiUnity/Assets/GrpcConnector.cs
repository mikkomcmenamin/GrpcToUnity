using System.Net;
using Grpc.Core;
using Grpcexample;
using UnityEngine;

public class GrpcConnector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
        var client = new UnityService.UnityServiceClient(channel);

        var request = new IdRequest
        {
            Name = "John Doe"
        };

        try
        {
            var response = client.GetId(request);
            Debug.Log($"The ID for {request.Name} is {response.Id}");
        }
        catch(RpcException e)
        {
            Debug.Log($"ID Request failed: {e}");
        }
        
        channel.ShutdownAsync().Wait();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
