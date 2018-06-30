using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using DemoJSON.Model;
using Newtonsoft.Json;

namespace DemoJSON
{
    class Program
    {
        public static readonly string VSTS_COLLECTION_URL = "https://domoreexp.visualstudio.com/";
        public static readonly string MEDIA_TYPE = "application/json";
        public static readonly string VSTS_BATCH_API = "https://domoreexp.visualstudio.com/_apis/wit/$batch?api-version=4.1";

        private static readonly string PAT = "";

        static void Main(string[] args)
        {
            string output = HttpContentComposer();
            PatchAsync(output, PAT).Wait();

            Console.WriteLine("The operation is complete");
            Console.ReadLine();
        }

        public static async Task<HttpResponseMessage> PatchAsync(string httpContent, string PAT)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(VSTS_BATCH_API);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(MEDIA_TYPE));
            client.DefaultRequestHeaders.Add("User-Agent", "VSTSAutoUpdateHelper");
            client.DefaultRequestHeaders.Add("X-TFS-FedAuthRedirect", "Suppress");
            var authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(":" + PAT));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authorization);

            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, VSTS_BATCH_API)
            {
                Content = new StringContent(httpContent, Encoding.UTF8, MEDIA_TYPE)
            };

            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.SendAsync(request);
                Console.WriteLine();
                Console.WriteLine(response.ToString());
                Console.WriteLine();
                Console.WriteLine(response.RequestMessage);
            }
            catch (TaskCanceledException ex)
            {

            }

            return response;
        }

        // https://docs.microsoft.com/en-us/rest/api/vsts/wit/WorkItemBatchUpdate?view=vsts-rest-4.1
        private static string HttpContentComposer()
        {
            // Update request No. 1, with 2 operations
            UpdateOperation updateOperation1 = new UpdateOperation(
                UpdateOperation.OPERATION_NAME_ADD,
                "/fields/MicrosoftTeamsCMMI.GPMOwner",
                "yanglu@microsoft.com"
                );
            UpdateOperation updateOperation2 = new UpdateOperation(
                UpdateOperation.OPERATION_NAME_ADD,
                "/fields/MicrosoftTeamsCMMI.GEMOwner",
                "jofr@microsoft.com"
                );
            List<UpdateOperation> updateOperations1 = new List<UpdateOperation>();
            updateOperations1.Add(updateOperation1);
            updateOperations1.Add(updateOperation2);
            PatchRequest patchRequest1 = new PatchRequest(289194, updateOperations1);

            // Update request No. 1, with 2 operations
            UpdateOperation updateOperation3 = new UpdateOperation(
                UpdateOperation.OPERATION_NAME_ADD,
                "/fields/MicrosoftTeamsCMMI.GPMOwner",
                "jofr@microsoft.com"
                );
            UpdateOperation updateOperation4 = new UpdateOperation(
                UpdateOperation.OPERATION_NAME_ADD,
                "/fields/MicrosoftTeamsCMMI.GEMOwner",
                "yanglu@microsoft.com"
                );
            List<UpdateOperation> updateOperations2 = new List<UpdateOperation>();
            updateOperations2.Add(updateOperation1);
            updateOperations2.Add(updateOperation2);
            PatchRequest patchRequest2 = new PatchRequest(289192, updateOperations2);

            List<PatchRequest> patchRequests = new List<PatchRequest>();
            patchRequests.Add(patchRequest1);
            patchRequests.Add(patchRequest2);

            string output = JsonConvert.SerializeObject(patchRequests);
            Console.WriteLine(output);

            return output;
        }
    }
}