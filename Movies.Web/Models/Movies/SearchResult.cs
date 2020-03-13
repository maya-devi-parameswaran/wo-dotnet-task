using System.Runtime.Serialization;

namespace Movies.Web.Models.Movies
{
    [DataContract]
    public class SearchResult
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string Poster { get; set; }
    }
}
