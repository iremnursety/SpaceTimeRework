using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI'da bulunan eklentilere erişebilmek için
using System; //Convert ve ToInt32'ye erişebilmek için eklenmiştir.

public class SliderBars : MonoBehaviour
{
    public static SliderBars Instance { get; set; }

    public float Health;
    public float HealthOverTime;

    public float Drowning;
    public float DrowningOverTime;

    public float Hunger;
    public float HungerOverTime;

    public float Thirst;
    public float ThirstOverTime;

    public float Bladder;
    public float BladderOverTime;

    public float Hygiene;
    public float HygieneOverTime;

    public float Tiredness;
    public float TirednessOverTime;

    public float Sanity;
    public float SanityOverTime;

    public Slider HealthBar;
    public Slider DrowningBar;
    public Slider HungerBar;
    public Slider ThirstBar;
    public Slider BladderBar;
    public Slider HygieneBar;
    public Slider TirednessBar;
    public Slider SanityBar;

    public Text HealthValue;
    public Text DrowningValue;
    public Text DrowningText;
    public Text HungerValue;
    public Text ThirstValue;
    public Text BladderValue;
    public Text HygieneValue;
    public Text TirednessValue;
    public Text SanityValue;

    public float minimumdeger = 5f;

    public bool inwater;
    public bool bladderoverflow;
    public float yukseklik;



    // Update is called once per frame
    private void Start()
    {
       
        HealthBar.maxValue = Health;
        DrowningBar.maxValue = Drowning;
        HungerBar.maxValue = Hunger;
        ThirstBar.maxValue = Thirst;
        BladderBar.maxValue = Bladder;
        HygieneBar.maxValue = Hygiene;
        TirednessBar.maxValue = Tiredness;
        SanityBar.maxValue = Sanity;
 
        updateUI();
    }
    private void Update()
    {
        DegerHesaplama();
        if (transform.position.y < yukseklik)
        {
            inwater = true; //suda olup olmadığını kontrol etmek için
        }
        else
        {
            inwater = false;
        }

        if (bladderoverflow == true)
        {
            if (Bladder == BladderBar.maxValue)
            {
                Bladder = BladderBar.maxValue;
                bladderoverflow = false;
            }
            else
            {
                Bladder += 0.5f + BladderOverTime * Time.deltaTime;
                Hygiene -= 0.2f+HygieneOverTime * Time.deltaTime;
                Sanity -= 0.1f+SanityOverTime * Time.deltaTime;
                BladderValue.text = Convert.ToInt32(Bladder).ToString();
            }
        }
    }
    private void DegerHesaplama()
    {
        //Zamana bağlı olarak açlığın ve susuzluğun artması.
        Hunger -= HungerOverTime * Time.deltaTime;
        Thirst -= ThirstOverTime * Time.deltaTime;
        Bladder -= BladderOverTime * Time.deltaTime;
        Hygiene -= ThirstOverTime * Time.deltaTime;
        Tiredness -= TirednessOverTime * Time.deltaTime;


       
        if (Hunger <= minimumdeger || Thirst <= minimumdeger || Drowning <= minimumdeger)   // Açlık veya susuzluk minimum değerden düşük ise olacaklar
        {
            Health -= HealthOverTime * Time.deltaTime; //Zamana bağlı olarak can azalacak.
        }
        if (Tiredness <= minimumdeger)
        {
            Sanity -= SanityOverTime * Time.deltaTime;
            if (Sanity <= minimumdeger)
            {
                Health -= HealthOverTime * Time.deltaTime;
            }
        }
        if (Bladder <= minimumdeger)
        {
            bladderoverflow = true;
        }

        if (inwater) //Karakter su içindeyse zamana bağlı boğulma
        {
            Drowning -= DrowningOverTime * Time.deltaTime;
            DrowningText.text = "Drowning..";
            DrowningValue.text = Convert.ToInt32(Drowning).ToString();
        }
        else
        {
            if (Drowning == DrowningBar.maxValue)
            {
                Drowning = DrowningBar.maxValue; //Eğer suda değilse çalışacak ve boğulma max değere ulaşınca duracak.
                DrowningText.text = " ";
                DrowningValue.text = " ";
            }
            else
            {
                Drowning += 3.5f * DrowningOverTime * Time.deltaTime;
                DrowningText.text = "Stabilizing..";
                DrowningValue.text = Convert.ToInt32(Drowning).ToString();
            }
        }
        updateUI();
    }
    private void updateUI()
    {
        //UI'ları yani oluşturduğumuz sliderları burada updateleyeceğiz.

        Health = Mathf.Clamp(Health, 0, 100f); // Health değerini 0 ila 100 float arasında olacak şekilde ayarladık.
        Hunger = Mathf.Clamp(Hunger, 0, 50f);
        Thirst = Mathf.Clamp(Thirst, 0, 50f);
        Bladder = Mathf.Clamp(Bladder, 0, 50f);
        Hygiene = Mathf.Clamp(Hygiene, 0, 50f);
        Tiredness = Mathf.Clamp(Tiredness, 0, 50f);
        Sanity = Mathf.Clamp(Sanity, 0, 50f);
        Drowning = Mathf.Clamp(Drowning, 0, 20f);

        HealthBar.value = Health;
        HungerBar.value = Hunger;
        ThirstBar.value = Thirst;
        BladderBar.value = Bladder;
        HygieneBar.value = Hygiene;
        TirednessBar.value = Tiredness;
        SanityBar.value = Sanity;
        DrowningBar.value = Drowning;

        //Sliderlardan gelen veriler burda text olarak yazdırılıyor.
        HealthValue.text = Convert.ToInt32(Health).ToString();
        HungerValue.text = Convert.ToInt32(Hunger).ToString();
        ThirstValue.text = Convert.ToInt32(Thirst).ToString();
        BladderValue.text = Convert.ToInt32(Bladder).ToString();
        HygieneValue.text = Convert.ToInt32(Hygiene).ToString();
        TirednessValue.text = Convert.ToInt32(Tiredness).ToString();
        SanityValue.text=Convert.ToInt32(Sanity).ToString();


    }
    public void BladderOver()
    {
        while (Bladder < 40.0f)
        {
            if (Bladder == 40.0f)
            {
                bladderoverflow = false;
            }
            else
            {
                Bladder += 3.5f * BladderOverTime * Time.deltaTime;
                Hygiene -= 0.5f * Hygiene * Time.deltaTime;
                BladderValue.text = Convert.ToInt32(Bladder).ToString();
            }
  
        }
        
        
    }
}
