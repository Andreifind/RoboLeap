using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private Behaviour _player;
    private GameObject[][] _platform;
    [SerializeField] private GameObject[] _platforms1;
    [SerializeField] private GameObject[] _platforms2;
    [SerializeField] private GameObject[] _platforms3;
    [SerializeField] private GameObject _coin;

    [SerializeField] private int _stageSize;

    private int _luckyCoin;
    private float _wallLength = 2.5f;
    private float _spawnY = -4.5f;
    private float _xPos;
    private float _lastXPos = 99;
    private int _stage = 0;
    private float _snapPos;
    private float[] _position;
    private int _amount;
    private int _map;
    private PlayerData data;

    public int LastPowerup;

    private void Awake()
    {
        _stageSize = this.GetComponentInParent<LevelManager>().StageSize;
        data = SaveGame.LoadPlayer();
        if(data != null)
        {
            _map = data.currentMap;
            _stageSize = data.stgSize;
        }    
        else _map = 0;
        _platform = new GameObject[5][];
        //for (int i = 0; i < _platform.Length; i++)
        for (int i = 0; i < 5; i++)
            _platform[i] = new GameObject[3];
        for (int i = 0; i < 5; i++)
        {
            _platform[i][0] = _platforms1[i];
        }
        for (int i = 0; i < 5; i++)
        {
            _platform[i][1] = _platforms2[i];
        }
        for (int i = 0; i < 5; i++)
        {
            _platform[i][2] = _platforms3[i];
        }
        _position = new float[6];
        _position[0] = 1.38f;
        _position[1] = 1.46f;
        _position[2] = 1.56f;
        _position[3] = 1.68f;
        _position[4] = 1.785f;
        //block size 0.2182f;
    }

    private void Update()
    {
        if (_spawnY < _stageSize) _stage = 0;

        if (_spawnY >= _stageSize && _spawnY < _stageSize * 2) _stage = 1;

        if (_spawnY >= _stageSize * 2 && _spawnY < _stageSize * 3) _stage = 2;

        if (_spawnY >= _stageSize * 3 && _spawnY < _stageSize * 4) _stage = 3;

        if (_spawnY >= _stageSize * 4) _stage = 4;

        if (_player.transform.position.y > _spawnY - 16)
            SpawnPlatform();
        if (_player.isFlying == false) _amount = (int)_player.SecondsToFly+ _player.PowerLevel;
    }

    private void SpawnPlatform()
    {
        if (_spawnY != -4.5f)
        {
            _luckyCoin = Random.Range(0, 80) + _player.Luck;

            _xPos = Random.Range(-_position[_stage], _position[_stage]);
            if (_lastXPos == 99) 
                _lastXPos = _xPos;

            while(Mathf.Abs(_xPos-_lastXPos)>1.5f)
                _xPos = Random.Range(-_position[_stage], _position[_stage]);

            if (!_player.isFlying)
                _lastXPos = _xPos;
            else
                _lastXPos = _player.transform.position.x;

            GameObject platform;
            platform = Instantiate(_platform[_stage][_map], transform) as GameObject;
            platform.transform.position = Vector2.up * _spawnY;
            if(_player.isFlying && (_amount == 0))
            {
                platform.transform.position = new Vector2(_player.transform.position.x, platform.transform.position.y);
                Debug.Log(platform.transform.position.x + " " + _player.transform.position.x);
                _amount--;
            }
            else
            {
                platform.transform.position = new Vector2(_xPos, platform.transform.position.y);
                _amount--;
            }
            if (_luckyCoin > 60 && ((_spawnY + 4.5f) % 45 != 0))
            {
                GameObject coin;
                coin = Instantiate(_coin, transform.position, Quaternion.identity);
                coin.transform.position = new Vector2(platform.transform.position.x, platform.transform.position.y + 0.5f);
            }
        }
        _spawnY += _wallLength;
    }
}
