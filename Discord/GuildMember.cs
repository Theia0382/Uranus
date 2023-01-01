namespace Uranus.Discord
{
	public class GuildMember
	{
		public Client Client { get; init; }
		public User? User { get; init; }
		public string? Nick { get; init; }
		public string? Avatar { get; init; }
		public List<string> Roles { get; init; }
		public DateTimeOffset JoinedAt { get; init; }
		public DateTimeOffset? PremiumSince { get; init; }
		public bool Deaf { get; init; }
		public bool Mute { get; init; }
		public bool? Pending { get; init; }
		public string? Permissions { get; init; }
		public DateTimeOffset? CommunicationDisabledUntil { get; init; }
	}
}
