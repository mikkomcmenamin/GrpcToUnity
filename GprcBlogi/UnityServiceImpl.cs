using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Grpc.Core;
using Grpcexample;

namespace GrpcUnityTutorial
{
    public class UnityServiceImpl : UnityService.UnityServiceBase
    {
        public override Task<IdResponse> GetId(IdRequest request, ServerCallContext context)
        {
            if (EmployeeIds.ContainsKey(request.Name))
            {
                return Task.FromResult(new IdResponse
                {
                    Id = EmployeeIds[request.Name]
                });
            }
            else
            {
                return Task.FromException<IdResponse>(
                    new KeyNotFoundException("Employee not found in database"));
            }
        }
        
        private Dictionary<string, int> EmployeeIds { get; set; }

      
    }
}