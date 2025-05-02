**Card Number Validation**

**Author:**
John Carlo M. Landicho

Web API project repository for **ZEIL Senior Backend Developer** application.



**NOTES:**
1. API Key authentication is used, as it should be appropriate for the task "Card number validation" such as scalable e-commerce website where users have no need to authenticate (register an account) when purchasing a product using credit card.

   Web API will look for API Key in an Environment Variable. Kindly set up the API key as follow (change the Value if needed):
   
   **Name**: X-Api-Key
   
   **Value**: PbjyPd1vHUX1nQKqXVP5AHaUglr3WrKX

3. Luhn Algorithm is used to validate the card number
4. Global exception handling where a detailed exception will show if the environment is in "development", otherwise a generic "Internal server error" message will show.

   
