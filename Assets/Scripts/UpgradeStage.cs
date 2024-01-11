using UnityEngine;

public class UpgradeStage : MonoBehaviour
{
    [SerializeField] private CostChanger _stage;
    [SerializeField] private GameObject _stageCanvas;
    [SerializeField] private Behaviour _player;
    [SerializeField] private LevelManager _levelManager;

    public void UpStage()
    {
        _stageCanvas.SetActive(true);
        switch (_levelManager.StageSize-40)
        {
            case 0:
                _stage.Show1();
                break;
            case 15:
                _stage.Show2();
                break;
            case 30:
                _stage.Show3();
                break;
            case 45:
                _stage.Show4();
                break;
            case 60:
                _stage.Show5();
                break;
            case 75:
                _stage.Show6();
                break;
            case 90:
                _stage.Show7();
                break;
        }
    }
    public void CloseStage()
    {
        _stageCanvas.SetActive(false);
    }
    public void IncStage()
    {
        switch (_levelManager.StageSize-40)
        {
            case 0:
                if (_player.Coins >= 10)
                {
                    _player.Coins -= 10;
                    _levelManager.StageSize+=15;
                    _player.StgSize=_levelManager.StageSize;
                }
                CloseStage();
                break;
            case 15:
                if (_player.Coins >= 20)
                {
                    _player.Coins -= 20;
                    _levelManager.StageSize += 15;
                    _player.StgSize = _levelManager.StageSize;
                }
                CloseStage();
                break;
            case 30:
                if (_player.Coins >= 25)
                {
                    _player.Coins -= 25;
                    _levelManager.StageSize += 15;
                    _player.StgSize = _levelManager.StageSize;
                }
                CloseStage();
                break;
            case 45:
                if (_player.Coins >= 30)
                {
                    _player.Coins -= 30;
                    _levelManager.StageSize += 15;
                    _player.StgSize = _levelManager.StageSize;
                }
                CloseStage();
                break;
            case 60:
                if (_player.Coins >= 35)
                {
                    _player.Coins -= 35;
                    _levelManager.StageSize += 15;
                    _player.StgSize = _levelManager.StageSize;
                }
                CloseStage();
                break;
            case 75:
                if (_player.Coins >= 40)
                {
                    _player.Coins -= 40;
                    _levelManager.StageSize += 15;
                    _player.StgSize = _levelManager.StageSize;
                }
                CloseStage();
                break;
            case 90:
                if (_player.Coins >= 45)
                {
                    _player.Coins -= 45;
                    _levelManager.StageSize += 15;
                    _player.StgSize = _levelManager.StageSize;
                }
                CloseStage();
                break;
        }
    }
}
