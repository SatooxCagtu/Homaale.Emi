

namespace Homaale.Emi.Api.Emi;

public class DetailBreakdown
{
    public int Month { get; set; }
    public double PrincipalAmount { get; set; }
    public double InterestAmount { get; set; } 
    public double PrincipalAndInterest { get; set; }

    public double LeftPrincipalToBePaid { get; set; }
}
