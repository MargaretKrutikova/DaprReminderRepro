using Dapr.Actors;
using Dapr.Actors.Client;
using Microsoft.AspNetCore.Mvc;

namespace DaprActorTest.Controllers;

[ApiController]
[Route("[controller]")]
public class ActorReminderController : ControllerBase
{
    [HttpGet(Name = "RegisterReminder")]
    public async Task<int> RegisterReminder(string actorId)
    {
        var actorProxy = ActorProxy.Create<ITestActor>(new ActorId(actorId), "ActorTest");
        var result = await actorProxy.RegisterReminder();

        return result;
    }
}