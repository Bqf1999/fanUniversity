using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class huo : MonoBehaviour
{

    public InputField huo1;
    public InputField huo2;
    public Text t21;
    public Text t22;
    public Text t23;
    // Start is called before the first frame update
    void Start()
    {
        huo1.text = "69";
        huo2.text = "55";
        EditOver();

    }
    public void EditOver()
    {
        string s1 = sixthTotwo(huo1.text);
        string s2 = sixthTotwo(huo2.text);
        t21.text = "["+s1+"] | ["+s2+"]";
        t22.text = CalHuo(s1,s2);
        t23.text = Convert.ToInt32(t22.text, 2).ToString("X");//二进制转16进制

    }

    string CalHuo(string str1, string str2)
    {
        string res = "";
        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i]=='1'||str2[i]=='1')
            {
                res += '1';
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
