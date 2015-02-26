using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class ShadowHand: MonoBehaviour {
	private PXCUPipeline pp;
	private Texture2D handImage;
	private byte[] labelmap;
	
	public  Camera camera2;
	public  PXCMGesture.GeoNode[][] handData;
	public  Options options;
	
    void Start() {
		pp=new PXCUPipeline();
		
		int[] size=new int[2]{320,240};
		if (pp.Init(PXCUPipeline.Mode.GESTURE)) {
	        pp.QueryLabelMapSize(size);
	        print("LabelMap: width=" + size[0] + ", height=" + size[1]);
			labelmap=new byte[size[0]*size[1]];
		} else {
			options.SetMessage("Failed to detect the Creative* camera. Please plugin the camera and click restart.");
		}
		handImage=new Texture2D(size[0],size[1],TextureFormat.ARGB32,false);
		ZeroImage(handImage);
		handData=new PXCMGesture.GeoNode[2][];
		handData[0]=new PXCMGesture.GeoNode[6];
		handData[1]=new PXCMGesture.GeoNode[6];
    }
    
    void OnDisable() {
		if (pp==null) return;
		pp.Dispose();
		pp=null;
    }

    void OnGUI () {
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height), handImage, ScaleMode.StretchToFill);
    }
	
	void Update() {
		if (pp!=null) {
			if (pp.AcquireFrame(false)) {
				options.SetMessage(pp.IsDisconnected()?"Camera unplugged? Please replugin the camera to the same USB port. Thanks.":null);
				
				int[] labels=new int[3]{0,256,256};
				pp.QueryLabelMap(labelmap,labels);
			    Color32[] pixels=handImage.GetPixels32(0);
				for (int y=0, yy1=0, yy2=(handImage.height-1)*handImage.width;y<handImage.height;y++,yy1+=handImage.width,yy2-=handImage.width) {
					for (int x=0;x<handImage.width;x++) {
						int pixel=labelmap[yy1+x];
						pixels[yy2+(handImage.width-1-x)]=new Color32(0,0,0,(byte)((pixel==labels[1] || pixel==labels[2])?160:0));
					}
				}
		        handImage.SetPixels32 (pixels, 0);
				handImage.Apply();
				
				pp.QueryGeoNode(PXCMGesture.GeoNode.Label.LABEL_BODY_HAND_SECONDARY,handData[0]);
				pp.QueryGeoNode(PXCMGesture.GeoNode.Label.LABEL_BODY_HAND_PRIMARY,handData[1]);
				
				pp.ReleaseFrame();
			}
		}
	}
	
	public Vector3 MapCoordinates(PXCMPoint3DF32 pos1) {
		Vector3 pos2=camera2.ViewportToWorldPoint(new Vector3((float)(handImage.width-1-pos1.x)/handImage.width,(float)(handImage.height-1-pos1.y)/handImage.height,0));
		pos2.z=0;
		return pos2;
	}
	
	private void ZeroImage(Texture2D image) {
		Color32[] pixels=image.GetPixels32(0);
		for (int x=0;x<image.width*image.height;x++) pixels[x]=new Color32(255,255,255,128);
	    image.SetPixels32(pixels, 0);
		image.Apply();
	}
}
