namespace Uranus.Discord
{
	public struct EmojiStructure
	{
		public string? id { get; set; }
		public string? name { get; set; }
		public string[ ]? roles { get; set; }
		public UserStructure? user { get; set; }
		public bool? require_colons { get; set; }
		public bool? managed { get; set; }
		public bool? animated { get; set; }
		public bool? available { get; set; }

		public Emoji Resolve( Client client )
		{
			Emoji emoji = new( )
			{
				ID = id,
				Name = name,
				Roles = roles?.ToList( ),
				User = user?.Resolve( client ),
				RequireColons = require_colons,
				Managed = managed,
				Animated = animated,
				Available = available
			};

			return emoji;
		}
	}
}
