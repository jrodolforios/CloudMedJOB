using System.Collections.ObjectModel;

namespace MediCloud.View.Areas.HelpPage.ModelDescriptions
{
    public class EnumTypeModelDescription : ModelDescription
    {
        #region Public Constructors

        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        #endregion Public Constructors



        #region Public Properties

        public Collection<EnumValueDescription> Values { get; private set; }

        #endregion Public Properties
    }
}