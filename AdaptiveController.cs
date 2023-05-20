using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptiveController : MonoBehaviour
{
    public GameObject PanelLeft;
    public GameObject OutfitPanel;
    public GameObject FitMapPanel;
    public GameObject MeasurementsPanel;
    public GameObject PanelRight;
    public GameObject RightControlPanel;
    private void Start()
    {
        AdjustObjectWidth();
    }
    void AdjustObjectWidth()
    {
        float width = Screen.width;
        float height = Screen.height;
        float aspect = width/height;
        RectTransform rt = PanelLeft.GetComponent<RectTransform>();
        float percent = (aspect/ 1.778f);
        rt.sizeDelta = new Vector2(100*percent+((aspect-1)*width * 0.031f), 937);

        float value = ((100 * percent + ((aspect - 1) * width * 0.031f)) / 2);
        rt.anchoredPosition = new Vector2(value, 30);

        RectTransform rt2 = OutfitPanel.GetComponent<RectTransform>();
        rt2.anchoredPosition = new Vector2((value * 2 + 185 + 40), -290);

        RectTransform rt3 = FitMapPanel.GetComponent<RectTransform>();
        rt3.anchoredPosition = new Vector2((value * 2 + 180 + 30), 31);

        RectTransform rt4 = MeasurementsPanel.GetComponent<RectTransform>();
        rt4.anchoredPosition = new Vector2((value * 2 + 241 + 30), 38);

        RectTransform rt5 = PanelRight.GetComponent<RectTransform>();
        rt5.sizeDelta = new Vector2(100 * percent + ((aspect - 1) * width * 0.031f), 937); 
        rt5.anchoredPosition = new Vector2(-value, 30);

        RectTransform rt6 = RightControlPanel.GetComponent<RectTransform>();
        rt6.anchoredPosition = new Vector2((-(value * 2 + 123 + 10)), 27.5f);
    }
    private void Update()
    {
        if (Input.GetKeyDown("s")) { AdjustObjectWidth(); }
    }
}
