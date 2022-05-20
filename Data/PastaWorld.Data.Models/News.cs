namespace PastaWorld.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using PastaWorld.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        public string ImageName { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime NewsDate { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
