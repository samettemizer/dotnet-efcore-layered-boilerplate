using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Menus.Dtos
{
    public class MenuOutputDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public int MenuOrder { get; set; }
        public string Url { get; set; }
        public Guid? UpperMenuId { get; set; }
        public bool IsActive { get; set; }
    }
}