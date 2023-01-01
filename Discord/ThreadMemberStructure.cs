namespace Uranus.Discord
{
	public struct ThreadMemberStructure
	{
		public string? id { get; set; }
		public string? user_id { get; set; }
		public DateTimeOffset join_timestamp { get; set; }
		public uint flags { get; set; }

		public ThreadMember Solve( )
		{
			ThreadMember member = new( )
			{
				ID = id,
				UserID = user_id,
				JoinTimestamp = join_timestamp,
				Flags = flags
			};

			return member;
		}
	}
}
