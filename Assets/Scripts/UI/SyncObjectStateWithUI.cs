using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyncObjectStateWithUI : MonoBehaviour
{
    IObjectControllable currentObject;

    //-------- UI TO OBJECT BINDING -------------//
    [Header("UI Controls")]
    [SerializeField] [Range(0f, 1f)] float lift;
    [SerializeField] [Range(0f, 1f)] float rotation;
    [SerializeField] [Range(0f, 1f)] float scale;
    [SerializeField] Color color;

    public void SetCurrentObject(GameObject obj)
    {
        var controllable = obj.GetComponent<IObjectControllable>();
        if (controllable != null)
        {
            currentObject = controllable;
            SetUIValues();
        }
    }

    public float Lift {
        get => lift;
        set { 
            lift = value;
            currentObject.ChangeLift(value);
        } 
    }
    public float Rotation { 
        get => rotation;
        set {
            rotation = value;
            currentObject.ChangeRotation(value);
        } 
    }

    public float Scale { 
        get => scale; 
        set { 
            scale = value;
            currentObject.ChangeScale(value);
        } 
    }
    public Color Color { 
        get => color; 
        set { 
            if(currentObject != null)
            {
                color = value;
                currentObject.ChangeColor(value);
            }
        }
    }


    //-------- OBJECT TO UI BINDING -------------//

    public Slider liftSlider, rotationSlider, scaleSlider;
    void SetUIValues()
    {
        ObjectState objectState = currentObject.GetObjectState();
        liftSlider.value = objectState.lift;
        rotationSlider.value = objectState.rotation;
        scaleSlider.value = objectState.scale;
    }
}
