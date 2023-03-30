

namespace Homaale.Emi.Api.Emi;

public class EmiCalculationResponse
{
    public double Principal { get; set; }
    public double MonthlyEmi { get; set; }
    public double TotalPayable { get; set; }

    public List<DetailBreakdown> DetailBreakdowns { get; set; } = new List<DetailBreakdown>();
}
