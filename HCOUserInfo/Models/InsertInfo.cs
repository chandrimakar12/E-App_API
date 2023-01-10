using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace HCOUserInfo.Models
{
    public class InsertInformation
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public long? id { get; set; }


        [Required(ErrorMessage ="Organization Name is required")]
        [BsonElement("Name")]
        public string organizationName { get; set; }
        //[Required]
       // public int Age { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string country { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string state { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }
        [Required(ErrorMessage = "Zip Code is required")]
        [RegularExpression(@"^(\d{6})$",ErrorMessage ="Zip Code must be 6 digits")]
        public int zipCode { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage ="Email must contain '@' and '.'")]
        public string email { get; set; }
        [Required(ErrorMessage = "Website is required")]
        [Url(ErrorMessage ="Invalid format for URL")]
        public string webSite { get; set; }
        [Required(ErrorMessage = "Primary Contact Name is required")]
        public string primaryContact { get; set; }
        [Required(ErrorMessage = "Primary Contact Phone is required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage ="Phone number must be of 10 digits")]
        public long primaryContactPhone { get; set; }
        [Required(ErrorMessage = "Secondary Contact Name is required")]
        public string secondaryContact { get; set; }
        [Required(ErrorMessage = "Secondary Contact Phone is required")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone number must be of 10 digits")]
        public long secondaryContactPhone { get; set; }

        [Required(ErrorMessage ="Programs to be Accredited is required")]
        public string programs { get; set; }
       // public string UpdateDate { get; set; }
        public string Status { get; set; }
        public string submittedBy { get; set; }

    }

    public class InsertInfoResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

    }
}
