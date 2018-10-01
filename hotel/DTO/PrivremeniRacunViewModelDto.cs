using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hotel.DTO
{
    public class PrivremeniRacunViewModelDto
    {
        public List<StavkeDto> Stavkes { get; set; }

        public List<ElementPonudeDto> ElementPonudes { get; set; }

    }
}