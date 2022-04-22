using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class luojiyu : MonoBehaviour
{

    public InputField yu1;
    public InputField yu2;

    public Text res;

    void Start()
    {
        yu1.text = "69";
        yu2.text = "55";
        EditOver();

    }
    public void EditOver()
    {
        Boolean s1 = isZero(yu1.text);
        Boolean s2 = isZero(yu2.text);
        if (s1 && s2)
        {
            res.text = "1 true";
        }
        else
        {
            res.text = "0 false";
        }

    }

    public Boolean isZero(string str)
    {

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
