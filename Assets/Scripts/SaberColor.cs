using UnityEngine;
using System.Collections;

public class SaberColor : MonoBehaviour {

	void Start () {
		var line = gameObject.GetComponent<VolumetricLines.VolumetricLineBehavior> ();
		switch (ApplicationModel.CurrentDifficultyLevel)
		{
			case ApplicationModel.DiffictultyLevel.EASY:
				line.LineColor = Color.green;
				break;
			case ApplicationModel.DiffictultyLevel.NORMAL:
				line.LineColor = Color.blue;
				break;
			case ApplicationModel.DiffictultyLevel.HARD:
				line.LineColor = Color.magenta;
				break;
			case ApplicationModel.DiffictultyLevel.TURBO:
				line.LineColor = Color.red;
				break;
		}

	}
}
