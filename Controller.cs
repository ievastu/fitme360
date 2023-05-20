using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public int fit = 1;
    public float shape;
    int shapeGet;
    public GameObject RotationSlider_Developed;
    public GameObject ShapeSlider_Developed;
    public GameObject AnimationOBJ;
    //
    public GameObject AnimationBlock;
    public List<GameObject> AnimationOBJs = new List<GameObject>();
    public List<Animator> Animations = new List<Animator>();
    public List<string> AnimationsNames = new List<string>();
    Animator anim;
    //
    public GameObject Panel;
    //
    public Toggle Outfit01;
    public Toggle Outfit02;
    public Toggle Outfit03;
    public Toggle Outfit04;
    public Toggle Outfit05;
    public Toggle Outfit06;//L
    public Toggle Outfit07;//M
    //
    float lastframe = 0;
    void ShowAdditionToggles() { Outfit06.interactable = true;  }
    void HideAdditionToggles() { Outfit06.interactable = false;  }
    void HideFit(bool State, int fit)
    {
        if (fit == 1)
        {
            for (int y = 0; y < 23; y++)
            {
                AnimationOBJs[y].gameObject.SetActive(State);
            }
        }
        if (fit == 2)
        {
            for (int y = 23; y < 46; y++)
            {
                AnimationOBJs[y].gameObject.SetActive(State);
            }
        }
        if (fit == 3)
        {
            for (int y = 46; y < 69; y++)
            {
                AnimationOBJs[y].gameObject.SetActive(State);
            }
        }
        if (fit == 4)
        {
            for (int y = 69; y < 92; y++)
            {
                AnimationOBJs[y].gameObject.SetActive(State);
            }
        }
        if (fit == 5)
        {
            for (int y = 92; y < 115; y++)
            {
                AnimationOBJs[y].gameObject.SetActive(State);
            }
        }
        if (fit == 6)
        {
            for (int y = 115; y < 138; y++)
            {
                AnimationOBJs[y].gameObject.SetActive(State);
            }
        }
    }

    void HoldState()
    {
        float value = ShapeSlider_Developed.GetComponent<RadialSlider>().GetValue;
        OnShapeSliderValueChanged(value);
    }
    public void ShowFit1()
    {
        if (Outfit01.GetComponent<Toggle>().isOn == true)
        {
            fit = 1;
            ShowAdditionToggles();
            GetValueShape();
            HideFit(true, 1);
            HideFit(false, 2);
            HideFit(false, 3);
            HideFit(false, 4);
            HideFit(false, 5);
            HideFit(false, 6);
            HoldState();
        }
    }

    public void ShowFit2()
    {
        if (Outfit02.GetComponent<Toggle>().isOn == true)
        {
            fit = 2;
            HideAdditionToggles(); Outfit07.isOn = true;
            GetValueShape();
            HideFit(true, 2);
            HideFit(false, 1);
            HideFit(false, 3);
            HideFit(false, 4);
            HideFit(false, 5);
            HideFit(false, 6);
            HoldState();
        }
    }

    public void ShowFit3()
    {
        if (Outfit03.GetComponent<Toggle>().isOn == true)
        {
            HideAdditionToggles(); Outfit07.isOn = true;
            fit = 3;
            GetValueShape();
            HideFit(true, 3);
            HideFit(false, 1);
            HideFit(false, 2);
            HideFit(false, 4);
            HideFit(false, 5);
            HideFit(false, 6);
            HoldState();
        }
    }
    public void GetValueShape() 
    {
        shapeGet = (int)ShapeSlider_Developed.GetComponent<RadialSlider>().GetValue;
    }
    public void ShowFit4()
    {
        if (Outfit04.GetComponent<Toggle>().isOn == true)
        {
            HideAdditionToggles(); Outfit07.isOn = true;
            GetValueShape();
            fit = 4;
            HideFit(true, 4);
            HideFit(false, 1);
            HideFit(false, 2);
            HideFit(false, 3);
            HideFit(false, 5);
            HideFit(false, 6);
            HoldState();
        }
    }
    public void ShowFit5()
    {
        if (Outfit05.GetComponent<Toggle>().isOn == true)
        {
            HideAdditionToggles(); Outfit07.isOn = true;
            GetValueShape();
            fit = 5;
            HideFit(true, 5);
            HideFit(false, 1);
            HideFit(false, 2);
            HideFit(false, 3);
            HideFit(false, 4);
            HideFit(false, 6);
            HoldState();
        }
    }
    public void ShowFit6()
    {
        if (Outfit06.GetComponent<Toggle>().isOn == true)
        {
            GetValueShape();
            fit = 6;
            HideFit(true, 6);
            HideFit(false, 1);
            HideFit(false, 2);
            HideFit(false, 3);
            HideFit(false, 4);
            HideFit(false, 5);
            HoldState();
        }
    }
    private void Awake()
    {
        AssignAnimationOBJs();
    }
    void AssignAnimationOBJs()
    {
        for (int i = 0; i < AnimationBlock.transform.childCount; i++)
        {
            AnimationOBJs.Add(AnimationBlock.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < AnimationOBJs.Count; i++)
        {
            Animations.Add(AnimationOBJs[i].GetComponent<Animator>());
            Animations[i].speed = 0f;
        }
        
        for (int i = 0; i < AnimationOBJs.Count; i++)
        {
            AnimationsNames.Add(AnimationOBJs[i].gameObject.name);
        }
    }
    private void Start()
    {

        Outfit01.isOn = true;
        fit = 1;
        ShowFit1();
    }
    void SetToLastFrame(int x)
    {
        int add = 0;
        if (Outfit01.isOn == true && fit != 6) { add = 0; }
        if (Outfit02.isOn == true && fit != 6) { add = 23; }
        if (Outfit03.isOn == true && fit != 6) { add = 46; }
        if (Outfit04.isOn == true && fit != 6) { add = 69; }
        if (Outfit05.isOn == true && fit != 6) { add = 92; }
        if (Outfit06.isOn == true && fit!=1) { add = 115; }
        Animations[x+add] = AnimationOBJs[x+add].GetComponent<Animator>();
        Animations[x+add].speed = 0f;
        Animations[x+add].Play(AnimationsNames[x+add], 0, lastframe);
    }
    public void OnRotationSliderValueChanged(float frame) {
        lastframe = frame;
        if (Outfit01.isOn == true)
        {
            if(fit!=6)
            { 
            //fit1
            int shapes = (int)shapeGet+1;
            for (int x = shapes - 1; x < (shapes); x++)
            {
                Animations[x] = AnimationOBJs[x].GetComponent<Animator>();
                Animations[x].speed = 0f;
                Animations[x].Play(AnimationsNames[x], 0, frame);

            }
            }
        }
        if (Outfit02.isOn == true)
        {
            //fit2
            int shapes = (int)shapeGet+1;
            for (int x = shapes+22; x < (shapes+23); x++)
            {
                Animations[x] = AnimationOBJs[x].GetComponent<Animator>();
                Animations[x].speed = 0f;
                Animations[x].Play(AnimationsNames[x], 0, frame);
            }
        }
        if (Outfit03.isOn == true)
        {
            //fit3
            int shapes = (int)shapeGet+1;
            for (int x = shapes + 45; x < (shapes + 46); x++)
            {
                Animations[x] = AnimationOBJs[x].GetComponent<Animator>();
                Animations[x].speed = 0f;
                Animations[x].Play(AnimationsNames[x], 0, frame);
            }
        }
        if (Outfit04.isOn == true)
        {
            //fit4
            int shapes = (int)shapeGet+1;
            for (int x = shapes + 68; x < (shapes + 69); x++)
            {
                Animations[x] = AnimationOBJs[x].GetComponent<Animator>();
                Animations[x].speed = 0f;
                Animations[x].Play(AnimationsNames[x], 0, frame);
            }
        }
        if (Outfit05.isOn == true)
        {
            //fit5
            int shapes = (int)shapeGet+1;
            for (int x = shapes + 91; x < (shapes + 92); x++)
            {
                Animations[x] = AnimationOBJs[x].GetComponent<Animator>();
                Animations[x].speed = 0f;
                Animations[x].Play(AnimationsNames[x], 0, frame);
            }
        }
        if (Outfit06.isOn == true)
        {
            //fit6
            int shapes = (int)shapeGet+1;
            for (int x = shapes + 114; x < (shapes + 115); x++)
            {
                Animations[x] = AnimationOBJs[x].GetComponent<Animator>();
                Animations[x].speed = 0f;
                Animations[x].Play(AnimationsNames[x], 0, frame);
            }
        }
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnShapeSliderValueChanged(float shape) {
        //fit1
        shapeGet = (int)shape;
        SetToLastFrame(shapeGet);
        int newShape = (int)shape+1;
        if (Outfit01.isOn == true && fit!=6)
        {
            AnimationOBJs[newShape - 1].transform.SetAsLastSibling(); 
        }
        //fit2
        if (Outfit02.isOn == true)
        {
            AnimationOBJs[newShape + 22].transform.SetAsLastSibling();
        }
        //fit3
        if (Outfit03.isOn == true)
        {
            AnimationOBJs[newShape + 45].transform.SetAsLastSibling();
        }
        //fit4
        if (Outfit04.isOn == true)
        {
            AnimationOBJs[newShape + 68].transform.SetAsLastSibling();
        }
        //fit5
        if (Outfit05.isOn == true)
        {
            AnimationOBJs[newShape + 91].transform.SetAsLastSibling();
        }
        //fit6
        if (Outfit06.isOn == true)
        {
            AnimationOBJs[newShape + 114].transform.SetAsLastSibling();
        }

        GameObject.Find("InfoManager").GetComponent<InfoController>().ShowDataOutfit(fit-1,shape);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
