using System.Threading.Tasks;
using TwitchLib.Api;
using System.Linq;

namespace Griffin.TwitchFunctions
{
    public class Twitch
    {
        private TwitchAPI _api;

        public Twitch(string clientId, string accessToken)
        {
            _api = new TwitchAPI();
            _api.Settings.ClientId = clientId;
            _api.Settings.AccessToken = accessToken;
        }

        public async Task<bool> IsChannelOnlineAsync(string channelName)
        {
            var user = await _api.V5.Users.GetUserByNameAsync(channelName);
            var isOnline = await _api.V5.Streams.BroadcasterOnlineAsync(user.Matches.First().Id);

            return isOnline;
        }
    }
}
