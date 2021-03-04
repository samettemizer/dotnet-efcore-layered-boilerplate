using TaTava.Entities;

namespace TaTava.Core.Settings
{
    public class Setting : FullAuditedEntity<int>
    {
        #region Properties
        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public bool ForceRegistrationToMakeComment { get; set; }
        public bool AllowComment { get; set; }

        public bool SendActivationLinkWhileRegistering { get; set; }

        public bool ActivateMaintenenceMode { get; set; }

        #endregion
    
        #region Navigation Properties

        

        #endregion

        #region Domain Methods

        

        #endregion
    }
}