using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hacker : Player {
    private GameObject HackerProgress;
    private GameObject HackerProgressText;

    private float ProgressMilestone;

    //Sends passive reply if enough time has passed
    void SendPassiveLine() {
        if (Progress() >= ProgressMilestone) {
            //Send random line
            Debug.Log("Random line Lmao");
            ProgressMilestone += 10;
        }
    }

    // Use this for initialization
    void Start () {
        DefaultWinInS = 120;
        ProgressMilestone = 10;
        HackerProgress = GameObject.Find("HackerProgress");
        HackerProgressText = GameObject.Find("HackerProgressText");
        PlayerPortrait = GameObject.Find("HackerPortrait");
        ChangeFace(Face.Normal);
    }
	
	// Update is called once per frame
	void Update () {
        //Draw changes to the UI progress bars
        HackerProgress.transform.localScale = new Vector3((Progress() / 100) * 1, 1, 1);
        Text text = HackerProgressText.GetComponent<Text>();
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
