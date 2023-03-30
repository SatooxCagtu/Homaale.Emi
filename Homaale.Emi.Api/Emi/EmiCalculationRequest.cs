

namespace Homaale.Emi.Api.Emi;

public class EmiCalculationRequest
{
    public double LoanAmount { get; set; }
    public double InterestRate { get; set; }
    public bool TenureMonth { get; set; }
    public bool TenureYear { get; set; }
    public int LoanTenure { get; set; }
}
