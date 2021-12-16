using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformController : MonoBehaviour
{
    public bool isActive;

    public float changespeed = 1;
    Vector3 temp;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            IncreaseSize();
        }
        else
        {
            DownSize();
        }
    }

    private void DownSize()
    {
        if (temp.x < 1)
        {
            temp = transform.localScale;
            temp.x += 1f * changespeed * Time.deltaTime;
            temp.y += 1f * changespeed * Time.deltaTime;
            transform.localScale = temp;
        }

    }

    private void IncreaseSize()
    {
        if (temp.x > 0.01)
        {
            temp = transform.localScale;
            temp.x -= 1f * changespeed * Time.deltaTime;
            temp.y -= 1f * changespeed * Time.deltaTime;
            transform.localScale = temp;
        }
    }
}
