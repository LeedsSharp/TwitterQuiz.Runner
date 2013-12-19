using System.Collections.Generic;
using TweetSharp;

namespace TwitterQuiz.Domain.Account
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Locale { get; set; }
        public string Picture { get; set; }
        public IList<AccessToken> AccessTokens { get; set; }
        public bool IsAuthenticated { get; set; }

        public User()
        {
            AccessTokens = new List<AccessToken>();
        }

        public static User FromAuthenticatedTwitterUser(TwitterUser userCreds, OAuthAccessToken token)
        {
            var newUser = new User
            {
                Username = userCreds.ScreenName,
                Name = userCreds.Name,
                //Email = userCreds.ProfileImageUrl,
                //Gender = GenderTypeHelpers.ToGenderType(userCreds..UserInformation.Gender.ToString()),
                Locale = userCreds.Language,
                Picture = userCreds.ProfileImageUrl,
                IsAuthenticated = true
            };
            AccessToken accessToken = new AccessToken
            {
                PublicAccessToken = token.Token,
                ProviderType = "twitter",
                TokenSecret = token.TokenSecret
            };
            newUser.AccessTokens.Add(accessToken);

            return newUser;
        }
    }
}
