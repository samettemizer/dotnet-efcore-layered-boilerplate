using TaTava.Entities.Audited;

namespace TaTava.Entities
{
    public interface IFullAudited : IAudited, ICreationAudited, IHasCreationTime, IModificationAudited, IHasModificationTime, IDeletionAudited, IHasDeletionTime, ISoftDelete
    {
         
    }
}