namespace Uranus.Discord
{
	public struct RoleStructure
	{
		public string id { get; set; }
		public string name { get; set; }
		public uint color { get; set; }
		public bool hoist { get; set; }
		public string? icon { get; set; }
		public string? unicode_emoji { get; set; }
		public ushort position { get; set; }
		public bool managed { get; set; }
		public bool mentionable { get; set; }
		public RoleTagsStructure? tags { get; set; }

		public Role Solve( )
		{
			Role role = new( )
			{
				ID = id,
				Name = name,
				Color = color,
				Hoist = hoist,
				Icon = icon,
				UnicodeEmoji = unicode_emoji,
				Position = position,
				Managed = managed,
				Mentionable = mentionable,
				Tags = tags?.Solve( )
			};

			return role;
		}
	}
}
