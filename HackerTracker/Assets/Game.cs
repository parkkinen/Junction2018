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
    

    void GameLoop() {
        //Start by adding passive action progress to Hacker and Itguy
        HackerObj.AddDurationProgress();
        ItguyObj.AddDurationProgress();
        //Change Player faces based on the progress
        HackerObj.ProgressFace(ItguyObj.Progress());
        ItguyObj.ProgressFace(HackerObj.Progress());
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
        HackerObj.ChangeFace(Player.Face.Normal);
        ItguyObj.ChangeFace(Player.Face.Normal);
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
                HackerObj.ChangeFace(Player.Face.Normal);
                ItguyObj.ChangeFace(Player.Face.Surprised);
                break;
            case GameState.ItguyWins:
                Debug.Log("Itguy Wins");
                HackerObj.ChangeFace(Player.Face.Surprised);
                ItguyObj.ChangeFace(Player.Face.Normal);
                break;
            default:
                break;
        }
        
	}
}
