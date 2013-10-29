using UnityEngine;
using System.Collections;
using TouchScript.Events;
using TouchScript.Gestures;

public class GuiHandlers : MonoBehaviour {

    private GameObject goToRotate;

	// Use this for initialization
	void Start () {
        goToRotate = GameObject.Find( "Planet" );
        if ( GetComponent<TapGesture>() != null ) GetComponent<TapGesture>().StateChanged += onTap;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void onTap(object sender, GestureStateChangeEventArgs gestureStateChangeEventArgs)
    {
        if ( gestureStateChangeEventArgs.State == Gesture.GestureState.Recognized )
        {
            iTween.RotateTo( goToRotate, Random.rotation.eulerAngles, 2.0f );
            if (  this.name.IndexOf("red") > 0 )
            {
            
            }
            else if ( this.name.IndexOf( "blue" ) > 0 )
            {

            }
           
        }
    }
}
