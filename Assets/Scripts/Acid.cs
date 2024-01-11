using UnityEngine;

public class Acid : MonoBehaviour
{
    public float Speed;
    [SerializeField] private Transform _player;
    public bool _canClimb = true;
    private void Start()
    {
        
    }

    private void Update()
    {
        if(_canClimb)
        {
            if (_player.position.y - transform.position.y > -3)
                transform.Translate(Vector2.up * Speed * 4 * Time.deltaTime);
            else
                transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
    }
}
