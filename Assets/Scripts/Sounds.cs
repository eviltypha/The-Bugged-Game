using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    static AudioSource audiosrc;
    public static AudioClip coins, jump, enemy, player;
    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        coins = Resources.Load<AudioClip>("smb_coin");
        jump = Resources.Load<AudioClip>("smb_jump-small");
        enemy = Resources.Load<AudioClip>("smb_fireball");
        player = Resources.Load<AudioClip>("smb_kick");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound(string Clip)
    {
        switch(Clip)
        {
            case "smb_coin":
                audiosrc.PlayOneShot(coins);
                break;
            case "smb_jump-small":
                audiosrc.PlayOneShot(jump);
                break;
            case "smb_fireball":
                audiosrc.PlayOneShot(enemy);
                break;
            case "smb_kick":
                audiosrc.PlayOneShot(player);
                break;
        }
    }
}
