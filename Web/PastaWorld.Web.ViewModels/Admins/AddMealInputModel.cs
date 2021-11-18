namespace PastaWorld.Web.ViewModels.Admins
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class AddMealInputModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string ImageName { get; set; }

        [Required]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        public DateTime CreateDate => DateTime.Now;

        [Required]
        public IFormFile Image { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
