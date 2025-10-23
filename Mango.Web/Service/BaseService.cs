using Mango.Web.Models;
using Mango.Web.Service.IService;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Net;
using Newtonsoft.Json;
namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClient;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }
        public async Task<ResponseDTO?> SendAsync(RequestDTO requestDTO)
        {
            try
            {
                HttpClient httpClient = _httpClient.CreateClient("MangoAPI");
                HttpRequestMessage requestMessage = new();
                requestMessage.Headers.Add("Accept", "application/json");
                requestMessage.RequestUri= new Uri(requestDTO.Url);
                if (requestDTO.Url != null)
                {
                    requestMessage.Content= new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");

                }
                HttpResponseMessage? responseMessage = null;
                switch (requestDTO.ApiType)
                {
                    case Utility.SD.ApiType.GET:
                        requestMessage.Method= HttpMethod.Get;
                        break;

                    case Utility.SD.ApiType.POST:
                        requestMessage.Method= HttpMethod.Post;

                        break;

                    case Utility.SD.ApiType.PUT:
                        requestMessage.Method= HttpMethod.Put;

                        break;

                    case Utility.SD.ApiType.DELETE:
                        requestMessage.Method= HttpMethod.Delete;
                        break;
                }

                responseMessage = await httpClient.SendAsync(requestMessage);

                switch (responseMessage.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSucceed= false, Message= "Not Found" };

                    case HttpStatusCode.Unauthorized:
                        return new() { IsSucceed= false, Message= "Unauthorized" };

                    case HttpStatusCode.Forbidden:
                        return new() { IsSucceed= false, Message= "Access Denied" };

                    case HttpStatusCode.InternalServerError:
                        return new() { IsSucceed= false, Message= "Internal Server Error" };

                    default:
                        var ResponseContent = await responseMessage.Content.ReadAsStringAsync()
    ; var responseDTO = JsonConvert.DeserializeObject<ResponseDTO>(ResponseContent);
                        return responseDTO;

                }
            }

            catch (Exception ex)
            {

                var dto = new ResponseDTO()
                {
                    IsSucceed= false,
                    Message= ex.Message.ToString()
                };
                return dto;
                }

            }
        }
    }

