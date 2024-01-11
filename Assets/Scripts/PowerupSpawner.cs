using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    [SerializeField] private int _chance; //the smaller, the greater the odds.
    private int _lottery;
    [SerializeField] private GameObject[] _powerup;
    private int _pow;
    void Start()
    {
       // _powerup = new GameObject[3];
        _lottery = Random.Range(0, _chance);
        if ((_lottery == 1) && ((transform.position.y+4.5f)%45==0) && (transform.position.y + 4.5f > 1))
        {
            _pow = Random.Range(0, _powerup.Length);
            while(_pow == GetComponentInParent<PlatformManager>().LastPowerup)
                _pow = Random.Range(0, _powerup.Length);
            Instantiate(_powerup[_pow], new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);

        }
    }

}
