using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _acid;
    [SerializeField] private AdsManager _ads;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _upgrades;
    [SerializeField] private GameObject _acidMove;
    [SerializeField] private GameObject _titlePanel;
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private GameObject _score;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private Behaviour _player;
    [SerializeField] private GameObject _frame1;
    [SerializeField] private GameObject _frame2;
    [SerializeField] private GameObject _frame3;
    private Acid _ad;
    private void Start()
    {
        _ad = _acidMove.GetComponent<Acid>();
        Screen.SetResolution(1080, 2340, true);
    }

    private void Update()
    {
        
    }

    public void Play()
    {
        Sounds.PlaySound("click");
        _acid.enabled = true;
        //_ad.Speed = 0.35f;
        _titlePanel.SetActive(false);
        _score.SetActive(true);
        _arrow.SetActive(true);
    }

    public void Death()
    {
        //_ads.PlayAd();
        _ad.Speed = 0f;
        _deathPanel.SetActive(true);
        _score.SetActive(false);
        if(_player.Score < 35)
        {
            _frame1.SetActive(true);
            _frame2.SetActive(false);
            _frame3.SetActive(false);
        }
        if (_player.Score >= 35 && _player.Score < 70)
        {
            _frame2.SetActive(true);
            _frame1.SetActive(false);
            _frame3.SetActive(false);
        }
        if (_player.Score >= 70)
        {
            _frame3.SetActive(true);
            _frame1.SetActive(false);
            _frame2.SetActive(false);
        }
    }

    public void OpenShop()
    {
        Sounds.PlaySound("click");
        _shop.SetActive(true);
    }

    public void CloseShop()
    {
        Sounds.PlaySound("click");
        _shop.SetActive(false);
    }

    public void OpenUpgrades()
    {
        Sounds.PlaySound("click");
        _upgrades.SetActive(true);
    }

    public void CloseUpgrades()
    {
        Sounds.PlaySound("click");
        _upgrades.SetActive(false);
    }

    public void Retry()
    {
        Sounds.PlaySound("click");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        Sounds.PlaySound("click");
        Application.Quit();
    }
}
