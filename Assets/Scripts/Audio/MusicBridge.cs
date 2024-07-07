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

        GameObject objetoAmbience = GameObject.Find("AmbienceAudio"); //Bucar el objeto Ambience para modificar los parámetros del sonido ambeintal

        if (objetoAmbience != null)
        {
            audioBehaviourInstance = objetoAmbience.GetComponent<AudioBehaviour>();

            if (audioBehaviourInstance != null)
            {
                Debug.Log("Componente AudioBehaviour encontrado!");
                // Aquí puedes usar el componente controladorJugador
            }
            else
            {
                Debug.LogWarning("El objeto no tiene un componente AudioBehaviour");
            }
        }
        else
        {
            Debug.LogError("No se encontró el objeto 'Ambience'");
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
    public void NotificarEstadoJuego(string evento)
    {
        switch (evento)
        {
            case "JuegoEnCurso":
                MusicNotificarFinJuego(0);
                break;
            case "Ganar":
                MusicNotificarFinJuego(1);
                break;
            case "Perder":
                MusicNotificarFinJuego(2);
                break;
            case "NoDestruir":
                musicBehaviourInstance.DontDestroyMusic();
                break;
            case "DetenerMusica":
                musicBehaviourInstance.DontDestroyMusic();
                break;
            default:
                throw new ArgumentException("ERROR.Parámetro no válido.");
        }
    }

    public void DestroyMusic()
    {
        musicBehaviourInstance.DestroyMusic();
    }
    private void MusicNotificarFinJuego(int estadoJuego)
    {
        musicBehaviourInstance.OnGameStateChanged(estadoJuego); // 0 = en juego, 1 = Victoria, 2 = Derrota. 
    }

    private void AudioNotificarLocura(int locura)
    {
        musicBehaviourInstance.GameStateChange(locura);
        audioBehaviourInstance.GameStateChange(locura);
    }
    private void DetenerMusica(int locura)
    {
        musicBehaviourInstance.MusicStop();
        audioBehaviourInstance.AudioStop();
    }
    public void DetenerAmbience()
    {
        audioBehaviourInstance.AudioStop();
    }
    private void AudioNotificarPausa(bool isPaused)
    {
        musicBehaviourInstance.OnGamePaused(isPaused);
    }
}