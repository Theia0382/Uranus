namespace Uranus.Discord
{
	public struct ForumTagStructure
	{
		public string id { get; set; }
		public string name { get; set; }
		public bool moderated { get; set; }
		public string emoji_id { get; set; }
		public string? emoji_name { get; set; }

		public ForumTag Solve( )
		{
			ForumTag tag = new( )
			{
				ID = id,
				Name = name,
				Moderated = moderated,
				EmojiID = emoji_id,
				EmojiName = emoji_name
			};

			return tag;
		}
	}
}
