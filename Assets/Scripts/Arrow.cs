using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private GameObject _pivot;
    [SerializeField] private GameObject _top;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _maxAngle;
    [SerializeField] private int _speed;
    private int _sspeed;
    private Behaviour _playe;
    void Start()
    {
        _playe = _player.GetComponent<Behaviour>();
        _sspeed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(_playe.isGrounded() && _playe._rb.velocity.y==0f)
        {
            if (transform.rotation.z * 100 >= _maxAngle)
            {
                _speed = -_sspeed;
                //transform.RotateAround(_pivot.transform.position, new Vector3(0, 0, 1), _speed * Time.deltaTime);
            }

            if (transform.rotation.z * 100 <= -_maxAngle)
            {
                _speed = _sspeed;
                //transform.RotateAround(_pivot.transform.position, new Vector3(0, 0, 1), _speed * Time.deltaTime);
            }
            transform.RotateAround(_pivot.transform.position, new Vector3(0, 0, 1), _speed * Time.deltaTime);
        }
    }
    public Vector2 getpos()
    {
        return _top.transform.position;
    }
}
