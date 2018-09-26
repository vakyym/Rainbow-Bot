# Rainbow

Discord bot, changes role color every 15 seconds. Must be self hosted (or use Heroku).

To customize, edit these lines of code: <br />
var Guild = Client.GetGuild(INSERT SERVER ID HERE) as SocketGuild; <br />
var Role = Guild.Roles.Where(x => x.Name == "INSERT ROLE NAME HERE").FirstOrDefault() as SocketRole; <br />


###### Colors:

> #f03e3e (red)

> #ee8640 (orange)

> #ecde71 (yellow)

> #61df61 (green)

> #50a1ec (blue)

> #a46ec7 (purple)
