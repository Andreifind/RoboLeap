using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text ScoreText;
    [SerializeField] private GameObject _player;
    private Behaviour _height;
    private int _temp=0;
    private void Start()
    {
        ScoreText = GetComponent<Text>();
        _height= _player.GetComponent<Behaviour>();
    }

    private void Update()
    {
        if ((int)(_height.transform.position.y + 3.5f) / 2 > _temp)
            _temp = (int)(_height.transform.position.y + 3.5f) / 2;
        ScoreText.text = ""+_temp;
    }
}
