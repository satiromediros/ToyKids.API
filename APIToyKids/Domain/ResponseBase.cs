namespace APIToyKids.Domain;
public class ResponseBase<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
        
    public ResponseBase() { }

    public ResponseBase(T data, string message, bool success)
    {
        Data = data;
        Message = message;
        Success = success;
    }
}
