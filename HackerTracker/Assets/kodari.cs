using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class kodari {

    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " ";

    // Use this for initialization
    public kodari() {
        theSourceFile = new FileInfo("kodari.txt");
    }
	
    public string ReturnLine(int linenum) {
        reader = theSourceFile.OpenText();
        for (int i = 0 ; i <= linenum ; i++) {
            text = reader.ReadLine();
        }
        reader.Close();
        return text;
    }
}
