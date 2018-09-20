using System.Collections.ObjectModel;

namespace MediCloud.View.Areas.HelpPage.ModelDescriptions
{
    public class ParameterDescription
    {
        #region Public Constructors

        public ParameterDescription()
        {
            Annotations = new Collection<ParameterAnnotation>();
        }

        #endregion Public Constructors



        #region Public Properties

        public Collection<ParameterAnnotation> Annotations { get; private set; }

        public string Documentation { get; set; }

        public string Name { get; set; }

        public ModelDescription TypeDescription { get; set; }

        #endregion Public Properties
    }
}