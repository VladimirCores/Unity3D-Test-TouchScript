using UnityEngine;
using System.Collections;
using TouchScript.Events;
using TouchScript.Gestures;

public class RotatePlanet : MonoBehaviour {

	// Use this for initialization

    public Vector2 speedMultiplier = new Vector2( 15, 15 );

	void Start () {
        if ( GetComponent<PanGesture>() != null ) GetComponent<PanGesture>().StateChanged += OnStateChanged;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void onPress(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
    {

    }

    private void OnStateChanged(object sender, GestureStateChangeEventArgs e)
    {
        var target = sender as PanGesture;
        switch ( e.State )
        {
            case Gesture.GestureState.Began: 
                break;
            case Gesture.GestureState.Changed:
                this.transform.rotation = Quaternion.Euler(
                                                            -target.LocalDeltaPosition.y * speedMultiplier.x,
                                                            target.LocalDeltaPosition.x * speedMultiplier.y,
                                                            0
                                                            ) * this.transform.rotation;
              
                break;
            case Gesture.GestureState.Ended:
                break;
        }
    }
}
