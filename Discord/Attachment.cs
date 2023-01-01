namespace Uranus.Discord
{
	public class Attachment
	{
		public string ID { get; init; }
		public string FileName { get; init; }
		public string? Description { get; init; }
		public string? ContentType { get; init; }
		public ulong Size { get; init; }
		public string URL { get; init; }
		public string ProxyURL { get; init; }
		public uint? Height { get; init; }
		public uint? Width { get; init; }
		public bool? Ephemeral { get; init; }
	}
}
