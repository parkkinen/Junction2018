using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itguy : Player {
    private GameObject ItguyPortrait;
    private GameObject ItguyProgress;
    private GameObject ItguyProgressText;

    // Use this for initialization
    void Start () {
        DefaultWinInS = 5;
        PlayerPortrait = GameObject.Find("ItguyPortrait");
        ItguyProgressText = GameObject.Find("ItguyProgressText");
        ItguyProgress = GameObject.Find("ItguyProgress");
        ChangeFace(Face.Normal);
    }
	
	// Update is called once per frame
	void Update () {
        ItguyProgress.transform.localScale = new Vector3((Progress() / 100) * 1, 1, 1);
        Text text = ItguyProgressText.GetComponent<Text>();
        text.text = "IP track finished in " + SecondsLeftOnAction() + " seconds!";
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
