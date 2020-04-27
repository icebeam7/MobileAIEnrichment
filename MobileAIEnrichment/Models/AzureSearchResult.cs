using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace MobileAIEnrichment.Models
{
    public class AzureSearchResult
    {
        [JsonProperty("@odata.context")]
        public Uri OdataContext { get; set; }

        [JsonProperty("value")]
        public List<Value> Value { get; set; }
    }

    public class Value
    {
        [JsonProperty("@search.score")]
        public double SearchScore { get; set; }

        [JsonProperty("metadata_storage_name")]
        public string MetadataStorageName { get; set; }

        [JsonProperty("people")]
        public List<string> People { get; set; }

        [JsonProperty("organizations")]
        public List<string> Organizations { get; set; }

        [JsonProperty("locations")]
        public List<string> Locations { get; set; }

        [JsonProperty("imageTags")]
        public List<string> ImageTags { get; set; }

        public string PeopleStr =>
            (People.Count > 0) ? string.Join(",", People) : string.Empty;

        public string ImageTagsStr =>
            (ImageTags.Count > 0) ? string.Join(",", ImageTags) : string.Empty;
    }
}
