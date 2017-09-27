namespace CustomCommand
{
    using Sitecore.Diagnostics;
    using Sitecore.Shell.Applications.ContentEditor;
    using System.Web.UI;

    public class CustomField : Sitecore.Web.UI.HtmlControls.Control, IContentField
    {
        public string GetValue()
        {
            return this.Value;
        }

        public void SetValue(string value)
        {
            this.Value = value;
        }

        protected override void DoRender(HtmlTextWriter output)
        {
            Assert.ArgumentNotNull(output, "output");

            output.Write("Hello from CustomField");
        }
    }
}