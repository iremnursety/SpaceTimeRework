using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Sceneler arası geçiş sağlamak için
using UnityEngine.UI;//Loading Screen Slider'a erişebilmek için
using System; //Convert ve ToInt32'ye erişebilmek için eklenmiştir.
using UnityEngine.Audio;//Oyun içerisinde Mixer'a erişmek sesi azaltıp yükseltmek için
public class MenuScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text ProgressText;

    public bool GameDataCheck;

    public GameObject Settings;
    public GameObject Credits;
    public GameObject AReYouSure;
    public GameObject Buttons;
    public GameObject PatchNotes;
    public GameObject NotFound;

    public float VolumePercent1;
    public Text VolumePercentText1;
    public AudioMixer audioMixer1;


    private void Start()
    {
        Buttons.SetActive(true);
        PatchNotes.SetActive(true);

        Settings.SetActive(false);
        Credits.SetActive(false);
        AReYouSure.SetActive(false);
        NotFound.SetActive(false);

    }

    public void NewGameButton()
    {
        float GameDataCheck = PlayerPrefs.GetFloat("HealthValue");
        if (GameDataCheck <= 0)
        {   
            //Debug.Log("Scene Yükleme başlatıldı.");
            SceneLoad();
        }
        else
        { 
            Buttons.SetActive(false);
            AReYouSure.SetActive(true);
            //Debug.Log("Devam Etmek istediğinize emin misiniz? Kaydedilmiş veriler Silinecek.");
        }
    }
       
    public void LoadGameButton()
    {
         float GameDataCheck = PlayerPrefs.GetFloat("HealthValue");
        if (GameDataCheck <= 0)
        {
            NotFound.SetActive(true);
            //Debug.Log("Kayıt bulunamadı.");
        }
        else
        {
            SceneLoad();
            //Debug.Log("Scene Yükleme başlatıldı.");
        }
    }
    public void LoadScene(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(WaitTime());
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            ProgressText.text = "%"+Convert.ToInt32(progress*100f).ToString();
            //Debug.Log(progress);
            yield return null;
        }   
    }
    public void CreditsButton()
    {
        Buttons.SetActive(false);
        Credits.SetActive(true);
    }
    public void CreditsBackButton()
    {
        Buttons.SetActive(true);
        Credits.SetActive(false);
    }
    public void SettingsButton()
    {
        Buttons.SetActive(false);
        Settings.SetActive(true);
    }
    public void SettingsBackButton()
    {
        Buttons.SetActive(true);
        Settings.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit(); //Oyundan çıkış için
    }
    public void AreYouSureYes()
    {
        AReYouSure.SetActive(false);
        SceneLoad();
        LoadScene(1); //Oyunun ana sahnesini yükler
        PlayerPrefs.DeleteAll();

    }
    public void AreYouSureNo()
    {
        AReYouSure.SetActive(false);
        Buttons.SetActive(true);
    }
    public void SceneLoad()
    {
        Buttons.SetActive(false);
        PatchNotes.SetActive(false);
        PatchNotes.SetActive(false);
        LoadScene(1);
    }
    
    public void SetVolume(float volumee)
    {
        audioMixer1.SetFloat("VolumeMixer", Mathf.Log10(volumee)*20);
        //Mixer'ın değerini 0 db ile -80 db arasında tutabilmek için Mathf.Log10(volume)*20 kullanıldı.
        VolumePercent1= volumee * 100f;
        VolumePercentage1();
    }
    public void VolumePercentage1()
    {
        VolumePercentText1.text= "%"+Convert.ToInt32(VolumePercent1).ToString();
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(LoadAsynchronously(1));
    }
}
