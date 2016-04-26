using System.Runtime.Serialization;

namespace FindMyItem.Domain
{
    [DataContract]
    public class SearchEnquiry
    {
        [DataMember]
        public int CategoryId { get; set; }
        [DataMember]
        public string Item { get; set; }
        [DataMember]
        public bool AdvancedSearch { get; set; }
    }
}
