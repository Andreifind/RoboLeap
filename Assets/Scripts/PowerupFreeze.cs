using UnityEngine;
using System.Collections;

public class PowerupFreeze : MonoBehaviour
{
    private GameObject _acid;
    private GameObject _pl;
    private Acid _asid;
    private float _secondsWait;
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _acid = GameObject.FindWithTag("Finish");
        _asid = _acid.GetComponent<Acid>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _spriteRenderer.enabled = false;
            _secondsWait = other.GetComponent<Behaviour>().SecondsToFreeze;
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        _asid._canClimb = false;
        yield return new WaitForSeconds(_secondsWait);
        _asid._canClimb = true;
        Destroy(gameObject);
    }
}
