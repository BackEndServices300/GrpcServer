using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace GrpcServer.Services
{
    public class RoutingService : DrivingRouter.DrivingRouterBase
    {
        public override  Task<RouteResponse> PlanRoute(RouteRequest request, ServerCallContext context)
        {
            var response = new RouteResponse();
            response.Miles = new Random().Next(15, 200);
            response.Steps.Add("At the end of your driveway, go left");
            response.Steps.Add("Turn right at Darrow");
            response.Steps.Add("Keep going until you get to the pacific");
            response.Steps.Add("You missed it  - " + request.Street);
            response.ArrivalTime = Timestamp.FromDateTime(DateTime.Now.AddHours(12).ToUniversalTime());
            return Task.FromResult( response);
        }

        

        
    }
}
