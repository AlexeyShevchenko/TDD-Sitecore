namespace CustomCommandTests
{
    using System;
    using CustomCommand;
    using FluentAssertions;
    using NUnit.Framework;
    using Sitecore.Data;
    using Sitecore.FakeDb;
    using Sitecore.Shell.Framework.Commands;

    public class Example2Tests
    {
        [TestCase]
        public void CommandState_ShouldBeHidden_WhenNoOneItemsContainStartDateLargerDateTimeNow()
        {
            // arrange
            var folderId = new ID("{B4F0DAD0-B60E-49D9-8332-8DF1A61C5101}");
            var doSomethingCommand = new FakeExample2 { FakeDateTimeNow = new DateTime(2018, 1, 1, 0, 0, 0) };
            var commandContext = new CommandContext();

            using (var db = new Db
            {
                new DbItem("Folder", folderId)
                {
                    new DbItem("child 1")
                    {
                        new DbField("Start Date") { Value = "20170000T000000" }
                    }
                }
            })
            {
                // act
                var commandState = doSomethingCommand.QueryState(commandContext);

                // assert
                commandState.Should().Be(CommandState.Hidden);
            }
        }

        [TestCase]
        public void CommandState_ShouldBeHidden_WhenExistItemContainsStartDateLargerDateTimeNow()
        {
            // arrange
            var folderId = new ID("{B4F0DAD0-B60E-49D9-8332-8DF1A61C5101}");
            var doSomethingCommand = new FakeExample2 { FakeDateTimeNow = new DateTime(2018, 1, 1, 0, 0, 0) };
            var commandContext = new CommandContext();

            using (var db = new Db
            {
                new DbItem("Folder", folderId)
                {
                    new DbItem("child 1")
                    {
                        new DbField("Start Date") { Value = "20181231T235959" }
                    }
                }
            })
            {
                // act
                var commandState = doSomethingCommand.QueryState(commandContext);

                // assert
                commandState.Should().Be(CommandState.Enabled);
            }
        }
    }

    public class FakeExample2 : Example2
    {
        public DateTime FakeDateTimeNow { get; set; }

        public override DateTime GetDateTimeNow()
        {
            return FakeDateTimeNow;
        }
    }
}