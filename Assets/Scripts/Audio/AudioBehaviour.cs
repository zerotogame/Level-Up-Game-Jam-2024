using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
using System.Data;

[RequireComponent(typeof(StudioEventEmitter), typeof(MusicBridge))]
public class AudioBehaviour : MonoBehaviour //Modifica los distintos parámetros para los cambios en la música.
{

    public StudioEventEmitter levelAmbience;
    //public StudioEventEmitter levelAmbience;
    public static AudioBehaviour instance { get; private set; }

    private void Awake()
    {
        levelAmbience = GetComponent<FMODUnity.StudioEventEmitter>();
    }


    #region Métodos para actualizar
    public void GameStateChange(int locura)
    {
        levelAmbience.SetParameter("Locura", locura);
    }
    #endregion
}

