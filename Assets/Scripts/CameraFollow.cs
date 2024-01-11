using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _acid;
    private float _offset;
    void Start()
    {
        _offset = transform.position.y-_player.position.y;
    }

    void Update()
    {
        if(_player.position.y-_acid.position.y > 3.05f)
            transform.position = new Vector3(transform.position.x, _player.position.y + _offset, -100);
        else
            transform.position = new Vector3(transform.position.x, _acid.position.y + _offset+ 3.05f, -100);
    }
}
