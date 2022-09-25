using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationSounds : MonoBehaviour
{

    public AudioSource _walkingOnSand,_walkingOnMetal;
    
    private void Start()
    {
        _walkingOnSand = GetComponent<AudioSource>();
        _walkingOnMetal = GetComponent<AudioSource>();
    }
    
    private void PlayerFootstepSounds()
    {
        _walkingOnSand.Play();

    }
}
