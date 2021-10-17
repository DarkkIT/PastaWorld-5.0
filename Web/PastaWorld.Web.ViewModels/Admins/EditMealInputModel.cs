namespace PastaWorld.Web.ViewModels.Admins
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class EditMealInputModel
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
