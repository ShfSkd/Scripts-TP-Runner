using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    public static bool gameOver;
    public static bool isGameStarted;
    public static int numOfToiletPepers;
    public Text TPText;

    public GameObject startingText;

    

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isGameStarted = false;
        Time.timeScale = 1f;
        numOfToiletPepers = 0;
        
        
    }
 

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        TPText.text = "TP:" + numOfToiletPepers;
        if (SwipeManager.instance.Tap)
        {
            isGameStarted = true;
            startingText.SetActive(false);
        }
    }
 

}
