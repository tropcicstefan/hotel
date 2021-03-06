﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class DatumiViewModelDto
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumOd { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumDo { get; set; }
        public int GostID { get; set; }
    }
}