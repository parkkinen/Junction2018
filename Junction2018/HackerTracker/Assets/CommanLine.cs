using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CommanLine : MonoBehaviour {

    string path;

    public Text Code;

    public Text PopUpText;

    public Text HackName;

    StreamReader reader;

    //public GameObject scrollObject;

    [SerializeField]
    private int pointsUpperLimit;

    [SerializeField]
    private int points;

    public GameObject ThePopUp;
    public RectTransform theCanvas;

    //private GameObject input;

    private Vector3 popupLoc;

    bool solved;
    bool popUpSpawned;

    private string[] hacks = new string[] {"penetrator.exe", "FinnishHorse", "Back Burner", "1337Hackz.exe", "JunctDownIon", "Minecraft.exe",
    "DumpBTC","Sminem.zip", "Bogdanoff.dll", "HDDBomber.std", "wondowsUpdate.exe"};

    private int hackIterator;

    private int chosenHack;

    // Use this for initialization
    void Start () {
		path = "Assets/code.txt";
        reader = new StreamReader(path);
        pointsUpperLimit = Random.Range(80,120);
        points = 0;
        popupLoc = new Vector3(theCanvas.rect.width * theCanvas.localScale.x * 0.2f, theCanvas.rect.height * theCanvas.localScale.y * 0.6f,0);
        solved = false;
        popUpSpawned = false;
        hackIterator = 0;
        Random.InitState(System.DateTime.Now.Millisecond); 
        //ThePopUp.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1) && !Input.GetMouseButtonDown(2)) {
            

            if(points < pointsUpperLimit) {
                WriteCodeToCommandLine();
                points += 1;
            } else if(points >= pointsUpperLimit) {
                HackPopUp();
            }
  
            
        }
	}

    void WriteCodeToCommandLine() {
        for(int i = 0; i < 3; i++) {
            int cInt = reader.Read();
            if(cInt == -1) {
                reader.Close();
                reader = new StreamReader(path);
            }

            char c = (char)cInt;
            Code.text = Code.text + c;

            //Debug.Log(points);
          
            //reader.Close();
            //Debug.Log("paska");
        }
    }

    void HackPopUp() {
        if(popUpSpawned == false && points >= pointsUpperLimit) {
            chosenHack = Random.Range(0,hacks.Length-1);
            //Debug.Log("TYPE PASKA TO SEND VIRUS");
            ThePopUp.SetActive(true);
            popUpSpawned = true;
            HackName.text = hacks[chosenHack];
        }

        if(hackIterator >= hacks[chosenHack].Length-1) {
            popUpSpawned = false;
            solved = true;
            hackIterator = 0;
            points = 0;
            PopUpText.text = "";
            pointsUpperLimit = Random.Range(80,120);
            ThePopUp.SetActive(false);
        } else {
            foreach(char c in Input.inputString) {
                Debug.Log(hacks[chosenHack]);
                if(c == hacks[chosenHack][hackIterator]) {
                    PopUpText.text += c;
                    hackIterator++;
                }

            }
        }

        

        

       // PopUpText.text = PopUpText +;
        //Debug.Log(Input.inputString);

        //input = ThePopUp.Find("InputField").gameObject;
        //input.GetComponent<InputField>().ActivateInputField();
        //input.GetComponent<InputField>().Select();
    }


}


