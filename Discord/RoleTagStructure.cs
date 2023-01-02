namespace Uranus.Discord
{
	public class RoleTagsStructure
	{
		public string? bot_id { get; set; }
		public string? integration_id { get; set; }
		public object? premium_subscriber { get; set; }

		public RoleTags Resolve( )
		{
			bool? PremiumSubscriber = null;
			if ( premium_subscriber != null )
			{
				PremiumSubscriber = true;
			}

			RoleTags tags = new( )
			{
				BotID = bot_id,
				IntegrationID = integration_id,
				PrimiumSubscriber = PremiumSubscriber
			};

			return tags;
		}
	}
}
