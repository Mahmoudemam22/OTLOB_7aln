namespace OTLOB_7aln_API.Dtos
{
    public class OrderDto
    {
        public string basketId { get; set; }
        public AddressDto shippingaddress { get; set; }
        public int deliveryMethodId { get; set; }
    }
}
