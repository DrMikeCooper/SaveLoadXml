using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class Capsule : Saveable {
    // Update is called once per frame

    Vector3 dir;

    void Start()
    {
        StartCoroutine(Wander());
    }


	void Update () {
        transform.position += dir * Time.deltaTime;
	}

    IEnumerator Wander()
    {
        while (true)
        {
            float angle = Random.Range(0, 360);
            dir = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            yield return new WaitForSeconds(2);
        }
    }

    public override void OnLoad(XElement el)
    {
        transform.position = LoadVector3(el, "pos");
        dir = LoadVector3(el, "dir");
    }

    public override XElement OnSave()
    {
        XElement el = new XElement(name);
        SaveVector3(el, "pos", transform.position);
        SaveVector3(el, "dir", dir);
        return el;
    }

    /*public override void OnLoad(XElement el)
    {
        float x = float.Parse(el.Attribute("X").Value);
        float y = float.Parse(el.Attribute("Y").Value);
        float z = float.Parse(el.Attribute("Z").Value);

        transform.position = new Vector3(x, y, z);
    }

    public override XElement OnSave()
    {
        XElement el = new XElement(name);
        el.SetAttributeValue("X", transform.position.x);
        el.SetAttributeValue("Y", transform.position.y);
        el.SetAttributeValue("Z", transform.position.z);

        return el;
    }*/
}
