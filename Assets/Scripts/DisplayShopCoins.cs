using UnityEngine;
using UnityEngine.UI;

public class DisplayShopCoins : MonoBehaviour
{
    private Text ScoreText;
    [SerializeField] private Behaviour _player;

    private void Start()
    {
        ScoreText = GetComponent<Text>();
    }

    private void Update()
    {
        ScoreText.text = ""+_player.Coins;
    }
}
