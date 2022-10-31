using Ganss.Excel;
namespace Domain.Entities;
public class Fuel
{
	[Column("Prices in force on")]
	public string Date { get; set; }
	[Column("Country Name")]
	public string CountryName { get; set; }
	[Column("Country EU Code")]
	public string CountryCode { get; set; }
	[Column("Product Name")]
	public string FuelName { get; set; }
	[Column("Currency Code")]
	public string Code { get; set; }
	[Column("Prices Unit")]
	public string PricesUnit { get; set; }
	[Column("Euro exchange rate")]
	public string EuroExchangeRate { get; set; }
	[Column("Weekly price with taxes")]
	public string WeeklyPricesWithTax { get; set; }
}
