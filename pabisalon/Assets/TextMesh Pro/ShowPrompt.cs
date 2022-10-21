using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPrompt : MonoBehaviour
{
    public string textValue;
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
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
