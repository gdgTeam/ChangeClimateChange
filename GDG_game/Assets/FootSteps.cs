using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clipsS;
    [SerializeField]  private AudioClip[] clipsJ;
    private AudioSource audioSourceS;
    private AudioSource audioSourceJ;
    [SerializeField] private AudioClip[] clipsD;
    private AudioSource audioSourceD;
    [SerializeField] private AudioClip[] clipsPush;
    private AudioSource audioSourcePush;

    private void Awake()
    {

        audioSourceS = GetComponent<AudioSource>();
        audioSourceJ = GetComponent<AudioSource>();
        audioSourceD = GetComponent<AudioSource>();
        audioSourcePush = GetComponent<AudioSource>();
    }
    private void Step()
    {
        AudioClip clip = GetRandomClip();

        audioSourceS.PlayOneShot(clip);
    }
    private  AudioClip GetRandomClip()
    {
        return clipsS[UnityEngine.Random.Range(0, clipsS.Length)];
    }
    private void Jump()
    {
        AudioClip clip = GetRandomClipJ();

        audioSourceJ.PlayOneShot(clip);
    }
    private AudioClip GetRandomClipJ()
    {
        return clipsS[UnityEngine.Random.Range(0, clipsJ.Length)];
    }
    
    private void Death ()
    {
        AudioClip clip = GetRandomClipD();

        audioSourceD.PlayOneShot(clip);



    }
    private AudioClip GetRandomClipD()
    {
        return clipsD[UnityEngine.Random.Range(0, clipsD.Length)];
    }
    private void Push()
    {
        AudioClip clip = GetRandomClipP();

        audioSourcePush.PlayOneShot(clip);
    }
    private AudioClip GetRandomClipP()
    {
        return clipsPush[UnityEngine.Random.Range(0, clipsPush.Length)];
    }
}