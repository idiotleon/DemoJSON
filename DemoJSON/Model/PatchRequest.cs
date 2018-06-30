using System.Collections.Generic;
using Newtonsoft.Json;

namespace DemoJSON.Model
{
    public class PatchRequest : BatchOperationsItem
    {
        public const string METHOD = "PATCH";
        public const string CONTENT_TYPE = "application/json-patch+json";

        private int WorkItemId;
        private List<UpdateOperation> UpdateOperations;
        public PatchRequest(int workItemId, List<UpdateOperation> updateOperations) : base(METHOD, URIComposer.GetURIForVSTSWorkItem(workItemId), new Headers(CONTENT_TYPE), updateOperations)
        {
            this.WorkItemId = workItemId;
            this.UpdateOperations = updateOperations;
        }
    }
}
