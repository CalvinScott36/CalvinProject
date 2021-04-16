namespace CalvinProject.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime DateCreated { get; set; }

        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public string CartItemStatus { get; set; }
        public virtual Product Product { get; set; }

    }
}