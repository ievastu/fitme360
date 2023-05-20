using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZoomController : MonoBehaviour
{
    public GameObject OutfitObject;
    Vector3 TempScale;

    RectTransform TempRectTransform;
    public RectTransform OutfitObjectRF;
    bool ZoomInTopActivated = false;
    bool ZoomInBottomActivated = false;
    Vector3 StepZoom;
    float stepMoveVertical = 0.005f;
    float stepMoveHorizontal = 0.015f;
    float step = 0.2f;
    public List<Button> Buttons = new List<Button>();
    public List<Button> ZoomButtons = new List<Button>();
    float limitXMin = 0.49f;
    float limitXMax = 0.51f;
    float limitYMin = 0;
    float limitYMax = 0;
    void ActivateMovement() { for (int i=0;i<Buttons.Count;i++) { Buttons[i].interactable = true; } }
    void DeactivateMovement() { for (int i = 0; i < Buttons.Count; i++) { Buttons[i].interactable = false; } }

    void ActivateMovementZoom() { for (int i = 0; i < ZoomButtons.Count; i++) { ZoomButtons[i].interactable = true; } }
    void DeactivateMovementZoom() { for (int i = 0; i < ZoomButtons.Count; i++) { ZoomButtons[i].interactable = false; } }


    private void Start()
    {
        TempRectTransform = OutfitObjectRF; 
        TempScale = OutfitObject.transform.localScale;
        StepZoom = OutfitObject.transform.localScale;
        DeactivateMovement(); DeactivateMovementZoom();
    }
    public void Default()
    {
        OutfitObjectRF.pivot = TempRectTransform.pivot; ZoomOut();
    }
    public void StepRight()
    {
        if ((OutfitObjectRF.pivot.x-stepMoveVertical)>=limitXMin)
        {
            float x = OutfitObjectRF.pivot.x;
            x = x - stepMoveVertical;
            float y = OutfitObjectRF.pivot.y;
            OutfitObjectRF.pivot = new Vector2(x, y);
        }
    }
    public void StepLeft() 
    {
        if ((OutfitObjectRF.pivot.x + stepMoveVertical) <= limitXMax)
        {
            float x = OutfitObjectRF.pivot.x;
            x = x + stepMoveVertical;
            float y = OutfitObjectRF.pivot.y;
            OutfitObjectRF.pivot = new Vector2(x, y);
        }
    }
    public void StepUp() 
    {
        if ((OutfitObjectRF.pivot.y + stepMoveHorizontal) <= limitYMax)
        {
            float x = OutfitObjectRF.pivot.x;
            float y = OutfitObjectRF.pivot.y;
            y = y + stepMoveHorizontal;
            OutfitObjectRF.pivot = new Vector2(x, y);
        }
    }
    public void StepDown() 
    {
        if ((OutfitObjectRF.pivot.y - stepMoveHorizontal) >= limitYMin)
        {
            float x = OutfitObjectRF.pivot.x;
            float y = OutfitObjectRF.pivot.y;
            y = y - stepMoveHorizontal;
            OutfitObjectRF.pivot = new Vector2(x, y);
        }
    }
    public void ZoomInStep()
    {
        StepZoom = OutfitObject.transform.localScale;
        CheckZoomState();
        if ((StepZoom.x + step) <=4) 
        {
            StepZoom.x = StepZoom.x + step;
            StepZoom.y = StepZoom.y + step;
            StepZoom.z = StepZoom.z + step;
            OutfitObject.transform.localScale = StepZoom;
        }
    }
    void CheckZoomState()
    {
        if ((StepZoom.x + step) >= 4) { ZoomButtons[0].interactable = false; } else { ZoomButtons[0].interactable = true; }
        if ((StepZoom.x - step) <= 2.1) { ZoomButtons[1].interactable = false; } else { ZoomButtons[1].interactable = true; }
    }
    public void ZoomOutStep() 
    {
        StepZoom = OutfitObject.transform.localScale;
        CheckZoomState();
        if ((StepZoom.x - step) >= 2.1)
        {
            StepZoom.x = StepZoom.x - step;
            StepZoom.y = StepZoom.y - step;
            StepZoom.z = StepZoom.z - step;
            OutfitObject.transform.localScale = StepZoom;
        }
    }
    
    public void ZoomTop() { if (ZoomInTopActivated == false) { ZoomInTop(); } else { ZoomOut();  } }
    public void ZoomBottom() { if (ZoomInBottomActivated == false) { ZoomInBottom(); } else { ZoomOut(); } }
    void ZoomOut() 
    {
        OutfitObjectRF.pivot = new Vector2(0.5f, 0.5f); OutfitObject.transform.localScale = TempScale;
        ZoomInTopActivated = false; ZoomInBottomActivated = false;
        DeactivateMovement();
        DeactivateMovementZoom();
    }
    void ZoomInTop()
    {
        ActivateMovementZoom();
        limitYMin = 0.65f;
        limitYMax = 0.7f;
        OutfitObject.transform.localScale = new Vector3(2.5f,2.5f,2.5f); OutfitObjectRF.pivot = new Vector2(0.5f, 0.7f);
        ZoomInTopActivated = true; ZoomInBottomActivated = false;
        ActivateMovement();
    }
    void ZoomInBottom()
    {
        ActivateMovementZoom();
        limitYMin = 0.22f;
        limitYMax = 0.45f;
        OutfitObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f); OutfitObjectRF.pivot = new Vector2(0.5f, 0.35f);
        ZoomInBottomActivated = true; ZoomInTopActivated = false;
        ActivateMovement();
    }
}
