using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class hakeri {

    protected FileInfo theSourceFile = null;
    protected StreamReader reader = null;
    protected string text = " ";

    public hakeri() {
        theSourceFile = new FileInfo("hakeri.txt");
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
