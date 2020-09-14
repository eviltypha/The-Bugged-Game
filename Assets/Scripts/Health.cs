    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    Image healthImage;
    public static float max = 100f;
    public static float health;
    // Start is called before the first frame update
    void Start()
    {
        healthImage = GetComponent<Image>();
        health = max;
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = health / max;
        if (health <= 0)
            GameOver.gameOver = true;
    }
}
