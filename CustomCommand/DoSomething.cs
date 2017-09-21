namespace CustomCommand
{
    using Sitecore.Data;
    using Sitecore.Shell.Framework.Commands;

    public class DoSomething : Command
    {
        public override void Execute(CommandContext context) { }

        public override CommandState QueryState(CommandContext context)
        {
            var folderId = new ID("{B4F0DAD0-B60E-49D9-8332-8DF1A61C5101}");
            var folder = Sitecore.Context.Database.GetItem(folderId);

            if (folder == null)
            {
                return CommandState.Hidden;
            }

            return folder.HasChildren ? CommandState.Enabled : CommandState.Hidden;
        }
    }
}