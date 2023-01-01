namespace Uranus.Discord
{
	public struct OverwriteStructure
	{
		public string id { get; set; }
		public OverwriteType type { get; set; }
		public string allow { get; set; }
		public string deny { get; set; }

		public Overwrite Solve( )
		{
			Overwrite overwrite = new( )
			{
				ID = id,
				Type = type,
				Allow = allow,
				Deny = deny
			};

			return overwrite;
		}
	}
}
