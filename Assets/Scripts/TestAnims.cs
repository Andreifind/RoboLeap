using UnityEngine;

public class TestAnims : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ResAnims();
            _animator.SetTrigger("jump");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ResAnims();
            _animator.SetTrigger("prop");
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            ResAnims();
            _animator.SetTrigger("over");
        }
    }

    public void ResAnims()
    {
        _animator.ResetTrigger("prop");
        _animator.ResetTrigger("over");
        _animator.ResetTrigger("jump");
    }
}
