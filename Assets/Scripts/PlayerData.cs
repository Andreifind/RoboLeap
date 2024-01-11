[System.Serializable]
public class PlayerData
{
    public int highscore;
    public int coins;
    public bool _skin1;
    public bool _skin2;
    public bool _skin3;
    public bool _map1;
    public int currentSkin;
    public int currentMap;
    public int luck;
    public int powerLevel;
    public int stgSize;

    public PlayerData(Behaviour player)
    {
        currentSkin = player.CurrentSkin;
        currentMap = player.CurrentMap;
        coins = player.Coins;
        _skin1 = player.Skin1;
        _skin2 = player.Skin2;
        _skin3 = player.Skin3;
        _map1 = player.Map1;
        if (highscore < player.Highscore) highscore = player.Highscore;
        luck = player.Luck;
        powerLevel = player.PowerLevel;
        stgSize = player.StgSize;
    }
}
