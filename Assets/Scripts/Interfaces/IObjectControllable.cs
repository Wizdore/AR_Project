using System.Collections;
using UnityEngine;

public interface IObjectControllable{
    ObjectState GetObjectState();
    void SetObjectState(ObjectState objstate);
    void Select();
    void DeSelect();
    void ChangeColor(Color color);
    void ChangeLift(float lift);
    void ChangeRotation(float rotation);
    void ChangeScale(float scale);
}
