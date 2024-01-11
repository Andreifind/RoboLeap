using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unload : MonoBehaviour
{
    public void Despawn()
    {
        Destroy(gameObject);
    }
}
