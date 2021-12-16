using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformController : MonoBehaviour
{
    public bool isActive;

    public float changespeed = 1;
    Vector3 temp;

    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;
    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;

        nextPos = startPos.position;
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

        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }
}
