namespace YelpSharp.Data
{
    public class AccessToken : ApiResponse
    {
        /// <summary>
        /// Access token to be used with all calls
        /// </summary>
		public string access_token { get; set; }

        /// <summary>
        /// Always returns 'Bearer'
        /// </summary>
		public string token_type { get; set; }

        /// <summary>
        /// Represents the number of seconds after which this access token will expire. Right now it's always 15552000, which is 180 days.
        /// </summary>
		public int expires_in { get; set; }
    }
}
