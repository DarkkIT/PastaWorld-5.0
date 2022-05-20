namespace PastaWorld.Data.Models
{
    using PastaWorld.Data.Common.Models;

    public class MetaData : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }
    }
}
