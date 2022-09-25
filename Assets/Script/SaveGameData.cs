using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameData : MonoBehaviour
{
    public static SaveGameData Instance { get; private set; }
    
    public float stathealth;
    public float stathunger;
    public float statthirst;
    public float statbladder;
    public float stathygiene;
    public float stattiredness;
    public float statsanity;
    public float statdrowning;
    

    public float hours;
    public int day;


    //public float[] position;
    public float playerPositionX;
    public float playerPositionY;
    public float playerPositionZ;

    public PlayerPosition playerTransform;
    public SliderBars playerStats;
    public DayNightController daytime;

    public GameObject gameDataSaved;
    public GameObject loadedGameData;
    public GameObject noSaveData;



    public void SaveGame()
    {
        playerPositionX = playerTransform.player.transform.position.x;
        playerPositionY = playerTransform.player.transform.position.y;
        playerPositionZ = playerTransform.player.transform.position.z;

        hours = daytime.time;
        day = daytime.days;

        stathealth = playerStats.Health;
        stathunger = playerStats.Hunger;
        statthirst = playerStats.Thirst;
        statdrowning = playerStats.Drowning;
        statbladder = playerStats.Bladder;
        stathygiene = playerStats.Hygiene;
        stattiredness = playerStats.Tiredness;
        statsanity = playerStats.Sanity;



        PlayerPrefs.SetFloat("PlayerPositionX", playerPositionX);
        PlayerPrefs.SetFloat("PlayerPositionY", playerPositionY);
        PlayerPrefs.SetFloat("PlayerPositionZ", playerPositionZ);

        PlayerPrefs.SetFloat("GameTime", hours);
        PlayerPrefs.SetInt("GameDay", day);

        PlayerPrefs.SetFloat("HealthValue", stathealth);
        PlayerPrefs.SetFloat("HungerhValue", stathunger);
        PlayerPrefs.SetFloat("ThirstValue", statthirst);
        PlayerPrefs.SetFloat("DrowningValue", statdrowning);
        PlayerPrefs.SetFloat("BladderValue", statbladder);
        PlayerPrefs.SetFloat("HygieneValue", stathygiene);
        PlayerPrefs.SetFloat("TirednessValue", stattiredness);
        PlayerPrefs.SetFloat("SanityValue", statsanity);

        PlayerPrefs.Save();

        Debug.Log("Game Saved");
        
        loadedGameData.SetActive(false);
        noSaveData.SetActive(false);
        gameDataSaved.SetActive(true);
    }
    
    
}
