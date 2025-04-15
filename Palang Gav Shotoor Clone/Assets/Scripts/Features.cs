using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Features
{
    public void Move(Transform objTransform, Vector3 direction, float speed)
    {
        objTransform.Translate(direction * speed * Time.deltaTime);
    }
    public void Laser(Transform objTransform, Vector3 direction, float speed)
    {
        objTransform.Translate(direction * speed * Time.deltaTime);
    }

}
