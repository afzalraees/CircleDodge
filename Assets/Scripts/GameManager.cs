using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public RecordManager recordManager;
    public StoreManager storeManager;
    public ThornManager thornManager;
    public PlayerManager player;

    public int timeScore;
    public GameObject thorns;
    public static GameManager instance;

    public bool isGameOver;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }

    

    public void StartGame()
    {
        uiManager.PlayGameUI();
        player.transform.parent.gameObject.SetActive(true);
        thorns.SetActive(true);
        isGameOver = false;
    }

    public void gameOver(TextMeshProUGUI finalScore)
    {
        isGameOver = true;
        player.gameObject.SetActive(false);
        thorns.SetActive(false);
        uiManager.SetTimer(timeScore, null, finalScore);
        if(timeScore > recordManager.record)
        {
            recordManager.Updaterecord(timeScore);
        }
        PlayerPrefs.SetInt("Record", recordManager.record);
    }

    public void RestartGame()
    {
        player.gameObject.SetActive(true);
        thornManager.ResetThorns();
        thorns.SetActive(true);
        player.transform.localPosition = new Vector3(0,1.5f,0);
        timeScore = 0;
        uiManager.OpenScreen(null);
        uiManager.ResetUI();
    }
}
