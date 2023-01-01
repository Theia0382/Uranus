namespace Uranus.Discord
{
	public class Sticker
	{
		public string ID { get; init; }
		public string? PackID { get; init; }
		public string Name { get; init; }
		public string? Description { get; init; }
		public string Tags { get; init; }
		public string? Asset { get; init; }
		public StickerType Type { get; init; }
		public StickerFormatType FormatType { get; init; }
		public bool? Available { get; init; }
		public string? GuildID { get; init; }
		public User? User { get; init; }
		public ushort? SortValue { get; init; }
	}
}
