using UnityEngine;
using System.Collections;

public class ApplicationModel : MonoBehaviour {
	public enum DiffictultyLevel {EASY, NORMAL, HARD};
	public static DiffictultyLevel CurrentDifficultyLevel;
	public static bool ShootingAllowed = true;
}
