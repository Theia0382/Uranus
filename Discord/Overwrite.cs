namespace Uranus.Discord
{
	public class Overwrite
	{
		public string ID { get; init; }
		public OverwriteType Type { get; init; }
		public string Allow { get; init; }
		public string Deny { get; init; }
	}
}
