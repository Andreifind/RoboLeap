using UnityEngine;

public class PowerupBoost : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<Behaviour>().isFlying==false)
                other.GetComponent<Behaviour>().Fly();
            Destroy(gameObject);
        }
    }
}
