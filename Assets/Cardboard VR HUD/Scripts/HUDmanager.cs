using UnityEngine;
using System.Collections;

public class HUDGame : MonoBehaviour {

	// Use this for initialization
	public Animator HitCanvas;
	public UnityEngine.UI.Slider healthSLD,ammoSLD;
	public UnityEngine.UI.Image[] ammoImg,healthImg;
	public Canvas LeftCanvas;
	public Camera rightCam;

	Canvas RightCanvas;

	void Start () 
	{
		// WE NEED TO DUPLICATE CANVAS BUT ATTACHED TO THE RIGHT CANVAS
		RightCanvas= GameObject.Instantiate(LeftCanvas) as Canvas;
		RightCanvas.worldCamera=rightCam;
		RightCanvas.transform.parent=transform;
		RightCanvas.name="HUDRight";

		ammoImg[1]=RightCanvas.transform.GetChild(2).GetComponent<UnityEngine.UI.Image>();
		healthImg[1]=RightCanvas.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>();


	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
			
	}


	public void getHit()
	{
		HitCanvas.SetTrigger("GetHit");
	}

	public void updateHealthSLD()
	{
		for(int jj=0;jj<2;jj++)
		{
			healthImg[jj].fillAmount=healthSLD.value;
		}
	}

	public void updateAmmo()
	{
		for(int jj=0;jj<2;jj++)
		{
			ammoImg[jj].fillAmount=ammoSLD.value;
		}
	}


}
