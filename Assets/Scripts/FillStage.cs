using UnityEngine;

public class FillStage : MonoBehaviour
{
    [SerializeField] private LevelManager _stage;
    [SerializeField] private GameObject _image;

    void Update()
    {
        switch (_stage.StageSize-40)
        {
            case 0:
                _image.transform.localScale = new Vector2(0.79f, 1);
                break;
            case 15:
                _image.transform.localScale = new Vector2(1.5f, 1);
                break;
            case 30:
                _image.transform.localScale = new Vector2(2.4f, 1);
                break;
            case 45:
                _image.transform.localScale = new Vector2(3.3f, 1);
                break;
            case 60:
                _image.transform.localScale = new Vector2(4.4f, 1);
                break;
            case 75:
                _image.transform.localScale = new Vector2(5.2f, 1);
                break;
            case 90:
                _image.transform.localScale = new Vector2(6.2f, 1);
                break;
            case 105:
                _image.transform.localScale = new Vector2(7.1f, 1);
                break;
        }
    }
}
