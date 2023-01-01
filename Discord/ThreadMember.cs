namespace Uranus.Discord
{
	public class ThreadMember
	{
		public string? ID { get; init; }
		public string? UserID { get; init; }
		public DateTimeOffset JoinTimestamp { get; init; }
		public uint Flags { get; init; }
	}
}
