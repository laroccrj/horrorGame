using UnityEngine;
using System.Collections;

public class GUIScaler : object {
	
	float Pixels_Per_Unit = 0;
	
	public GUIScaler(float intensity){
		Pixels_Per_Unit = (float)Screen.width / intensity;
	}
	
	public Rect FormatRect(Rect rect) {
		rect.x *= Pixels_Per_Unit;
		rect.y *= Pixels_Per_Unit;
		rect.height *= Pixels_Per_Unit;
		rect.width *= Pixels_Per_Unit;
		
		return rect;
	}
	
}
