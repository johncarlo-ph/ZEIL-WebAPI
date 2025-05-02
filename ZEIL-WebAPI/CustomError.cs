using System.Text.Json;

namespace ZEIL_WebAPI
{
    public class CustomError
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
