using UnityEngine;
using UnityEngine.UI;

public class CostChanger : MonoBehaviour
{
    [SerializeField] private Sprite _cost1;
    [SerializeField] private Sprite _cost2;
    [SerializeField] private Sprite _cost3;
    [SerializeField] private Sprite _cost4;
    [SerializeField] private Sprite _cost5;
    [SerializeField] private Sprite _cost6;
    [SerializeField] private Sprite _cost7;

    [SerializeField] private Image m_Image;

    private void Start()
    {

    }
    private void Update()
    {

    }
    public void Show1()
    {
        m_Image.sprite = _cost1;
    }
    public void Show2()
    {
        m_Image.sprite = _cost2;
    }
    public void Show3()
    {
        m_Image.sprite = _cost3;
    }
    public void Show4()
    {
        m_Image.sprite = _cost4;
    }
    public void Show5()
    {
        m_Image.sprite = _cost5;
    }
    public void Show6()
    {
        m_Image.sprite = _cost6;
    }
    public void Show7()
    {
        m_Image.sprite = _cost7;
    }

}
 