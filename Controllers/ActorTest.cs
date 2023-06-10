using Dapr.Actors;
using Dapr.Actors.Runtime;

namespace DaprActorTest.Controllers;
using DaprActor = Dapr.Actors.Runtime.Actor;

public class ActorTest : DaprActor, ITestActor, IRemindable
{
    public ActorTest(ActorHost host) : base(host)
    {
    }
    public Task<int> RegisterReminder()
    {
        RegisterReminderAsync("RandomReminder", null, TimeSpan.FromHours(1), TimeSpan.FromMilliseconds(-1));
        return Task.FromResult(42);
    }

    public Task ReceiveReminderAsync(string reminderName, byte[] state, TimeSpan dueTime, TimeSpan period)
    {
        return Task.CompletedTask;
    }
}

public interface ITestActor : IActor
{
    public Task<int> RegisterReminder();
}