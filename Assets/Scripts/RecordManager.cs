using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RecordManager : MonoBehaviour
{
    public int record;
    public TextMeshProUGUI recordTxt;
    // Start is called before the first frame update
    void Start()
    {
        LoadRecord();
    }

    void LoadRecord()
    {
        if (PlayerPrefs.HasKey("Record"))
        {
            record = PlayerPrefs.GetInt("Record");
            Updaterecord(record);
        }
        else
        {
            PlayerPrefs.SetInt("Record", record);
            Updaterecord(record);
        }
    }
    public void Updaterecord(int score)
    {
        record = score;
        GameManager.instance.uiManager.SetTimer(record, null, recordTxt);
    }
}
