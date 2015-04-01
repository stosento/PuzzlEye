using UnityEngine;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

public class UploadImage : MonoBehaviour {

	public static string FinalPath;
	public static List<string> Paths = new List<string>();

	public void ImageDialog() {
		var dialog = new OpenFileDialog();
		dialog.InitialDirectory = "%PICTURES%";
		dialog.Filter = "Image Files(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
		dialog.Title = "Select a picture for your puzzle";
		dialog.Multiselect = false;
		dialog.ShowDialog ();
		var path = dialog.FileName;

		if (path != null) {
			FinalPath = path;
			if (!Paths.Contains (path)) Paths.Add (path);
		}
	}

}
