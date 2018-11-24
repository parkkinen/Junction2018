using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public enum Face {
        Normal, Surprised, Stressed
    };

    public GameObject PlayerPortrait;

    protected float DefaultWinInS = 120;

    private float ActionProgress = 0;


    public int SecondsLeftOnAction() {
        return (int)(DefaultWinInS - DefaultWinInS * (ActionProgress / 100));
    }

    public bool IsActionFinished() {
        if (ActionProgress >= 100)
            return true;
        return false;
    }

    public void AddProgress(float progress) {
        ActionProgress = progress;
    }

    public float Progress() {
        return ActionProgress;
    }
	
	public void AddDurationProgress() {
        ActionProgress += (100 / DefaultWinInS) * Time.deltaTime;
    }

    private float LastProgress = 0;

    public void ProgressFace(float prog) {
        if (prog >= 30 && prog < 70) {
            if (LastProgress < 30) {
                ChangeFace(Face.Surprised);
                LastProgress = prog;
            }
        }
        else if (prog >= 70) {
            if (LastProgress < 70) {
                ChangeFace(Face.Stressed);
                LastProgress = prog;
            }
        }
    }

    public virtual void ChangeFace(Face face) {
        Debug.Log("Unimplemented ChangeFace()");
    }
}
