using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itguy : Player {

    private kodari Kodari = new kodari();

    //Sends passive reply if enough time has passed
    public override void SendPassiveLine() {
        if (Progress() >= ProgressMilestone) {
            Text text = PlayerComment.GetComponent<Text>();
            text.text = Kodari.ReturnLine(Random.Range(0, 32));
            ProgressMilestone += 10;
        }
    }

    // Use this for initialization
    void Start () {
        DefaultWinInS = 120;
        PlayerPortrait = GameObject.Find("ItguyPortrait");
        PlayerProgressText = GameObject.Find("ItguyProgressText");
        PlayerProgress = GameObject.Find("ItguyProgress");
        PlayerComment = GameObject.Find("ItguyComment");
        ChangeFace(Face.Normal);
    }
	
	// Update is called once per frame
	void Update () {
        PlayerProgress.transform.localScale = new Vector3((Progress() / 100) * 1, 1, 1);
        Text text = PlayerProgressText.GetComponent<Text>();
        text.text = "IP track finished in " + SecondsLeftOnAction() + " seconds!";
        SendPassiveLine();
    }

    public override void ChangeFace(Face face) {
        Animator anim = PlayerPortrait.GetComponent<Animator>();
        switch (face) {
            case Face.Normal:
                anim.Play("ItguyNormal");
                break;
            case Face.Stressed:
                anim.Play("ItguyStressed");
                break;
            case Face.Surprised:
                anim.Play("ItguySurprised");
                break;
            default:
                break;
        }
    }
}
