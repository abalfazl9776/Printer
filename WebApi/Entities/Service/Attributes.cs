using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Entities.Common;

namespace Entities.Service
{
    public class Attributes : BaseEntity
    {
        public string Name { get; set; }

        public string DataType { get; set; }

        public bool Modifiable { get; set; }
        
    }

}
