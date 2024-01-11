using UnityEngine;

public class FillLuck : MonoBehaviour
{
    [SerializeField] private Behaviour _robot;
    [SerializeField] private GameObject _image;

    void Update()
    {
        switch(_robot.Luck)
        {
            case 0:
                _image.transform.localScale = new Vector2(0.79f, 1);
                break;
            case 4:
                _image.transform.localScale = new Vector2(1.5f, 1);
                break;
            case 8:
                _image.transform.localScale = new Vector2(2.4f, 1);
                break;
            case 12:
                _image.transform.localScale = new Vector2(3.3f, 1);
                break;
            case 16:
                _image.transform.localScale = new Vector2(4.4f, 1);
                break;
            case 20:
                _image.transform.localScale = new Vector2(5.2f, 1);
                break;
            case 24:
                _image.transform.localScale = new Vector2(6.2f, 1);
                break;
            case 28:
                _image.transform.localScale = new Vector2(7.1f, 1);
                break;
        }
    }
}
