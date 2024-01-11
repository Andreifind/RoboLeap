using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject _maps;
    [SerializeField] private GameObject _robots;
    public void SwitchToMaps()
    {
        Sounds.PlaySound("click");
        _robots.SetActive(false);
        _maps.SetActive(true);
    }

    public void SwitchToRobots()
    {
        Sounds.PlaySound("click");
        _maps.SetActive(false);
        _robots.SetActive(true);
    }
}
