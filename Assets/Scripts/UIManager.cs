using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject playButton;
    public Transform bg;
    public TextMeshProUGUI finalScore;
    public GameObject gameOverScreen, storeScreen, homeScreen, playScreen;

    public Text timer;
    // Start is called before the first frame update

    private void Start()
    {
        StartCoroutine(StartTimer(3600, timer));
    }

    IEnumerator StartTimer(int seconds, Text activeTimer)
    {
        for (int i = 0; i < seconds; i++)
        {
            SetTimer(i, activeTimer, null);
            GameManager.instance.timeScore = i;
            yield return new WaitForSeconds(1);
        }
    }

    public void SetTimer(int Seconds, Text activeTimer, TextMeshProUGUI text)
    {
        int hours, minutes, seconds;
        hours = Seconds / 3600;
        Seconds %= 3600;
        minutes = Seconds / 60;
        seconds = Seconds % 60;

        if(activeTimer != null)
        {
            if (hours == 0)
            {
                activeTimer.text = string.Format("{0:D2}'{1:D2}", minutes, seconds);
            }
            else
                activeTimer.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
        
        if(text != null)
        {
            if (hours == 0)
            {
                text.text = string.Format("{0:D2}'{1:D2}", minutes, seconds);
            }
            else
                text.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }

        
    }

    public void PlayGameUI()
    {
        OpenScreen(null);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        timer.gameObject.SetActive(false);
        GameManager.instance.gameOver(finalScore);
    }

    public void OpenScreen(GameObject screen)
    {
        gameOverScreen.SetActive(false);
        homeScreen.SetActive(false);
        storeScreen.SetActive(false);
        playScreen.SetActive(false);
        if(screen!=null)
        {
            screen.SetActive(true);
        }        
    }

    public void ResetUI()
    {
        timer.text = "00'00";
    }
}
