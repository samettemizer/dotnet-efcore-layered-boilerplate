using TaTava.Entities.Audited;

namespace TaTava.Entities.Audited
{
    public interface IAudited: ICreationAudited, IHasCreationTime, IModificationAudited, IHasModificationTime
    {
         
    }
}