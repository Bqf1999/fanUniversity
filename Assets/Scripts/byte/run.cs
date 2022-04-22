using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class run : MonoBehaviour
{
    public InputField input;

    public Text txt;

    string[] array = new string[8];

    private int le = 0;

    private void Start()
    {
        input.text = "12345678";
        EditionOver();
    }

    public  void InputChange() {

        Separat(input.text);
        Debug.Log(array);
        string ss = "";
        for (int i = 0; i < le; i++)
        {
            ss += array[i];
            ss += " ";
        }
        input.text = ss;
    }
    public void RemovedTxt()
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag("zijie");
        foreach (GameObject gameObject in list)
        {
            Destroy(gameObject);
        }
        le = 0;
    }
    public void EditionOver() {

        //用户填写的数据不准，检验
        //
        //
        //
        if (input.text == "")
        {
            return;
        }
        RemovedTxt();      //此处顺序不能颠倒，因为le归零在removetxt函数中
        InputChange();
        
        int xx = 0;
        for (int i = 0; i < le; i++)
        {

            var newtext = Instantiate(txt,input.transform);
            newtext.transform.position = new Vector3(input.transform.position.x +180+ 100 * (++xx), input.transform.position.y - 50,0);
            newtext.text = "0x10" + i;


            var big = Instantiate(txt,input.transform);
            big.transform.position = new Vector3(newtext.transform.position.x+15, input.transform.position.y - 80, 0);
            big.text = array[i];
            Debug.Log(array[i]);

            var little= Instantiate(txt,input.transform);
            little.transform.position = new Vector3(newtext.transform.position.x+15, input.transform.position.y - 110, 0);
            little.text = array[le -1-i];
            
            

        }
       
    }

    public string[] Separat(string str) {
        string newstr="";
        if (str.Length < 8)
        {
            for (int i = str.Length; i < 8; i++)
            {
                str = "0" + str;
            }
        }
        else if (str.Length != 8 && str.Length < 16)
        {
            for (int i = str.Length; i < 16; i++)
            {
                str = "0" + str;
            }
        }
        else {

        }
        for (int i = 0; i < str.Length; i++)
        {
            newstr =newstr+ str[i];
            if (i % 2 == 1)
            {
                array[i/2]=newstr;
                newstr = "";
                le++;
            }
        }
        
        return array;
    }

}
