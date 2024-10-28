using System.ComponentModel.DataAnnotations;
public class Product
{
    public int ProductId { get; set; }
    
    [MaxLength(255)]
    public string ProductName { get; set; }

    // Foreign key to Category
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
}
