using System;
using System.Collections.Generic;
using DemoJSON.Model;
using Newtonsoft.Json;

namespace DemoJSON
{
    class Program
    {
        static void Main(string[] args)
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
                "yanglu@microsoft.com"
                );
            List<UpdateOperation> updateOperations1 = new List<UpdateOperation>();
            updateOperations1.Add(updateOperation1);
            updateOperations1.Add(updateOperation2);
            PatchRequest patchRequest1 = new PatchRequest(289294, updateOperations1);

            // Update request No. 1, with 2 operations
            UpdateOperation updateOperation3 = new UpdateOperation(
                UpdateOperation.OPERATION_NAME_ADD,
                "/fields/MicrosoftTeamsCMMI.GPMOwner",
                "yanglu@microsoft.com"
                );
            UpdateOperation updateOperation4 = new UpdateOperation(
                UpdateOperation.OPERATION_NAME_ADD,
                "/fields/MicrosoftTeamsCMMI.GEMOwner",
                "yanglu@microsoft.com"
                );
            List<UpdateOperation> updateOperations2 = new List<UpdateOperation>();
            updateOperations2.Add(updateOperation1);
            updateOperations2.Add(updateOperation2);
            PatchRequest patchRequest2 = new PatchRequest(289294, updateOperations2);

            List<PatchRequest> patchRequests = new List<PatchRequest>();
            patchRequests.Add(patchRequest1);
            patchRequests.Add(patchRequest2);

            string output = JsonConvert.SerializeObject(patchRequests);
            Console.WriteLine(output);

            Console.WriteLine("The operation is complete");
            Console.ReadLine();
        }
    }
}