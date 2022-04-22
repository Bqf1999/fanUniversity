using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class yu : MonoBehaviour
{
    public InputField yu1;
    public InputField yu2;
    public Text t31;
    public Text t32;
    public Text t33;

    // Start is called before the first frame update
    void Start()
    {
        yu1.text = "69";
        yu2.text = "55";
        EditOver();
    }

    public void EditOver()
    {
        string s1 = sixthTotwo(yu1.text);
        string s2 = sixthTotwo(yu2.text);
        t31.text = "[" + s1 + "] & [" + s2 + "]";
        t32.text = CalYu(s1, s2);
        t33.text = Convert.ToInt32(t32.text, 2).ToString("X");//二进制转16进制

    }
    string CalYu(string str1,string str2 )
    {
        string res = "";
        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] == str2[i])
            {
                res += str1[i];
            }
            else
            {
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
            for (int i = 0; res.Length < 8; i++)
            {
                res = "0" + res;
            }
        }
        return res;
    }
}
