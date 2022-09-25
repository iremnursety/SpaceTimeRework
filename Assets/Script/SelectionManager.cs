using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    //TODO:Change them to enum.
    [SerializeField] private string selectableTagFood = "SelectableFood";
    [SerializeField] private string selectableTagWater = "SelectableWater";
    [SerializeField] private string selectableTagFruit = "SelectableFruit";
    [SerializeField] private string selectableTagOpenDoor = "SelectableOpenDoor";
    [SerializeField] private string selectableTagBed = "SelectableBed";
    [SerializeField] private string selectableTagToilet = "SelectableToilet";
    [SerializeField] private string selectableTagShower = "SelectableShower";
    [SerializeField] private string selectableTagHandWasher = "SelectableHandWasher";
    [SerializeField] private string selectableTagCraft = "SelectableCraft";
    [SerializeField] private string selectableTagCWaterMachine = "SelectableWaterMachine";
    [SerializeField] private Text itemNameText;
    [SerializeField] private GameObject itemText;
    [SerializeField] private Image crossHair;
    [SerializeField] private SliderBars playerStats;
    [SerializeField] private DayNightController dayTime;

    [SerializeField] private Animator animator;
    private Animator _openDoor;

    private AudioSource _audioS;

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,2.0f))
        {
            var selection = hit.transform;

            if (selection.CompareTag(selectableTagWater))
            {
                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Drink Water";

                if (Input.GetMouseButtonDown(0))
                {
                    playerStats.Thirst = playerStats.Thirst + 20;
                    playerStats.Bladder = playerStats.Bladder - 8;
                    _audioS = selection.GetComponent<AudioSource>();
                    _audioS.Play();
                }
            }
            else if (selection.CompareTag(selectableTagFood))
            {
                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Eat Food";
                if (Input.GetMouseButtonDown(0))
                {
                    playerStats.Hunger = playerStats.Hunger + 20;
                    _audioS = selection.GetComponent<AudioSource>();
                    _audioS.Play();
                }
            }
            else if (selection.CompareTag(selectableTagFruit))
            {

                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Eat Fruit";
                if (Input.GetMouseButtonDown(0))
                {
                    playerStats.Thirst = playerStats.Thirst + 20;
                    playerStats.Hunger = playerStats.Hunger + 20;
                    playerStats.Bladder = playerStats.Bladder - 5;
                    _audioS = selection.GetComponent<AudioSource>();
                    _audioS.Play();
                }
            }
            else if (selection.CompareTag(selectableTagBed))
            {
                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Sleep";
                if (Input.GetMouseButtonDown(0))
                {
                    dayTime.days = dayTime.days + 1;
                    dayTime.time = 19000;
                    animator.SetTrigger("FadeOut");
                    animator.SetTrigger("FadeIn");
                    playerStats.Thirst = playerStats.Thirst - 20;
                    playerStats.Hunger = playerStats.Hunger - 20;
                    playerStats.Tiredness = playerStats.Tiredness + 30;
                    playerStats.Sanity = playerStats.Sanity + 40;
                }
            }
            else if (selection.CompareTag(selectableTagOpenDoor))
            {
                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Door";
                if (Input.GetMouseButtonDown(0))
                {
                    _audioS = selection.GetComponent<AudioSource>();
                    _openDoor = selection.GetComponent<Animator>();
                    _openDoor.Play("253DoorOpen", 0, 0.0f);
                    _audioS.Play();
                }
            }
            else if (selection.CompareTag(selectableTagCraft))
            {
                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Healing Pack";
                if (Input.GetMouseButtonDown(0))
                {
                    playerStats.Health = playerStats.Health + 10;
                }
            }
            else if (selection.CompareTag(selectableTagCWaterMachine))
            {
                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Water Machine";
            }
            else if (selection.CompareTag(selectableTagToilet))
            {
                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Toilet";
                if (Input.GetMouseButtonDown(0))
                {
                    playerStats.Bladder = playerStats.Bladder + 50.0f;
                    playerStats.Hygiene = playerStats.Hygiene - 20.0f;
                }
            }
            else if (selection.CompareTag(selectableTagShower))
            {
                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Take Shower";
                if (Input.GetMouseButtonDown(0))
                {
                    playerStats.Hygiene = playerStats.Hygiene + 50.0f;
                }
            }
            else if (selection.CompareTag(selectableTagHandWasher))
            {
                itemText.SetActive(true);
                crossHair.color = Color.red;
                itemNameText.text = "Wash Hands";
                if (Input.GetMouseButtonDown(0))
                {
                    playerStats.Hygiene = playerStats.Hygiene + 5.0f;
                }
            }


            else
            {
                crossHair.color = Color.cyan;
                itemText.SetActive(false);
            }
        }

        else
        {
            crossHair.color = Color.cyan;
            itemText.SetActive(false);
        }
    }

}
