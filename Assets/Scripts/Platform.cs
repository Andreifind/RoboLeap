using System.Runtime.InteropServices;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject _bigPlatform;
    [SerializeField] private GameObject _effect;

    public void Enlarge()
    {
        Instantiate(_bigPlatform, new Vector2(0, transform.position.y), Quaternion.identity);
        Instantiate(_effect, new Vector2(0, transform.position.y), Quaternion.Euler(-260, 0, 0));
        Destroy(gameObject);
    }
}
