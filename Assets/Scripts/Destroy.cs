using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Finish")
        {
            Destroy(gameObject);
        }
    }
}
