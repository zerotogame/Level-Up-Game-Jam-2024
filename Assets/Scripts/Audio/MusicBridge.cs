using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MusicBridge : MonoBehaviour // MusicBridge conecta los distintos scripts del juego con MusicBehaviour y AudioBehaviour.
{
    public MusicBehaviour musicBehaviourInstance;
    //public AudioBehaviour audioBehaviourInstance;
    AudioBehaviour audioBehaviourInstance;

    void Start()
    {
        musicBehaviourInstance = GetComponent<MusicBehaviour>();
        //audioBehaviourInstance = GetComponent<AudioBehaviour>();

        GameObject objetoAmbience = GameObject.Find("AmbienceAudio"); //Bucar el objeto Ambience para modificar los par�metros del sonido ambeintal

        if (objetoAmbience != null)
        {
            audioBehaviourInstance = objetoAmbience.GetComponent<AudioBehaviour>();

            if (audioBehaviourInstance != null)
            {
                Debug.Log("Componente AudioBehaviour encontrado!");
                // Aqu� puedes usar el componente controladorJugador
            }
            else
            {
                Debug.LogWarning("El objeto no tiene un componente AudioBehaviour");
            }
        }
        else
        {
            Debug.LogError("No se encontr� el objeto 'Ambience'");
        }
    }

    public void NotificarCambioAudio(int locura)
    {
        AudioNotificarLocura(locura);
    }
    public void NotificarPausaMusica(bool isPaused)
    {
        AudioNotificarPausa(isPaused);
    }

    public void DestroyMusic()
    {
        musicBehaviourInstance.DestroyMusic();
    }

    private void AudioNotificarLocura(int locura)
    {
        musicBehaviourInstance.GameStateChange(locura);
        audioBehaviourInstance.GameStateChange(locura);
    }
    private void AudioNotificarPausa(bool isPaused)
    {
        musicBehaviourInstance.OnGamePaused(isPaused);
    }
}