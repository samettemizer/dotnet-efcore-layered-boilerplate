using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Firmalar.Sektorler.Dtos
{
    public class SektorListOutputDto : EntityDto<short>
    {
        public string SektorAdi { get; set; }
    }
}