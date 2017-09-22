namespace CustomCommand
{
    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Shell.Framework.Commands;
    using System;
    using System.Linq;

    public class Example2 : Command
    {
        public override void Execute(CommandContext context) { }

        public override CommandState QueryState(CommandContext context)
        {
            var folderId = new ID("{B4F0DAD0-B60E-49D9-8332-8DF1A61C5101}");
            var folder = Context.Database.GetItem(folderId);

            if (folder == null)
            {
                return CommandState.Hidden;
            }

            if (folder.HasChildren
                && folder.Children.Any(c => DateUtil.IsoDateToDateTime(c["Start Date"]) > GetDateTimeNow()))
            {
                return CommandState.Enabled;
            }

            return CommandState.Hidden;
        }

        protected virtual DateTime GetDateTimeNow()
        {
            return DateTime.Now;
        }
    }
}