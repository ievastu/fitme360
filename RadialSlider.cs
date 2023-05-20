using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RadialSlider: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
	public RectTransform Knob;
	public int maxValue = 1;
	public bool WholeNumbers = false;
	public bool ShapeChange = false;
	public float GetValue=5;

	public void ManualknobPositions(int val)
	{
		Knob.transform.localEulerAngles = new Vector3(0, 0, (-0.04347826f*(val)) * 360);
		float val2 = (this.gameObject.GetComponent<Image>().fillAmount) * maxValue;
		GetValue = (val);
	}
	public void Rotate()
    {
		if ((this.gameObject.GetComponent<Image>().fillAmount * 360)<=360)
		{
			Knob.transform.localEulerAngles = new Vector3(0, 0, -this.gameObject.GetComponent<Image>().fillAmount * 360);
			float val = (this.gameObject.GetComponent<Image>().fillAmount)*maxValue;
			if (WholeNumbers == true) { val=Mathf.FloorToInt(val); }
            if (val<0) { val = 0; } if (val > maxValue) { val = maxValue; }
            if (ShapeChange == false) { GameObject.Find("AnimationsController").GetComponent<Controller>().OnRotationSliderValueChanged(val); }
			if (ShapeChange == true)
			{
				GameObject.Find("AnimationsController").GetComponent<Controller>().OnShapeSliderValueChanged(val); 
				GetValue = (val); 
			}		
		}
    }
	bool isPointerDown=false;
	public void OnPointerEnter( PointerEventData eventData )
	{
		StartCoroutine( "TrackPointer" );            
	}
	public void OnPointerExit( PointerEventData eventData )
	{
		StopCoroutine( "TrackPointer" );
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		isPointerDown= true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isPointerDown= false;
	}
	IEnumerator TrackPointer()
	{
		var ray = GetComponentInParent<GraphicRaycaster>();
		var input = FindObjectOfType<StandaloneInputModule>();		
		if( ray != null && input != null )
		{
			while( Application.isPlaying )
			{                    
				if (isPointerDown)
				{
					Vector2 localPos; 
					RectTransformUtility.ScreenPointToLocalPointInRectangle( transform as RectTransform, Input.mousePosition, ray.eventCamera, out localPos );
					float angle = (Mathf.Atan2(-localPos.y, localPos.x)*180f/Mathf.PI+180f)/360f;
					GetComponent<Image>().fillAmount = angle;
					Rotate();
				}
				yield return 0;
			}        
		}
		else
			UnityEngine.Debug.LogWarning( "Could not find GraphicRaycaster and/or StandaloneInputModule" );        
	}
}
