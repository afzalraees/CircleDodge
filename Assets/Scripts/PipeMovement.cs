using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    float moveSpeed = 10;
    float time = 0;

    public Transform coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * Time.deltaTime * moveSpeed;
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > 60)
        {
            moveSpeed++;
            time = 0;
        }
    }

    public void RandomCoin()
    {
        int random = Random.Range(0, 2);
        if(random == 0)
        {
            coin.gameObject.SetActive(true);
            int posY = Random.Range(20, -21);
            Vector3 pos = new Vector3(coin.localPosition.x, posY, coin.localPosition.z);
            coin.localPosition = pos;
        }
        else 
        {
            coin.gameObject.SetActive(false);
        }
    }
}
