using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using Uranus.Discord.Builders;

namespace Uranus.Discord
{
	public class Client
	{
		public string Token;
		public User? User { get; private set; }

		private readonly ClientWebSocket wsClient = new( );
		private readonly HttpClient httpClient = new( );
		private const string WebSocketUri = "wss://gateway.discord.gg/?v=10&encoding=json";
		private const string HttpBaseUri = "https://discord.com/api/v10";
		private uint? s;

		public Client( string token )
		{
			ArgumentNullException.ThrowIfNull( token );

			Token = token;
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bot", Token );
			WebSocketData += OnWebSocketData;
			Hello += OnHello;
			Heartbeat += OnHeartbeat;
		}

		public async Task LoginAsync( )
		{
			Uri uri = new( WebSocketUri );

			Console.WriteLine( $"Connecting to {uri}" );

			await wsClient.ConnectAsync( uri, CancellationToken.None );

			while ( wsClient.State == WebSocketState.Open )
			{
				ArraySegment<byte> buffer = new byte[ 1024 * 4 ];
				WebSocketReceiveResult request = wsClient.ReceiveAsync( buffer, CancellationToken.None ).Result;
				JsonDocument data = JsonDocument.Parse( buffer[ ..request.Count ] );

				WebSocketData( data );
			}
		}

		public async Task<User?> GetUserAsync( string user_id )
		{
			string path = $"/users/{user_id}";

			Console.WriteLine( $"Get User\nUser ID: {user_id}" );

			HttpResponseMessage response = await HttpGetAsync( path );
			if ( response.IsSuccessStatusCode )
			{
				string data = await response.Content.ReadAsStringAsync( );
				User user = JsonSerializer.Deserialize<UserStructure>( data ).Resolve( this );

				return user;
			}
			else
			{
				return null;
			}
		}
		public async Task<Guild?> GetGuildAsync( string guild_id )
		{
			string path = $"/guilds/{guild_id}";

			Console.WriteLine( $"Get Guild\nGuild ID: {guild_id}" );

			HttpResponseMessage response = await HttpGetAsync( path );

			if ( response.IsSuccessStatusCode )
			{
				string data = await response.Content.ReadAsStringAsync( );
				Guild guild = JsonSerializer.Deserialize<GuildStructure>( data ).Resolve( this );

				return guild;
			}
			else
			{
				return null;
			}
		}
		public async Task<Channel?> GetChannelAsync( string channel_id )
		{
			string path = $"/channels/{channel_id}";

			Console.WriteLine( $"Get Channel\nChannel ID: {channel_id}" );

			HttpResponseMessage response = await HttpGetAsync( path );

			if ( response.IsSuccessStatusCode )
			{
				string data = await response.Content.ReadAsStringAsync( );
				Channel channel = JsonSerializer.Deserialize<ChannelStructure>( data ).Resolve( this );

				return channel;
			}
			else
			{
				return null;
			}
		}

		public async Task BulkOverwriteGlobalApplicationCommandsAsync( List<SlashCommandProperties> commandList, string application_id )
		{
			string path = $"/applications/{application_id}/commands";
			string str = "[";
			commandList.ForEach( command =>
			{
				str = str + JsonSerializer.Serialize( command ) + ',';
			} );
			str = str.TrimEnd( ',' ) + ']';
			JsonDocument data = JsonDocument.Parse( str );

			Console.WriteLine( $"Bulk overwrite global application commands\nApplication ID: {application_id}\nCommands: {str}" );

			await HttpPutAsync( path, data );
		}
		public async Task BulkOverwriteGuildApplicationCommandsAsync( List<SlashCommandProperties> commandList, string application_id, string guild_id )
		{
			string path = $"/applications/{application_id}/guilds/{guild_id}/commands";
			string str = "[";
			commandList.ForEach( command =>
			{
				str = str + JsonSerializer.Serialize( command ) + ',';
			} );
			str = str.TrimEnd( ',' ) + ']';
			JsonDocument data = JsonDocument.Parse( str );

			Console.WriteLine( $"Bulk overwrite guild application commands\nApplication ID: {application_id}\nGuild ID: {guild_id}\nCommands: {str}" );

			await HttpPutAsync( path, data );
		}

		public async Task WebSocketSendAsync( JsonDocument data )
		{
			ArraySegment<byte> message = new( Encoding.UTF8.GetBytes( data.RootElement.GetRawText( ) ) );

			Console.WriteLine( $"\nSend data through websocket\nData:\n{data.RootElement}\n" );

			await wsClient.SendAsync( message, WebSocketMessageType.Text, true, CancellationToken.None );
		}
		public async Task<HttpResponseMessage> HttpGetAsync( string path )
		{
			Uri uri = new( $"{HttpBaseUri}{path}" );

			Console.WriteLine( $"\nGet data through http\nUri: {uri}\n" );

			HttpResponseMessage response = await httpClient.GetAsync( uri );

			Console.WriteLine( $"\nReceived data through http\nUri: {uri}\nStatusCode: {response.StatusCode}\nContent: {await response.Content.ReadAsStringAsync( )}\n" );

			return response;
		}
		public async Task<HttpResponseMessage> HttpPostAsync( string path, JsonDocument data )
		{
			Uri uri = new( $"{HttpBaseUri}{path}" );
			StringContent json = new( data.RootElement.GetRawText( ), Encoding.UTF8, "application/json" );

			Console.WriteLine( $"\nPost data through http\nUri: {uri}\nData: {data.RootElement.GetRawText( )}\n" );

			HttpResponseMessage response = await httpClient.PostAsync( uri, json );

			Console.WriteLine( $"\nReceived data through http\nUri: {uri}\nStatusCode: {response.StatusCode}\nContent: {await response.Content.ReadAsStringAsync( )}\n" );

			return response;
		}
		public async Task<HttpResponseMessage> HttpPatchAsync( string path, JsonDocument data )
		{
			Uri uri = new( $"{HttpBaseUri}{path}" );
			StringContent json = new( data.RootElement.GetRawText( ), Encoding.UTF8, "application/json" );

			Console.WriteLine( $"\nPatch data through http\nUri: {uri}\nData: {data.RootElement.GetRawText( )}\n" );

			HttpResponseMessage response = await httpClient.PatchAsync( uri, json );

			Console.WriteLine( $"\nReceived data through http\nUri: {uri}\nStatusCode: {response.StatusCode}\nContent: {await response.Content.ReadAsStringAsync( )}\n" );

			return response;
		}
		public async Task<HttpResponseMessage> HttpPutAsync( string path, JsonDocument data )
		{
			Uri uri = new( $"{HttpBaseUri}{path}" );
			StringContent json = new( data.RootElement.GetRawText( ), Encoding.UTF8, "application/json" );

			Console.WriteLine( $"\nPut data through http\nUri: {uri}\nData: {data.RootElement.GetRawText( )}\n" );

			HttpResponseMessage response = await httpClient.PutAsync( uri, json );

			Console.WriteLine( $"\nReceived data through http\nUri: {uri}\nStatusCode: {response.StatusCode}\nContent: {await response.Content.ReadAsStringAsync( )}\n" );

			return response;
		}

		private async Task OnWebSocketData( JsonDocument data )
		{
			Console.WriteLine( $"\nReceived data through websocket\nData:\n{data.RootElement}\n" );

			ushort op = data.RootElement.GetProperty( "op" ).GetUInt16( );

			if ( data.RootElement.GetProperty( "s" ).GetRawText( ) != "null" )
			{
				s = data.RootElement.GetProperty( "s" ).GetUInt32( );
			}

			if ( op == 0 )
			{
				string? t = data.RootElement.GetProperty( "t" ).GetString( );

				if ( t == "READY" )
				{
					User = JsonSerializer.Deserialize<UserStructure>( data.RootElement.GetProperty( "d" ).GetProperty( "user" ).GetRawText( ) ).Resolve( this );

					Ready( this );
				}

				else if ( t == "INTERACTION_CREATE" )
				{
					BaseInteraction interaction = JsonSerializer.Deserialize<InteractionStructure>( data.RootElement.GetProperty( "d" ) ).Resolve( this );

					InteractionCreate( interaction );
				}
			}

			else if ( op == 1 )
			{
				Heartbeat( );
			}

			else if ( op == 10 )
			{
				Hello( data );
			}
		}
		private async Task OnHello( JsonDocument data )
		{
			await SendIdentify( );

			while ( true )
			{
				await Task.Delay( data.RootElement.GetProperty( "d" ).GetProperty( "heartbeat_interval" ).GetInt32( ) );
				SendHeartbeat( );
			}
		}
		private async Task OnHeartbeat( )
		{
			SendHeartbeat( );
		}

		private async Task SendIdentify( )
		{
			string message = $@"
			{{
				""op"" : 2,
				""d"" :
				{{
					""token"" : ""{Token}"",
					""intents"" : 8,
					""properties"" :
					{{
						""os"" : ""Windows"",
						""browser"" : ""Uranus"",
						""device"" : ""Uranus""
					}}
				}}
			}}";
			JsonDocument data = JsonDocument.Parse( message );

			await WebSocketSendAsync( data );
		}
		private async Task SendHeartbeat( )
		{
			string message = $@"
			{{
				""op"" : 1,
				""d"" : {( s != null ? s : "null" )}
			}}";
			JsonDocument data = JsonDocument.Parse( message );

			await WebSocketSendAsync( data );
		}

		private event Func<JsonDocument, Task> WebSocketData = delegate { return Task.CompletedTask; };
		private event Func<JsonDocument, Task> Hello = delegate { return Task.CompletedTask; };
		private event Func<Task> Heartbeat = delegate { return Task.CompletedTask; };
		public event Func<Client, Task> Ready = delegate { return Task.CompletedTask; };
		public event Func<BaseInteraction, Task> InteractionCreate = delegate { return Task.CompletedTask; };
	}
}