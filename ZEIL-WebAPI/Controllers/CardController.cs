using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZEIL_WebAPI.core;

namespace ZEIL_WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ValidateCard(CreditCard card)
        {
            if (card != null)
            {
                if (IsCardNumberValid(card.CardNumber))
                {
                    return Ok("Card number is valid");
                }
            }

            return BadRequest("Invalid card details");
        }

        private bool IsCardNumberValid(string cardNumber)
        {
            if (!string.IsNullOrEmpty(cardNumber) && cardNumber.Length >= 15 && cardNumber.Length <= 16)
            {
                int sum = 0;
                bool multiply = false;

                for (int i = cardNumber.Length - 1; i >= 0; i--)
                {
                    int current = cardNumber[i] - '0';

                    if (multiply)
                    {
                        multiply = false;
                        current = (current * 2);

                        if (current > 9)
                        {
                            current = current.ToString().Sum(c => c - '0');
                        }
                    }
                    else
                    {
                        multiply = true;
                    }

                    sum += current;
                }

                return sum % 10 == 0;
            }

            return false;
        }
    }
}
