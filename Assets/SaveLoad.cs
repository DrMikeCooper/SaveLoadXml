using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class SaveLoad : MonoBehaviour {

    Saveable[] saveables;

	// Use this for initialization
	void Start () {
        saveables = GameObject.FindObjectsOfType<Saveable>();	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F1))
            Save();
        if (Input.GetKeyDown(KeyCode.F2))
            Load();
	}

    void Save()
    {
        XDocument document = new XDocument();
        XElement root = new XElement("Saveables");
        foreach (Saveable s in saveables)
        {
            root.Add(s.OnSave());
        }
        document.Add(root);
        document.Save("savegame.xml");
    }

    void Load()
    {
        XElement root = XElement.Load("savegame.xml");
        foreach (Saveable s in saveables)
        {
            XElement el = root.Element(s.name);
            if (el != null)
                s.OnLoad(el);
        }

    }
}
