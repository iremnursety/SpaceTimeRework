using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;

    private CursorLockMode _lockMode;
    private CursorLockMode _free;
   

    [SerializeField] private GameObject noGameData;
    [SerializeField] private GameObject gameLoaded;
    [SerializeField] private GameObject gameDataSaved;
    [SerializeField] private GameObject settingExcept;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private float volumePercent;
    [SerializeField] private Text volumePercentText;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private GameObject crosshairMiddle;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private Animator animator;

    private void Start()
    {
        _lockMode = CursorLockMode.Locked;
        _free = CursorLockMode.None;
        CursorLocked();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            crosshairMiddle.SetActive(false);
            crosshair.SetActive(false);
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        CursorVisible();
        pauseMenuPanel.SetActive(true);
        DisableNotification();
    }

    public void MainMenu()
    {
        animator.SetTrigger("FadeOut");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void SettingMenu()
    {
        DisableNotification();
        settingsMenu.SetActive(true);
        settingExcept.SetActive(false);
    }

    public void SettingBackButton()
    {
        settingsMenu.SetActive(false);
        settingExcept.SetActive(true);
    }

    public void ExitButton()
    {
        animator.SetTrigger("FadeOut");
        Time.timeScale = 1f;
        Debug.Log("ExitButton");
        Application.Quit();
    }

    public void BackToGameButton()
    {
        Time.timeScale = 1f;
        pauseMenuPanel.SetActive(false);
        DisableNotification();
        CursorLocked();
        crosshairMiddle.SetActive(true);
        crosshair.SetActive(true);
    }

    public void CursorVisible()
    {
        Cursor.visible = true;
        Cursor.lockState = _free;
    }

    public void CursorLocked()
    {
        Cursor.visible = false;
        Cursor.lockState = _lockMode;
    }

    public void DisableNotification()
    {
        noGameData.SetActive(false);
        gameLoaded.SetActive(false);
        gameDataSaved.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("InGameMixer", Mathf.Log10(volume) * 20);
        volumePercent = volume * 100f;
        VolumePercentage();
    }

    public void VolumePercentage()
    {
        volumePercentText.text = "%" + Convert.ToInt32(volumePercent).ToString();
    }
}