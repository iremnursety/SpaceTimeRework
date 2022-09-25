using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DayNightController : MonoBehaviour
{
    
    private TimeSpan _currentTime;
    [SerializeField] private Transform sunTransform;
    [SerializeField] private Transform moonTransform;
    [SerializeField] private Transform starsTransform;
    [SerializeField] private Light sun;
    [SerializeField] private Light moon;

    [SerializeField] private Text timeText;
    [SerializeField] private Text dayText;

    [SerializeField] private float intensity;
    [SerializeField] private Color fogDay = Color.gray;
    [SerializeField] private Color fogNight = Color.black;

    [SerializeField] private int speed;
    [SerializeField] private int sunCycle;
    [SerializeField] private int moonCycle;

    public int days;
    public float time;
    
    public ParticleSystemRenderer particleRenderer;

    private void Update()
    {
        ChangeTime();
    }

    public void ChangeTime()
    {
        time += Time.deltaTime * speed;
        if (time > 86400)
        {
            days += 1;
            time = 0;
            sunCycle += 5;
            moonCycle += 25;
        }

        _currentTime = TimeSpan.FromSeconds(time);
        var tempTime = _currentTime.ToString().Split(":"[0]);

        timeText.text = "Time: " + tempTime[0] + ":" + tempTime[1];
        dayText.text = "Day: " + days;

        sunTransform.rotation =
            Quaternion.Euler(new Vector3((time - 21600) / 86400 * 360, (time - 21600) / 86400 * +sunCycle, 0));
        moonTransform.rotation =
            Quaternion.Euler(new Vector3((time - 21600) / 86400 * -360, (time - 21600) / 86400 * +moonCycle, 0));
        starsTransform.rotation = Quaternion.Euler(new Vector3(0, (time - 21600) / 86400 * 2 * 360, 0) / 10);

        if (time < 43200)
        {
            intensity = 1 - (43200 - time) / 432000;
        }
        else
        {
            intensity = 1 - (43200 - time) / 432000 * -1;
        }

        RenderSettings.fogColor = Color.Lerp(fogNight, fogDay, intensity * intensity);
        sun.intensity = intensity;

        if (time > 19800 && time < 65280)
        {
            particleRenderer.enabled = false;
        }
        else
            particleRenderer.enabled = true;
    }
}