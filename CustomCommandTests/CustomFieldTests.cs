namespace CustomCommandTests
{
    using CustomCommand;
    using FluentAssertions;
    using NUnit.Framework;
    using System.IO;
    using System.Web.UI;

    public class CustomFieldTests
    {
        [TestCase]
        public void DoRender_ShouldFillOutput()
        {
            // arrange
            var customField = new FakeCustomField();
            var output = new HtmlTextWriter(new StringWriter());

            // assert
            output.InnerWriter.ToString().Should().BeEmpty();

            // act
            customField.FakeDoRender(output);

            // assert
            output.InnerWriter.ToString().Should().Be("Hello from CustomField");
        }

        class FakeCustomField : CustomField
        {
            public void FakeDoRender(HtmlTextWriter output)
            {
                base.DoRender(output);
            }
        }
    }
}
