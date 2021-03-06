using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ComplaintManagementRestClient
{
    public static class RestClient
    {

        public static async Task<string> CallRestClient(HttpMethod httpMethod, string requestUrl, string body)
        {
            try
            {
                string baseUrl = "https://localhost:44374/";
                using (var client = new HttpClient())
                {
                    if (httpMethod.Method == HttpMethod.Get.ToString())
                    {
                        //Passing service base url  
                        client.BaseAddress = new Uri(baseUrl);

                        client.DefaultRequestHeaders.Clear();
                        //Define request data format  
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        using (HttpResponseMessage Respose = await client.GetAsync(requestUrl))
                        {
                            var content = "";
                            if (Respose.IsSuccessStatusCode)
                            {
                                 content = await Respose.Content.ReadAsStringAsync();
                            }
                            else
                            {
                                content = Respose.ReasonPhrase;
                            }
                            return content;
                        }
                    }
                    else if (httpMethod.Method == HttpMethod.Post.ToString())
                    {
                        client.BaseAddress = new Uri(baseUrl);

                        client.DefaultRequestHeaders.Clear();
                        //Define request data format  
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        using (HttpResponseMessage Respose = await client.PostAsJsonAsync(requestUrl, body))
                        {

                            var content = "";
                            if (Respose.IsSuccessStatusCode)
                            {
                                content = await Respose.Content.ReadAsStringAsync();
                            }
                            else
                            {
                                content = Respose.ReasonPhrase;
                            }
                            return content;
                        }
                    }
                    else // for Http PUT
                    {
                        client.BaseAddress = new Uri(baseUrl);

                        client.DefaultRequestHeaders.Clear();
                        //Define request data format  
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        using (HttpResponseMessage Respose = await client.PutAsJsonAsync(requestUrl, body))
                        {

                            var content = "";
                            if (Respose.IsSuccessStatusCode)
                            {
                                content = await Respose.Content.ReadAsStringAsync();
                            }
                            else
                            {
                                content = Respose.ReasonPhrase;
                            }
                            return content;
                        }
                    }
                }

              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
