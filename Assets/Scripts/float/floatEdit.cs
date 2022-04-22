using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class floatEdit : MonoBehaviour
{
    public InputField fuHaoWeiShu;
    public InputField weiShuWeiShu;
    public InputField jieMaWeiShu;

    public InputField []minGuiGe=new InputField[4];
    public InputField[] minFeiGuiGe = new InputField[4];
    public InputField[] maxGuiGe = new InputField[4];
    public InputField[] maxFeiGuiGe = new InputField[4];
    public InputField[] wuQiongda = new InputField[4];

    public void CalResult() {

        minGuiGe[0].text = "0";
        maxGuiGe[0].text = "0";
        minFeiGuiGe[0].text = "0";
        maxFeiGuiGe[0].text = "0";
        wuQiongda[0].text = "0";

        string two = "";
        string guige = "";
        for (int i = 1; i < Int32.Parse(jieMaWeiShu.text); i++)
        {
            two += "0";
            guige += "1";
        }

        minGuiGe[1].text = two+"1";       //0 0001 000
        maxGuiGe[1].text = guige+"0";     //0 1110 111
        minFeiGuiGe[1].text = two+"0";    //0 0000 001
        maxFeiGuiGe[1].text = two+"0";    //0 0000 111
        wuQiongda[1].text = two + "0";
        string one = "",zero="";
        print(weiShuWeiShu.text);
        for (int i = 1; i < Int32.Parse(weiShuWeiShu.text); i++)
        {
            one += "1";
            zero += "0";
        }

        minGuiGe[2].text = zero + "0";      
        maxGuiGe[2].text = one + "1";     
        minFeiGuiGe[2].text = zero + "1";    
        maxFeiGuiGe[2].text = one + "1";
        wuQiongda[2].text = zero + "0";

        //浮点数转小数；
        minGuiGe[3].text = CalGuiGe(minGuiGe[1].text, minGuiGe[2].text)+"";
        maxGuiGe[3].text = CalGuiGe(maxGuiGe[1].text, maxGuiGe[2].text) + "";
        minFeiGuiGe[3].text = CalNoGuiGe(minFeiGuiGe[1].text, minFeiGuiGe[2].text) + "";
        maxFeiGuiGe[3].text = CalNoGuiGe(maxFeiGuiGe[1].text, maxFeiGuiGe[2].text) + "";
        wuQiongda[3].text = "无穷大";

    }

    public static double CalGuiGe(string jiema,string weishu) {

        //规格化 E=e-Bias
        int e = Convert.ToInt32(jiema, 2);               //二进制转十进制
        
        int E = e - Bias(jiema);                                //偏置值
        
        double result = Math.Pow(2, E);
        
        //M=res/leng

        double weishulength = Math.Pow(2, weishu.Length);  //除数，固定值

        double M = weishuValue(weishu, true) / weishulength * result;

        return M;
    }

    public static double CalNoGuiGe(string jiema, string weishu)
    {

        double result = twoE((E(jiema, Bias(jiema), false)));
        print(result);
        //M=res/leng
        double weishulength = Math.Pow(2, weishu.Length);  //除数，固定值

        double M = weishuValue(weishu, false) / weishulength * result;

        return M;

    }
    public static int Bias(string jiema) {
        
            int jiemalength = jiema.Length;                    //尾数长度
            int Bias = (int)Math.Pow(2, jiemalength - 1) - 1;
            return Bias;
    }


    //返回指数E
    public static int E(string jiema,int Bias,bool guige) {


        if (guige)
        {
            int e = Convert.ToInt32(jiema, 2);               //二进制转十进制
            return e - Bias;
           
        }
        else {
            return 1 - Bias;

        }
    }

    //返回2的E次方
    public static double twoE(int E) {
        return Math.Pow(2, E);
    }

    //返回尾数的值
    public static double weishuValue(string weishu,bool guige) {
        if (guige)
        {
            return Convert.ToInt32("1" + weishu, 2);

        }
        else {

             return Convert.ToInt32(weishu, 2);

        }

    }
    


}
