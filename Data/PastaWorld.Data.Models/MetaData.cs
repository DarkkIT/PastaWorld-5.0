using PastaWorld.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PastaWorld.Data.Models
{
    public class MetaData : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }
    }
}
