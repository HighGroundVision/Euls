# Euls
A dota2 Ability Draft Broadcasting overlay.

Install Steps
1. go to the following directory (create it if you need to) dota 2 beta\game\dota\cfg\gamestate_integration
2. Create a gamestate_integration_hgv.cfg file into the director in step 1.
3. Get a token from RGBKnights.

```
"HGV"
{
    "uri"               "https://euls.azurewebsites.net/api/events"
    "timeout"           "2.0"
    "buffer"            "10.0"
    "throttle"          "10.0"
    "heartbeat"         "60.0"
    "auth"
    {
        "token" "abc123"
    }
    "data"
    {
        "buildings"     "0"
        "provider"      "1"
        "map"           "0"
        "player"        "1"
        "hero"          "1"
        "abilities"     "1"
        "items"         "1"
        "draft"         "0"
        "wearables"     "0"
    }
}
```

3. Enabled GSI.

![alt text](https://s3.amazonaws.com/cdn.freshdesk.com/data/helpdesk/attachments/production/9153979246/original/vTeUh6O_Xpuqgn0iAfJWrBDa7rjQ8R2odw.png?1647271773)

4. Add a browser source to Stream Labs for Radiant Team with the following properties:
- URL: https://euls.azurewebsites.net/api/overlay/radiant/abc123
- Width: 500
- Height: 350
- Refresh browse when source becomes active: True

5. Add a browser source to Stream Labs or Dire Team with the following properties:
- URL: https://euls.azurewebsites.net/api/overlay/dire/abc123
- Width: 500
- Height: 350
- Refresh browse when source becomes active: True

NOTES:
1. Do not share your gamestate_integration_hgv.cfg TOKEN with anyone else it is personal to you.
2. The page is setup to auto refresh ever 10 seconds. You can change the timer by using the `?refresh=X` query paramter.
3. This will only work when you are spectating/watching a match and not a player.
