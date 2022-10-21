using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameHandler : MonoBehaviour {

      private GameObject player;

      public string textValue ;
      public Text textElement;
      public int rangeStart = 0;
      public int rangeEnd = 3;
      int randomNum;

      public string[] prompts = {"I just got admitted to Tufts", 
                        "my quincenera is tomorrow", "I'm going to arkansas"};
      
      public void get_prompt() {
            randomNum = Random.Range(rangeStart, rangeEnd);
            textValue = prompts[randomNum];
            textElement.text = textValue;
      }
    
      private string sceneName;

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
      
}