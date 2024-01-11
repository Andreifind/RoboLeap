using UnityEngine;

public class ShopRobots : MonoBehaviour
{
    [SerializeField] private GameObject[] _page;
    private int _pageIndex;
    private void Start()
    {
    }

    private void Update()
    {
        
    }

    public void NextButton()
    {
        Sounds.PlaySound("click");
        _page[_pageIndex].SetActive(false);
        if (_pageIndex < _page.Length-1)
            _pageIndex++;
        else _pageIndex = 0;
        _page[_pageIndex].SetActive(true);
    }

    public void PrevButton()
    {
        Sounds.PlaySound("click");
        _page[_pageIndex].SetActive(false);
        if (_pageIndex > 0)
            _pageIndex--;
        else _pageIndex = _page.Length - 1;
        _page[_pageIndex].SetActive(true);
    }
}
