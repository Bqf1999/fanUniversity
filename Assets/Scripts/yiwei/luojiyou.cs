using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class luojiyou : MonoBehaviour
{

    public InputField shuju;
    public InputField len;

    public Text er;
    public Text res1;
    public Text res2;
    public Text res3;
    // Start is called before the first frame update
    void Start()
    {
        shuju.text = "84";
        len.text = "2";
        EditOver();
    }

    public void EditOver() {
        er.text = sixthTotwo(shuju.text);
        res1.text = suanShuYou(er.text, int.Parse(len.text));
        
        res2.text = zuoYi(er.text, int.Parse(len.text));
        res3.text = luoJiYou(er.text, int.Parse(len.text));

    }
    public string luoJiYou(string str,int len) {

        
        for (int i = 0; i < len; i++)
        {
            str = "0" + str;
        }
        return str.Substring(0,8);
    }
    public string suanShuYou(string str, int len)
    {
        for (int i = 0; i < len; i++)
        {
            str = str[0] + str;
        }
        return str.Substring(0, 8);
    }
    public string zuoYi(string str, int len)
    {
        for (int i = 0; i < len; i++)
        {
            str += "0" ;
        }
        return str.Substring(0, 8);
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
