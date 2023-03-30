using Homaale.Emi.Api.Emi;
using Microsoft.AspNetCore.Mvc;

namespace Homaale.Emi.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmiCalculatorController : ControllerBase
    {
        [HttpPost]
        [ActionName("CalculateEmi")]
        public IActionResult CalculateEmi([FromBody] EmiCalculationRequest emiCalculationRequest)
        {
            EmiCalculationResponse emiCalculationResponse = new EmiCalculationResponse();
            int tenure = 0;

            int i = 0;

            if(emiCalculationRequest.TenureMonth)
            {
                tenure = emiCalculationRequest.LoanTenure;
            }
            if(emiCalculationRequest.TenureYear)
            {
                tenure = emiCalculationRequest.LoanTenure * Common.YearToMonthConversionValue;
            }


            double monthlyInterestRate = emiCalculationRequest.InterestRate / Common.TotalMonthsInYear / Common.TotalPercentage;

            emiCalculationResponse.Principal = emiCalculationRequest.LoanAmount;
            emiCalculationResponse.MonthlyEmi = emiCalculationRequest.LoanAmount * monthlyInterestRate * Math.Pow((1 + monthlyInterestRate),tenure) /
                                                (Math.Pow((1 + monthlyInterestRate), tenure) - 1);

            emiCalculationResponse.TotalPayable = emiCalculationResponse.MonthlyEmi * tenure;

            double monthlyInterestAmount = 0;
            double TotalLoanAmount = emiCalculationResponse.Principal;

            while( i < tenure)
            {
                monthlyInterestAmount = TotalLoanAmount * monthlyInterestRate;

                DetailBreakdown detailBreakdown = new DetailBreakdown(){
                    Month = i + 1,
                    PrincipalAmount = emiCalculationResponse.MonthlyEmi - monthlyInterestAmount,
                    InterestAmount = monthlyInterestAmount,
                    PrincipalAndInterest = (emiCalculationResponse.MonthlyEmi - monthlyInterestAmount) + monthlyInterestAmount,
                    LeftPrincipalToBePaid = TotalLoanAmount - (emiCalculationResponse.MonthlyEmi - monthlyInterestAmount)
                };
                TotalLoanAmount = TotalLoanAmount - (emiCalculationResponse.MonthlyEmi - monthlyInterestAmount);
                emiCalculationResponse.DetailBreakdowns.Add(detailBreakdown);
                i = i + 1;
            }

            
            return Ok(emiCalculationResponse);
        }
    }
}