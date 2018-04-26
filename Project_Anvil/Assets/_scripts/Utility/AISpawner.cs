using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour {

    ObjectPooler objectPooler;
    public GameObject spawningParent;
    public float x = 50; // x size or the area to spawn the units
    public float z = 50; // z size of the area to spawn the units
    public double prefabHeight;
    float offset;
    public int count = 100; // number of units to spawn
    float minDistance = 1.5f; // minimum proximity to one another
    List<Vector3> positions = new List<Vector3>();

    // Use this for initialization
    void Start () {
        spawningParent = GameObject.Find("Faction2");
        objectPooler = ObjectPooler.Instance;
        offset = x / 2;
    }
	
    // BeginPlacing //
    // loops through spawning the units in a randomly generated location
    public void BeginPlacing(double _prefabHeight)
    {
        prefabHeight = _prefabHeight;
        for(int j = 0; j < count; j++)
        {
            objectPooler.SpawnFromPool("AIUnit", PlaceStuffRandomly(), Quaternion.identity, gameObject);
        }
    }

    // PlaceStuffRandomly //
    // returns a new vector3 that is at least the minimum distance from other units
    public Vector3 PlaceStuffRandomly()
    {

        Vector3 newPos;
        bool Nope = false;

        // We want to place #count godly cubes
        for (int i = 0; i < count; i++)
        {

            do
            {
                //Pick a random new pos ...
                newPos = new Vector3(Random.value * x, 0, Random.value * z);
                
                // We have to ask mister perlin if he thinks this point is ok (And check distances)
                Nope = !(PerlinThinksItShouldBeThere(newPos) && CouldPlaceItThere(newPos));

            } while (Nope); // This loop will run endlessly, if you try to stuff too many things in a too small area
            newPos.x = newPos.x - offset;
            newPos.z = newPos.z - offset;
            newPos.y = newPos.y + (float)prefabHeight + 1; // +1 so that they display above the mesh, will (likely) change later
            positions.Add(newPos);
           // Debug.Log(newPos);
            return newPos;
        }
        return new Vector3(0, 0, 0);

    }
    // CouldPlaceItThere //
    // checks against the previously generated positions to make sure we arent placing two things on top of each other
    // returns false if the _newPos is too close and true if it isnt too close
    private bool CouldPlaceItThere(Vector3 _newPos)
    {
        // Loop through all positions where we already want to place something
        for (int i = 0; i < positions.Count; i++)
            if (Vector3.Distance(positions[i], _newPos) < minDistance) // ... and check if the new point maybe is to close
                return false;
        return true;
    }


    // PerlinThinksItShouldBeThere //
    // gets a perlin value using the new position. compares that to a random value [0 to 1] and if the perlin value is
    // greater than that random value there should be a unit spawned there so it returns true, false otherwise
    private bool PerlinThinksItShouldBeThere(Vector3 _newPos)
    {

        // Basically how fast perlin changes his mind when you ask him for nearby Points
        float frequency = .8f;

        // Lets ask him what he thinks of the current position
        float howSurePerlinIsThatItShouldBeThere = Mathf.PerlinNoise(_newPos.x / x * frequency, _newPos.z / z * frequency);

        if (Random.value <= howSurePerlinIsThatItShouldBeThere)
            return true;
        else
            return false;
    }
}
