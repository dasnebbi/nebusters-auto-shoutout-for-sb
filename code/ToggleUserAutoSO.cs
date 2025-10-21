using System;

public class CPHInline
{
	public bool Execute()
	{
		string userId = args["userId"].ToString(),
			   userName = args["userName"].ToString(),
			   autoShoutoutUsersGroupFieldName = CPH.GetGlobalVar<string>("autoShoutoutUsersGroupFieldName"), // "Shoutout"
			   autoShoutoutUserStateFieldName = CPH.GetGlobalVar<string>("autoShoutoutUserStateFieldName"); // "autoShoutoutUserState"
		
		if (CPH.UserInGroup(userName, Platform.Twitch, autoShoutoutUsersGroupFieldName)) {
			bool autoShoutoutUserState = CPH.GetTwitchUserVarById<bool>(userId, autoShoutoutUserStateFieldName, true);
			string newAutoShoutoutUserStateString = (!autoShoutoutUserState == true) ? "enabled" : "disabled";

			CPH.SetTwitchUserVarById(userId, autoShoutoutUserStateFieldName, !autoShoutoutUserState);
			CPH.LogInfo($"AutoShoutout: Action has been {newAutoShoutoutUserStateString} for {userName} (User decision).");
		}
		
		return true;
	}
}
