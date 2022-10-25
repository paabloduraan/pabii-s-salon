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
      public Image messyBun;
      public Image bangs;
      public Image pixie;

      public GameObject hairScroll;
      public GameObject colorScroll;
	  //public GameObject accessoriesScroll;

	public GameObject ButtonNewPrompt;
	public GameObject ButtonStyleDone;
	private bool hasHair = false;
	private bool hasColor = false;
	private bool hasAccessory = false;

      private string sceneName;


//prompt variables
	public static string currentPrompt;
	public static int currentPromptNum;
	public static int PromptNum1=100;
	public static int PromptNum2=100;
	public static int PromptNum3=100;
	public GameObject promptDisplayText;
	public GameObject promptDisplayBubble;
	private string [] thePrompts = {
			"I just got admitted to Tufts",
			"my Quince˜nera is tomorrow",
			"I'm going to arkansas",
			"I just broke up with my boyfriend",
			"I have a job interview",
            "It's my wedding tomorrow",
            "I'm trying to fit in with friends at Tufts",
            "I need to yell at the manager for getting my order wrong",
            "I just got dumped",
            "My bachelorette party is tomorrow",
            "I just got a job teaching at Tufts",
            "I'm going to an Avril Lavigne concert tonight",
            "I am going to court for a traffic violation tomorrow",
            "I am starring on an episode of toddlers and tiaras tomorrow",
            "I lasted 8 weeks on Survivor, the reality TV show",
            "I have a movie casting in Los Angeles tomorrow",
            "I am a Real Housewife of New Jersey",
            "I just declared my major as CS",
            "I am TikTok influencer with 22.3k followers",
            "I just left the Mormon church",
            "I am a transplant infuencer living in the East Village, NYC",
            "I'm going to a rave tonight",
            "I am meeting my boyfriend's rich parents tomorrow",
            "I am an edm dj",
			"Im a tech bro in SF",
            "I am moving to a hippie commune",
            "I'm getting coffe with my ex"
			};

	//style variables
	public static int currentHair = 0;
	public static Color currentHairColor = new Color(0,0,0,1);
	public static int currentHairColorID = 0;
	public static int CurrentAccessory = 0;

	//score variables
	public GameObject ScoreButton;
	public GameObject GetEventButton;
	public static bool hasStyled = false;
	public static int theScore = 0;
	public static int theRound = 1;
	public int maxRound = 5;
	public static bool newRound = true;
	public GameObject scoreDisplayText;
	public bool endGame = false;

	public void Start(){
		DisplayPrompt();
		DisplayScore();
		if (currentHair > 0){DisplayCurrentHair();}
		if (newRound){
			GetEventButton.SetActive(true);
			ScoreButton.SetActive(false);
			}
		else {
			GetEventButton.SetActive(false);
			ScoreButton.SetActive(true);
		}
		hasHair = false;
		hasColor = false;
		hasAccessory = false;
	}

	public void Update(){

		//if sceneName = styleme, if all 3 styles have been clicked, display done
		if (SceneManager.GetActiveScene().name == "StyleRoom"){
			//if ((hasHair)&&(hasColor)&&(hasAccessory)){
			if ((hasHair)&&(hasColor)){
				ButtonStyleDone.SetActive(true);
			}
			else{
				ButtonStyleDone.SetActive(false);
			}
		}

		//endgame:
		if (endGame){
			//show final tally scripts go here
			GetEventButton.SetActive(false);
			ScoreButton.SetActive(false);
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
		GetEventButton.SetActive(false);
		newRound = false;
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

	public void DisplayScore(){
		if (theRound > maxRound) {theRound = maxRound; endGame=true;}
		Text displayScoreTextTemp = scoreDisplayText.GetComponent<Text>();
        displayScoreTextTemp.text = "ROUND: " + theRound + ", SCORE: " + theScore;
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
		AllColor();
		if (currentHair == 1){Puffs();}
		else if (currentHair == 2){Braids();}
		else if (currentHair == 3){Ponytails();}
		else if (currentHair == 4){Straight();}
		else if (currentHair == 5){Punk();}
		else if (currentHair == 6){Mustache();}
		else if (currentHair == 7){Natural();}
		else if (currentHair == 8){Shaved();}
        else if (currentHair == 9){MessyBun();}
        else if (currentHair == 10){Bangs();}
        else if (currentHair == 11){Pixie();}
	}

//hair style button functions

      public void AllFalse() {
          puffs.enabled = false;
          braids.enabled = false;
          ponytails.enabled = false;
          straight.enabled = false;
          punk.enabled = false;
          mustache.enabled = false;
          natural.enabled = false;
          shaved.enabled = false;
          messyBun.enabled = false;
          bangs.enabled = false;
          pixie.enabled = false;
      }

      public void Puffs() {
            AllFalse();
            puffs.enabled = !puffs.enabled;
			//puffs.color = currentHairColor;
			currentHair = 1;
			hasHair = true;
      }

      public void Braids() {
            AllFalse();
            braids.enabled = !braids.enabled;
			//braids.color = currentHairColor;
			currentHair = 2;
			hasHair = true;
      }

      public void Ponytails() {
            AllFalse();
            ponytails.enabled = !ponytails.enabled;
			//Ponytail.color = currentHairColor;
			currentHair = 3;
			hasHair = true;
      }

      public void Straight() {
            AllFalse();
            straight.enabled = !straight.enabled;
			//Straight.color = currentHairColor;
			currentHair = 4;
			hasHair = true;
      }

      public void Punk() {
            AllFalse();
            punk.enabled = !punk.enabled;
			//Punk.color = currentHairColor;
			currentHair = 5;
			hasHair = true;
      }

      public void Mustache() {
            AllFalse();
            mustache.enabled = !mustache.enabled;
			//Mustache.color = currentHairColor;
			currentHair = 6;
			hasHair = true;
      }

      public void Natural() {
            AllFalse();
            natural.enabled = !natural.enabled;
			//Natural.color = currentHairColor;
			currentHair = 7;
			hasHair = true;
      }

      public void Shaved() {
            AllFalse();
            shaved.enabled = !shaved.enabled;
			//Shaved.color = currentHairColor;
			currentHair = 8;
			hasHair = true;
      }

      public void MessyBun() {
            AllFalse();
            messyBun.enabled = !messyBun.enabled;
			//messyBun.color = currentHairColor;
			currentHair = 9;
			hasHair = true;

      }

      public void Bangs() {
            AllFalse();
            bangs.enabled = !bangs.enabled;
			//bangs.color = currentHairColor;
			currentHair = 10;
			hasHair = true;
      }

      public void Pixie() {
            AllFalse();
            pixie.enabled = !pixie.enabled;
			//pixie.color = currentHairColor;
			currentHair = 11;
			hasHair = true;
      }

// hair color functions
      public void AllColor() {
          puffs.color = currentHairColor;
          braids.color = currentHairColor;
          ponytails.color = currentHairColor;
          straight.color = currentHairColor;
          punk.color = currentHairColor;
          mustache.color = currentHairColor;
          natural.color = currentHairColor;
          shaved.color = currentHairColor;
          messyBun.color = currentHairColor;
          bangs.color = currentHairColor;
          pixie.color = currentHairColor;
      }


	   public void ColorRed() {
			//currentHairColor = new Color(2.3f,0.2f,0.2f,1f);
			Color newColor = GameObject.FindWithTag("red").GetComponent<Image>().color;
			currentHairColor = newColor;
			AllColor();
			currentHairColorID = 1;
			hasColor = true;
      }

		public void ColorBlue() {
			//currentHairColor = new Color(0.2f,0.4f,2.4f,1f);
			Color newColor = GameObject.FindWithTag("blue").GetComponent<Image>().color;
			currentHairColor = newColor;
			AllColor();
			currentHairColorID = 2;
			hasColor = true;
      }

	  public void ColorGreen() {
			//currentHairColor = new Color(0f,1.6f,0.2f,1f);
			Color newColor = GameObject.FindWithTag("green").GetComponent<Image>().color;
			currentHairColor = newColor;
			AllColor();
			currentHairColorID = 3;
			hasColor = true;
      }

		public void ColorBrown() {
			//currentHairColor = new Color(1f,0.7f,0.3f,1f);
			Color newColor = GameObject.FindWithTag("brown").GetComponent<Image>().color;
			currentHairColor = newColor;
			AllColor();
			currentHairColorID = 4;
			hasColor = true;
      }

		public void ColorWhite() {
			//currentHairColor = new Color(2.5f, 2.5f, 2.5f,1f);
			Color newColor = GameObject.FindWithTag("white").GetComponent<Image>().color;
			currentHairColor = newColor;
			AllColor();
			currentHairColorID = 5;
			hasColor = true;
      }

		public void ColorBlack() {
			//currentHairColor = new Color(0f,0f, 0f,1f);
			Color newColor = GameObject.FindWithTag("black").GetComponent<Image>().color;
			currentHairColor = newColor;
			AllColor();
			currentHairColorID = 6;
			hasColor = true;
      }


	  //Scoring Round System for 27 options
	  public void Scoring(){
			GetEventButton.SetActive(true);
			ScoreButton.SetActive(false);
			newRound = true;
			theRound += 1;

		//dialogue #1, placeholder results
		if (currentPromptNum == 0){
            //hairtest
			if (currentHair == 9){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)|| (currentHairColorID == 2)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //EXPLANATION: we add points for messy bun because tufts students are busy and dont have time
            //to do their hair! points for brown and blue for tufts colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #2, placeholder results
		if (currentPromptNum == 1){
            //hairtest
			if ((currentHair == 4)||(currentHair == 7)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //explanation: for quincenera we add points for natural hair styles with natural colors, such as brown and black
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #3, placeholder results
		if (currentPromptNum == 2){
            //hairtest
			if ((currentHair == 4)||(currentHair == 2)||(currentHair == 1)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //explanation: for arkansas we wanted a hometown feel with simple styles and natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #4, placeholder results
		if (currentPromptNum == 3){
            //hairtest
			if ((currentHair == 2)||(currentHair == 7)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //eplanation: just dumped him? no sweat off your back! go for something elegant and beautiful, like
            // long braids or rock your natural texture!
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}


		//dialogue #5, placeholder results
		if (currentPromptNum == 4){
            //hairtest
			if ((currentHair == 1)||(currentHair == 3)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //job interviews require a professional, natural look. we reccomend your hair out of your face and not too brightly colored
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #6, placeholder results
		if (currentPromptNum == 5){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 3)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //for a wedding we add points for natural styles in natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #7, placeholder results
		if (currentPromptNum == 6){
            //hairtest
			if ((currentHair == 5)||(currentHair == 10)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 1)||(currentHairColorID == 2) ||(currentHairColorID == 3)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //tufts students love to be creative! we reward bright colors and bold styles, try something new like bangs!
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #8, placeholder results
		if (currentPromptNum == 7){
            //hairtest
			if ((currentHair == 11)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //yelling at the manager? there's only one hairstyle we can think of
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #9, placeholder results
		if (currentPromptNum == 8){
            //hairtest
            if ((currentHair == 5)||(currentHair == 8)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
            //colortest
            if ((currentHairColorID == 1)||(currentHairColorID == 2) ||(currentHairColorID == 3)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //eplanation: just got dumped? switch it up with an edgy, colorful look!

			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

        //dialogue #10, placeholder results
		if (currentPromptNum == 9){
			//hairtest
			if ((currentHair == 1)||(currentHair == 3)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 2)||(currentHairColorID == 1)||(currentHairColorID == 3)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //bachelorette parties call for some spunk! go for a cool updo and a fun color to celebrate!
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #11, placeholder results
		if (currentPromptNum == 10){
            //hairtest
			if ((currentHair == 6)||(currentHair == 11)||(currentHair == 1)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 2)||(currentHairColorID == 4)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            // a new job requires a professional look, but you still gotta rep those tufts colors!
            // try a short hair style in brown or blue!
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #12, placeholder results
		if (currentPromptNum == 11){
            //hairtest
			if ((currentHair == 3)||(currentHair == 1)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
            if ((currentHairColorID == 3)||(currentHairColorID == 5)||(currentHairColorID == 2)||(currentHairColorID == 1)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}

            //an edm DJ needs to be bold! go for a fun updo and a bold color
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}


		//dialogue #13, placeholder results
		if (currentPromptNum == 12){
            //hairtest
			if ((currentHair == 5)||(currentHair == 4)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 1)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //an avril concert calls for nothing less than the boldest!
            //her signature red highlights should influence your look
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #14, placeholder results
		if (currentPromptNum == 13){
            //hairtest
			if ((currentHair == 6)||(currentHair == 3)||(currentHair == 1)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //going to court needs something professional and subtle. try an updo or short hair with natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #15, placeholder results
		if (currentPromptNum == 14){
            //hairtest
			if ((currentHair == 3)||(currentHair == 1)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //toddlers and tiaras needs some drama! go for a dramatic updo but keep the colors natural
            //for that pageant girl look
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #16, placeholder results
		if (currentPromptNum == 15){
            //hairtest
			if ((currentHair == 1)||(currentHair == 9)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //just got back from survivor? we are assuming your hair is probably just thrown into a bun and you didn't dye it
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #17, placeholder results
		if (currentPromptNum == 16){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            // a movie casting in LA is all about the glamour! keep the hair down and elegant with a natural color
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #18, placeholder results
		if (currentPromptNum == 17){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)||(currentHair == 11)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}

            //the real Housevies keep it classy, but we know there are some Karen's in the mix...
            //opt for hair staying down rather than up and some natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #19, placeholder results
		if (currentPromptNum == 18){
            //hairtest
			if ((currentHair == 3)||(currentHair == 9)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            // cs majors are always on the go! opt for hair up with natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #20, placeholder results
		if (currentPromptNum == 19){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 3)||(currentHairColorID == 5)||(currentHairColorID == 2)||(currentHairColorID == 1)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //the influencer life is glamourous! keep your hair down but go for a fun color to engage your audience
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}


		//dialogue #21, placeholder results
		if (currentPromptNum == 20){
            //hairtest
			if ((currentHair == 2)||(currentHair == 10)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //the mormons like to keep it modest. go for somehting reserved in color and style
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #22, placeholder results
		if (currentPromptNum == 21){
            //hairtest
			if ((currentHair == 5)||(currentHair == 10)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
            if ((currentHairColorID == 3)||(currentHairColorID == 5)||(currentHairColorID == 2)||(currentHairColorID == 1)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}

            //go for something bold and spunky to capture your audience's attention
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #23, placeholder results
		if (currentPromptNum == 22){
            //hairtest
			if ((currentHair == 5)||(currentHair == 8)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
            if ((currentHairColorID == 3)||(currentHairColorID == 5)||(currentHairColorID == 2)||(currentHairColorID == 1)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //at a rave you gotta bring the spunk! gor for somethinge edgy with a bold color
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #24, placeholder results
		if (currentPromptNum == 23){
            //hairtest
			if ((currentHair == 2)||(currentHair == 4)||(currentHair == 7)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //your boyfriend's parents are probably hoping to see something
            //wholesome and sweet. stick to a wholesome feel with some long
            //braids or just hair down and a natural color
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #25, placeholder results
		if (currentPromptNum == 24){
            //hairtest
			if ((currentHair == 6)||(currentHair == 8)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //tech bros in SF have a signature look, nothing too out of the box
            //stick to shorter hair and neutral colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #26, placeholder results
		if (currentPromptNum == 25){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //hippies are all about freedom! let your hair down and stick to a natural color for that earthy look
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

		//dialogue #27, placeholder results
		if (currentPromptNum == 26){
            //hairtest
			if ((currentHair == 10)||(currentHair == 3)){theScore +=1; Debug.Log("+1 for hair #" + currentHair);}
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)){theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);}
            //coffee with an ex? go for something that will make you feel confident
            //like some bold bangs or some cute ponytails! a natural color will work great
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
		}

	  }


}
