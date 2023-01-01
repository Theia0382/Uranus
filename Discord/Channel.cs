namespace Uranus.Discord
{
	public class Channel
	{
		public Client Client { get; init; }
		public string ID { get; init; }
		public ChannelType Type { get; init; }
		public string? GuildID { get; init; }
		public ushort? Position { get; init; }
		public List<Overwrite>? PermissionOverwrites { get; init; }
		public string? Name { get; init; }
		public string? Topic { get; init; }
		public string? LastMessageID { get; init; }
		public uint? Bitrate { get; init; }
		public ushort? UserLimit { get; init; }
		public ushort? RateLimitPerUser { get; init; }
		public List<User>? Recipients { get; init; }
		public string? Icon { get; init; }
		public string? OwnerID { get; init; }
		public string? ApplicationID { get; init; }
		public string? ParentID { get; init; }
		public DateTimeOffset? LastPinTimestamp { get; init; }
		public string? RTCRegion { get; init; }
		public VideoQualityMode? VideoQualityMode { get; init; }
		public uint? MessageCount { get; init; }
		public ushort? MemberCount { get; init; }
		public ThreadMetadata? ThreadMetadata { get; init; }
		public ThreadMember? Member { get; init; }
		public ushort? DefaultAutoArchiveDuration { get; init; }
		public string? Permissions { get; init; }
		public uint? Flags { get; init; }
		public uint? TotalMessageSent { get; init; }
		public List<ForumTag>? AvailableTags { get; init; }
		public List<string>? AppliedTags { get; init; }
		public DefaultReaction? DefaultReactionEmoji { get; init; }
		public ushort? DefaultThreadRateLimitPerUser { get; init; }
		public SortOrderType? DefaultSortOrder { get; init; }
		public ForumLayoutType? DefaultForumLayout { get; init; }
	}
}
