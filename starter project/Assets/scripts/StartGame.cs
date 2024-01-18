using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public float timeLeft1 = 3.0f;
    public float timeLeft2 = 10.0f;
    public Text startText; // used for showing countdown from 3, 2, 1 
    public Text startText2;
    public Text winscreen;

    private void Start()
    {
        // sets 10sec and winscreen not active
        startText2.enabled = false;
        winscreen.enabled = false;
    }

    void Update()
    {
        //starts 3 sec countdown
        timeLeft1 -= Time.deltaTime;
        startText.text = (timeLeft1).ToString("0");
        if (timeLeft1 < 0)
        {
            //disables text for 3 sec countdown and enables 10 
            startText.gameObject.SetActive(false);
            startText2.enabled = true;
            timeLeft2 -= Time.deltaTime;
            startText2.text = (timeLeft2).ToString("0");
            if (timeLeft2 < 0)
            {
                startText2.enabled = false;
                winscreen.enabled = true;
            }
        }
    }
}