using UnityEngine;

public class PlatformFinder : MonoBehaviour
{
    [SerializeField] private Behaviour _player;
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Platform" && _player.isFlying)
        {
            _player.FollowX = other.transform.position.x;
            _player.PlatformsPassed++;
        }
    }
}
