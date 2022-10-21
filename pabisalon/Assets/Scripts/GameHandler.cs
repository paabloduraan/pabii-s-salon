using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      private GameObject player;
      public Image puffs;
      public Image braids;
      public Image ponytails;
      public Image straight;
      public Image punk;
      public Image mustache;
      public Image natural;
      public Image shaved;
      public GameObject hairScroll;
      public GameObject colorScroll;

      private string sceneName;

//prompt variables
	public static string currentPrompt;
	public static int currentPromptNum;
	public static int PromptNum1=100;
	public static int PromptNum2=100;
	public static int PromptNum3=100;
	public GameObject promptDisplayText;
	public GameObject promptDisplayBubble;
	public string [] thePrompts = {
			"I just got admitted to Tufts", 
			"my quincenera is tomorrow", 
			"I'm going to arkansas",
			"I at a donut",
			"Staying at home and crying"
			};
	
	public static int currentHair;
	public static Color currentHairColor = new Color(0,0,0,1);
	
	
	public void Start(){
		DisplayPrompt();
		if (currentHair > 0){
			DisplayCurrentHair();
		}
		
	}

	public void DisplayPrompt(){
		Text displayPromptTextTemp = promptDisplayText.GetComponent<Text>();
        displayPromptTextTemp.text = "" + currentPrompt;
		if (displayPromptTextTemp.text == ""){
			promptDisplayBubble.SetActive(false);
		} else {promptDisplayBubble.SetActive(true);}
	}
	
	//button function to get a new prompt
	public void GimmePrompt(){
		currentPromptNum = Random.Range(0, thePrompts.Length -1);
		if ((currentPromptNum != PromptNum1)&&(currentPromptNum != PromptNum2)&&(currentPromptNum != PromptNum3)){
			currentPrompt = thePrompts[currentPromptNum];
			if (PromptNum1 == 100){PromptNum1 = currentPromptNum;}
			else if (PromptNum2 == 100){PromptNum2 = currentPromptNum;}
			else if (PromptNum3 == 100){PromptNum3 = currentPromptNum;}
			else {Debug.Log("You only get three chance.");}
		} else {
			GimmePrompt();
		}
		DisplayPrompt();
	}

      public void StartGame() {
            SceneManager.LoadScene("New_Salon");
      }

      public void GameInfo() {
            SceneManager.LoadScene("Questions");
      }

      public void Info2Start() {
            SceneManager.LoadScene("MainMenu");
      }

      public void StyleMe() {
            SceneManager.LoadScene("StyleRoom");
      }

      public void Hairstyle_Button() {
          if (colorScroll.activeSelf) {
              colorScroll.SetActive(false);
          }

          if (hairScroll.activeSelf) {
              hairScroll.SetActive(false);
          }
          else {
              hairScroll.SetActive(true);
          }
      }

      public void Color_Button() {
          if (hairScroll.activeSelf) {
              hairScroll.SetActive(false);
          }

          if (colorScroll.activeSelf) {
              colorScroll.SetActive(false);
          }
          else {
              colorScroll.SetActive(true);
          }

      }

	public void DisplayCurrentHair(){
		if (currentHair == 1){Puffs();}
		else if (currentHair == 2){Braids();}
		else if (currentHair == 3){Ponytails();}
		else if (currentHair == 4){Straight();}
		else if (currentHair == 5){Punk();}
		else if (currentHair == 6){Mustache();}
		else if (currentHair == 7){Puffs();}
		else if (currentHair == 6){Natural();}
		else if (currentHair == 7){Shaved();}
	}

      public void AllFalse() {
          puffs.enabled = false;
          braids.enabled = false;
          ponytails.enabled = false;
          straight.enabled = false;
          punk.enabled = false;
          mustache.enabled = false;
          natural.enabled = false;
          shaved.enabled = false;
      }

      public void Puffs() {
            AllFalse();
            puffs.enabled = !puffs.enabled;
			puffs.color = currentHairColor;
			currentHair = 1;
      }

      public void Braids() {
            AllFalse();
            braids.enabled = !braids.enabled;
			currentHair = 2;
      }

      public void Ponytails() {
            AllFalse();
            ponytails.enabled = !ponytails.enabled;
			currentHair = 3;
      }

      public void Straight() {
            AllFalse();
            straight.enabled = !straight.enabled;
			currentHair = 4;
      }

      public void Punk() {
            AllFalse();
            punk.enabled = !punk.enabled;
			currentHair = 5;
      }

      public void Mustache() {
            AllFalse();
            mustache.enabled = !mustache.enabled;
			currentHair = 6;
      }

      public void Natural() {
            AllFalse();
            natural.enabled = !natural.enabled;
			currentHair = 7;
      }

      public void Shaved() {
            AllFalse();
            shaved.enabled = !shaved.enabled;
			currentHair = 8;
      }
}
