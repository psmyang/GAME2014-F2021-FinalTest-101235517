//*********************************************************************************************************
// GAME2014-F2021-Final Test-101235517.C# Unity by Mingkun Yang (C) December 16th 2021 All Rights Reserved.
//
// Name: Mingkun Yang 
//
// StudentID: 101235517
//
// Final Test submission.
//
// Description: Make platform is floating and shrinked, add sound effect
//
// Modified: December 16th 2021
//
// File Name: FloatingPlatformController.cs
//
//******************************************************************************************************

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

    public AudioSource[] platformAudio;

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
            if (!platformAudio[1].isPlaying && !platformAudio[0].isPlaying)
            {
                platformAudio[1].Play();
            }
            else
            {
                platformAudio[0].Play();
            }
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
