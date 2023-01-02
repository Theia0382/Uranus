using System.Text.Json;

namespace Uranus.Discord
{
	public class CommandInteraction : BaseInteraction
	{
		public CommandData CommandData { get; init; }

		public async Task ReplyAsync( string content )
		{
			string path = $"/interactions/{ID}/{Token}/callback";
			string str = $@"
			{{
				""type"" : 4,
				""data"" :
				{{
					""content"" : ""{content}""
				}}
			}}";
			JsonDocument data = JsonDocument.Parse( str );

			await Client.HttpPostAsync( path, data );
		}

		public async Task DeferReplyAsync( )
		{
			string path = $"/interactions/{ID}/{Token}/callback";
			string str = $@"
			{{
				""type"" : 5
			}}";
			JsonDocument data = JsonDocument.Parse( str );

			await Client.HttpPostAsync( path, data );
		}

		public async Task EditReplyAsync( string content )
		{
			string path = $"/webhooks/{ApplicationID}/{Token}/messages/@original";
			string str = $@"
			{{
				""content"" : ""{content}""
			}}";
			JsonDocument data = JsonDocument.Parse( str );

			await Client.HttpPatchAsync( path, data );
		}
	}
}
