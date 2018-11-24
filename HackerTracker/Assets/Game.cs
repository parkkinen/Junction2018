using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
    public enum GameState {
        Menu, Game, HackerWins, ItguyWins
    };

    public GameState state;

    private Hacker HackerObj;
    private Itguy ItguyObj;

    private GameObject HackerProgress;
    private GameObject HackerProgressText;
    private GameObject ItguyProgress;
    private GameObject ItguyProgressText;

    void GameLoop() {
        //Start by adding passive action progress to Hacker and Itguy
        HackerObj.AddDurationProgress();
        ItguyObj.AddDurationProgress();
        //Draw changes to the UI progress bars
        HackerProgress.transform.localScale = new Vector3((HackerObj.Progress() / 100) * 1, 1, 1);
        Text text = HackerProgressText.GetComponent<Text>();
        text.text = "Hack Completed in " + HackerObj.SecondsLeftOnAction() + " seconds!";
        ItguyProgress.transform.localScale = new Vector3((ItguyObj.Progress() / 100) * 1, 1, 1);
        text = ItguyProgressText.GetComponent<Text>();
        text.text = "IP track finished in " + ItguyObj.SecondsLeftOnAction() + " seconds!";
       //Check if either player has won
        if (HackerObj.IsActionFinished()) {
            Debug.Log("Hacker wins!");
            state = GameState.HackerWins;
        }
        else if (ItguyObj.IsActionFinished()) {
            Debug.Log("Itguy wins!");
            state = GameState.ItguyWins;
        }
    }

	// Use this for initialization
	void Start () {
        state = GameState.Game;
        HackerObj = (Hacker)GameObject.Find("Hacker").GetComponent(typeof(Hacker));
        ItguyObj = (Itguy)GameObject.Find("Itguy").GetComponent(typeof(Itguy));
        HackerProgress = GameObject.Find("HackerProgress");
        ItguyProgress = GameObject.Find("ItguyProgress");
        HackerProgressText = GameObject.Find("HackerProgressText");
        ItguyProgressText = GameObject.Find("ItguyProgressText");
    }
	
	// Update is called once per frame
	void Update () {
        switch (state) {
            case GameState.Menu:
                break;
            case GameState.Game:
                GameLoop();
                break;
            case GameState.HackerWins:
                Debug.Log("Hacker Wins");
                break;
            case GameState.ItguyWins:
                Debug.Log("Itguy Wins");
                break;
            default:
                break;
        }
        
	}
}
