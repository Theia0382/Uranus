namespace Uranus.Discord
{
	public struct GuildMemberStructure
	{
		public UserStructure? user { get; set; }
		public string? nick { get; set; }
		public string? avatar { get; set; }
		public string[ ] roles { get; set; }
		public DateTimeOffset joined_at { get; set; }
		public DateTimeOffset? premium_since { get; set; }
		public bool deaf { get; set; }
		public bool mute { get; set; }
		public bool? pending { get; set; }
		public string? permissions { get; set; }
		public DateTimeOffset? communication_disabled_until { get; set; }

		public GuildMember Solve( Client client )
		{
			GuildMember member = new( )
			{
				Client = client,
				User = user?.Solve( client ),
				Nick = nick,
				Avatar = avatar,
				Roles = roles.ToList( ),
				JoinedAt = joined_at,
				PremiumSince = premium_since,
				Deaf = deaf,
				Mute = mute,
				Pending = pending,
				Permissions = permissions,
				CommunicationDisabledUntil = communication_disabled_until
			};

			return member;
		}
	}
}
