using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Sliders
{
    public class Slider:FullAuditedEntity<Guid>
    {
        public Slider(string title)
        {
            SetTitle(title);
        }

        #region Properties

        public string Title { get; private set; }
        public string Url { get; set; }

        #endregion

        #region Navigation Properties
        #endregion

        #region Domain Properties
        public void SetTitle(string title)
        {
            Policy.NullOrWhiteSpaceCheck(title, nameof(title));
            Title = title;
        }
        #endregion
    }
}
