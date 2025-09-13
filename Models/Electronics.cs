using System.ComponentModel.DataAnnotations;

namespace WebAppWithLogin.Models
{
    public class Electronics
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string category { get; set; }
        public string Description { get; set; }
        public int  Quantity { get; set; }
        public bool InStock { get; set; }
    }
}
