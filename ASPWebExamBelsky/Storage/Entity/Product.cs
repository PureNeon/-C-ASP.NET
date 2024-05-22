namespace ASPWebExamBelsky.Storage.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Title} - {Price} - {Available}";
        }
    }
}
