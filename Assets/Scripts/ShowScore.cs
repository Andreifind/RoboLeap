using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private Text _text;
    [SerializeField] private Behaviour _player;
    void Start()
    {
        _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = "Score: " + _player.Score;
    }
}
