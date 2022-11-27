namespace EndPlannerApp.Shared.Countries.Queries;

public class GetCountriesVm
{
	public ICollection<GetCountriesDto> Countries { get; set; } = new List<GetCountriesDto>();
}