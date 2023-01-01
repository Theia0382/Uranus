namespace Uranus.Discord
{
	public class GuildStructure
	{
		public string id { get; set; }
		public string name { get; set; }
		public string? icon { get; set; }
		public string? icon_hash { get; set; }
		public string? splash { get; set; }
		public string? discovery_splash { get; set; }
		public bool? owner { get; set; }
		public string owner_id { get; set; }
		public string? permissions { get; set; }
		public string? region { get; set; }
		public string? afk_channel_id { get; set; }
		public ushort afk_timeout { get; set; }
		public bool? widget_enabled { get; set; }
		public string? widget_channel_id { get; set; }
		public VerificationLevel verification_level { get; set; }
		public DefaultMessageNotificaitonLevel default_message_notificaitons { get; set; }
		public ExplicitContentFilterLevel explicit_content_filter { get; set; }
		public RoleStructure[ ] roles { get; set; }
		public EmojiStructure[ ] emojis { get; set; }
		public string[ ] features { get; set; }
		public MFALevel mfa_level { get; set; }
		public string? application_id { get; set; }
		public string? system_channel_id { get; set; }
		public uint system_channel_flags { get; set; }
		public string? rules_channel_id { get; set; }
		public uint? max_presences { get; set; }
		public uint? max_members { get; set; }
		public string? vanity_url_code { get; set; }
		public string? description { get; set; }
		public string? banner { get; set; }
		public PremiumTier premium_tier { get; set; }
		public uint? premium_subscription_count { get; set; }
		public string preferred_locale { get; set; }
		public string? public_updates_channel_id { get; set; }
		public uint? max_video_channel_users { get; set; }
		public uint? approximate_member_count { get; set; }
		public uint? approximate_presence_count { get; set; }
		public WelComeScreenStructure? welcome_screen { get; set; }
		public StickerStructure[ ]? stickers { get; set; }
		public bool premium_progress_bar_enabled { get; set; }

		public Guild Solve( Client client )
		{
			List<Role> Roles = new( );
			List<Emoji> Emojis = new( );
			List<Sticker>? Stickers = null;
			if ( roles.Any( ) )
			{
				roles.ToList( ).ForEach( delegate ( RoleStructure role )
				{
					Roles.Add( role.Solve( ) );
				} );
			}
			if ( emojis.Any( ) )
			{
				Emojis = new( );
				emojis.ToList( ).ForEach( delegate ( EmojiStructure emoji )
				{
					Emojis.Add( emoji.Solve( client ) );
				} );
			}
			if ( stickers != null && stickers.Any( ) )
			{
				Stickers = new( );
				stickers.ToList( ).ForEach( delegate ( StickerStructure sticker )
				{
					Stickers.Add( sticker.Solve( client ) );
				} );
			}

			Guild guild = new( )
			{
				Client = client,
				ID = id,
				Name = name,
				Icon = icon,
				IconHash = icon_hash,
				Splash = splash,
				DiscoverySplash = discovery_splash,
				Owner = owner,
				OwnerID = owner_id,
				Permissions = permissions,
				Region = region,
				AFKChannelID = afk_channel_id,
				AFKTimeout = afk_timeout,
				WidgetEnabled = widget_enabled,
				WidgetChannelID = widget_channel_id,
				VerificationLevel = verification_level,
				DefaultMessageNotificaitons = default_message_notificaitons,
				ExplicitContentFilter = explicit_content_filter,
				Roles = Roles,
				Emojis = Emojis,
				Features = features.ToList( ),
				MFALevel = mfa_level,
				ApplicationID = application_id,
				SystemChannelID = system_channel_id,
				SystemChannelFlags = system_channel_flags,
				RulesChannelID = rules_channel_id,
				MaxPresences = max_presences,
				MaxMembers = max_members,
				VanityURLCode = vanity_url_code,
				Description = description,
				Banner = banner,
				PremiumTier = premium_tier,
				PremiumSubscriptionCount = premium_subscription_count,
				PreferredLocale = preferred_locale,
				PublicUpdatesChannelID = public_updates_channel_id,
				MaxVideoChannelUsers = max_video_channel_users,
				ApproximateMemberCount = approximate_member_count,
				ApproximatePresenceCount = approximate_presence_count,
				WelcomeScreen = welcome_screen?.Solve( ),
				Stickers = Stickers,
				PremiumProgressBarEnabled = premium_progress_bar_enabled
			};

			return guild;
		}
	}
}
