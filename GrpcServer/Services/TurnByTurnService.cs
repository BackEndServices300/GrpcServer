using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class TurnByTurnService : TurnByTurn.TurnByTurnBase
    {
        public override async Task StartGuidance(Empty request, IServerStreamWriter<Step> responseStream, ServerCallContext context)
        {
            var steps = new List<Step>
            {
                new Step() { Direction ="Left", Road="Main"},
                new Step() { Direction = "Left", Road="Lincoln"},
                new Step() { Direction = "Right", Road="Hollingsworth"},
                new Step() { Direction = "Right", Road ="Canton Mills"},
                new Step() { Direction="Stop", Road="You have Arrived!"}
            };
            foreach (var step in steps)
            {
                await Task.Delay(new Random().Next(1500, 3000));
                await responseStream.WriteAsync(step);
            }
        }

    }
}
