using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool GameStart;
    public GameObject StartText;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        GameStart = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        if(Swipe.tap)
        {
            GameStart = true;
            Destroy(StartText);
        }
    }
}
