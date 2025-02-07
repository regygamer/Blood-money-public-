﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class BackGroundMusicFadeIn : MonoBehaviour
{
    [SerializeField]
    private int m_FadeInTime = 10;
    private AudioSource m_AudioSource;


    private void Awake()
    {
        Time.timeScale = 1;
        m_AudioSource = this.GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            if (m_AudioSource.volume < PlayerPrefs.GetFloat("MasterVol"))
            {
                m_AudioSource.volume = m_AudioSource.volume + (Time.deltaTime / (m_FadeInTime + 1));
            }
            else
            {
                Destroy(this);
            }
        }

        else
        {
            if (m_AudioSource.volume < .5)
            {
                m_AudioSource.volume = m_AudioSource.volume + (Time.deltaTime / (m_FadeInTime + 1));
            }
            else
            {
                Destroy(this);
            }
        }


    }
}
