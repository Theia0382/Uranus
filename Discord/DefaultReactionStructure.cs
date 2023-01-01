namespace Uranus.Discord
{
	public struct DefaultReactionStructure
	{
		public string? emoji_id { get; set; }
		public string? emoji_name { get; set; }

		public DefaultReaction Solve( )
		{
			DefaultReaction reaction = new( )
			{
				EmojiID = emoji_id,
				EmojiName = emoji_name
			};

			return reaction;
		}
	}
}
