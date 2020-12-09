using Firebase.Auth;
using System;
using System.Threading.Tasks;
using XamFormsFirebaseAuth.Features.Common;

namespace XamFormsFirebaseAuth.Android
{
    public class FirebaseAuthentication : IAuthenticationService
    {
        public async Task<bool> CreateUser(string username, string email, string password)
        {
            try
            {
                var authResult = await FirebaseAuth.Instance
                    .CreateUserWithEmailAndPasswordAsync(email, password);

                var userProfileChangeRequestBuilder = new UserProfileChangeRequest.Builder();
                userProfileChangeRequestBuilder.SetDisplayName(username);

                var userProfileChangeRequest = userProfileChangeRequestBuilder.Build();
                await authResult.User.UpdateProfileAsync(userProfileChangeRequest);

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }
        }

        public bool IsSignIn() 
            => FirebaseAuth.Instance.CurrentUser != null;

        public async Task ResetPassword(string email) 
            => await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);

        public async Task<string> SignIn(string email, string password)
        {
            var authResult = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token =  await authResult.User.GetIdTokenAsync(false);
            return token.Token;
        }

        public void SignOut() 
            => FirebaseAuth.Instance.SignOut();
    }
}