using Newtonsoft.Json.Linq;

namespace DonVo.GraphAPI.Year2021.GraphqlCore
{
    public class GraphqlQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}
