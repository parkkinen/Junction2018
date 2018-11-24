using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    protected float mDefaultWinInS = 120;

    private float mActionProgress = 0;

    public int SecondsLeftOnAction() {
        return (int)(mDefaultWinInS - mDefaultWinInS * (mActionProgress / 100));
    }

    public bool IsActionFinished() {
        if (mActionProgress >= 100)
            return true;
        return false;
    }

    public void AddProgress(float progress) {
        mActionProgress = progress;
    }

    public float Progress() {
        return mActionProgress;
    }
	
	public void AddDurationProgress() {
        mActionProgress += (100 / mDefaultWinInS) * Time.deltaTime;
    }
}
