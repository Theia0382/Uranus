namespace Uranus.Discord.Builders
{
	public class SlashCommandOptionBuilder
	{
		public ApplicationCommandOptionType? Type { get; set; }
		public string? Name { get; set; }
		public Dictionary<string, string>? NameLocalizations { get; set; }
		public string? Description { get; set; }
		public Dictionary<string, string>? DescriptionLocalizations { get; set; }
		public bool? Required { get; set; }
		public List<SlashCommandOptionChoiceBuilder>? Choices { get; set; }
		public List<SlashCommandOptionBuilder>? Options { get; set; }
		public List<ChannelType>? ChannelTypes { get; set; }
		public double? MinValue { get; set; }
		public double? MaxValue { get; set; }
		public ushort? MinLength { get; set; }
		public ushort? MaxLength { get; set; }
		public bool? Autocomplete { get; set; }

		public SlashCommandOptionBuilder SetName( string name ) { Name = name; return this; }
		public SlashCommandOptionBuilder SetNameLocalizations( Dictionary<string, string> nameLocalizaitons ) { NameLocalizations = nameLocalizaitons; return this; }
		public SlashCommandOptionBuilder SetDescription( string description ) { Description = description; return this; }
		public SlashCommandOptionBuilder SetDescriptionLocalizations( Dictionary<string, string> descriptionLocalizaitons ) { DescriptionLocalizations = descriptionLocalizaitons; return this; }
		public SlashCommandOptionBuilder SetRequired( bool required ) { Required = required; return this; }
		public SlashCommandOptionBuilder SetChoices( List<SlashCommandOptionChoiceBuilder> choices ) { Choices = choices; return this; }
		public SlashCommandOptionBuilder SetOptions( List<SlashCommandOptionBuilder> options ) { Options = options; return this; }
		public SlashCommandOptionBuilder SetChannelTypes( List<ChannelType> channelTypes ) { ChannelTypes = channelTypes; return this; }
		public SlashCommandOptionBuilder SetMinValue( double minValue ) { MinValue = minValue; return this; }
		public SlashCommandOptionBuilder SetMaxValue( double maxValue ) { MaxValue = maxValue; return this; }
		public SlashCommandOptionBuilder SetMinLength( ushort minLength ) { MinLength = minLength; return this; }
		public SlashCommandOptionBuilder SetMaxLength( ushort maxLength ) { MaxLength = maxLength; return this; }
		public SlashCommandOptionBuilder SetAutocomplete( bool autocomplete ) { Autocomplete = autocomplete; return this; }

		public SlashCommandOptionBuilder AddOptions( List<SlashCommandOptionBuilder> options )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			Options.AddRange( options );
			return this;
		}
		public SlashCommandOptionBuilder AddChoices( List<SlashCommandOptionChoiceBuilder> choices )
		{
			Choices ??= new List<SlashCommandOptionChoiceBuilder>( );
			Choices.AddRange( choices );
			return this;
		}
		public SlashCommandOptionBuilder AddChoice( SlashCommandOptionChoiceBuilder choice )
		{
			Choices ??= new List<SlashCommandOptionChoiceBuilder>( );
			Choices.Add( choice );
			return this;
		}

		public SlashCommandOptionBuilder AddSubCommand( SlashCommandOptionBuilder subCommand )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			subCommand.Type = ApplicationCommandOptionType.SubCommand;
			Options.Add( subCommand );
			return this;
		}
		public SlashCommandOptionBuilder AddStringOption( SlashCommandOptionBuilder stringOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			stringOption.Type = ApplicationCommandOptionType.String;
			Options.Add( stringOption );
			return this;
		}
		public SlashCommandOptionBuilder AddIntegerOption( SlashCommandOptionBuilder integerOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			integerOption.Type = ApplicationCommandOptionType.Integer;
			Options.Add( integerOption );
			return this;
		}
		public SlashCommandOptionBuilder AddBooleanOption( SlashCommandOptionBuilder booleanOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			booleanOption.Type = ApplicationCommandOptionType.Boolean;
			Options.Add( booleanOption );
			return this;
		}
		public SlashCommandOptionBuilder AddUserOption( SlashCommandOptionBuilder userOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			userOption.Type = ApplicationCommandOptionType.User;
			Options.Add( userOption );
			return this;
		}
		public SlashCommandOptionBuilder AddChannelOption( SlashCommandOptionBuilder channelOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			channelOption.Type = ApplicationCommandOptionType.Channel;
			Options.Add( channelOption );
			return this;
		}
		public SlashCommandOptionBuilder AddRoleOption( SlashCommandOptionBuilder roleOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			roleOption.Type = ApplicationCommandOptionType.Role;
			Options.Add( roleOption );
			return this;
		}
		public SlashCommandOptionBuilder AddMentionableOption( SlashCommandOptionBuilder mentionableOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			mentionableOption.Type = ApplicationCommandOptionType.Mentionable;
			Options.Add( mentionableOption );
			return this;
		}
		public SlashCommandOptionBuilder AddNumberOption( SlashCommandOptionBuilder numberOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			numberOption.Type = ApplicationCommandOptionType.Number;
			Options.Add( numberOption );
			return this;
		}
		public SlashCommandOptionBuilder AddAttachmentOption( SlashCommandOptionBuilder attachmentOption )
		{
			Options ??= new List<SlashCommandOptionBuilder>( );
			attachmentOption.Type = ApplicationCommandOptionType.Attachment;
			Options.Add( attachmentOption );
			return this;
		}

		public SlashCommandOptionProperties Build( )
		{
			SlashCommandOptionProperties properties = new( )
			{
				type = Type,
				name = Name,
				name_localizations = NameLocalizations,
				description = Description,
				description_localizations = DescriptionLocalizations,
				required = Required,
				channel_types = ChannelTypes?.ToArray( ),
				min_value = MinValue,
				max_value = MaxValue,
				min_length = MinLength,
				max_length = MaxLength,
				autocomplete = Autocomplete
			};

			if ( Choices != null && Choices.Any( ) )
			{
				List<SlashCommandOptionChoiceProperties> choices = new( );
				Choices.ForEach( delegate ( SlashCommandOptionChoiceBuilder choice )
				{
					choices.Add( choice.Build( ) );
				} );
				properties.choices = choices.ToArray( );
			}

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