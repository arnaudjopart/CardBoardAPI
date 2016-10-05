using UnityEngine;
using System.Collections;

public class MoveEvent : MonoBehaviour, IGvrGazeResponder {




	public delegate void MoveEventDelegate(bool _bool) ;
	public event MoveEventDelegate MoveEventHandler;

	// Use this for initialization

	void Awake(){
		m_rectTransform = GetComponent<RectTransform> ();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown(bool _bool){

		print ("Let's Move that way");
		MoveEventHandler(_bool);
	}

	public void OnGazeEnter(){


	}
	public void OnGazeExit(){


	}public void OnGazeTrigger(){
		//OnPointerDown();



	}

	private RectTransform m_rectTransform;

}
