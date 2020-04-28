using System;
using System.Collections.Generic;

namespace rest_api.Models.DBModels
{
    public partial class Siswa
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }

        public DateTime created_date { get; set; }
    }
}
