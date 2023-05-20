using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputController : MonoBehaviour
{
    string S1A = "0"; string S1B = "0"; string S1C = "0";
    string S2A = "0"; string S2B = "0"; string S2C = "0";
    string S3A = "0"; string S3B = "0"; string S3C = "0";
    public List<GameObject> InputField = new List<GameObject>();
        //
    public string JoinedInputA = "";
    public string JoinedInputB = "";
    public string JoinedInputC = "";
    public void Size1_A(string input) { S1A = input; JoinInputs(); }
    public void Size1_B(string input) { S1B = input; JoinInputs(); }
    public void Size1_C(string input) { S1C = input; JoinInputs(); }
    public void Size2_A(string input) { S2A = input; JoinInputs(); }
    public void Size2_B(string input) { S2B = input; JoinInputs(); }
    public void Size2_C(string input) { S2C = input; JoinInputs(); }
    public void Size3_A(string input) { S3A = input; JoinInputs(); }
    public void Size3_B(string input) { S3B = input; JoinInputs(); }
    public void Size3_C(string input) { S3C = input; JoinInputs(); }
    private void Start()
    {
        for (int i=0;i<InputField.Count;i++)
        {
           InputField[i].GetComponent<TMP_InputField>().characterLimit = 1;
        }
    }
    public void JoinInputs()
    {
        JoinedInputA = S1A + S1B + S1C;
        JoinedInputB = S2A + S2B + S2C;
        JoinedInputC = S3A + S3B + S3C;
    }
    public void ShowSelectedCloth()
    {
        int fit=GameObject.Find("AnimationsController").GetComponent<Controller>().fit;
        float input1; float input2; float input3;
        float.TryParse(JoinedInputA, out input1);
        float.TryParse(JoinedInputB, out input2);
        float.TryParse(JoinedInputC, out input3);
        GameObject.Find("InfoManager").GetComponent<InfoController>().Compare(input1, input2, input3, fit); 
    }
}
