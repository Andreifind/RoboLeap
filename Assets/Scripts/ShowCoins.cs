using UnityEngine;
using UnityEngine.UI;

public class ShowCoins : MonoBehaviour
{
    private Text _text;
    [SerializeField] private Behaviour _player;
    void Start()
    {
       _text = GetComponent<Text>();
    }

    void Update()
    {
        _text.text = "Coins: " + _player.CoinsInRound;
    }
}
