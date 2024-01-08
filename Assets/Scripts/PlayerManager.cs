using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Rotate(Input.mousePosition);
        }
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Rotate(Input.GetTouch(0).position);
        }
#endif
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag.Contains("thorn"))
        {
            GameManager.instance.uiManager.GameOver();
        }

    }

    void Rotate(Vector3 pos)
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(pos) - transform.parent.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.parent.localRotation = rotation;
     }
}
