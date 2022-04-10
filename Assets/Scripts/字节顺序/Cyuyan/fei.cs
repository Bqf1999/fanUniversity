using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class fei : MonoBehaviour
{
    public InputField feii;

    public Text t11;
    public Text t12;
    public Text t13;

    // Start is called before the first frame update
    void Start()
    {
        feii.text = "41";
        EditOver();
    }
    public void EditOver() {
        string s = sixthTotwo(feii.text);
        t11.text = s;
        t12.text = CalFei(s);
        t13.text = Convert.ToInt32(t12.text, 2).ToString("X");
        
    }
    
    string CalFei(string str) {
        string res = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '0')
            {
                res += "1";
            }
            else {
                res += "0";
            }
        }

        return res;
    }
    public string sixthTotwo(string str)
    {
        int num = Convert.ToInt32(str, 16);
        string res = Convert.ToString(num, 2);
        if (res.Length < 8)
        {
            for (int i = 0; res.Length<8; i++)
            {
                res = "0" + res;
            }
        }
       

        return res;
    }
}
