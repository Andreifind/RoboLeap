using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private Material _material;
    private bool _isDissolving=false;
    private float _fade = 1f;
    [SerializeField] private bool _isPlayer=false;

    void Start()
    {
        _material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (_isDissolving)
        {
            if (!_isPlayer)
                _fade -= Time.deltaTime;
            else _fade -= Time.deltaTime*0.5f;
            _material.SetFloat("_Fade", _fade);
            if(_fade<=0f)
            {
                _fade = 0;
                _isDissolving = false;
                if(!_isPlayer)
                    Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if(other.tag=="Finish")
            _isDissolving=true;
    }
}
