using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class FitMapHelpCotroller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject FitMapExplain;
    private void Start()
    {
        FitMapExplain.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        FitMapExplain.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        FitMapExplain.SetActive(false);
    }
}
