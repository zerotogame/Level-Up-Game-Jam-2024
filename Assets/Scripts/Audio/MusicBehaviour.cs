using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
using System.Data;

[RequireComponent(typeof(StudioEventEmitter), typeof(MusicBridge))]
public class MusicBehaviour : MonoBehaviour //Modifica los distintos parámetros para los cambios en la música.
{

    public StudioEventEmitter levelMusic;
    //public StudioEventEmitter levelAmbience;
    public static MusicBehaviour instance { get; private set; }

    private void Awake()
    {
        levelMusic = GetComponent<FMODUnity.StudioEventEmitter>();
        //levelAmbience = Ambience.GetComponent<FMODUnity.StudioEventEmitter>();
    }


    #region Métodos para actualizar
    public void GameStateChange(int locura)
    {
        levelMusic.SetParameter("Locura", locura);
    }
    public void OnGamePaused(bool isGamePaused)
    {
        if (!isGamePaused)
        {
            levelMusic.SetParameter("enPausa", 0);
        }
        else
        {
            levelMusic.SetParameter("enPausa", 1);
        }
    }
    #endregion


    public void MusicStart()
    {
        levelMusic.Play();
    }
    public void MusicStop()
    {
        levelMusic.Stop();
    }
    public void DestroyMusic()
    {
        Destroy(gameObject);
    }
    public void DontDestroyMusic()
    {
        DontDestroyOnLoad(gameObject);
    }
}

