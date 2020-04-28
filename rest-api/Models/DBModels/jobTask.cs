using System;
using System.Collections.Generic;

namespace rest_api.Models.DBModels
{
    public partial class jobTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsComplete { get; set; }
        public decimal Percentage { get; set; }
    }
}
