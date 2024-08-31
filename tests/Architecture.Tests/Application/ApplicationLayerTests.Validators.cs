using ArchUnitNET.xUnit;

namespace Architecture.Tests.Application;

public partial class ApplicationLayerTests : ArchBaseTest
{
    [Fact]
    public void Validators_Should_ResideInApplicationLayer()
    {
        _requestValidators
            .Should()
            .ResideInAssembly(ApplicationAssembly)
            .Check(Architecture);
    }

    [Fact]
    public void Validators_Should_NotBePublic()
    {
        _requestValidators
            .Should()
            .BeInternal()
            .Check(Architecture);
    }

    [Fact]
    public void Validators_Should_BeSealed()
    {
        _requestValidators
            .Should()
            .BeSealed()
            .Check(Architecture);
    }

    [Fact]
    public void Validators_Should_HaveValidationPostfix()
    {
        _requestValidators
            .Should()
            .HaveNameEndingWith("Validator")
            .Check(Architecture);
    }
}