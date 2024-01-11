using UnityEngine;

public class PowerupPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Behaviour>().SpawnExtender();
            Destroy(gameObject);
        }
    }
}
