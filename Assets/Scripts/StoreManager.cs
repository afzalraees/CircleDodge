using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    public ItemManager currentPlayer;
    public List<ItemManager> items = new List<ItemManager>();

    int playerNum;
    private void Start()
    {
        LoadItem();
    }

    void LoadItem()
    {
        if(PlayerPrefs.HasKey("Currentplayer"))
        {
            playerNum = PlayerPrefs.GetInt("Currentplayer");
        }
        else
        {
            PlayerPrefs.SetInt("Currentplayer", 0);
            playerNum = PlayerPrefs.GetInt("Currentplayer");
        }

        switch (playerNum)
        {
            case 0:
                {
                    UpdatePlayer(items[0]);
                    break;
                }
            case 1:
                {
                    UpdatePlayer(items[1]);
                    break;
                }
            case 2:
                {
                    UpdatePlayer(items[2]);
                    break;
                }
            case 3:
                {
                    UpdatePlayer(items[3]);
                    break;
                }
        }
    }

    

    public void UpdatePlayer(ItemManager item)
    {
        foreach (ItemManager itemManager in items) 
        {
            itemManager.correct.SetActive(false);
        }
        GameManager.instance.player.GetComponent<SpriteRenderer>().sprite = item.image.sprite;
        item.correct.SetActive(true);

        PlayerPrefs.SetInt("Currentplayer", item.itemNumber);
    }
    
}
