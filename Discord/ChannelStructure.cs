namespace Uranus.Discord
{
	public struct ChannelStructure
	{
		public string id { get; set; }
		public ChannelType type { get; set; }
		public string? guild_id { get; set; }
		public ushort? position { get; set; }
		public OverwriteStructure[ ]? permission_overwrites { get; set; }
		public string? name { get; set; }
		public string? topic { get; set; }
		public string? last_message_id { get; set; }
		public uint? bitrate { get; set; }
		public ushort? user_limit { get; set; }
		public ushort? rate_limit_per_user { get; set; }
		public UserStructure[ ]? recipients { get; set; }
		public string? icon { get; set; }
		public string? owner_id { get; set; }
		public string? application_id { get; set; }
		public string? parent_id { get; set; }
		public DateTimeOffset? last_pin_timestamp { get; set; }
		public string? rtc_region { get; set; }
		public VideoQualityMode? video_quality_mode { get; set; }
		public uint? message_count { get; set; }
		public ushort? member_count { get; set; }
		public ThreadMetadataStructure? thread_metadata { get; set; }
		public ThreadMemberStructure? member { get; set; }
		public ushort? default_auto_archive_duration { get; set; }
		public string? permissions { get; set; }
		public uint? flags { get; set; }
		public uint? total_message_sent { get; set; }
		public ForumTagStructure[ ]? available_tags { get; set; }
		public string[ ]? applied_tags { get; set; }
		public DefaultReactionStructure? default_reaction_emoji { get; set; }
		public ushort? default_thread_rate_limit_per_user { get; set; }
		public SortOrderType? default_sort_order { get; set; }
		public ForumLayoutType? default_forum_layout { get; set; }

		public Channel Resolve( Client client )
		{
			List<Overwrite>? PermissionOverwrites = null;
			List<User>? Recipients = null;
			List<ForumTag>? AvailableTags = null;
			if ( permission_overwrites != null && permission_overwrites.Any( ) )
			{
				PermissionOverwrites = new( );
				permission_overwrites.ToList( ).ForEach( delegate ( OverwriteStructure overwrite )
				{
					PermissionOverwrites.Add( overwrite.Resolve( ) );
				} );
			}
			if ( recipients != null && recipients.Any( ) )
			{
				Recipients = new( );
				recipients.ToList( ).ForEach( delegate ( UserStructure recipient )
				{
					Recipients.Add( recipient.Resolve( client ) );
				} );
			}
			if ( available_tags != null && available_tags.Any( ) )
			{
				AvailableTags = new( );
				available_tags.ToList( ).ForEach( delegate ( ForumTagStructure available_tag )
				{
					AvailableTags.Add( available_tag.Resolve( ) );
				} );
			}

			Channel channel = new( )
			{
				Client = client,
				ID = id,
				Type = type,
				GuildID = guild_id,
				Position = position,
				PermissionOverwrites = PermissionOverwrites,
				Name = name,
				Topic = topic,
				LastMessageID = last_message_id,
				Bitrate = bitrate,
				UserLimit = user_limit,
				RateLimitPerUser = rate_limit_per_user,
				Recipients = Recipients,
				Icon = icon,
				OwnerID = owner_id,
				ApplicationID = application_id,
				ParentID = parent_id,
				LastPinTimestamp = last_pin_timestamp,
				RTCRegion = rtc_region,
				VideoQualityMode = video_quality_mode,
				MessageCount = message_count,
				MemberCount = member_count,
				ThreadMetadata = thread_metadata?.Resolve( ),
				Member = member?.Resolve( ),
				DefaultAutoArchiveDuration = default_auto_archive_duration,
				Permissions = permissions,
				Flags = flags,
				TotalMessageSent = total_message_sent,
				AvailableTags = AvailableTags,
				AppliedTags = applied_tags?.ToList( ),
				DefaultReactionEmoji = default_reaction_emoji?.Resolve( ),
				DefaultThreadRateLimitPerUser = default_thread_rate_limit_per_user,
				DefaultSortOrder = default_sort_order,
				DefaultForumLayout = default_forum_layout
			};

			return channel;
		}
	}
}
