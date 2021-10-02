using Terraria.ModLoader;

namespace IndustrialPickaxes.Commands
{
    public class CommandAddOre : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "ip_addore";

        public override string Description => "Debug command. Adds the specified ore with the specified smelt chance and result, not saved on reload.";

        public override string Usage => "/ip_addore INT[ore] INT[chance] INT[result]";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            caller.Reply("Added tile " + args[0] + " with chance " + args[1] + " and result " + args[2]);
            Helpers.OreList.AddOres(int.Parse(args[0]), int.Parse(args[1]), int.Parse(args[2]));
        }
    }

    public class CommandRegenOreList : ModCommand 
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "ip_regenores";

        public override string Description => "Debug command. Regenerates the ore lists, only use this if you know what you're doing.";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            caller.Reply("Regenerated ore lists");
            Helpers.OreList.RegenerateOres();
        }
    }

    public class CommandClearOreList : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "ip_clearores";

        public override string Description => "Debug command. Clears the ore lists, only use this if you know what you're doing.";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            caller.Reply("Cleared ore lists");
            Helpers.OreList.ClearOres();
        }
    }

    public class CommandGetLists : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "ip_getlist";

        public override string Description => "Debug command. Retrieves all current lists.";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            for (int i = 0; i < Helpers.OreList.oreType.Count; i++)
            {
                caller.Reply("Tile: " + Helpers.OreList.oreType[i] + ", Chance: " + Helpers.OreList.smeltChance[i] + ", Item: " + Helpers.OreList.barType[i]);
            }
            caller.Reply("Total: " + Helpers.OreList.oreType.Count + "/" + Helpers.OreList.oreType.Capacity);
        }
    }
}
