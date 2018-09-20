using System;
using System.Reflection;

namespace MediCloud.View.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        #region Public Methods

        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);

        #endregion Public Methods
    }
}