using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class buma : MonoBehaviour
{
    public InputField input;
    public InputField er;
    public Text text;


    public void ChangValue() {

        bool fushu = false;
        string result = "";
        string shuju = input.text;

        if (shuju[0] == '-')
        {
            fushu = true;
            shuju = shuju.Substring(1);
            result += "负数\n\n减法\n减去一个负数\n变为加一个正数\n    ";
        }
        else {
            result += "正数\n\n保持原形不变";
        }

        int shu = Int32.Parse(shuju);

        string erjinzhi = ToTwo(shu);

        er.text = erjinzhi;

        int i = 0;
        string cal = "1";
        while (i < er.text.Length)  //生成长度加1的被减数
        {
            cal += "0";
            i++;
        }
        result += cal + "\n" + "-   " + er.text + "\n";
        
        if (fushu)  //负数 ，做减法
        {

            result += CalAdd(cal, er.text);
        }
        else {     //正数，保持原型不变

            result += er.text;
        }

        text.text = result;
       
    }



    
    public string CalSub(string str, string s)
    {
        //二进制转十进制，加减后再转二进制，妙

        int jian1 = Convert.ToInt32(str, 2);
        int jian2 = Convert.ToInt32(s, 2);
        return Convert.ToString(jian1 - jian2, 2);


    }

   public string CalAdd(string a, string  b)
    {
        int le = a.Length-1, ri = b.Length-1;

        int flag = 0;
        string res = "";
        while (le >= 0 && ri >= 0)
        {
            int ll = a[le] - '0';
            int rr = b[ri] - '0';
            flag = flag + ll + rr;
            if (flag > 1)
            {
                flag = flag - 1;
                res = '1'+res;
            }
            else {

                res =  flag+res;
                flag = 0;
            }

            le--;
            ri--;
        }
        if (ri >= 0)
        {
            while (ri >= 0)
            {
                int rr = b[ri] - '0';
                flag = flag + rr;

                if (flag > 1)
                {
                    flag = flag - 1;
                    res =  '1'+res;
                }
                else
                {

                    res = flag+res ;
                    flag = 0;
                }
                ri--;
            }
        }
        else {

            while (le >= 0)
            {
                int ll = a[le] - '0';
                flag =  ll+flag ;

                if (flag > 1)
                {
                    flag = flag - 1;
                    res = '1'+res;
                    
                }
                else
                {

                    res = flag+res;
                    flag = 0;
                }
                le--;
            }
        }

        

        return res;
    }

   


    //翻译二进制
    public string ToTwo(int res) {


        return Convert.ToString(res,2);
    }

}
