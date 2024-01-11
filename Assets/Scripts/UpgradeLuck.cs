using UnityEngine;

public class UpgradeLuck : MonoBehaviour
{
    [SerializeField] private CostChanger _luck;
    [SerializeField] private GameObject _luckCanvas;
    [SerializeField] private Behaviour _player;

    public void UpLuck()
    {
        _luckCanvas.SetActive(true);
        switch (_player.Luck)
        {
            case 0:
                _luck.Show1();
                break;
            case 4:
                _luck.Show2();
                break;
            case 8:
                _luck.Show3();
                break;
            case 12:
                _luck.Show4();
                break;
            case 16:
                _luck.Show5();
                break;
            case 20:
                _luck.Show6();
                break;
            case 24:
                _luck.Show7();
                break;
        }
    }
    public void CloseLuck()
    {
        _luckCanvas.SetActive(false);
    }
    public void IncLuck()
    {
        switch (_player.Luck)
        {
            case 0:
                if (_player.Coins >= 10)
                {
                    _player.Coins -= 10;
                    _player.Luck += 4;
                }
                CloseLuck();
                break;
            case 4:
                if (_player.Coins >= 20)
                {
                    _player.Coins -= 20;
                    _player.Luck += 4;
                }
                CloseLuck();
                break;
            case 8:
                if (_player.Coins >= 25)
                {
                    _player.Coins -= 25;
                    _player.Luck += 4;
                }
                CloseLuck();
                break;
            case 12:
                if (_player.Coins >= 30)
                {
                    _player.Coins -= 30;
                    _player.Luck += 4;
                }
                CloseLuck();
                break;
            case 16:
                if (_player.Coins >= 35)
                {
                    _player.Coins -= 35;
                    _player.Luck += 4;
                }
                CloseLuck();
                break;
            case 20:
                if (_player.Coins >= 40)
                {
                    _player.Coins -= 40;
                    _player.Luck += 4;
                }
                CloseLuck();
                break;
            case 24:
                if (_player.Coins >= 45)
                {
                    _player.Coins -= 45;
                    _player.Luck += 4;
                }
                CloseLuck();
                break;
        }
    }
}
