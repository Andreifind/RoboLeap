using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public void Jump()
    {
        transform.parent.GetComponent<Behaviour>().Jump();
    }
    public void Fly()
    {
        transform.parent.GetComponent<Behaviour>().FlyOn();
    }

}
