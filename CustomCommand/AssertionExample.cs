namespace CustomCommand
{
    using Sitecore.Diagnostics;

    public class AssertionExample
    {
        public void DoSomething(SomeData someData)
        {
            Assert.ArgumentNotNull(someData, "someData");
            Assert.ArgumentNotNullOrEmpty(someData.SomeString, "someData.SomeString");

            // TODO
        }
    }

    public class SomeData
    {
        public string SomeString { get; set; }
    }
}
