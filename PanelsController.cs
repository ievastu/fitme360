using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine.UI;
public class PanelsController : MonoBehaviour
{
    public List<GameObject> Panels = new List<GameObject>();
    bool OutfitActivated = false;
    bool MeasurementsActivated = false;
    bool FitMapsActivated = false;
    bool ShapesActivated = false;
    bool ZoomActivated = false;
    bool View360Activated = false;

    void ShowPanel(int i) { Panels[i].GetComponent<UIView>().Show(false);  }
    void ClosePanel(int i) { Panels[i].GetComponent<UIView>().Hide(false); }

    public void ManualActivatePanel() { ShowPanel(5); ShapesActivated = true; }
    public void ShowOutfits() { if (OutfitActivated==false) { ShowPanel(0); OutfitActivated = true; MeasurementsActivated = false; FitMapsActivated = false; } else { ClosePanel(0); OutfitActivated = false; MeasurementsActivated = false; FitMapsActivated = false; } }
    public void ShowMeasurements() { if (MeasurementsActivated == false) { ShowPanel(2); ShowPanel(1); MeasurementsActivated = true; OutfitActivated = false; FitMapsActivated = false; } else {ClosePanel(2); ClosePanel(1); MeasurementsActivated = false; OutfitActivated = false; FitMapsActivated = false; } }
    public void ShowFitMaps() { if (FitMapsActivated == false) { ShowPanel(3); ShowPanel(4); FitMapsActivated = true; MeasurementsActivated = false; OutfitActivated = false; } else { ClosePanel(3); ClosePanel(4); FitMapsActivated = false; MeasurementsActivated = false; OutfitActivated = false; } }
    //
    public void ShowBodyShapes() { if (ShapesActivated==false) { ShowPanel(5); ShapesActivated = true; } else { ClosePanel(5); ShapesActivated = false; } }
    public void ShowZoom() { if (ZoomActivated == false) { ShowPanel(6); ZoomActivated = true; } else { ClosePanel(6); ZoomActivated = false; } }
    public void Show360() { if (View360Activated == false) { ShowPanel(7); View360Activated = true; } else { ClosePanel(7); View360Activated = false; } }
}
