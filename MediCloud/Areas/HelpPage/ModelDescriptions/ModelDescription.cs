using System;

namespace MediCloud.View.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// Describes a type model.
    /// </summary>
    public abstract class ModelDescription
    {
        #region Public Properties

        public string Documentation { get; set; }

        public Type ModelType { get; set; }

        public string Name { get; set; }

        #endregion Public Properties
    }
}