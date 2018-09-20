using System;

namespace MediCloud.View.Areas.HelpPage
{
    /// <summary>
    /// This represents a preformatted text sample on the help page. There's a display template named TextSample associated with this class.
    /// </summary>
    public class TextSample
    {
        #region Public Constructors

        public TextSample(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            Text = text;
        }

        #endregion Public Constructors



        #region Public Properties

        public string Text { get; private set; }

        #endregion Public Properties



        #region Public Methods

        public override bool Equals(object obj)
        {
            TextSample other = obj as TextSample;
            return other != null && Text == other.Text;
        }

        public override int GetHashCode()
        {
            return Text.GetHashCode();
        }

        public override string ToString()
        {
            return Text;
        }

        #endregion Public Methods
    }
}