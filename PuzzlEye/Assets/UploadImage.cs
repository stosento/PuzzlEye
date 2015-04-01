using UnityEngine;
using System.Windows.Forms;
using System.Collections;

public class UploadImage : MonoBehaviour {

	public static string FinalPath;

	public void ImageDialog() {
		var dialog = new OpenFileDialog();
		dialog.InitialDirectory = "%PICTURES%";
		dialog.Filter = "Image Files|(*.jpg;*.png;*.jpeg)";
		dialog.Title = "Select a picture for your puzzle";
		dialog.Multiselect = false;
		dialog.ShowDialog ();
		var path = dialog.FileName;

		if (path != null) {
			FinalPath = path;
		}
	}

}
