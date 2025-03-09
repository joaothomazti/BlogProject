using System.Net.Security;

namespace Blog.Application.Dtos.Category
{
    public class ResultDto<T>
    {
        public ResultDto(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }

        public ResultDto(T data)
        {
            Data = data;
        }

        public ResultDto(List<string> errors)
        {
            Errors = errors;
        }

        public ResultDto(string error)
        {
            Errors.Add(error);
        }
        
        public T Data { get; private set; }
        public List<string> Errors { get; set; } = [];

    }
}
