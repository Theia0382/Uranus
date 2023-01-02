namespace Uranus.Discord.Builders
{
	public class SlashCommandBuilder
	{
		public string? Name { get; set; }
		public Dictionary<string, string>? NameLocalizations { get; set; }
		public string? Description { get; set; }
		public Dictionary<string, string>? DescriptionLocalizations { get; set; }
		public List<SlashCommandOptionBuilder>? Options { get; set; }
		public string? DefaultMemberPermissions { get; set; }
		public bool? DMPermission { get; set; }
		public ApplicationCommandType? Type = ApplicationCommandType.ChatInput;

		public SlashCommandBuilder SetName( string name ) { Name = name; return this; }
		public SlashCommandBuilder SetNameLocalizations( Dictionary<string, string> nameLocalizaitons ) { NameLocalizations = nameLocalizaitons; return this; }
		public SlashCommandBuilder SetDescription( string description ) { Description = description; return this; }
		public SlashCommandBuilder SetDescriptionLocalizations( Dictionary<string, string> descriptionLocalizaitons ) { DescriptionLocalizations = descriptionLocalizaitons; return this; }
		public SlashCommandBuilder SetOptions( List<SlashCommandOptionBuilder> options ) { Options = options; return this; }
		public SlashCommandBuilder SetDefaultMemberPermissions( string defaultMemberPermissions ) { DefaultMemberPermissions = defaultMemberPermissions; return this; }
		public SlashCommandBuilder SetDMPermission( bool? dmPermission ) { DMPermission = dmPermission; return this; }

		public SlashCommandBuilder AddNameLocalizations( Dictionary<string, string> nameLocalizations )
		{
			NameLocalizations ??= new Dictionary<string, string>( );
			foreach ( KeyValuePair<string, string> items in nameLocalizations )
			{
				NameLocalizations.Add( items.Key, items.Value );
			}
			return this;
		}
		public SlashCommandBuilder AddNameLocalization( string locale, string name )
		{
			NameLocalizations ??= new Dictionary<string, string>( );
			NameLocalizations.Add( locale, name );
			return this;
		}
		public SlashCommandBuilder AddDescriptionLocalizations( Dictionary<string, string> descriptionLocalizations )
		{
			DescriptionLocalizations ??= new Dictionary<string, string>( );
			foreach ( KeyValuePair<string, string> items in descriptionLocalizations )
			{
				DescriptionLocalizations.Add( items.Key, items.Value );
			}
			return this;
		}
		public SlashCommandBuilder AddDescriptionLocalization( string locale, string description )
		{
			DescriptionLocalizations ??= new Dictionary<string, string>( );
			DescriptionLocalizations.Add( locale, description );
			return this;
		}
		public SlashCommandBuilder AddOptions( List<SlashCommandOptionBuilder> options )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			Options.AddRange( options );
			return this;
		}
		public SlashCommandBuilder AddSubCommand( SlashCommandOptionBuilder subCommand )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			subCommand.Type = ApplicationCommandOptionType.SubCommand;
			Options.Add( subCommand );
			return this;
		}
		public SlashCommandBuilder AddSubCommandGroup( SlashCommandOptionBuilder subCommandGroup )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			subCommandGroup.Type = ApplicationCommandOptionType.SubCommandGroup;
			Options.Add( subCommandGroup );
			return this;
		}
		public SlashCommandBuilder AddStringOption( SlashCommandOptionBuilder stringOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			stringOption.Type = ApplicationCommandOptionType.String;
			Options.Add( stringOption );
			return this;
		}
		public SlashCommandBuilder AddIntegerOption( SlashCommandOptionBuilder integerOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			integerOption.Type = ApplicationCommandOptionType.Integer;
			Options.Add( integerOption );
			return this;
		}
		public SlashCommandBuilder AddBooleanOption( SlashCommandOptionBuilder booleanOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			booleanOption.Type = ApplicationCommandOptionType.Boolean;
			Options.Add( booleanOption );
			return this;
		}
		public SlashCommandBuilder AddUserOption( SlashCommandOptionBuilder userOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			userOption.Type = ApplicationCommandOptionType.User;
			Options.Add( userOption );
			return this;
		}
		public SlashCommandBuilder AddChannelOption( SlashCommandOptionBuilder channelOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			channelOption.Type = ApplicationCommandOptionType.Channel;
			Options.Add( channelOption );
			return this;
		}
		public SlashCommandBuilder AddRoleOption( SlashCommandOptionBuilder roleOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			roleOption.Type = ApplicationCommandOptionType.Role;
			Options.Add( roleOption );
			return this;
		}
		public SlashCommandBuilder AddMentionableOption( SlashCommandOptionBuilder mentionableOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			mentionableOption.Type = ApplicationCommandOptionType.Mentionable;
			Options.Add( mentionableOption );
			return this;
		}
		public SlashCommandBuilder AddNumberOption( SlashCommandOptionBuilder numberOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			numberOption.Type = ApplicationCommandOptionType.Number;
			Options.Add( numberOption );
			return this;
		}
		public SlashCommandBuilder AddAttachmentOption( SlashCommandOptionBuilder attachmentOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			attachmentOption.Type = ApplicationCommandOptionType.Attachment;
			Options.Add( attachmentOption );
			return this;
		}

		public SlashCommandProperties Build( )
		{
			SlashCommandProperties properties = new( )
			{
				name = Name,
				name_localizations = NameLocalizations,
				description = Description,
				description_localizations = DescriptionLocalizations,
				default_member_permissions = DefaultMemberPermissions,
				dm_permission = DMPermission,
				type = Type
			};

			if ( Options != null && Options.Any( ) )
			{
				List<SlashCommandOptionProperties> options = new( );
				Options.OrderByDescending( ( SlashCommandOptionBuilder option ) => option.Required.GetValueOrDefault( ) ).ToList( ).ForEach( delegate ( SlashCommandOptionBuilder option )
				{
					options.Add( option.Build( ) );
				} );
				properties.options = options.ToArray( );
			}

			return properties;
		}
	}
}
