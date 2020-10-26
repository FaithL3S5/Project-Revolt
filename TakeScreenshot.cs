using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class TakeScreenshot : MonoBehaviour {

	[SerializeField]
	public GameObject Blink;

	[SerializeField]
	public GameObject Canvas;

	int ButtonNumber = 1;

	private void Update()
	{
		if (Input.GetMouseButtonDown(ButtonNumber))
		{
			TakeAShot();
		}
	}

		public void TakeAShot()
	{
		
		StartCoroutine ("CaptureIt");
		

	}

	IEnumerator CaptureIt()
	{
		//clear the UI
		Canvas.SetActive(false);
		
		string folderPath = Directory.GetCurrentDirectory() + "/Screenshots/";

		//create ScreenShot folder
		if (!System.IO.Directory.Exists(folderPath))
		{
			System.IO.Directory.CreateDirectory(folderPath);
		}

		var screenshotName =
								"Screenshot_" +
								System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") +
								".png";
		ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
		Debug.Log(folderPath + screenshotName);

		
		yield return new WaitForEndOfFrame();
		
		Blink.SetActive(true);
		Canvas.SetActive(true);


		yield return new WaitForEndOfFrame();
		

		Blink.SetActive(false);
		

	}
	

}
/*
		if (true)
		{
			Canvas.SetActive(true);
		}*/

/*
		string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
		string fileName = "Screenshot" + timeStamp + ".png";
		string pathToSave = fileName;
		ScreenCapture.CaptureScreenshot(pathToSave);*/
//yield return new WaitForSeconds(1);