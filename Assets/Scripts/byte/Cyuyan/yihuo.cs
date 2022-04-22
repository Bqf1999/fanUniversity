using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
public class yihuo : MonoBehaviour
{
    public InputField yihuo1;
    public InputField yihuo2;

    public Text t41;
    public Text t42;
    public Text t43;
    void Start()
    {
        yihuo1.text = "69";
        yihuo2.text = "55";
        EditOver();
    }

    public void EditOver()
    {
        string s1 = sixthTotwo(yihuo1.text);
        string s2 = sixthTotwo(yihuo2.text);
        t41.text = "[" + s1 + "] ^ [" + s2 + "]";
        t42.text = CalYiHuo(s1, s2);
        t43.text = Convert.ToInt32(t42.text, 2).ToString("X");//二进制转16进制

    }

    string CalYiHuo(string str1, string str2)
    {
        string res = "";
        for (int i = 0; i < str1.Length; i++)
        {
            if (str1[i] == str2[i])
            {
                res += '0';
            }
            else
            {
                res += "1";
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
