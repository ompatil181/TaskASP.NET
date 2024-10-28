using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category
{
    public int CategoryId { get; set; }

    [MaxLength(255)]
    public string CategoryName { get; set; }

    // Navigation property for related Products
    public virtual ICollection<Product> Products { get; set; }
}
