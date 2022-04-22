using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class read : MonoBehaviour
{
    public InputField input;

    public Button btn;

    public string res = "";
    public string rA="none";
    public string rB="none";
    public string dest;

    public string register="none";  //0(%rax)专用来解决这种类型。


    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(butClick);       
    }
    public void butClick() {
        jieXi(input.text);
    }
    public void jieXi(string str) {

        string[] instruction = str.Split(new char[2] {'\\','n' });
        //irmovq $10,%rdx
        //addq %rdx,%rax
        //mrmovq 0(%rdx),%rax
        //ret
        //call proc
        //xorq %rsp,%rsp
        //pushq %rax
        foreach (string s in instruction)
        {
            try
            {
                string[] tmp = s.Split(' ');
                print(instruct(tmp[0], tmp[1]));
            }
            catch {

            }



        }
    }

    //将指令解析为字节码
    public string instruct(string reg,string after) {

        

        switch (reg[0]) {
            case 'h':                    //hatl
                res="00";
                break;
            case 'n':                    //nop
                res = "10";
                break;
            case 'r':                    //rrmovq,rmmovq,ret
                switch (reg[1]) {
                    case 'r': //rrmovq
                        string[] tmp = after.Split(',');
                        rA = Register.getRegister(tmp[0]);
                        rB = Register.getRegister(tmp[1]);
                        res = "20" + rA + rB;
                        break;
                    case 'm'://rmmovq
                        string []tm = after.Split(',');
                        rA = Register.getRegister(tm[0]);
                        Num(tm[1]);
                        rB = Register.getRegister(register);
                        res = "40" + rA + rB + dest;        //注意此处rb可能不存在的问题
                        break;
                    case 'e': //ret
                        res = "90";
                        break;
                    default:
                        break;
                }
                break;
            case 'i':                    //irmovq --立即数
                Num(after.Split(',')[0]);
                res = "30" + "F" + Register.getRegister(after.Split(',')[1])+dest;
                print(after.Split(',')[1]);
                break;
            case 'm':                    //mrmovq
                Num(after.Split(',')[0]);
                res = "50" + Register.getRegister(after.Split(',')[1]) + Register.getRegister(register) + dest;
                break;
            case 'j':                    //jle
                switch (reg) {
                    case "jmp":
                        res = "70" + "解析数字";
                        break;
                    case "jle":
                        res = "71" + "解析数字";
                        break;
                    case "jl":
                        res = "72" + "解析数字";
                        break;
                    case "je":
                        res = "73" + "解析数字";
                        break;
                    case "jne":
                        res = "74" + "解析数字";
                        break;
                    case "jge":
                        res = "75" + "解析数字";
                        break;
                    case "jg":
                        res = "76" + "解析数字";
                        break;
                }
                break;
            case 'c':                    //call
                Num(after);
                res = "80"+dest;
                break;
            case 'p':                    //pushq,popq
                if (reg[1] == 'u')
                {
                    res = "A0"; 
                }
                else {
                    res = "B0";  
                }
                res+= Register.getRegister(after) + "F";
                break;
            case 'a': //addq,andq,
                if (reg == "addq")
                {
                    res = "60";
                }
                else {
                    res = "62";
                }
                res += Register.getRegister(after.Split(',')[0]) + Register.getRegister(after.Split(',')[1]);
                break;
            case 's': //subq
                res ="61"+ Register.getRegister(after.Split(',')[0]) + Register.getRegister(after.Split(',')[1]);
                break;
            case 'x': //xorq
                res="63"+ Register.getRegister(after.Split(',')[0]) + Register.getRegister(after.Split(',')[1]);
                break;
            default:
                print("此指令尚未实现");
                break;
        }
        //每次使用完后清空
        rA = "none";
        rB = "none";
        dest = "00000000";
        register = "none";
        return res;
    }
    public string sixth(int num) {

        string res=num.ToString("X6");
        
        for (int i=res.Length; i < 8; i++)
        {
            res = "0" + res;
        }
        return res;
    }
    public void   Num(string line) {
        int res = 0;
        string rNum = "", rReg = "";
        if (line[0] == '$')    //立即数,转为16进制
        {
            res =Convert.ToInt32(line.Substring(1));


            
            dest = sixth(res);    //赋值给dest 常数 不存在寄存器使用

        }
        else if ((line[0] >= '0' && line[0] <= '9')) { //0(%rax)
            
            for (int i = 0; i < line.Length; i++)
            {
                rNum+= line[i];
                if (i == '(')
                {
                    int x = i;
                   
                    while (line[x] != ')')
                    {
                        x++;
                        rReg += line[x];
                    }
                    register = rReg;
                    dest = rNum;        //此处需要转换进制，可以把进制转换单独分出一个函数
                }
            }
        }
        
           
    }
    
}
