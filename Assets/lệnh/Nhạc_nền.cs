using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nhạc_nền : MonoBehaviour
{
    public static Nhạc_nền instance;
    public AudioSource nhạc_nền;
    public AudioSource yatta;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            nhạc_nền.Play();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void YATTA()
    {
        yatta.Play();
    }
}
