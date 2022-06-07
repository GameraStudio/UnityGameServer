using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axis {xAxis,yAxis,zAxis}
public class MirrorConverter 
{

    public static Vector3 MirrorVector3(Vector3 vector3,Axis axis)
    {
        switch (axis)
        {
            case Axis.xAxis:
                return new Vector3(vector3.x, -vector3.y, -vector3.z);
            case Axis.yAxis:
                return new Vector3(-vector3.x, vector3.y, -vector3.z);
            case Axis.zAxis:
                return new Vector3(-vector3.x, -vector3.y, vector3.z);
            default:
                return new Vector3(vector3.x, vector3.y, vector3.z);

        }
    }

    //public static Quaternion MirrorQuaternion(Quaternion rotation, Axis axis)
    //{
    //    switch (axis)
    //    {
            
    //        case Axis.xAxis:
    //            return new Quaternion(vector3.x, -vector3.y, -vector3.z);
    //        case Axis.yAxis:
    //            return new Vector3(-vector3.x, vector3.y, -vector3.z);
    //        case Axis.zAxis:
    //            return new Vector3(-vector3.x, -vector3.y, vector3.z);
    //        default:
    //            return new Vector3(vector3.x, vector3.y, vector3.z);

    //    }
    //}
}
