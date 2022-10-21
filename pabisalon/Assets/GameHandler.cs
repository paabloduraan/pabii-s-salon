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
      public GameObject myScrollRect;

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

      public void Hairstyle_Button() {
          if (myScrollRect.activeSelf) {
              myScrollRect.SetActive(false);
          }
          else {
              myScrollRect.SetActive(true);
          }

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
      }

      public void Braids() {
            AllFalse();
            braids.enabled = !braids.enabled;
      }

      public void Ponytails() {
            AllFalse();
            ponytails.enabled = !ponytails.enabled;
      }

      public void Straight() {
            AllFalse();
            straight.enabled = !straight.enabled;
      }

      public void Punk() {
            AllFalse();
            punk.enabled = !punk.enabled;
      }

      public void Mustache() {
            AllFalse();
            mustache.enabled = !mustache.enabled;
      }

      public void Natural() {
            AllFalse();
            natural.enabled = !natural.enabled;
      }

      public void Shaved() {
            AllFalse();
            shaved.enabled = !shaved.enabled;
      }
}
