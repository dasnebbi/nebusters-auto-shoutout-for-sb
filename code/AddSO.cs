using System;

public class CPHInline
{
    public bool Execute()
    {
        string userId = args["targetUserId"].ToString(), 
			   userName = args["targetUserName"].ToString(), 
			   autoShoutoutUsersGroupFieldName = CPH.GetGlobalVar<string>("autoShoutoutUsersGroupFieldName", true),
			   shoutoutActionId = "b78384ad-f6db-4349-b4c7-e3aec4432541";
			   
        if (!CPH.UserIdInGroup(userId, Platform.Twitch, autoShoutoutUsersGroupFieldName))
        {
            CPH.AddUserIdToGroup(userId, Platform.Twitch, autoShoutoutUsersGroupFieldName);
            CPH.LogInfo($"AutoShoutout: {userName} has been added.");
            CPH.SetArgument("targetUserName", userName);
            CPH.RunActionById(shoutoutActionId);
        }

        return true;
    }
}
