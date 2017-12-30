﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoControler : MonoBehaviour
{

    private VideoPlayer videoPlayer;
    public bool DestroyOnEnd; // destroy video player on end
    public GameObject pauseSplash; //splash screen that displays Pause Gui
    public GameObject choiceSplash; //splash screen that displays choice Gui

    //[SerializeField]
    //private AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Play or pause the video from user input
        if (pauseSplash)
        {
            if (Input.GetKeyDown("space") ||
                Input.GetMouseButtonDown(0))
            {
                if (videoPlayer.isPlaying)
                {
                    videoPlayer.Pause();
                    pauseSplash.SetActive(true);
                }
               
//                else
//                {
//                    videoPlayer.Play();
//                    pauseSplash.SetActive(false);
//                }
            }
        }
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.Pause();
        if (DestroyOnEnd)
        {
            DestroyObject(vp.gameObject);
        }
        
        choiceSplash.SetActive(true);
    }

    // PlayPause Controller
    public void PlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }

    // Restart Video controoler
    public void Restart()
    {
        videoPlayer.Stop();
        videoPlayer.Play();
    }

}

