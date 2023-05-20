using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class InfoController : MonoBehaviour
{
    string[,] Size1 = new string[6, 23];
    string[,] Size2 = new string[6, 23];
    string[,] Size3 = new string[6, 23];

    string[,] GarmentSize1 = new string[6, 1];
    string[,] GarmentSize2 = new string[6, 1];
    string[,] GarmentSize3 = new string[6, 1];

    public List<Sprite> StrainMap = new List<Sprite>();
    //
    public List<string> BodyShapeNames = new List<string>();
    public TextMeshProUGUI BodyShapeName;
    //
    public TextMeshProUGUI Size1TextA;
    public TextMeshProUGUI Size1TextB;
    public TextMeshProUGUI Size1TextC;
    public TextMeshProUGUI Size2TextA;
    public TextMeshProUGUI Size2TextB;
    public TextMeshProUGUI Size2TextC;
    public TextMeshProUGUI Size3TextA;
    public TextMeshProUGUI Size3TextB;
    public TextMeshProUGUI Size3TextC;

    public TextMeshProUGUI GarmentSize1TextA;
    public TextMeshProUGUI GarmentSize1TextB;
    public TextMeshProUGUI GarmentSize1TextC;
    public TextMeshProUGUI GarmentSize2TextA;
    public TextMeshProUGUI GarmentSize2TextB;
    public TextMeshProUGUI GarmentSize2TextC;
    public TextMeshProUGUI GarmentSize3TextA;
    public TextMeshProUGUI GarmentSize3TextB;
    public TextMeshProUGUI GarmentSize3TextC;

    public List<string> Folders = new List<string>();
    public Image StrainImageMap;
    float weight1 = 0.33f;
    float weight2 = 0.33f;
    float weight3 = 0.33f;

    int selectedShapeID = -1;

    public TextMeshProUGUI SizeLabel;

    public void Compare(float A, float B, float C, int clothID)
    {
        float minimum = 1000000;
        for(int i=0; i<23; i++)
        {
            float temp=CalcDifference(A, B, C, clothID,i);
            if (temp<minimum) { minimum = temp; selectedShapeID = i; }
        }
        if (selectedShapeID<0) { selectedShapeID = 0; }
        GameObject.Find("AnimationsController").GetComponent<Controller>().OnShapeSliderValueChanged(selectedShapeID);

        if (GameObject.Find("ShapeSliderMain")==null) 
        {
            GameObject.Find("PanelsManager").GetComponent<PanelsController>().ManualActivatePanel();
            GameObject.Find("ShapeSliderMain").GetComponent<RadialSlider>().ManualknobPositions(selectedShapeID);
        } 
        else 
        { 
            GameObject.Find("ShapeSliderMain").GetComponent<RadialSlider>().ManualknobPositions(selectedShapeID);
        }
    }

    float CalcDifference(float A, float B, float C, int clothID, int shapeID)
    {
        float val1; float val2; float val3;
        Debug.Log(shapeID);
        Debug.Log(clothID);
        float.TryParse(Size1[clothID-1, shapeID], out val1);
        float.TryParse(Size2[clothID-1, shapeID], out val2);
        float.TryParse(Size3[clothID-1, shapeID], out val3);
        float diff1 = Mathf.Abs(val1 - A);
        float diff2 = Mathf.Abs(val2 - B);
        float diff3 = Mathf.Abs(val3 - C);
        float sum = (weight1 * diff1) + (weight2 * diff2) + (weight3 * diff3);
        return sum;
    }
    private void Awake()
    {
        BodyShapeNames.Add("Skinny");
        BodyShapeNames.Add("Skinny"); 
        BodyShapeNames.Add("Slim");
        BodyShapeNames.Add("Slim"); 
        BodyShapeNames.Add("Slim");
        BodyShapeNames.Add("Slim");
        BodyShapeNames.Add("Athletic");
        BodyShapeNames.Add("Athletic");
        BodyShapeNames.Add("Athletic");
        BodyShapeNames.Add("Athletic");
        BodyShapeNames.Add("Hourglass");
        BodyShapeNames.Add("Hourglass");
        BodyShapeNames.Add("Hourglass");
        BodyShapeNames.Add("Hourglass");
        BodyShapeNames.Add("Hourglass");
        BodyShapeNames.Add("Pear");
        BodyShapeNames.Add("Pear");
        BodyShapeNames.Add("Pear");
        BodyShapeNames.Add("Pear");
        BodyShapeNames.Add("Round");
        BodyShapeNames.Add("Round");
        BodyShapeNames.Add("Round");
        BodyShapeNames.Add("Round");

        //Size1-model bust / [outfit, body shape]
        Size1[0, 0] = "085"; //emaciated
        Size1[0, 1] = "087"; //thin
        Size1[0, 2] = "088"; //slimhd
        Size1[0, 3] = "090"; //slimhd
        Size1[0, 4] = "091"; //slimhd
        Size1[0, 5] = "092"; //default
        Size1[0, 6] = "094"; //fitness
        Size1[0, 7] = "098"; //fitness
        Size1[0, 8] = "101"; //bodybuilder
        Size1[0, 9] = "104"; //bodybuilder
        Size1[0, 10] = "093"; //curvyhd
        Size1[0, 11] = "093"; //curvyhd
        Size1[0, 12] = "097"; //voluptuous
        Size1[0, 13] = "101"; //voluptuous
        Size1[0, 14] = "103"; //voluptuous
        Size1[0, 15] = "095"; //pear
        Size1[0, 16] = "098"; //pear
        Size1[0, 17] = "100"; //pear
        Size1[0, 18] = "103"; //pear
        Size1[0, 19] = "102"; //heavy
        Size1[0, 20] = "112"; //heavy
        Size1[0, 21] = "122"; //heavy
        Size1[0, 22] = "133"; //heavy

        Size1[1, 0] = "085"; Size1[1, 1] = "087"; Size1[1, 2] = "088"; 
        Size1[1, 3] = "090"; Size1[1, 4] = "091"; Size1[1, 5] = "092"; 
        Size1[1, 6] = "094"; Size1[1, 7] = "098"; Size1[1, 8] = "101"; 
        Size1[1, 9] = "104"; Size1[1, 10] = "093"; Size1[1, 11] = "093"; 
        Size1[1, 12] = "097"; Size1[1, 13] = "101"; Size1[1, 14] = "103"; 
        Size1[1, 15] = "095"; Size1[1, 16] = "098"; Size1[1, 17] = "100"; 
        Size1[1, 18] = "103"; Size1[1, 19] = "102"; Size1[1, 20] = "112"; 
        Size1[1, 21] = "122"; Size1[1, 22] = "133";

        Size1[2, 0] = "085"; Size1[2, 1] = "087"; Size1[2, 2] = "088";
        Size1[2, 3] = "090"; Size1[2, 4] = "091"; Size1[2, 5] = "092";
        Size1[2, 6] = "094"; Size1[2, 7] = "098"; Size1[2, 8] = "101";
        Size1[2, 9] = "104"; Size1[2, 10] = "093"; Size1[2, 11] = "093";
        Size1[2, 12] = "097"; Size1[2, 13] = "101"; Size1[2, 14] = "103";
        Size1[2, 15] = "095"; Size1[2, 16] = "098"; Size1[2, 17] = "100";
        Size1[2, 18] = "103"; Size1[2, 19] = "102"; Size1[2, 20] = "112";
        Size1[2, 21] = "122"; Size1[2, 22] = "133";

        Size1[3, 0] = "085"; Size1[3, 1] = "087"; Size1[3, 2] = "088";
        Size1[3, 3] = "090"; Size1[3, 4] = "091"; Size1[3, 5] = "092";
        Size1[3, 6] = "094"; Size1[3, 7] = "098"; Size1[3, 8] = "101";
        Size1[3, 9] = "104"; Size1[3, 10] = "093"; Size1[3, 11] = "093";
        Size1[3, 12] = "097"; Size1[3, 13] = "101"; Size1[3, 14] = "103";
        Size1[3, 15] = "095"; Size1[3, 16] = "098"; Size1[3, 17] = "100";
        Size1[3, 18] = "103"; Size1[3, 19] = "102"; Size1[3, 20] = "112";
        Size1[3, 21] = "122"; Size1[3, 22] = "133";

        Size1[4, 0] = "085"; Size1[4, 1] = "087"; Size1[4, 2] = "088";
        Size1[4, 3] = "090"; Size1[4, 4] = "091"; Size1[4, 5] = "092";
        Size1[4, 6] = "094"; Size1[4, 7] = "098"; Size1[4, 8] = "101";
        Size1[4, 9] = "104"; Size1[4, 10] = "093"; Size1[4, 11] = "093";
        Size1[4, 12] = "097"; Size1[4, 13] = "101"; Size1[4, 14] = "103";
        Size1[4, 15] = "095"; Size1[4, 16] = "098"; Size1[4, 17] = "100";
        Size1[4, 18] = "103"; Size1[4, 19] = "102"; Size1[4, 20] = "112";
        Size1[4, 21] = "122"; Size1[4, 22] = "133";

        Size1[5, 0] = "085"; Size1[5, 1] = "087"; Size1[5, 2] = "088";
        Size1[5, 3] = "090"; Size1[5, 4] = "091"; Size1[5, 5] = "092";
        Size1[5, 6] = "094"; Size1[5, 7] = "098"; Size1[5, 8] = "101";
        Size1[5, 9] = "104"; Size1[5, 10] = "093"; Size1[5, 11] = "093";
        Size1[5, 12] = "097"; Size1[5, 13] = "101"; Size1[5, 14] = "103";
        Size1[5, 15] = "095"; Size1[5, 16] = "098"; Size1[5, 17] = "100";
        Size1[5, 18] = "103"; Size1[5, 19] = "102"; Size1[5, 20] = "112";
        Size1[5, 21] = "122"; Size1[5, 22] = "133";

        //Size2-model waist / [outfit, body shape]
        Size2[0, 0] = "063"; 
        Size2[0, 1] = "063"; 
        Size2[0, 2] = "063"; 
        Size2[0, 3] = "063"; 
        Size2[0, 4] = "065"; 
        Size2[0, 5] = "068"; 
        Size2[0, 6] = "067";
        Size2[0, 7] = "068";
        Size2[0, 8] = "071";
        Size2[0, 9] = "072";
        Size2[0, 10] = "066";
        Size2[0, 11] = "067";
        Size2[0, 12] = "069";
        Size2[0, 13] = "070";
        Size2[0, 14] = "071";
        Size2[0, 15] = "075";
        Size2[0, 16] = "083";
        Size2[0, 17] = "091";
        Size2[0, 18] = "101";
        Size2[0, 19] = "080";
        Size2[0, 20] = "094";
        Size2[0, 21] = "108";
        Size2[0, 22] = "123";

        Size2[1, 0] = "063"; Size2[1, 1] = "063"; Size2[1, 2] = "063"; 
        Size2[1, 3] = "063"; Size2[1, 4] = "065"; Size2[1, 5] = "068"; 
        Size2[1, 6] = "067"; Size2[1, 7] = "068"; Size2[1, 8] = "071";
        Size2[1, 9] = "072"; Size2[1, 10] = "066"; Size2[1, 11] = "067";
        Size2[1, 12] = "069"; Size2[1, 13] = "070"; Size2[1, 14] = "071";
        Size2[1, 15] = "075"; Size2[1, 16] = "083"; Size2[1, 17] = "091";
        Size2[1, 18] = "101"; Size2[1, 19] = "080"; Size2[1, 20] = "094";
        Size2[1, 21] = "108"; Size2[1, 22] = "123";

        Size2[2, 0] = "063"; Size2[2, 1] = "063"; Size2[2, 2] = "063";
        Size2[2, 3] = "063"; Size2[2, 4] = "065"; Size2[2, 5] = "068";
        Size2[2, 6] = "067"; Size2[2, 7] = "068"; Size2[2, 8] = "071";
        Size2[2, 9] = "072"; Size2[2, 10] = "066"; Size2[2, 11] = "067";
        Size2[2, 12] = "069"; Size2[2, 13] = "070"; Size2[2, 14] = "071";
        Size2[2, 15] = "075"; Size2[2, 16] = "083"; Size2[2, 17] = "091";
        Size2[2, 18] = "101"; Size2[2, 19] = "080"; Size2[2, 20] = "094";
        Size2[2, 21] = "108"; Size2[2, 22] = "123";

        Size2[3, 0] = "063"; Size2[3, 1] = "063"; Size2[3, 2] = "063";
        Size2[3, 3] = "063"; Size2[3, 4] = "065"; Size2[3, 5] = "068";
        Size2[3, 6] = "067"; Size2[3, 7] = "068"; Size2[3, 8] = "071";
        Size2[3, 9] = "072"; Size2[3, 10] = "066"; Size2[3, 11] = "067";
        Size2[3, 12] = "069"; Size2[3, 13] = "070"; Size2[3, 14] = "071";
        Size2[3, 15] = "075"; Size2[3, 16] = "083"; Size2[3, 17] = "091";
        Size2[3, 18] = "101"; Size2[3, 19] = "080"; Size2[3, 20] = "094";
        Size2[3, 21] = "108"; Size2[3, 22] = "123";

        Size2[4, 0] = "063"; Size2[4, 1] = "063"; Size2[4, 2] = "063";
        Size2[4, 3] = "063"; Size2[4, 4] = "065"; Size2[4, 5] = "068";
        Size2[4, 6] = "067"; Size2[4, 7] = "068"; Size2[4, 8] = "071";
        Size2[4, 9] = "072"; Size2[4, 10] = "066"; Size2[4, 11] = "067";
        Size2[4, 12] = "069"; Size2[4, 13] = "070"; Size2[4, 14] = "071";
        Size2[4, 15] = "075"; Size2[4, 16] = "083"; Size2[4, 17] = "091";
        Size2[4, 18] = "101"; Size2[4, 19] = "080"; Size2[4, 20] = "094";
        Size2[4, 21] = "108"; Size2[4, 22] = "123";

        Size2[5, 0] = "063"; Size2[5, 1] = "063"; Size2[5, 2] = "063";
        Size2[5, 3] = "063"; Size2[5, 4] = "065"; Size2[5, 5] = "068";
        Size2[5, 6] = "067"; Size2[5, 7] = "068"; Size2[5, 8] = "071";
        Size2[5, 9] = "072"; Size2[5, 10] = "066"; Size2[5, 11] = "067";
        Size2[5, 12] = "069"; Size2[5, 13] = "070"; Size2[5, 14] = "071";
        Size2[5, 15] = "075"; Size2[5, 16] = "083"; Size2[5, 17] = "091";
        Size2[5, 18] = "101"; Size2[5, 19] = "080"; Size2[5, 20] = "094";
        Size2[5, 21] = "108"; Size2[5, 22] = "123";


        //Size3-model hips / [outfit, body shape]
        Size3[0, 0] = "093"; 
        Size3[0, 1] = "093"; 
        Size3[0, 2] = "094"; 
        Size3[0, 3] = "096"; 
        Size3[0, 4] = "098"; 
        Size3[0, 5] = "100"; 
        Size3[0, 6] = "101";
        Size3[0, 7] = "101";
        Size3[0, 8] = "103";
        Size3[0, 9] = "104";
        Size3[0, 10] = "101";
        Size3[0, 11] = "102";
        Size3[0, 12] = "109";
        Size3[0, 13] = "113";
        Size3[0, 14] = "118";
        Size3[0, 15] = "118";
        Size3[0, 16] = "116";
        Size3[0, 17] = "124";
        Size3[0, 18] = "133";
        Size3[0, 19] = "111";
        Size3[0, 20] = "124";
        Size3[0, 21] = "136";
        Size3[0, 22] = "149";

        Size3[1, 0] = "093"; Size3[1, 1] = "093"; Size3[1, 2] = "094"; 
        Size3[1, 3] = "096"; Size3[1, 4] = "098"; Size3[1, 5] = "100"; 
        Size3[1, 6] = "110"; Size3[1, 7] = "101"; Size3[1, 8] = "103";
        Size3[1, 9] = "104"; Size3[1, 10] = "101"; Size3[1, 11] = "102";
        Size3[1, 12] = "109"; Size3[1, 13] = "113"; Size3[1, 14] = "118";
        Size3[1, 15] = "118"; Size3[1, 16] = "116"; Size3[1, 17] = "124";
        Size3[1, 18] = "133"; Size3[1, 19] = "111"; Size3[1, 20] = "124";
        Size3[1, 21] = "136"; Size3[1, 22] = "149";

        Size3[2, 0] = "093"; Size3[2, 1] = "093"; Size3[2, 2] = "094";
        Size3[2, 3] = "096"; Size3[2, 4] = "098"; Size3[2, 5] = "100";
        Size3[2, 6] = "110"; Size3[2, 7] = "101"; Size3[2, 8] = "103";
        Size3[2, 9] = "104"; Size3[2, 10] = "101"; Size3[2, 11] = "102";
        Size3[2, 12] = "109"; Size3[2, 13] = "113"; Size3[2, 14] = "118";
        Size3[2, 15] = "118"; Size3[2, 16] = "116"; Size3[2, 17] = "124";
        Size3[2, 18] = "133"; Size3[2, 19] = "111"; Size3[2, 20] = "124";
        Size3[2, 21] = "136"; Size3[2, 22] = "149";

        Size3[3, 0] = "093"; Size3[3, 1] = "093"; Size3[3, 2] = "094";
        Size3[3, 3] = "096"; Size3[3, 4] = "098"; Size3[3, 5] = "100";
        Size3[3, 6] = "110"; Size3[3, 7] = "101"; Size3[3, 8] = "103";
        Size3[3, 9] = "104"; Size3[3, 10] = "101"; Size3[3, 11] = "102";
        Size3[3, 12] = "109"; Size3[3, 13] = "113"; Size3[3, 14] = "118";
        Size3[3, 15] = "118"; Size3[3, 16] = "116"; Size3[3, 17] = "124";
        Size3[3, 18] = "133"; Size3[3, 19] = "111"; Size3[3, 20] = "124";
        Size3[3, 21] = "136"; Size3[3, 22] = "149";

        Size3[4, 0] = "093"; Size3[4, 1] = "093"; Size3[4, 2] = "094";
        Size3[4, 3] = "096"; Size3[4, 4] = "098"; Size3[4, 5] = "100";
        Size3[4, 6] = "110"; Size3[4, 7] = "101"; Size3[4, 8] = "103";
        Size3[4, 9] = "104"; Size3[4, 10] = "101"; Size3[4, 11] = "102";
        Size3[4, 12] = "109"; Size3[4, 13] = "113"; Size3[4, 14] = "118";
        Size3[4, 15] = "118"; Size3[4, 16] = "116"; Size3[4, 17] = "124";
        Size3[4, 18] = "133"; Size3[4, 19] = "111"; Size3[4, 20] = "124";
        Size3[4, 21] = "136"; Size3[4, 22] = "149";

        Size3[5, 0] = "093"; Size3[5, 1] = "093"; Size3[5, 2] = "094";
        Size3[5, 3] = "096"; Size3[5, 4] = "098"; Size3[5, 5] = "100";
        Size3[5, 6] = "110"; Size3[5, 7] = "101"; Size3[5, 8] = "103";
        Size3[5, 9] = "104"; Size3[5, 10] = "101"; Size3[5, 11] = "102";
        Size3[5, 12] = "109"; Size3[5, 13] = "113"; Size3[5, 14] = "118";
        Size3[5, 15] = "118"; Size3[5, 16] = "116"; Size3[5, 17] = "124";
        Size3[5, 18] = "133"; Size3[5, 19] = "111"; Size3[5, 20] = "124";
        Size3[5, 21] = "136"; Size3[5, 22] = "149";

        //Folders
        Folders.Add("StrainImages/Outfit1"); 
        Folders.Add("StrainImages/Outfit2"); 
        Folders.Add("StrainImages/Outfit3"); 
        Folders.Add("StrainImages/Outfit4");
        Folders.Add("StrainImages/Outfit5");
        Folders.Add("StrainImages/Outfit6");

        //Size1-garment bust
        GarmentSize1[0, 0] = "098"; 
        GarmentSize1[1, 0] = "084";
        GarmentSize1[2, 0] = "090";
        GarmentSize1[3, 0] = "108";
        GarmentSize1[4, 0] = "106";
        GarmentSize1[5, 0] = "102";
        //Size2-garment waist
        GarmentSize2[0, 0] = "072"; 
        GarmentSize2[1, 0] = "065";
        GarmentSize2[2, 0] = "068";
        GarmentSize2[3, 0] = "062";
        GarmentSize2[4, 0] = "102";
        GarmentSize2[5, 0] = "076";
        //Size3-garment hips
        GarmentSize3[0, 0] = "124"; 
        GarmentSize3[1, 0] = "099";
        GarmentSize3[2, 0] = "100";
        GarmentSize3[3, 0] = "095";
        GarmentSize3[4, 0] = "105";
        GarmentSize3[5, 0] = "128";
        //
    }
    void LoadStrainMapSprites(int i)
    {
        StrainMap.Clear();
        object[] objects = Resources.LoadAll(Folders[i], typeof(Sprite));
        Debug.Log(Folders[i]);
        for (int j = 0; j < objects.Length; j++)
        {
            StrainMap.Add(objects[j] as Sprite);
        }
    }

    public void ShowDataOutfit(int i, float y)
    {
        Debug.Log(i);
        if (i==5) { SizeLabel.SetText("L"); } else { SizeLabel.SetText("M"); }
        LoadStrainMapSprites(i);
        //
        int c = (int)y;
        //
        BodyShapeName.SetText(BodyShapeNames[c]);
        //
        string text1 = Size1[i, c];
        string[] characters1 = new string[text1.Length];
        for (int k = 0; k < text1.Length; k++)
        {
            characters1[k] = System.Convert.ToString(text1[k]);
        }
        Size1TextA.SetText(characters1[0]);
        Size1TextB.SetText(characters1[1]);
        Size1TextC.SetText(characters1[2]);

        string text2 = Size2[i, c];
        string[] characters2 = new string[text2.Length];
        for (int k = 0; k < text2.Length; k++)
        {
            characters2[k] = System.Convert.ToString(text2[k]);
        }
        Size2TextA.SetText(characters2[0]);
        Size2TextB.SetText(characters2[1]);
        Size2TextC.SetText(characters2[2]);

        string text3 = Size3[i, c];
        string[] characters3 = new string[text3.Length];
        for (int k = 0; k < text3.Length; k++)
        {
            characters3[k] = System.Convert.ToString(text3[k]);
        }
        Size3TextA.SetText(characters3[0]);
        Size3TextB.SetText(characters3[1]);
        Size3TextC.SetText(characters3[2]);

        StrainImageMap.sprite = StrainMap[c];

        int d = 0;
        string Gtext1 = GarmentSize1[i, d];
        string[] Gcharacters1 = new string[Gtext1.Length];
        for (int k = 0; k < Gtext1.Length; k++)
        {
            characters1[k] = System.Convert.ToString(Gtext1[k]);
        }
        GarmentSize1TextA.SetText(characters1[0]);
        GarmentSize1TextB.SetText(characters1[1]);
        GarmentSize1TextC.SetText(characters1[2]);

        string Gtext2 = GarmentSize2[i, d];
        string[] Gcharacters2 = new string[Gtext2.Length];
        for (int k = 0; k < Gtext2.Length; k++)
        {
            characters2[k] = System.Convert.ToString(Gtext2[k]);
        }
        GarmentSize2TextA.SetText(characters2[0]);
        GarmentSize2TextB.SetText(characters2[1]);
        GarmentSize2TextC.SetText(characters2[2]);

        string Gtext3 = GarmentSize3[i, d];
        string[] Gcharacters3 = new string[Gtext3.Length];
        for (int k = 0; k < Gtext3.Length; k++)
        {
            characters3[k] = System.Convert.ToString(Gtext3[k]);
        }
        GarmentSize3TextA.SetText(characters3[0]);
        GarmentSize3TextB.SetText(characters3[1]);
        GarmentSize3TextC.SetText(characters3[2]);
    }
}
