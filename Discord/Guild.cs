namespace Uranus.Discord
{
	public class Guild
	{
		public Client Client { get; init; }
		public string ID { get; init; }
		public string Name { get; init; }
		public string? Icon { get; init; }
		public string? IconHash { get; init; }
		public string? Splash { get; init; }
		public string? DiscoverySplash { get; init; }
		public bool? Owner { get; init; }
		public string OwnerID { get; init; }
		public string? Permissions { get; init; }
		public string? Region { get; init; }
		public string? AFKChannelID { get; init; }
		public ushort AFKTimeout { get; init; }
		public bool? WidgetEnabled { get; init; }
		public string? WidgetChannelID { get; init; }
		public VerificationLevel VerificationLevel { get; init; }
		public DefaultMessageNotificaitonLevel DefaultMessageNotificaitons { get; init; }
		public ExplicitContentFilterLevel ExplicitContentFilter { get; init; }
		public List<Role> Roles { get; init; }
		public List<Emoji> Emojis { get; init; }
		public List<string> Features { get; init; }
		public MFALevel MFALevel { get; init; }
		public string? ApplicationID { get; init; }
		public string? SystemChannelID { get; init; }
		public uint SystemChannelFlags { get; init; }
		public string? RulesChannelID { get; init; }
		public uint? MaxPresences { get; init; }
		public uint? MaxMembers { get; init; }
		public string? VanityURLCode { get; init; }
		public string? Description { get; init; }
		public string? Banner { get; init; }
		public PremiumTier PremiumTier { get; init; }
		public uint? PremiumSubscriptionCount { get; init; }
		public string PreferredLocale { get; init; }
		public string? PublicUpdatesChannelID { get; init; }
		public uint? MaxVideoChannelUsers { get; init; }
		public uint? ApproximateMemberCount { get; init; }
		public uint? ApproximatePresenceCount { get; init; }
		public WelcomeScreen? WelcomeScreen { get; init; }
		public List<Sticker>? Stickers { get; init; }
		public bool PremiumProgressBarEnabled { get; init; }
	}
}
