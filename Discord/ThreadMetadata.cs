namespace Uranus.Discord
{
	public class ThreadMetadata
	{
		public bool Archived { get; init; }
		public ushort AutoArchiveDuration { get; init; }
		public DateTimeOffset ArchiveTimestamp { get; init; }
		public bool Locked { get; init; }
		public bool? Invitable { get; init; }
		public DateTimeOffset? CreateTimestamp { get; init; }
	}
}
