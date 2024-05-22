using ASPWebExamBelsky.Storage.Entity;
using System.Text.Json.Serialization;

namespace ASPWebExamBelsky.Controllers.ProjectControllers.ControllerJsonReadBase
{
    public class WebOrder
    {
        public string ClientName { get; set; }
        public Dictionary<int,int> Products { get; set; }

        public override string ToString()
        {
            return $"{ClientName} - {Products}";
        }
    }
}
