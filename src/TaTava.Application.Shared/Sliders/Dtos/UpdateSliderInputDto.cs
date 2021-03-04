using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Sliders.Dtos
{
    public class UpdateSliderInputDto:EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
