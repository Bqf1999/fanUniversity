using UnityEngine;
using System.Collections;

public class Register :MonoBehaviour
{
    public static string rax = "0";
    public static string rcx = "1";
    public static string rdx = "2";
    public static string rbx = "3";
    public static string rsp = "4";
    public static string rbp = "5";
    public static string rsi = "6";
    public static string rdi = "7";
    public static string r8 = "8";
    public static string r9 = "9";
    public static string r10 = "A";
    public static string r11 = "B";
    public static string r12 = "C";
    public static string r13 = "D";
    public static string r14 = "E";
    public static string none = "F";

    public static string getRegister(string reg) {
        string res = "";
        switch (reg)
        {
            case "%rax":
                res = Register.rax;
                break;
            case "%rcx":
                res = Register.rcx;
                break;
            case "%rdx":
                res = Register.rax;
                break;
            case "%rbx":
                res = Register.rbx;
                break;
            case "%rsp":
                res = Register.rsp;
                break;
            case "%rbp":
                res = Register.rbp;
                break;
            case "%rsi":
                res = Register.rsi;
                break;
            case "%rdi":
                res = Register.rdi;
                break;
            case "%r8":
                res = Register.r8;
                break;
            case "%r9":
                res = Register.r9;
                break;
            case "%r10":
                res = Register.r10;
                break;
            case "%r11":
                res = Register.r11;
                break;
            case "%r12":
                res = Register.r12;
                break;
            case "%r13":
                res = Register.r13;
                break;
            case "%r14":
                res = Register.r14;
                break;
            default:
                res = Register.none;
                break;

        }
        return res;
    }
}
