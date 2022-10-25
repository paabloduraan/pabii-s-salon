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
    public GameObject promptDisplayExplanation;
    // public GameOverScreen GameOverScreen;
	private string [] thePrompts = {
			"I just got admitted to Tufts", //0
			"my Quinceñera is tomorrow", //1
			"I'm going to Arkansas", //2
			"I just broke up with my boyfriend", //3
			"I have a job interview", //4
            "It's my wedding tomorrow", //5
            "I'm trying to fit in with friends at Tufts", //6
            "I need to yell at the manager for getting my order wrong", //7
            "I just got dumped", //8
            "My bachelorette party is tomorrow", //9
            "I just got a job teaching at Tufts", //10
            "I am an edm dj", //11
            "I'm going to an Avril Lavigne concert tonight", //12
            "I am going to court for a traffic violation tomorrow", //13
            "I am starring on an episode of toddlers and tiaras tomorrow", //14
            "I lasted 8 weeks on Survivor, the reality TV show", //15
            "I have a movie casting in Los Angeles tomorrow", //16
            "I am a Real Housewife of New Jersey", //17
            "I just declared my major as CS", //18
            "I am TikTok influencer with 22.3k followers", //19
            "I just left the Mormon church", //20
            "I am a transplant infuencer living in the East Village, NYC", //21
            "I'm going to a rave tonight", //22
            "I am meeting my boyfriend's rich parents tomorrow", //23
			"Im a tech bro in SF", //24
            "I am moving to a hippie commune", //25
            "I'm getting coffe with my ex" //26
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
    public static string theResponse = "";
	public int maxRound = 3;
	public static bool newRound = true;
	public GameObject scoreDisplayText;
	public bool endGame = false;

    //game over objects
    public GameObject gameOverTitle;
    public GameObject conditionsTitle;
    public GameObject gameOverScreen;
    public GameObject resetButton;
    // public GameObject restartButton;

	public void Start(){
		DisplayPrompt();
		DisplayScore();
        DisplayExplanation();

        gameOverTitle.SetActive(false);
        conditionsTitle.SetActive(false);
        resetButton.SetActive(false);
        gameOverScreen.SetActive(false);

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
            GameOverScene();
            // resetButton.SetActive(true);
            // restartButton();
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

    public void DisplayExplanation() {
        promptDisplayExplanation.SetActive(true);
        Text displayExplanationTextTemp = promptDisplayExplanation.GetComponent<Text>();
        displayExplanationTextTemp.text = "" + theResponse;
    }

    // public void restartButton() {
    //     gameOverScreen.SetActive(false);
    //     gameOverTitle.SetActive(false);
    //     conditionsTitle.SetActive(false);
    //     theScore = 0;
    //     theRound = 1;
    //     theResponse = "";
    //     newRound = true;
    //     currentHairColorID = 0;
    //     currentHair = 0;
    //     endGame = false;
    //     Start();
    //
    // }

    public void GameOverScene() {
        gameOverScreen.SetActive(true);
        gameOverTitle.SetActive(true);
        conditionsTitle.SetActive(true);
        resetButton.SetActive(true);
        Text gameOverTextTemp = conditionsTitle.GetComponent<Text>();
        if (theScore > 4) {
            gameOverTextTemp.text = "You scored over 4 points- You won!";
            // restartButton();
        } else {
            gameOverTextTemp.text = "You did not get 4 points- You lost!";
            // restartButton();
        }
        // restartButton();


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
      
      public void ColorYellow() {
           //currentHairColor = new Color(2.3f,0.2f,0.2f,1f);
           Color newColor = GameObject.FindWithTag("yellow").GetComponent<Image>().color;
           currentHairColor = newColor;
           AllColor();
           currentHairColorID = 7;
           hasColor = true;
     }
     
     public void ColorOrange() {
          //currentHairColor = new Color(2.3f,0.2f,0.2f,1f);
          Color newColor = GameObject.FindWithTag("orange").GetComponent<Image>().color;
          currentHairColor = newColor;
          AllColor();
          currentHairColorID = 8;
          hasColor = true;
    }


	  //Scoring Round System for 27 options
	  public void Scoring(){
			GetEventButton.SetActive(true);
			ScoreButton.SetActive(false);
			newRound = true;
			theRound += 1;

		//dialogue #1, placeholder results - admitted to tufts
		if (currentPromptNum == 0){
            //hairtest
			if (currentHair == 9){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Success! We add points for messy bun because Tufts students are busy and don't have time to do their hair!";
            }
			//colortest
			if ((currentHairColorID == 4)|| (currentHairColorID == 2)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Success! We add points for messy bun because Tufts students are busy and don't have time to do their hair!";
            }
            else {theResponse = "The client did not like this hairstyle :(  We add points for messy bun because Tufts students are busy and don't have time to do their hair! No points awarded.";}
            //EXPLANATION: we add points for messy bun because tufts students are busy and dont have time
            //to do their hair! points for brown and blue for tufts colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #2, placeholder results -- quince
		if (currentPromptNum == 1){
            //hairtest
			if ((currentHair == 4)||(currentHair == 7)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Success! For quinceneras we add points for natural hair styles with natural colors, such as brown and black!";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Success! For quinceneras we add points for natural hair styles with natural colors, such as brown and black!";
            }
            else {theResponse = "The client did not like this hairstyle :( For quinceneras we add points for natural hair styles with natural colors, such as brown and black! No points awarded.";}
            //explanation: for quincenera we add points for natural hair styles with natural colors, such as brown and black
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

		//dialogue #3, placeholder results -- arkansas
		if (currentPromptNum == 2){
            //hairtest
			if ((currentHair == 4)||(currentHair == 2)||(currentHair == 1)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Success! For Arkansas, we wanted a hometown feel with simple styles and natural colors.";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Success! For Arkansas, we wanted a hometown feel with simple styles and natural colors.";
            }
            else {theResponse = "The client did not like this hairstyle :( For Arkansas, we wanted a hometown feel with simple styles and natural colors. No points awarded.";}
            //explanation: for arkansas we wanted a hometown feel with simple styles and natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

		//dialogue #4, placeholder results -- broke up
		if (currentPromptNum == 3){
            //hairtest
			if ((currentHair == 2)||(currentHair == 7)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Just dumped him? No sweat off your back! Go for something elegant and beautiful, like braids or rock your natural texture!";
            }

			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Just dumped him? No sweat off your back! Go for something elegant and beautiful, like braids or rock your natural texture!";
            }
            else {theResponse = "The client did not like this hairstyle :( Since you just dumped him, go for something elegant and beautiful, like braids or rock your natural texture! No points awarded.";}
            //eplanation: just dumped him? no sweat off your back! go for something elegant and beautiful, like
            // long braids or rock your natural texture!
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}


		//dialogue #5, placeholder results -- job interview
		if (currentPromptNum == 4){
            //hairtest
			if ((currentHair == 1)||(currentHair == 3)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Nice job! Job interviews require a professional, natural look.";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Nice job! Job interviews require a professional, natural look.";
            }
            else {theResponse = "The client did not like this hairstyle :( Job interviews require a professional, natural look. No points awarded.";}
            //job interviews require a professional, natural look. we reccomend your hair out of your face and not too brightly colored
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

		//dialogue #6, placeholder results -- wedding
		if (currentPromptNum == 5){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Nice! For a wedding, we add points for natural styles and colors.";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Nice! For a wedding, we add points for natural styles and colors.";
            }
            else {theResponse = "The client did not like this hairstyle :( For a wedding, we add points for natural styles and colors. No points awarded.";}
            //for a wedding we add points for natural styles in natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

		//dialogue #7, placeholder results -- tufts
		if (currentPromptNum == 6){
            //hairtest
			if ((currentHair == 5)||(currentHair == 10)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Tufts students love to be creative! We reward bright colors and bold styles!";
            }
			//colortest
			if ((currentHairColorID == 1)||(currentHairColorID == 2) ||(currentHairColorID == 3)||(currentHairColorID == 5)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Tufts students love to be creative! We reward bright colors and bold styles!";
            }
            else {theResponse = "The client did not like this hairstyle :( Tufts students love to be creative so we reward bright colors and bold styles! No points awarded.";}
            //tufts students love to be creative! we reward bright colors and bold styles, try something new like bangs!
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

		//dialogue #8, placeholder results -- karen
		if (currentPromptNum == 7){
            //hairtest
			if ((currentHair == 11)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Yelling at the manager? There's only one hairstyle we can think of...";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 7)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Yelling at the manager? There's only one hairstyle we can think of...";
            }
            else {theResponse = "The client did not like this hairstyle :( Yelling at the manager? There's only one hairstyle we can think of... No points awarded.";}
            //yelling at the manager? there's only one hairstyle we can think of
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

		//dialogue #9, placeholder results -- dumped
		if (currentPromptNum == 8){
            //hairtest
            if ((currentHair == 5)||(currentHair == 8)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Just got dumped? Switch it up with an edgy, colorful look! Nice work!";
            }
            //colortest
            if ((currentHairColorID == 1)||(currentHairColorID == 2) ||(currentHairColorID == 3)||(currentHairColorID == 7)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Just got dumped? Switch it up with an edgy, colorful look! Nice work!";
            }
            else {theResponse = "The client did not like this hairstyle :( Just got dumped? Switch it up with an edgy, colorful look! No points awarded.";}
            //eplanation: just got dumped? switch it up with an edgy, colorful look!

			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

        //dialogue #10, placeholder results -- bach
		if (currentPromptNum == 9){
			//hairtest
			if ((currentHair == 1)||(currentHair == 3)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Nice! Barchelorette parties call for some spink! Go for a cool updo and a fun color to celebrate!";
            }
			//colortest
			if ((currentHairColorID == 2)||(currentHairColorID == 1)||(currentHairColorID == 3)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Nice! Barchelorette parties call for some spink! Go for a cool updo and a fun color to celebrate!";
            }
            else {theResponse = "The client did not like this hairstyle :( Barchelorette parties call for some spink! Next time, go for a cool updo and a fun color to celebrate! No points awarded.";}
            //bachelorette parties call for some spunk! go for a cool updo and a fun color to celebrate!
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

		//dialogue #11, placeholder results -- job at tufts
		if (currentPromptNum == 10){
            //hairtest
			if ((currentHair == 6)||(currentHair == 11)||(currentHair == 1)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Nice! A new job requires a professional look, but you still gotta rep those Tufts colors!";
            }
			//colortest
			if ((currentHairColorID == 2)||(currentHairColorID == 4)||(currentHairColorID == 5)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Nice! A new job requires a professional look, but you still gotta rep those Tufts colors!";
            }
            else {theResponse = "The client did not like this hairstyle :( A new job requires a professional look, but you still gotta rep those Tufts colors! No points awarded.";}
            // a new job requires a professional look, but you still gotta rep those tufts colors!
            // try a short hair style in brown or blue!
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

		//dialogue #12, placeholder results -- edm dj
		if (currentPromptNum == 11){
            //hairtest
			if ((currentHair == 3)||(currentHair == 1)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Good thinking. An EDM DJ needs to be bold! Go for a fun updo and a bold color.";
            }
			//colortest
            if ((currentHairColorID == 3)||(currentHairColorID == 5)||(currentHairColorID == 2)||(currentHairColorID == 1)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Good thinking. An EDM DJ needs to be bold! Go for a fun updo and a bold color.";
            }
            else {theResponse = "The client did not like this hairstyle :( An EDM DJ needs to be bold! Go for a fun updo and a bold color. No points awarded.";}

            //an edm DJ needs to be bold! go for a fun updo and a bold color
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}


		//dialogue #13, placeholder results -- avril
		if (currentPromptNum == 12){
            //hairtest
			if ((currentHair == 5)||(currentHair == 4)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Yes! An Avril concert calls for nothing less than the boldest!";
            }
			//colortest
			if ((currentHairColorID == 1)||(currentHairColorID == 6)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Yes! An Avril concert calls for nothing less than the boldest!";
            }
            else {theResponse = "The client did not like this hairstyle :( An Avril concert calls for nothing less than the boldest! No points awarded.";}
            //an avril concert calls for nothing less than the boldest!
            //her signature red highlights should influence your look
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #14, placeholder results -- traffic
		if (currentPromptNum == 13){
            //hairtest
			if ((currentHair == 6)||(currentHair == 3)||(currentHair == 1)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Going to court needs something professional and subtle. An updo or short hair with natural colors is great.";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Going to court needs something professional and subtle. An updo or short hair with natural colors is great.";
            }
            else {theResponse = "The client did not like this hairstyle :( Going to court needs something professional and subtle. Try and updo or short hair with natural colors. No points awarded.";}
            //going to court needs something professional and subtle. try an updo or short hair with natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #15, placeholder results -- toddlers
		if (currentPromptNum == 14){
            //hairtest
			if ((currentHair == 3)||(currentHair == 1)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Yup, Toddlers and Tiaras needs some drama! Go for a dramatic updo, but keep the colors natural";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Yup, Toddlers and Tiaras needs some drama! Go for a dramatic updo, but keep the colors natural";
            }
            else {theResponse = "The client did not like this hairstyle :( Toddlers and Tiaras needs some drama! Go for a dramatic updo, but keep the colors natural. No points awarded.";}
            //toddlers and tiaras needs some drama! go for a dramatic updo but keep the colors natural
            //for that pageant girl look
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #16, placeholder results -- survivor
		if (currentPromptNum == 15){
            //hairtest
			if ((currentHair == 1)||(currentHair == 9)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Just got back from Survivor? We are assuming your hair is as messy as it gets...";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Just got back from Survivor? We are assuming your hair is as messy as it gets...";
            }
            else {theResponse = "The client did not like this hairstyle :( Just got back from Survivor? We are assuming your hair is as messy as it gets... No points awarded.";}
            //just got back from survivor? we are assuming your hair is probably just thrown into a bun and you didn't dye it
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #17, placeholder results -- la
		if (currentPromptNum == 16){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Amazing, A movie casting in LA is all about the glamour! Keep the hair down and elegant!";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Amazing, A movie casting in LA is all about the glamour! Keep the hair down and elegant!";
            }
            else {theResponse = "The client did not like this hairstyle :( A movie casting in LA is all about the glamour! Keep the hair down and elegant! No points awarded.";}
            // a movie casting in LA is all about the glamour! keep the hair down and elegant with a natural color
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #18, placeholder results - nj
		if (currentPromptNum == 17){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)||(currentHair == 11)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "The Real Housewives keep it classy, but we know there are some Karen's in the mix...";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "The Real Housewives keep it classy, but we know there are some Karen's in the mix...";
            }
            else {theResponse = "The client did not like this hairstyle :( The Real Housewives keep it classy, but we know there are some Karen's in the mix...No points awarded.";}

            //the real Housevies keep it classy, but we know there are some Karen's in the mix...
            //opt for hair staying down rather than up and some natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #19, placeholder results -- cs
		if (currentPromptNum == 18){
            //hairtest
			if ((currentHair == 3)||(currentHair == 9)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "CS Majors are always on the go! Opt for hair up!";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "CS Majors are always on the go! Opt for hair up with natural colors!";
            }
            else {theResponse = "The client did not like this hairstyle :( CS Majors are always on the go! Opt for hair up with natural colors! No points awared.";}
            // cs majors are always on the go! opt for hair up with natural colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #20, placeholder results -- tiktok
		if (currentPromptNum == 19){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "The influencer life is glamourous! Keeping your hair down with a fun color to engage your audience is ideal!";
            }
			//colortest
			if ((currentHairColorID == 3)||(currentHairColorID == 5)||(currentHairColorID == 2)||(currentHairColorID == 1)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "The influencer life is glamourous! Keeping your hair down with a fun color to engage your audience is ideal!";
            }
            else {theResponse = "The client did not like this hairstyle :( The influencer life is glamourous! Keeping your hair down with a fun color to engage your audience is ideal. No points awared.";}
            //the influencer life is glamourous! keep your hair down but go for a fun color to engage your audience
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}


		//dialogue #21, placeholder results -- mormon church
		if (currentPromptNum == 20){
            //hairtest
			if ((currentHair == 2)||(currentHair == 10)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Yup, the mormons like to keep it modest. Something reserved in color and style is a good style choice.";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Yup, the mormons like to keep it modest. Something reserved in color and style is a good style choice.";
            }
            else {theResponse = "The client did not like this hairstyle :(The mormons like to keep it modest, so something reserved in color and style is a good style choice. No points awared.";}
            //the mormons like to keep it modest. go for somehting reserved in color and style
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #22, placeholder results -- influencer
		if (currentPromptNum == 21){
            //hairtest
			if ((currentHair == 5)||(currentHair == 10)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Good idea going for something bold and spunky to capture your audience's attention!";
            }
			//colortest
            if ((currentHairColorID == 3)||(currentHairColorID == 5)||(currentHairColorID == 2)||(currentHairColorID == 1)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Good idea going for something bold and spunky to capture your audience's attention!";
            }
            else {theResponse = "The client did not like this hairstyle :( Go for something bold and spunky to capture your audience's attention! No points awared.";}
            //go for something bold and spunky to capture your audience's attention
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #23, placeholder results -- rave
		if (currentPromptNum == 22){
            //hairtest
			if ((currentHair == 5)||(currentHair == 8)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Amazing! At a rave you gotta bring out the spunk! An edgy look with a bold color looks rad!";

            }
			//colortest
            if ((currentHairColorID == 3)||(currentHairColorID == 5)||(currentHairColorID == 2)||(currentHairColorID == 1)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Amazing! At a rave you gotta bring out the spunk! An edgy look with a bold color looks rad!";
            }

            else {theResponse = "The client did not like this hairstyle :( At a rave you gotta bring the spunk! Go for for somethinge edgy with a bold color. No points awared.";}
            //at a rave you gotta bring the spunk! gor for somethinge edgy with a bold color
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #24, placeholder results -- boyfriends parents
		if (currentPromptNum == 23){
            //hairtest
			if ((currentHair == 2)||(currentHair == 4)||(currentHair == 7)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Great! Your boyfriend's parents are probably hoping to see something wholesome and sweet, like braids or just hair down with a natural color.";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Great! Your boyfriend's parents are probably hoping to see something wholesome and sweet, like braids or just hair down with a natural color.";
            }
            else {theResponse = "The client did not like this hairstyle :( Your boyfriend's parents are probably hoping to see something wholesome and sweet, like braids or just hair down with a natural color. No points awared.";}
            //your boyfriend's parents are probably hoping to see something
            //wholesome and sweet. stick to a wholesome feel with some long
            //braids or just hair down and a natural color
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #25, placeholder results -- tech bro
		if (currentPromptNum == 24){
            //hairtest
			if ((currentHair == 6)||(currentHair == 8)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Yes! Tech bros in SF have a signature look: nothing too out of the box. Sticking to shorter hair and neutral colors is a great choice!";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Yes! Tech bros in SF have a signature look: nothing too out of the box. Sticking to shorter hair and neutral colors is a great choice!";
            }
            else {theResponse = "The client did not like this hairstyle :( Tech bros in SF have a signature look, nothing too out of the box. Stick to shorter hair and neutral colors. No points awared.";}
            //tech bros in SF have a signature look, nothing too out of the box
            //stick to shorter hair and neutral colors
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #26, placeholder results -- hippie commune
		if (currentPromptNum == 25){
            //hairtest
			if ((currentHair == 7)||(currentHair == 4)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Amazing! Hippies are all about freedom! Let your hair down and stick to a natural color for that earthy look.";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Amazing! Hippies are all about freedom! Let your hair down and stick to a natural color for that earthy look.";
            }
            else {theResponse = "The client did not like this hairstyle :( Hippies are all about freedom! Let your hair down and stick to a natural color for that earthy look. No points awarded.";}
            //hippies are all about freedom! let your hair down and stick to a natural color for that earthy look
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();

		}

		//dialogue #27, placeholder results -- coffee
		if (currentPromptNum == 26){
            //hairtest
			if ((currentHair == 10)||(currentHair == 3)){
                theScore +=1; Debug.Log("+1 for hair #" + currentHair);
                theResponse = "Success! Coffee with an ex is the perfect opportunity for something that will make you feel confident, like some bold bangs or cute pigtails! A natural color looks great too.";
            }
			//colortest
			if ((currentHairColorID == 4)||(currentHairColorID == 6)||(currentHairColorID == 7)||(currentHairColorID == 8)){
                theScore +=1; Debug.Log("+1 for color #" + currentHairColorID);
                theResponse = "Success! Coffee with an ex is the perfect opportunity for something that will make you feel confident, like some bold bangs or cute pigtails! A natural color looks great too.";
            }
            else {theResponse = "The client did not like this hairstyle :( Coffee with an ex is the perfect opportunity for something that will make you feel confident, like some bold bangs or cute pigtails! No points awarded.";}
            //coffee with an ex? go for something that will make you feel confident
            //like some bold bangs or some cute ponytails! a natural color will work great
			//accessory test
			//if ((CurrentAccessory==1)||(CurrentAccessory==2)){theScore +=1; Debug.Log("+1 for accessory #" + CurrentAccessory);} else {theScore -=1;}
			DisplayScore();
            DisplayExplanation();
		}

	  }


}
