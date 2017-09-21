namespace CustomCommandTests
{
    using CustomCommand;
    using FluentAssertions;
    using NUnit.Framework;
    using Sitecore.Data;
    using Sitecore.FakeDb;
    using Sitecore.Shell.Framework.Commands;

    public class Example1Tests
    {
        [TestCase]
        public void CommandState_ShouldBeHidden_WhenFolderDoesNotExist()
        {
            // arrange
            var doSomethingCommand = new Example1();
            var commandContext = new CommandContext();

            using (var db = new Db { })
            {
                // act
                var commandState = doSomethingCommand.QueryState(commandContext);

                // assert
                commandState.Should().Be(CommandState.Hidden);
            }
        }

        [TestCase]
        public void CommandState_ShouldBeHidden_WhenNoChildren()
        {
            // arrange
            var folderId = new ID("{B4F0DAD0-B60E-49D9-8332-8DF1A61C5101}");
            var doSomethingCommand = new Example1();
            var commandContext = new CommandContext();

            using (var db = new Db
            {
                new DbItem("Folder", folderId)
            })
            {
                // act
                var commandState = doSomethingCommand.QueryState(commandContext);

                // assert
                commandState.Should().Be(CommandState.Hidden);
            }
        }

        [TestCase]
        public void CommandState_ShouldBeHidden_WhenChildrenExist()
        {
            // arrange
            var folderId = new ID("{B4F0DAD0-B60E-49D9-8332-8DF1A61C5101}");
            var doSomethingCommand = new Example1();
            var commandContext = new CommandContext();

            using (var db = new Db
            {
                new DbItem("Folder", folderId)
                {
                    new DbItem("child 1"),
                    new DbItem("child 2")
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
}