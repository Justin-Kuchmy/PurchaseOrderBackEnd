using System.ComponentModel.DataAnnotations;

namespace PurchaseOrderBackEnd.Vendors { 
    public class Vendors {
        [Key]
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postalcode { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}