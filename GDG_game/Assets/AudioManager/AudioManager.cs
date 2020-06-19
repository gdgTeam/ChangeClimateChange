﻿using UnityEngine.Audio;
using System;
using UnityEngine;

namespace roundbeargames_tutorial
{
    public class AudioManager : MonoBehaviour
    {

        public static AudioManager instance;

        public AudioMixerGroup mixerGroup;

        public Sound[] sounds;

        void Awake()
        {
            if (instance != null)
            {
                //fa in modo che ci sia sempre solo un audio manager attivo
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                //serve per non fermare la musica tra una scena e l'altra
                //potrebbe essere utile per mettere la musica durante le transizioni
                DontDestroyOnLoad(gameObject);
            }

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.loop = s.loop;

                s.source.outputAudioMixerGroup = mixerGroup;
            }
        }

        public void Play(string sound)
        {
            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
            s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

            s.source.Play();
        }

        public void StopPlaying(string sound)
        {
            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
            s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

            s.source.Stop();
        }

    }
}
