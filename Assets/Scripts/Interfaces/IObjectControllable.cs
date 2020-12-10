using System.Collections;
using UnityEngine;

public interface IObjectControllable{
    void ChangeColor(Color color);
    void ChangeLift(float lift);
    void ChangeRotation(float rotation);
    void ChangeScale(float scale);
}
