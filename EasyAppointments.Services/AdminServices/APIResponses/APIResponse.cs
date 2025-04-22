namespace EasyAppointments.Services.AdminServices.APIResponses
{
    public class APIResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public static APIResponse<T> SuccessResponse(T? data) => new APIResponse<T> { Data = data, IsSuccess = true };
        public static APIResponse<T> ErrorResponse(string? error) => new APIResponse<T> { Error = error, IsSuccess = false };
    }
}
