using EndPlannerApp.Shared.Members.Commands;

namespace Application.Members.Commands;
public class UpdateMemberCommandValidator : AbstractValidator<UpdateMemberCommand>
{
	public UpdateMemberCommandValidator()
	{
		RuleFor(m => m.UserEmail).MaximumLength(200).MinimumLength(5).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
	}
}
