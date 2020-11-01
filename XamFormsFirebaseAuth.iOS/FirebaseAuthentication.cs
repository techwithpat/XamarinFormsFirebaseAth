using System;
using System.Threading.Tasks;
using Firebase.Auth;
using XamFormsFirebaseAuth.Features.Common;

namespace XamFormsFirebaseAuth.iOS
{
    public class FirebaseAuthentication : IAuthenticationService
    {
        public async Task<bool> CreateUser(string username, string email, string password)
        {
            try
            {
                var authResult = await Auth.DefaultInstance
                    .CreateUserAsync(email, password);

                var changeRequest = authResult.User.ProfileChangeRequest();
                changeRequest.DisplayName = username;
                await changeRequest.CommitChangesAsync();

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return await Task.FromResult(false);
            }
        }

        public bool IsSignIn()
        {            
            var currentUser = Auth.DefaultInstance.CurrentUser;
            return currentUser != null;
        }

        public async Task ResetPassword(string email)
        {
            await Auth.DefaultInstance.SendPasswordResetAsync(email);
        }

        public async Task<string> SignIn(string email, string password)
        {
            var authResult = await Auth.DefaultInstance
                .SignInWithPasswordAsync(email, password);

            return await authResult.User.GetIdTokenAsync();
        }

        public void SignOut()
        {
            Auth.DefaultInstance.SignOut(out _);
        }
    }
}
