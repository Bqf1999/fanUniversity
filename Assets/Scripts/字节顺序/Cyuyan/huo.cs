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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string sixthTotwo(string str)
    {
        int num = Convert.ToInt32(str, 16);
        string res = Convert.ToString(num, 2);


        return res;
    }
}
