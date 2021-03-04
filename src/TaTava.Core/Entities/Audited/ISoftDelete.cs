namespace TaTava.Entities.Audited
{
    public interface ISoftDelete
    {
         bool IsDeleted { get; set; }
    }
}