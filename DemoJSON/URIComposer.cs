namespace DemoJSON.Model
{
    /**
     * This class contains the mechanisms for composing URI
     */
    public static class URIComposer
    {
        public static int WorkItemId { get; set; }
        public readonly static string VSTS_API_PRE_FOR_WORK_ITEM = "/_apis/wit/workitems/";
        public readonly static string VSTS_API_VERSION = "?api-version=4.1";

        public static string GetURIForVSTSWorkItem(int WorkItemId)
        {
            return VSTS_API_PRE_FOR_WORK_ITEM + WorkItemId.ToString() + VSTS_API_VERSION;
        }
    }
}
