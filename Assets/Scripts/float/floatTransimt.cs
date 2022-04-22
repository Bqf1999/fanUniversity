using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class floatTransimt : MonoBehaviour
{
    public InputField input;

    public InputField weishuleng;
    public InputField jiemaleng;

    public Dropdown dropdown;

    public Text result;

    public void OnValueChangde() {

        string tmp = input.text;

        if (dropdown.value == 1)
        {
            string fuhao = tmp.Substring(0, 1);
            string jiema = tmp.Substring(1, Int32.Parse(jiemaleng.text));
            string weishu = tmp.Substring(Int32.Parse(jiemaleng.text) + 1);
            double weishulength = Math.Pow(2, weishu.Length);  //除数，固定值
            int ss = jiema.IndexOf('1');
            if (jiema.IndexOf('1') == -1) //not found 1 非规格化数
            {
                int Bia = floatEdit.Bias(jiema);
                int E = floatEdit.E(jiema, Bia, false);
                double res = (int)floatEdit.twoE(E);
                double fenzi = floatEdit.weishuValue(weishu, false);

                floatEdit.CalNoGuiGe(jiema, weishu);
                result.text = "符号 :" + fuhao + "     阶码 :" + jiema + "     尾数 :" + weishu + "\n"
                             + "阶码全为0，非规格化数，k为阶码长度，Bias=pow(2,k-1)-1 ,  E=1-Bias,  value=pow(2," + E + ")" + "\n"
                             + "Bias  =  " + Bia + "          E=  " + E + "           value=  " + res + "\n"
                            + "尾数长度 :" + (weishu.Length) + "       分母 = pow(2," + weishu.Length + ")= " + weishulength + "       分子为尾数  " + weishu + " 转换为十进制=" + fenzi + "        (M=分子/分母)" + "\n"
                              + "最终结果-------value*M------->  " + floatEdit.CalNoGuiGe(jiema, weishu);
            }
            else
            {                       //规格化数

                int Bia = floatEdit.Bias(jiema);
                int E = floatEdit.E(jiema, Bia, true);
                double res = (int)floatEdit.twoE(E);
                double fenzi = floatEdit.weishuValue(weishu, true);
                int e = Convert.ToInt32(jiema, 2);               //二进制转十进制


                result.text = "符号 :" + fuhao + "          阶码 :" + jiema + "          尾数 :" + weishu + "\n"
                             + "阶码不全为0，规格化数，k为阶码长度，Bias=pow(2,k-1)-1 ,  e为阶码的十进制值，  E=e-Bias ,  value=pow(2," + E + ")" + "\n"
                             + "Bias =   " + Bia + "          e =   " + e + "          E =   " + E + "          value =   " + res + "\n"
                             + "尾数长度 :" + (weishu.Length) + "       分母 = pow(2," + weishu.Length + ")= " + weishulength + "       分子为尾数(规格化数尾数前边默认多1)" + " 1" + weishu + " 转换为十进制=" + fenzi + "        (M=分子/分母)" + "\n"
                             + "最终结果------->value*M------->" + floatEdit.CalGuiGe(jiema, weishu);


            }
        }
        else if(dropdown.value==2){

            string FuHao = "";
            string JieMa = "";
            string WeiSHu = "";


            //将十进制转为二进制浮点数
            if (Convert.ToDouble(tmp) < 0)
            {
                FuHao = "1";
                result.text = "负数---符号位为1";
            }
            else {
                FuHao = "0";
                result.text = "正数---符号位为0";
            }
            if (tmp.IndexOf('.') == -1) //整数,大于0.肯定为规格化数
            {
                string erjinzhi = Convert.ToString(Int32.Parse(tmp), 2);

                result.text += "           整数---转为二进制---"+erjinzhi+"\n";

                string jieduan = erjinzhi.Substring(1);  //截去首位1，规格化数

                int jiema = jieduan.Length;              //阶码大小

               
                int e = jiema + Bias(jiemaleng.text);

                
                string E = Convert.ToString(e,2);//阶码+Bias=E;

                while (E.Length < Int32.Parse(jiemaleng.text))
                {
                    E = "0" + E;
                }
                result.text += "规格化数---去掉首位1" + jieduan + "        长度为" + jiema + "        阶码的大小=阶码长度+Bias---"+ "\n"+"Bias = "
                            +floatEdit.Bias(jiemaleng.text)+" + "+jiema+" = "+e+"    转为二进制表示 "+E;
                

                
                if (E.Length > Int32.Parse(jiemaleng.text))
                {

                    result.text += "\n\n" + "----超出所能表示的大小---" + E + " > " + Int32.Parse(jiemaleng.text);

                    return;
                }
                else {

                    JieMa = E;
                    WeiSHu = erjinzhi.Substring(0, Convert.ToInt32(weishuleng.text));
                    result.text += "转换结果为----" + FuHao +" "+ E +" "+ WeiSHu;
                }



            }
            else {                      //小数


            }
        }
    }
    public int Bias(string leng)
    {
                          //尾数长度
        int Bias = (int)Math.Pow(2, Int32.Parse(leng) - 1) - 1;
        return Bias;
    } 
}
