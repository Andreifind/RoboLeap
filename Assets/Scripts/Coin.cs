using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int v = other.GetComponent<Behaviour>().CoinsInRound++;
            Sounds.PlaySound("coin");
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Boost" || other.tag == "Powerup")
            Destroy(gameObject);
    }
}
