using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class Saveable : MonoBehaviour {

    public virtual void OnLoad(XElement el)
    {
    }

    public virtual XElement OnSave()
    {
        return new XElement("Empty");
    }

    // utility functions
    protected void SaveVector3(XElement el, string name, Vector3 p)
    {
        el.SetAttributeValue(name + "X", p.x);
        el.SetAttributeValue(name + "Y", p.y);
        el.SetAttributeValue(name + "Z", p.z);
    }

    protected Vector3 LoadVector3(XElement el, string name)
    {
        float x = float.Parse(el.Attribute(name + "X").Value);
        float y = float.Parse(el.Attribute(name + "Y").Value);
        float z = float.Parse(el.Attribute(name + "Z").Value);

        return new Vector3(x, y, z);
    }
}
