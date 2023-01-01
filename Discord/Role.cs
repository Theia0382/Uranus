namespace Uranus.Discord
{
	public class Role
	{
		public string ID { get; init; }
		public string Name { get; init; }
		public uint Color { get; init; }
		public bool Hoist { get; init; }
		public string? Icon { get; init; }
		public string? UnicodeEmoji { get; init; }
		public ushort Position { get; init; }
		public string Permissions { get; init; }
		public bool Managed { get; init; }
		public bool Mentionable { get; init; }
		public RoleTags? Tags { get; init; }
	}
}
