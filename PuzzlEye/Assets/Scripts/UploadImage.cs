﻿using UnityEngine;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

public class UploadImage : MonoBehaviour {

	public static Texture2D FinalPath;
	public static List<string> Paths = new List<string>();

	public void ImageDialog() {
		FinalPath = new Texture2D(4, 4, TextureFormat.RGBA32, false);
		var dialog = new OpenFileDialog();
		dialog.InitialDirectory = "%PICTURES%";
		dialog.Filter = "Image Files(*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
		dialog.Title = "Select a picture for your puzzle";
		dialog.Multiselect = false;
		dialog.ShowDialog ();
		var path = dialog.FileName;

		if (path != null) {
			if (!Paths.Contains (path)) Paths.Add (path);
			var www = new WWW("file://" + path);
			www.LoadImageIntoTexture(FinalPath);
			AddTexture.Wait(www);
		}
	}
}
