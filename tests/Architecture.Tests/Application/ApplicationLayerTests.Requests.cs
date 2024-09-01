using MediatR;
using ErrorOr;
using ArchUnitNET.xUnit;
using Architecture.Tests.Common.Conditions;

namespace Architecture.Tests.Application;

public partial class ApplicationLayerTests
{
    [Fact]
    public void Requests_Should_ResideInApplicationLayer()
    {
        _requests
            .Should()
            .ResideInAssembly(ApplicationAssembly)
            .Check(Architecture);
    }

    [Fact]
    public void Requests_Should_BeSealed()
    {
        _requests
            .Should()
            .BeSealed()
            .Check(Architecture);
    }

    [Fact]
    public void Requests_Should_BeImmutable()
    {
        _requests
            .Should()
            .BeImmutable()
            .Check(Architecture);
    }

    [Fact]
    public void Requests_Should_HaveCommandOrQueryPostfix()
    {
        _requests
            .Should()
            .HaveNameEndingWith("Command")
            .OrShould()
            .HaveNameEndingWith("Query")
            .Check(Architecture);
    }

    [Fact]
    public void Requests_ShouldReturnErrorOrWrappedResult()
    {
        var condition = new InterfaceWrappedResultCondition(
            ApplicationAssembly,
            typeof(IRequest<>),
            typeof(ErrorOr<>));

        _requests
            .Should()
            .FollowCustomCondition(condition)
            .Check(Architecture);
    }
}