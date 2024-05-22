namespace ASPWebExamBelsky.Storage.Entity
{
    public class ProductInOrder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int ProductsCount { get; set; }

        public override string ToString()
        {
            return $"{Id} - Product:{ProductId} - Order:{OrderId} - {ProductsCount}";
        }
    }
}
