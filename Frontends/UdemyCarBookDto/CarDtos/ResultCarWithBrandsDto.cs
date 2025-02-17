using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CarDtos
{
    public class ResultCarWithBrandsDto
    {       
            public int carID { get; set; }
            public int brandID { get; set; }
            public string BrandName { get; set; }
            public string model { get; set; }
            public string CoverImageUrl { get; set; }
            public int km { get; set; }
            public string transmisson { get; set; }
            public int seat { get; set; }
            public int luggage { get; set; }
            public string fuel { get; set; }
            public string bigImageUrl { get; set; }

    }
}

