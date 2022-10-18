using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour {

      private GameObject player;

    
      private string sceneName;

      public void StartGame() {
            SceneManager.LoadScene("SampleScene");
      }
      
      public void GameInfo() {
            SceneManager.LoadScene("Questions");
      }
      
      public void Info2Start() {
            SceneManager.LoadScene("MainMenu");
      }
}