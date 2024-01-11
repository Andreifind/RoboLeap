using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int Map;
    public int StageSize;
    [SerializeField] private GameObject[] _liquid;
    [SerializeField] private WallSpawner _walls;
    [SerializeField] private PlatformManager _platforms;
    private PlayerData data;

    private void Start()
    {
        data = SaveGame.LoadPlayer();
        if (data != null)
        {
            StageSize = data.stgSize;
            Map = data.currentMap;
            if (StageSize == 0) StageSize = 40;
        }
        else
        {
            Map = 0;
            StageSize = 40;
        }

        for (int i = 0; i < _liquid.Length; i++)
        {
            if(i!=Map) 
                _liquid[i].SetActive(false);
            else _liquid[i].SetActive(true);
        }
    }
}
