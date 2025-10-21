using System;
using System.Collections;
using System.Collections.Generic;

public class CPHInline
{
	public bool Execute()
	{
		string userName = args["targetUserName"].ToString(),
			   userId = args["targetUserId"].ToString(),
			   category = args["game"].ToString().ToLower();

		List<string> validCategories = new List<string>() {
			"art",
			"makers-and-crafting",
			"music",
		};

		if (validCategories.Contains(category)) {
			CPH.SendMessage($"{userName}: Feel free to share anything with us. Your current project, social media, whatever - and I bet that we'll take a look at it.");
			CPH.SendMessage($"!permit {userName} 600");
		}

		return true;
	}
}
