using Newtonsoft.Json;

namespace IOT.Utilities.Response
{
    /// <summary>
    /// APIResponse
    /// </summary>
    /// <author>@HungDinh</author>
    public class APIResponse<T>
    {
        /// <summary>
        /// Code error or not error
        /// If success code is success, else error
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Message of code content
        /// </summary>
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public dynamic Message { get; set; }

        /// <summary>
        /// Data is result of action, if has error then data null
        /// </summary>
        [JsonProperty("result")]
        public T Result { get; set; }

        public APIResponse(int code, dynamic message, T result)
        {
            Code = code;
            Message = message;
            Result = result;
        }
    }
}
