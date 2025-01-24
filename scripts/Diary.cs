using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
 
    public GameObject Page01; // UI for displaying the note
    public GameObject Page02;
    public GameObject Page03;
    public GameObject Page04;
    public GameObject pickUpText; // Text for displaying "Press X to pick up"
    public AudioSource pickUpSound; // Sound to play on picking up the note
    public bool inReach; // Boolean to check if player is within reach to interact
    public AudioSource Voice;
    public AudioSource PageSound;

     public OneLineSubs OneLineSubs;

    void Start()
    {


        pickUpText.SetActive(false); // Hide the pick-up text initially
        inReach = false; // Initially, player is not in reach

 if (Page01 != null)
        {
            Page01.SetActive(false); // Ensure the hand with item is initially disabled
        }

    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player is within reach to interact
        if (other.CompareTag("Reach"))
        {
            inReach = true;
            pickUpText.SetActive(true); // Show the pick-up text
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the player has left the interaction range
        if (other.CompareTag("Reach"))
        {
            inReach = false;
            pickUpText.SetActive(false); // Hide the pick-up text
        }
    }

    void Update()
    {
        // Check if the player presses the interact button and is within reach (E key)
        if (Input.GetKeyDown(KeyCode.E) && inReach)
        {

            OpenNote();
        }
         if (Input.GetKeyDown(KeyCode.N) )
         {
            if (Page01.activeSelf){
                Page02.SetActive(true);
                PageSound.Play();
                Page01.SetActive(false);
            }
            if (Page02.activeSelf){
                Page03.SetActive(true);
                PageSound.Play();
                Page02.SetActive(false);
            }
            if (Page03.activeSelf){
                Page04.SetActive(true);
                PageSound.Play();
                Page03.SetActive(false);
            }

         }

        // Check if the player presses the V key to exit the note UI
        if (Input.GetKeyDown(KeyCode.V ))
        {
            if (Page01.activeSelf||Page02.activeSelf || Page03.activeSelf || Page04.activeSelf) // Check if note UI is currently active
            {
                ExitButton();
                 if (OneLineSubs != null)
                    {
                        OneLineSubs.StartOneLineSub();
                    }
                if (Voice != null)
                    {
                        Voice.Play();
                    }
            }
        }
    }

    // Function to handle opening the note
    void OpenNote()
    {
         Debug.Log("OpenNote called");
       
 if (Page01 != null)
        {
            Page01.SetActive(true); // Ensure the hand with item is initially disabled
        }

    
        pickUpSound.Play(); // Play the pick-up sound
        
    
    }

    // Function to handle closing the note
    public void ExitButton()
    {
        Page01.SetActive(false); // Hide the note UI
        Page02.SetActive(false); // Hide the note UI
        Page03.SetActive(false); // Hide the note UI
        Page04.SetActive(false); // Hide the note UI

  
    }
}
