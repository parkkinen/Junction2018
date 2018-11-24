using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hacker : Player {

    private hakeri Hakeri = new hakeri();

    //Sends passive reply if enough time has passed
    public override void SendPassiveLine() {
        if (Progress() >= ProgressMilestone) {
            Text text = PlayerComment.GetComponent<Text>();
            text.text = Hakeri.ReturnLine(Random.Range(0, 32));
            ProgressMilestone += 10;
        }
    }

    // Use this for initialization
    void Start () {
        DefaultWinInS = 120;
        ProgressMilestone = 10;
        PlayerProgress = GameObject.Find("HackerProgress");
        PlayerProgressText = GameObject.Find("HackerProgressText");
        PlayerPortrait = GameObject.Find("HackerPortrait");
        PlayerComment = GameObject.Find("HackerComment");
        ChangeFace(Face.Normal);
    }
	
	// Update is called once per frame
	void Update () {
        //Draw changes to the UI progress bars
        PlayerProgress.transform.localScale = new Vector3((Progress() / 100) * 1, 1, 1);
        Text text = PlayerProgressText.GetComponent<Text>();
        text.text = "Hack Completed in " + SecondsLeftOnAction() + " seconds!";
        SendPassiveLine();
    }

    public override void ChangeFace(Face face) {
        Animator anim = PlayerPortrait.GetComponent<Animator>();
        switch (face) {
            case Face.Normal:
                anim.Play("HackerNormal");
                break;
            case Face.Stressed:
                anim.Play("HackerStressed");
                break;
            case Face.Surprised:
                anim.Play("HackerSurprised");
                break;
            default:
                break;
        }
    }
}
