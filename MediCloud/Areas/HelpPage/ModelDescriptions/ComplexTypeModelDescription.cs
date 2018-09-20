using System.Collections.ObjectModel;

namespace MediCloud.View.Areas.HelpPage.ModelDescriptions
{
    public class ComplexTypeModelDescription : ModelDescription
    {
        #region Public Constructors

        public ComplexTypeModelDescription()
        {
            Properties = new Collection<ParameterDescription>();
        }

        #endregion Public Constructors



        #region Public Properties

        public Collection<ParameterDescription> Properties { get; private set; }

        #endregion Public Properties
    }
}