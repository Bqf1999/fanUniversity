using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class luojihuo : MonoBehaviour
{

    public InputField huo1;
    public InputField huo2;

    public Text res;

    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        huo1.text = "69";
        huo2.text = "55";
        EditOver();

    }
    public void EditOver()
    {
        Boolean s1 = isZero(huo1.text);
        Boolean s2 = isZero(huo2.text);
        if (s1 || s2)
        {
            res.text = "1 true";
        }
        else {
            res.text = "0 false";
        }
        
    }

    public Boolean isZero(string str) {
       
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] != '0')
            {
                break;
               
            }
            if (i == str.Length - 1)
            {
                return true;
            }
        }
        return false;
    }
}
