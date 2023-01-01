namespace Uranus.Discord
{
	public class User
	{
		public Client Client { get; init; }
		public string ID { get; init; }
		public string Name { get; init; }
		public string Discriminator { get; init; }
		public string? Avatar { get; init; }
		public bool? Bot { get; init; }
		public bool? System { get; init; }
		public bool? MFAEnabled { get; init; }
		public string? Banner { get; init; }
		public uint? AccentColor { get; init; }
		public string? Locale { get; init; }
		public uint? Flags { get; init; }
		public PremiumType? PremiumType { get; init; }
		public uint? PublicFlags { get; init; }
	}
}
