using System;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Menus
{
    public class Menu : FullAuditedEntity<Guid>
    {
        public Menu(string title, int menuOrder)
        {
            SetTitle(title);
            SetMenuOrder(menuOrder);
        }

        #region Properties

        public string Title { get; private set; }
        public int MenuOrder { get; private set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }

        #endregion

        #region Navigation Properties

        public Guid? UpperMenuId { get; set; }
        
        #endregion

        #region Domain Properties

        public void SetTitle(string title)
        {
            Policy.NullOrWhiteSpaceCheck(title, nameof(title));
            Title = title;
        }
        public void SetMenuOrder(int menuOrder)
        {
            Policy.NullCheck(menuOrder, nameof(menuOrder));
            MenuOrder = menuOrder;
        }

        #endregion
    }
}