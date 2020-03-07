using Terraria.Achievements;
using WebmilioCommons.Achievements;

namespace IndustrialPickaxes.Achievements
{
	internal class DraconicEvolution : ModAchievement
	{
		public DraconicEvolution() : base("Happily Ever After", "Create the ultimate Industrial Pickaxe, the culmination of your journey.", AchievementCategory.Collector)
		{
		}

		public override void SetDefaults() => AddCompletionFlag();
	}
}