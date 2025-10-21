using System;

public class CPHInline
{
    public bool Execute()
    {
        string userId = args["targetUserId"].ToString(), 
			   userName = args["targetUserName"].ToString(), 
			   autoShoutoutUsersGroupFieldName = CPH.GetGlobalVar<string>("autoShoutoutUsersGroupFieldName", true);
			   
        if (CPH.UserIdInGroup(userId, Platform.Twitch, autoShoutoutUsersGroupFieldName)) {
            CPH.RemoveUserIdFromGroup(userId, Platform.Twitch, autoShoutoutUsersGroupFieldName);
            CPH.LogInfo($"AutoShoutout: {userName} has been removed.");
        }

        return true;
    }
}
