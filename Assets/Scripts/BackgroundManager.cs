using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject[] _background;

    private float _wallLength = 6.564f;
    private float _spawnY = -4.5f;
    private int _map;
    private PlayerData data;
    private void Update()
    {
        _map = gameObject.GetComponentInParent<LevelManager>().Map;
        if (_player.transform.position.y > _spawnY - 14)
            SpawnWall();
    }
    private void SpawnWall()
    {
        GameObject background;
        background = Instantiate(_background[_map], transform) as GameObject;
        background.transform.position = Vector2.up * _spawnY;
        background.transform.position = new Vector2(0, background.transform.position.y);
        _spawnY += _wallLength;
    }
}
