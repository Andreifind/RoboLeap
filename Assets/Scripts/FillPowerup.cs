using UnityEngine;

public class FillPowerup : MonoBehaviour
{
    [SerializeField] private Behaviour _robot;
    [SerializeField] private GameObject _image;

    void Update()
    {
        switch (_robot.PowerLevel)
        {
            case 0:
                _image.transform.localScale = new Vector2(0.79f, 1);
                break;
            case 1:
                _image.transform.localScale = new Vector2(1.5f, 1);
                break;
            case 2:
                _image.transform.localScale = new Vector2(2.4f, 1);
                break;
            case 3:
                _image.transform.localScale = new Vector2(3.3f, 1);
                break;
            case 4:
                _image.transform.localScale = new Vector2(4.4f, 1);
                break;
            case 5:
                _image.transform.localScale = new Vector2(5.2f, 1);
                break;
            case 6:
                _image.transform.localScale = new Vector2(6.2f, 1);
                break;
            case 7:
                _image.transform.localScale = new Vector2(7.1f, 1);
                break;
        }
    }
}
