﻿using UnityEngine;
using System.Collections;
using Managers;

public class VideoScript : MonoBehaviour
{
    public MovieTexture _video;

    private AudioSource _videoAudio;
    //private MovieTexture _video;
    private const string AVATAR_SELECT_SCREEN = "AvatarSelectScreen";

    // Use this for initialization
    void Start()
    {
        //_video = ((MovieTexture)GetComponent<Renderer>().material.mainTexture);
        _video.Play();
        _videoAudio = GetComponent<AudioSource>();
        _videoAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        skipManager();
    }

    private void skipManager()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_video.isPlaying)
            {
                _video.Stop();

            }
        }

        if (!_video.isPlaying)
        {
            GameController.Instance.loadScreenSingle(AVATAR_SELECT_SCREEN);
        }

    }
}
