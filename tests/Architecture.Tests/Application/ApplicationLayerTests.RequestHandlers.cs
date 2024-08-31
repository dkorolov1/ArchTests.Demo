using ArchUnitNET.xUnit;

namespace Architecture.Tests.Application;

public partial class ApplicationLayerTests
{
    [Fact]
    public void RequestHandlers_Should_HaveCommandOrQueryHandlerPostfix()
    {
        _requestHandlers
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .OrShould()
            .HaveNameEndingWith("QueryHandler")
            .AndShould()
            .ResideInAssembly(ApplicationAssembly)
            .Check(Architecture);
    }

    [Fact]
    public void RequestHandlers_Should_NotBePublic()
    {
        _requestHandlers
            .Should()
            .BeInternal()
            .Check(Architecture);
    }

    [Fact]
    public void RequestHandlers_Should_BeSealed()
    {
        _requestHandlers
            .Should()
            .BeSealed()
            .Check(Architecture);
    }

    [Fact]
    public void RequestHandlers_Should_ResideInApplicationLayer()
    {
        _requestHandlers
            .Should()
            .ResideInAssembly(ApplicationAssembly)
            .Check(Architecture);
    }
}