namespace Nop.Web.Framework.Models.DataTables
{
    public partial class RenderbuttonDelete : IRenders
    {
        public RenderbuttonDelete(DataUrl url)
        {
            Url = url;
            ClassName = NopButtonClassDefaults.Default;
        }
        #region Properties

        /// <summary>
        /// Gets or sets Url to action edit
        /// </summary>
        public DataUrl Url { get; set; }

        /// <summary>
        /// Gets or sets button class name
        /// </summary>
        public string ClassName { get; set; }
        #endregion
    }
}
