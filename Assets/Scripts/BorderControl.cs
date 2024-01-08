using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Contains("thorn"))
        {
            Transform thorn = collision.transform.transform;
            thorn.localPosition = new Vector3(Random.Range(-9,10), 25, thorn.position.z);
            thorn.gameObject.SetActive(false);
        }
    }
}
