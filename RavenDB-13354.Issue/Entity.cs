using Newtonsoft.Json;

namespace RavenDB_13354.Issue
{
    public class Entity
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Name-hyphen")]
        public string NameHypen { get; set; }

        [JsonProperty(PropertyName = "Name, hyphen")]
        public string NameComma { get; set; }

        [JsonProperty(PropertyName = "subentity, hyphen")]
        public SubEntity SubEntityComma { get; set; }

        [JsonProperty(PropertyName = "conventional")]
        public SubEntity Conventional { get; set; }

        [JsonProperty(PropertyName = "conv-entional")]
        public SubEntity Conv_entional { get; set; }

        [JsonProperty(PropertyName = "conv_entional")]
        public SubEntity Conv__entional { get; set; }

    }

    public class SubEntity
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Name-hyphen")]
        public string NameHypen { get; set; }

        [JsonProperty(PropertyName = "Name, hyphen")]
        public string NameComma { get; set; }
    }
}
