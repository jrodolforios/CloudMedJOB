using System;

namespace MediCloud.View.Areas.HelpPage
{
    /// <summary>
    /// This represents an image sample on the help page. There's a display template named ImageSample associated with this class.
    /// </summary>
    public class ImageSample
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSample"/> class.
        /// </summary>
        /// <param name="src">The URL of an image.</param>
        public ImageSample(string src)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            Src = src;
        }

        #endregion Public Constructors



        #region Public Properties

        public string Src { get; private set; }

        #endregion Public Properties



        #region Public Methods

        public override bool Equals(object obj)
        {
            ImageSample other = obj as ImageSample;
            return other != null && Src == other.Src;
        }

        public override int GetHashCode()
        {
            return Src.GetHashCode();
        }

        public override string ToString()
        {
            return Src;
        }

        #endregion Public Methods
    }
}