namespace TaTava.Application.Shared.Dtos
{
    public class EntityDto
    {
        
    }

    public class EntityDto<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}