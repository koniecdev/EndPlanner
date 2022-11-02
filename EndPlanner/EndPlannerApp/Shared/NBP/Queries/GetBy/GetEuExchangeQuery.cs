namespace EndPlannerApp.Shared.NBP.Queries.GetBy;
public class GetEuExchangeQuery: IRequest<GetEuExchangeVm>
{
	public string CurrencyCode { get; set; } = "";
}
