using UnityEngine;
using System;

public class Fade : MonoBehaviour
{
    private Color tmp;
    [SerializeField] private Behaviour _player;
    [SerializeField] private Acid _acid;
    private void Start()
    {
        tmp = this.GetComponent<SpriteRenderer>().color;
    }
    private void Update()
    {
        if (_player.HasJumped)
        {
            _acid.Speed = 0.35f;
            Destroy(gameObject);
        }
        tmp.a = Math.Abs(Mathf.Sin(Time.time * 4.5f));
        this.GetComponent<SpriteRenderer>().color = tmp;
        //Debug.Log(200*Mathf.PingPong(Time.deltaTime, 1f)-0.2);
    }
}