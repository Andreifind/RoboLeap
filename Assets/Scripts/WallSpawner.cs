using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _wall1;
    [SerializeField] private GameObject[] _wall2;
    [SerializeField] private GameObject[] _wall3;
    [SerializeField] private int _stageSize;
    private GameObject[][] _walls;
    private float _wallLength = 1.5f;
    private float _spawnY = -9f;
    private int _stage = 0;
    private int _wallsOnScreen = 10;
    private int _map;
    private PlayerData data;

    private void Start()
    {
        _stageSize = this.GetComponentInParent<LevelManager>().StageSize;
        data = SaveGame.LoadPlayer();
        if (data != null)
        {
            _map = data.currentMap;
            _stageSize = data.stgSize;
        }
        else _map = 0;
        Debug.LogWarning(_map);
        _walls = new GameObject[13][];
        for (int i = 0; i < 12; i++)
        {
            _walls[i] = new GameObject[3];
        }

        for (int i=0; i<12;i++)
        {
            _walls[i][0] = _wall1[i];
        }
        for (int i = 0; i < 12; i++)
        {
            _walls[i][1] = _wall2[i];
        }
        for (int i = 0; i < 12; i++)
        {
            _walls[i][2] = _wall3[i];
        }
        Debug.Log(_walls);
        SpawnWall();
        SpawnWall();
        SpawnWall();
        SpawnWall();
    }

    private void Update()
    {
        if (_spawnY < _stageSize) _stage = 0;

        if (_spawnY == _stageSize) _stage = 1;

        if (_spawnY > _stageSize && _spawnY < _stageSize*2) _stage = 2;
     
        if (_spawnY == _stageSize*2) _stage = 3;

        if (_spawnY > _stageSize*2 && _spawnY < _stageSize*3) _stage = 4;

        if (_spawnY == _stageSize*3) _stage = 5;

        if (_spawnY > _stageSize*3 && _spawnY < _stageSize*4) _stage = 6;

        if (_spawnY == _stageSize*4) _stage = 7;

        if (_spawnY > _stageSize*4 && _spawnY < _stageSize*5) _stage = 8;

        if (_spawnY == _stageSize*5) _stage = 9;

        if (_spawnY > _stageSize*5 && _spawnY < _stageSize*6) _stage = 10;

        if (_spawnY >= _stageSize*6) _stage = 11;

        if (_player.transform.position.y > _spawnY - _wallsOnScreen)
            SpawnWall();
    }

    private void SpawnWall()
    {
        GameObject right;
        GameObject left;
        right = Instantiate(_walls[_stage][_map],transform) as GameObject;
        right.transform.position = Vector2.up * _spawnY;
        right.transform.position = new Vector2(2.767f, right.transform.position.y);
        left = Instantiate(_walls[_stage][_map], transform) as GameObject;
        left.transform.position = Vector2.up * _spawnY;
        left.transform.position = new Vector2(-2.767f, left.transform.position.y);
        Debug.LogWarning(_stage + " " + _map);
        _spawnY += _wallLength;
    }
}
