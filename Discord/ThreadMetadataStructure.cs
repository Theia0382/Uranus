namespace Uranus.Discord
{
	public struct ThreadMetadataStructure
	{
		public bool archived { get; set; }
		public ushort auto_archive_duration { get; set; }
		public DateTimeOffset archive_timestamp { get; set; }
		public bool locked { get; set; }
		public bool? invitable { get; set; }
		public DateTimeOffset? create_timestamp { get; set; }

		public ThreadMetadata Resolve( )
		{
			ThreadMetadata metadata = new( )
			{
				Archived = archived,
				AutoArchiveDuration = auto_archive_duration,
				ArchiveTimestamp = archive_timestamp,
				Locked = locked,
				Invitable = invitable,
				CreateTimestamp = create_timestamp
			};

			return metadata;
		}
	}
}
