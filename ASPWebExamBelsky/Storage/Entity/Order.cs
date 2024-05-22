using System.Text.Json.Serialization;

namespace ASPWebExamBelsky.Storage.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderHash { get; set; }
        public string ClientName { get; set; }
        public DateOnly CreationDate { get; set; }
        [JsonIgnore]
        public ICollection<ProductInOrder>? Products { get; set; }

        public override string ToString()
        {
            return $"{Id} - {OrderHash} - {ClientName} - {CreationDate}";
        }
    }
}
