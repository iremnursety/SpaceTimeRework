using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameData : MonoBehaviour
{
    public static LoadGameData Instance { get; private set; }
    public float SavedHealthValue;
    public float SavedHungerValue;
    public float SavedThirstValue;
    public float SavedBladderValue;
    public float SavedHygieneValue;
    public float SavedTirednessValue;
    public float SavedSanityValue;
    public float SavedDrowningValue;

    public float SavedGameTime;
    public int SavedGameDay;

    public float SavedPlayerX;
    public float SavedPlayerY;
    public float SavedPlayerZ;

    public PlayerPosition LoadingPlayerPosition;
    public SliderBars LoadingPlayerStats;
    public DayNightController LoadingGameDayTime;
    public SaveGameData SavedData;

    public GameObject nogamedata;
    public GameObject GameLoaded;
    public GameObject GameDataSaved;

    public void Start()

    {
        LoadingGame();
    }

    public void LoadingGame()
    {
        //Kaydedilmiş veri dosyaları getirilir.
        if (PlayerPrefs.HasKey("PlayerPositionX"))
        {
            SavedHealthValue = PlayerPrefs.GetFloat("HealthValue");
            SavedHungerValue = PlayerPrefs.GetFloat("HungerhValue");
            SavedThirstValue = PlayerPrefs.GetFloat("ThirstValue");
            SavedBladderValue = PlayerPrefs.GetFloat("BladderValue");
            SavedHygieneValue = PlayerPrefs.GetFloat("HygieneValue");
            SavedTirednessValue = PlayerPrefs.GetFloat("TirednessValue");
            SavedSanityValue = PlayerPrefs.GetFloat("SanityValue");
            SavedDrowningValue = PlayerPrefs.GetFloat("DrowningValue");

            SavedGameTime = PlayerPrefs.GetFloat("GameTime");
            SavedGameDay = PlayerPrefs.GetInt("GameDay");

            SavedPlayerX = PlayerPrefs.GetFloat("PlayerPositionX");
            SavedPlayerY = PlayerPrefs.GetFloat("PlayerPositionY");
            SavedPlayerZ = PlayerPrefs.GetFloat("PlayerPositionZ");

            //Karakterin pozisyonunu kaydedilen veriler ile değiştiriyoruz.
            LoadingPlayerPosition.player.transform.position = new Vector3(SavedPlayerX, SavedPlayerY, SavedPlayerZ);

            //Debug.Log("Player Position Loaded.");

            LoadingPlayerStats.Health = SavedHealthValue;
            LoadingPlayerStats.Hunger = SavedHungerValue;
            LoadingPlayerStats.Thirst = SavedThirstValue;
            LoadingPlayerStats.Bladder = SavedBladderValue;
            LoadingPlayerStats.Hygiene = SavedHygieneValue;
            LoadingPlayerStats.Tiredness = SavedTirednessValue;
            LoadingPlayerStats.Sanity = SavedSanityValue;
            LoadingPlayerStats.Drowning = SavedDrowningValue;


            //Debug.Log("Player Stats Loaded");

            LoadingGameDayTime.time = SavedGameTime;
            LoadingGameDayTime.days = SavedGameDay;

            //Debug.Log("Game Time and Day Loaded");
            //Debug.Log("Game Loaded");
            nogamedata.SetActive(false);
            GameDataSaved.SetActive(false);
            GameLoaded.SetActive(true);
        }
        else
        {
            //Debug.Log("Kayıt Bulunamadı.");
            GameLoaded.SetActive(false);
            GameDataSaved.SetActive(false);
            nogamedata.SetActive(true);
        }
    }
}