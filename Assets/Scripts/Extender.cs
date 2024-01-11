using UnityEngine;

public class Extender : MonoBehaviour
{
    private int _nr;
    private Behaviour _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Behaviour>();
        _nr = _player.MaxPlatforms * 2;
        if (_player.PowerLevel > 3 && _player.PowerLevel < 7) _nr++;
        if (_player.PowerLevel == 7) _nr += 2;
    }
    private void Update()
    {
        transform.Translate(Vector2.up * 5 * Time.deltaTime);
        if(_nr == 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform")
        {
            other.GetComponent<Platform>().Enlarge();
            _nr--;
        }
    }
}
