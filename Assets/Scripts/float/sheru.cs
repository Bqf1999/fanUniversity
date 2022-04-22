using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class sheru : MonoBehaviour
{
    public InputField shuju;
    public InputField leng;

    public Text[] txt = new Text[4];

    
    public void ChangValue() {

        
        int l = Int32.Parse(leng.text); //获取保留位数

        string str = shuju.text;
        int sub = str.IndexOf('.');
        if (sub == -1)                 //不包含小数点
        {
            return;
        }
        string res = str.Substring(0, sub + l+1);  //截取前边数据

        print("截取前边数据" + res);

        string  weishu = str.Substring(sub + l+1); //获取保留位数后一位，用于取舍

        print("尾数"+weishu);

        txt[0].text = SetOu(res, weishu);
        txt[1].text = setZero(res, weishu);
        txt[2].text = setDown(res, weishu);
        txt[3].text = setUp(res, weishu);


    }

    //10.010  2
    public string  SetOu(string res,string  weishu) {

        string result = "";


        if (res[0] == '-')       //处理一下负号
        {
            res = res.Substring(1);
        }


        //后边尾数是10000…… 则位于中间值，向偶舍入才会生效
        if (weishu[0] == '1') {


            int i = 1;
            while (i<weishu.Length&&weishu[i] == '0')
            {

                i++;
            }


            if (i == weishu.Length )           //是中间值
            {
                if (res[res.Length - 1] == '0')   //直接舍去
                {

                    return res;
                }
                
            }
            return lastAdd(res);

        }
        //不是中间值,直接舍入，1进0舍
        if (weishu[0] == '0')
        {
            result = res;
        }
        

        return result;
    }

    public string setUp(string res, string weishu) {

        //向上舍入，只要不为0，就进位

        if (res[0] == '0')
        {
            res = res.Substring(1);
        }
        if (weishu[0] == '0') //舍
        {
            return res;
        }
        else {

            return lastAdd(res);

        }

       
    }

    public string lastAdd(string res)
    {

        //进一位

        int flag = 1;
        string rescopy = "";
        for (int j = res.Length - 1; j >=0; j--)
        {
            if (res[j] == '.')
            {

                rescopy = '.' + rescopy;
                continue;

            }
            if (res[j] == '1')
            {

                rescopy = '0' + rescopy;
                continue;
            }
            if (res[j] == '0')
            {
                rescopy = '1' + rescopy;

                flag = 0;
                rescopy = res.Substring(0, j) + rescopy;
                break;
            }
        }
        if (flag == 1)
        {
            rescopy = "1" + rescopy;
            
        }
        return rescopy;
    }
    public string setDown(string res, string weishu) {

        return res;
    }

    public string setZero(string res, string  weishu) {
        if (res[0] == '-')
        {
            return setDown(res, weishu);
        }
        else {
            return setUp(res, weishu);
        }

      
    }

}
