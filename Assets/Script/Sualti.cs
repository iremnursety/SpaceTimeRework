using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sualti : MonoBehaviour
{ 
    public float yukseklik;
    public bool inwater;
    
    public ParticleSystemRenderer particleRenderer;
    public ParticleSystem particlesystem;

    public AudioSource ocean1;
    public AudioSource ocean2;
    public AudioSource ocean3;
    public AudioSource ocean4;
    public AudioSource windtree;
    public AudioSource underwater;


    private void Update()
    {
        IsInWater();

        if (inwater)
        {

            particleRenderer.enabled = true;
        }
        else
        {
            particleRenderer.enabled = false;
            particlesystem.Clear();       
        }
    }
    private void IsInWater()
    {
        if (transform.position.y < yukseklik)
        {
            inwater = true; //suda olup olmadığını kontrol etmek için

            ocean1.volume = 0.0f;
            ocean2.volume = 0.0f;
            ocean3.volume = 0.0f;
            ocean4.volume = 0.0f;
            windtree.volume = 0.0f;
            underwater.volume = 100.0f;
        }
        else
        {
            inwater = false;
            ocean1.volume = 100.0f;
            ocean2.volume = 100.0f;
            ocean3.volume = 100.0f;
            ocean4.volume = 100.0f;
            windtree.volume = 100.0f;
            underwater.volume = 0.0f;
        }
    }
}
