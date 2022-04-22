using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class luojifei : MonoBehaviour
{

    public InputField input;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        input.text = "41";
        EditOver();
    }
    public void EditOver()
    {

        string s = input.text;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != '0')
            {
                text.text = "0 false";
                break;
            }
            if (i == s.Length - 1) {
                text.text = "1 true";
            }
        }
        
        
    }

    
}
