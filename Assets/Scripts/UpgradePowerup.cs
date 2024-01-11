using UnityEngine;

public class UpgradePowerup : MonoBehaviour
{
    [SerializeField] private CostChanger _power;
    [SerializeField] private GameObject _powerupCanvas;
    [SerializeField] private Behaviour _player;

    public void UpPower()
    {
        _powerupCanvas.SetActive(true);
        switch (_player.PowerLevel)
        {
            case 0:
                _power.Show1();
                break;
            case 1:
                _power.Show2();
                break;
            case 2:
                _power.Show3();
                break;
            case 3:
                _power.Show4();
                break;
            case 4:
                _power.Show5();
                break;
            case 5:
                _power.Show6();
                break;
            case 6:
                _power.Show7();
                break;
        }
    }
    public void ClosePower()
    {
        _powerupCanvas.SetActive(false);
    }
    public void IncPower()
    {
        switch (_player.PowerLevel)
        {
            case 0:
                if (_player.Coins >= 10)
                {
                    _player.Coins -= 10;
                    _player.PowerLevel++;
                }
                ClosePower();
                break;
            case 1:
                if (_player.Coins >= 20)
                {
                    _player.Coins -= 20;
                    _player.PowerLevel++;
                }
                ClosePower();
                break;
            case 2:
                if (_player.Coins >= 25)
                {
                    _player.Coins -= 25;
                    _player.PowerLevel++;
                }
                ClosePower();
                break;
            case 3:
                if (_player.Coins >= 30)
                {
                    _player.Coins -= 30;
                    _player.PowerLevel++;
                }
                ClosePower();
                break;
            case 4:
                if (_player.Coins >= 35)
                {
                    _player.Coins -= 35;
                    _player.PowerLevel++;
                }
                ClosePower();
                break;
            case 5:
                if (_player.Coins >= 40)
                {
                    _player.Coins -= 40;
                    _player.PowerLevel++;
                }
                ClosePower();
                break;
            case 6:
                if (_player.Coins >= 45)
                {
                    _player.Coins -= 45;
                    _player.PowerLevel++;
                }
                ClosePower();
                break;
        }
    }
}
