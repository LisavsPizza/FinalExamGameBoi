using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoomManager : MonoBehaviour {

    private static GameObject _currRoom;
    private List<GameObject> _allRooms;

	// Use this for initialization
	void Start () {
        _allRooms = new List<GameObject>();

        GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room").OrderBy(go => float.Parse(go.name.Substring(0, go.name.IndexOf(" ")))).ToArray();

        foreach (GameObject g in rooms)
        {
            _allRooms.Add(g);
        }

        _currRoom = _allRooms[0];

        foreach (GameObject g in _allRooms)
        {
            g.SetActive(false);
        }

        _currRoom.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeRoom(string name)
    {
        foreach (GameObject g in _allRooms)
        {
            if (g.name.ToUpper() == name.ToUpper())
            {
                _currRoom.SetActive(false);
                _currRoom = g;
                _currRoom.SetActive(true);
            }
        }
    }
}
