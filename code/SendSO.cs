using System;

public class CPHInline
{
    public bool Execute()
    {
        string user = args["user"].ToString(),
               game = args["game"].ToString();

        if (user == "nebbigraphy") {
            CPH.SendMessage($"/me Advertising for my own channel? Embarrassing, dude.");
        } else {
            CPH.SendMessage($"/me Go watch {user} over at https://twitch.tv/{user} where they were last streaming \"{game}\". It's pretty fun to watch as well!");
        }

        return true;
    }
}
