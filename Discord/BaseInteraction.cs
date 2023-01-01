namespace Uranus.Discord
{
	public class BaseInteraction
	{
		public Client Client { get; init; }
		public string ID { get; init; }
		public string ApplicationID { get; init; }
		public InteractionType Type { get; init; }
		public string? GuildID { get; init; }
		public string? ChannelID { get; init; }
		public GuildMember? Member { get; init; }
		public User? User { get; init; }
		public string Token { get; init; }
		public byte Version { get; init; }
		public string? AppPermissions { get; init; }
		public string? Locale { get; init; }
		public string? GuildLocale { get; init; }
	}
}
