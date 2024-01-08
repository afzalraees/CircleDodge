using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThornManager : MonoBehaviour
{
    public List<Transform> thorns = new List<Transform>();

    private void Start()
    {
        StartCoroutine(SpawnThorns());
    }
    public void ResetThorns()
    {
        int x = -9;
        for (int i = 0; i < thorns.Count; i++)
        {
            thorns[i].localPosition = new Vector3(x, 25, 0);
            x++;
        }
    }

    IEnumerator SpawnThorns()
    {
        while(!GameManager.instance.isGameOver)
        {
            int randomThorn = Random.Range(0, thorns.Count);
            thorns[randomThorn].gameObject.SetActive(true);

            int randTime = Random.Range(1, 4);
            yield return new WaitForSeconds(randTime);
        }
    }
}
