using MediatR;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Syntax.Elements.Types.Classes;
using FluentValidation;

namespace Architecture.Tests.Application;

public partial class ApplicationLayerTests : ArchBaseTest
{
	private readonly GivenClassesConjunction _requestHandlers = ArchRuleDefinition
		.Classes()
		.That()
		.ImplementInterface(typeof(IRequestHandler<,>));

	private readonly GivenClassesConjunction _requests = ArchRuleDefinition
		.Classes()
		.That()
		.ImplementInterface(typeof(IRequest<>));

	private readonly GivenClassesConjunction _requestValidators = ArchRuleDefinition
		.Classes()
		.That()
		.AreAssignableTo(typeof(AbstractValidator<>));
}