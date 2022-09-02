using FluentAssertions;
using Xunit;

namespace EngineKit.Native.Glfw.UnitTests;

public class UnitTest1
{
    [Fact]
    public void CanInitializeGlfw()
    {
        Glfw.Init().Should().BeTrue();
    }

    [Fact]
    public void CanTerminateGlfw()
    {
        this.Invoking(_ => Glfw.Init()).Should().NotThrow();
        this.Invoking(_ => Glfw.Terminate()).Should().NotThrow();
    }
}