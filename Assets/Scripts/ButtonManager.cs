using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Behaviour _player;
    [SerializeField] private GameObject[] _button1;
    [SerializeField] private GameObject[] _button2;
    [SerializeField] private GameObject[] _button3;
    [SerializeField] private GameObject[] _button4;
    [SerializeField] private GameObject[] _button5;
    [SerializeField] private LevelManager _map;
    private void Start()
    {
        
    }

    private void Update()
    {
        if( _player.Skin1)
        {
            _button1[0].SetActive(false);
            _button1[1].SetActive(true);
        }
        if (_player.Skin2)
        {
            _button2[0].SetActive(false);
            _button2[1].SetActive(true);
        }
        if (_player.Skin3)
        {
            _button4[0].SetActive(false);
            _button4[1].SetActive(true);
        }
        if ( _player.Map1)
        {
            _button3[0].SetActive(false);
            _button3[1].SetActive(true);
        }
        if (_player.Map2)
        {
            _button4[0].SetActive(false);
            _button4[1].SetActive(true);
        }
    }

    public void SelectSkin0()
    {
        Sounds.PlaySound("click");
        _player.CurrentSkin = 0;
        _player.SkinUpdate();
        _player.SavePlayer();
    }

    public void BuySkin1()
    {
        Sounds.PlaySound("click");
        if (_player.Coins>=100)
        {
            _player.Coins-=100;
            _button1[0].SetActive(false);
            _button1[1].SetActive(true);
            _player.CurrentSkin = 1;
            _player.Skin1 = true;
            _player.SkinUpdate();
            _player.SavePlayer();
        }
    }

    public void SelectSkin1()
    {
        Sounds.PlaySound("click");
        _player.CurrentSkin = 1;
        _player.SkinUpdate();
        _player.SavePlayer();
    }

    public void BuySkin2()
    {
        Sounds.PlaySound("click");
        if (_player.Coins >= 300)
        {
            _player.Coins -= 300;
            _button2[0].SetActive(false);
            _button2[1].SetActive(true);
            _player.CurrentSkin = 2;
            _player.Skin2 = true;
            _player.SkinUpdate();
            _player.SavePlayer();
        }
    }
    public void BuySkin3()
    {
        Sounds.PlaySound("click");
        if (_player.Coins >= 300)
        {
            _player.Coins -= 300;
            _button2[0].SetActive(false);
            _button2[1].SetActive(true);
            _player.CurrentSkin = 3;
            _player.Skin3 = true;
            _player.SkinUpdate();
            _player.SavePlayer();
        }
    }
    public void SelectSkin3()
    {
        Sounds.PlaySound("click");
        _player.CurrentSkin = 3;
        _player.SkinUpdate();
        _player.SavePlayer();
    }

    public void SelectSkin2()
    {
        Sounds.PlaySound("click");
        _player.CurrentSkin = 2;
        _player.SkinUpdate();
        _player.SavePlayer();
    }

    public void SelectMap0()
    {
        Sounds.PlaySound("click");
        _map.Map = 0;
        _player.CurrentMap = 0;
        _player.SavePlayer();
    }

    public void BuyMap1()
    {
        Sounds.PlaySound("click");
        if (_player.Coins >= 300)
        {
            _player.Coins -= 300;
            _map.Map = 1;
            _button3[0].SetActive(false);
            _button3[1].SetActive(true);
            _player.Map1 = true;
            _player.CurrentMap = 1;
            _player.SavePlayer();
        }
    }

    public void SelectMap1()
    {
        Sounds.PlaySound("click");
        _map.Map = 1;
        _player.CurrentMap = 1;
        _player.SavePlayer();
    }
    public void BuyMap2()
    {
        Sounds.PlaySound("click");
        if (_player.Coins >= 300)
        {
            _player.Coins -= 300;
            _map.Map = 2;
            _button4[0].SetActive(false);
            _button4[1].SetActive(true);
            _player.Map2 = true;
            _player.CurrentMap = 2;
            _player.SavePlayer();
        }
    }

    public void SelectMap2()
    {
        Sounds.PlaySound("click");
        _map.Map = 2;
        _player.CurrentMap = 2;
        _player.SavePlayer();
    }
}
