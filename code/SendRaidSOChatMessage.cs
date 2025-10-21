using System;

public class CPHInline
{
	public bool Execute()
	{
		string user = args["user"].ToString();
		Int32 viewers = Convert.ToInt32(args["viewers"]);
		string viewers_str = args["viewers"].ToString();

		if (viewers > 0 && viewers <= 10) {
			CPH.SendMessage($"/me nebbigEsFragen {user}, du und welche Armee? Diese {viewers_str} Waschlapp:innen?! Wir sehen uns beim Duell im Morgengrauen auf https://twitch.tv/{user}! nebbigEsFragen");
		} else if (viewers >= 11 && viewers <= 49) {
			CPH.SendMessage($"/me nebbigEsDrama Chat, bitte spendet {user} ein wenig Trost. Mit dem Erscheinen hier hat {user} möglicherweise {viewers_str} Zuschauer verloren, aber vielleicht könnt ihr zur Entschädigung mal unter https://twitch.tv/{user} vorbeischauen? nebbigEsDrama");
		} else if (viewers >= 50 && viewers <= 99) {
			CPH.SendMessage($"/me nebbigAnzWuetend Zu Hülfe, zu Hülfe, ein Überfall ward geschehen! {user.ToUpper()} hat {viewers_str} eindeutige Spuren am Tatort zurückgelassen, die die Täterschaft belegen. So folget mir dann auf nach https://twitch.tv/{user}, wo wir {user} mit unserer Followerschaft abstrafen werden! nebbigErHochmut");
		} else {
			CPH.SendMessage($"/me nebbigEsDerp nebbi.exe has stopped working. Error code: {viewers}. Caused by {user.ToUpper()}.");
		}

		return true;
	}
}

