using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
	public static AudioClip jump, coin, powerup, click, die;
	static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        jump= Resources.Load<AudioClip> ("jump");
		coin= Resources.Load<AudioClip> ("coin");
		powerup = Resources.Load<AudioClip>("powerup");
        click = Resources.Load<AudioClip>("click");
        die = Resources.Load<AudioClip>("die");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
		
    }
	public static void PlaySound (string clip)
		{
			switch (clip)
			{
				case "coin":
				audioSrc.PlayOneShot(coin);
				break;
				case "powerup":
				audioSrc.PlayOneShot(powerup);
				break;
                case "click":
                audioSrc.PlayOneShot(click);
                break;
                case "jump":
                audioSrc.PlayOneShot(jump);
                break;
                case "die":
                audioSrc.PlayOneShot(die);
                break;
        }
}
}
