using UnityEngine;
using System.Collections;

public class RadialCutoutMenu : MonoBehaviour {

	public ApplicationModel.DiffictultyLevel DifficultyLevel;
	public AudioSource SelectSound;
	public Light MenuItemLamp;

	// How long to look at Menu Item before taking action
	public float timerDuration = 3f;
	
	// This value will count down from the duration
	private float lookTimer = 0f;
	
	// My renderer so I can set _Cutoff value
	private Renderer myRenderer;
	
	// Box Collider
	private BoxCollider myCollider;
	
	// Is player looking at me?
	private bool isLookedAt = false;
	
	// MonoBehaviour Start
	void Start() {
		MenuItemLamp.enabled = false;		
		// My Collider
		myCollider = GetComponent<BoxCollider>();
		// Get my Renderer
		myRenderer = GetComponent<Renderer>();
		// Set cutoff
		myRenderer.material.SetFloat("_Cutoff", 0f);
	}
	
	// MonoBehaviour Update
	void Update() {
		// While player is looking at me
		if (isLookedAt) {
			lookTimer += Time.deltaTime;
			
			myRenderer.material.SetFloat("_Cutoff", lookTimer / timerDuration);
			
			if (lookTimer > timerDuration) {
				lookTimer = 0f;
				myCollider.enabled = false;
				
				ApplicationModel.CurrentDifficultyLevel = DifficultyLevel;
				Application.LoadLevel (1);
				
				// Disappear
				//gameObject.SetActive(false);
			}    
		}  else {			
			lookTimer = 0f;
			myRenderer.material.SetFloat("_Cutoff", 0f);
		}
	}
		
	public void callLog() 
	{		
		if (! isLookedAt) {
			isLookedAt = true;
			MenuItemLamp.enabled = true;
			if (SelectSound) {
				SelectSound.Play ();		
			}

		} else {
			MenuItemLamp.enabled = false;
			isLookedAt = false;
		}
	}

	// Google Cardboard Gaze
	public void SetGazedAt(bool gazedAt) {
		Debug.Log("Gazing.");
		isLookedAt = gazedAt;
	}
}