using System.Text.Json;

namespace Uranus.Discord
{
	public struct InteractionStructure
	{
		public string id { get; set; }
		public string application_id { get; set; }
		public InteractionType type { get; set; }
		public JsonElement? data { get; set; }
		public string? guild_id { get; set; }
		public string? channel_id { get; set; }
		public GuildMemberStructure? member { get; set; }
		public UserStructure? user { get; set; }
		public string token { get; set; }
		public byte version { get; set; }
		public string? app_permissions { get; set; }
		public string? locale { get; set; }
		public string? guild_locale { get; set; }

		public BaseInteraction Resolve( Client client )
		{
			if ( type == InteractionType.ApplicationCommand )
			{
				ApplicationCommandDataStructure Data = JsonSerializer.Deserialize<ApplicationCommandDataStructure>( ( JsonElement )data );

				CommandInteraction interaction = new( )
				{
					Client = client,
					ID = id,
					ApplicationID = application_id,
					Type = type,
					CommandData = Data.Resolve( ),
					GuildID = guild_id,
					ChannelID = channel_id,
					Member = member?.Resolve( client ),
					User = user?.Resolve( client ),
					Token = token,
					Version = version,
					AppPermissions = app_permissions,
					Locale = locale,
					GuildLocale = guild_locale
				};

				return interaction;
			}
			else
			{
				BaseInteraction interaction = new( )
				{
					ID = id,
					ApplicationID = application_id,
					Type = type,
					GuildID = guild_id,
					ChannelID = channel_id,
					Member = member?.Resolve( client ),
					User = user?.Resolve( client ),
					Token = token,
					Version = version,
					AppPermissions = app_permissions,
					Locale = locale,
					GuildLocale = guild_locale
				};
				return interaction;
			}
		}
	}
}
