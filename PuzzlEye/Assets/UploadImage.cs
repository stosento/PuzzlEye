using UnityEngine;
using UnityEditor;
using System.Collections;

public class UploadImage : MonoBehaviour {

	public static string FinalPath;

	public void ImageDialog() {
		var path = EditorUtility.OpenFilePanel ("Select Image", "C:\\", "png");

		if (path != null) {
			FinalPath = path;
		}
	}

}
