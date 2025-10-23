namespace Mango.Services.CouponAPI.DTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool IsSucceed { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
