using Xunit;

namespace OrderProcessing.Domain.Tests.Infrastructure;

public sealed class InfrastructureSmokeTests
{
    [Fact(Skip = "Order store setup not part of this infrastructure smoke test stage.")]
    public void Command_dispatcher_can_be_resolved_and_used()
    {
        // intentionally skipped
    }
}