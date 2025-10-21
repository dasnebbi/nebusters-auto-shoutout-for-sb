using System;

public class CPHInline
{
    public bool Execute()
    {
        string userId = args["targetUserId"].ToString(),
			   userName = args["targetUser"].ToString(),
               autoShoutoutUsersGroupFieldName = CPH.GetGlobalVar<string>("autoShoutoutUsersGroupFieldName"), // "Shoutout"
			   lastAutoShoutoutFieldName = CPH.GetGlobalVar<string>("lastAutoShoutoutFieldName"), // "lastAutoShoutout"
			   autoShoutoutCooldownFieldName = CPH.GetGlobalVar<string>("autoShoutoutCooldownFieldName"), // "autoShoutoutCooldown"
               autoShoutoutSuccessArgFieldName = CPH.GetGlobalVar<string>("autoShoutoutSuccessArgFieldName"); // "autoShoutoutSuccess"
        
        Int32 now = (Int32)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds,
              lastAutoShoutout = Convert.ToInt32(CPH.GetTwitchUserVarById<int>(userId, lastAutoShoutoutFieldName)), 
              autoShoutoutThreshold = 43200; // 21600 | 43200 | 86400
              
        string shoutoutErrorCooldown = $"AutoShoutout: Failed for {userName} ({userId}). Reason: Cooldown.",
			   shoutoutErrorNotEligible = $"AutoShoutout: Failed for {userName} ({userId}). Reason: Not eligible.";
        
        bool autoShoutoutCooldown = CPH.GetTwitchUserVarById<bool>(userId, autoShoutoutCooldownFieldName);

        if (autoShoutoutCooldown == true && ((now - lastAutoShoutout) > autoShoutoutThreshold)) {
            CPH.SetTwitchUserVarById(userId, autoShoutoutCooldownFieldName, false);
            autoShoutoutCooldown = false;
        }
        
        if (autoShoutoutCooldown == true) {
        	CPH.SetArgument(autoShoutoutSuccessArgFieldName, "false");
        	CPH.LogWarn(shoutoutErrorCooldown);
            return true;
        }
        
        if (CPH.UserIdInGroup(userId, Platform.Twitch, autoShoutoutUsersGroupFieldName) && autoShoutoutCooldown == false) {
            CPH.SetArgument(autoShoutoutSuccessArgFieldName, "true");
            CPH.SetTwitchUserVarById(userId, lastAutoShoutoutFieldName, now);
            CPH.SetTwitchUserVarById(userId, autoShoutoutCooldownFieldName, true);
            return true;
        }

        CPH.SetArgument(autoShoutoutSuccessArgFieldName, "false");
        
        return true;
    }
}
