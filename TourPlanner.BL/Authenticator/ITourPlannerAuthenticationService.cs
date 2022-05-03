namespace TourPlanner.Client.BL.Authenticator
{
    public interface ITourPlannerAuthenticationService<AuthenticationServiceMessage, AuthenticationData>
    {
        AuthenticationServiceMessage Authenticate(AuthenticationData dataToAuthenticate);
    }
}