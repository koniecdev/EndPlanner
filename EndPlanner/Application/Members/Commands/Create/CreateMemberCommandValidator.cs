using EndPlannerApp.Shared.Members.Commands;

namespace Application.Members.Commands;
public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
	public CreateMemberCommandValidator()
	{
		RuleFor(m => m.UserEmail).MaximumLength(200).MinimumLength(5).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).NotEmpty();
		RuleFor(m => m.UserId).NotEmpty();
	}
}
