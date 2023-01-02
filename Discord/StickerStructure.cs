namespace Uranus.Discord
{
	public struct StickerStructure
	{
		public string id { get; set; }
		public string? pack_id { get; set; }
		public string name { get; set; }
		public string? description { get; set; }
		public string tags { get; set; }
		public string? asset {get; set; }
		public StickerType type { get; set; }
		public StickerFormatType format_type { get; set; }
		public bool? available { get; set; }
		public string? guild_id { get; set; }
		public UserStructure? user { get; set; }
		public ushort? sort_value { get; set; }

		public Sticker Resolve( Client client )
		{
			Sticker sticker = new( )
			{
				ID = id,
				PackID = pack_id,
				Name = name,
				Description = description,
				Tags = tags,
				Asset = asset,
				Type = type,
				FormatType = format_type,
				Available = available,
				GuildID = guild_id,
				User = user?.Resolve( client ),
				SortValue = sort_value
			};

			return sticker;
		}
	}
}
