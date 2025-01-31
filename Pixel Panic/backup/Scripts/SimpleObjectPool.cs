﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// maintain a list of all inactive (available) game objects
/// </summary>
public class SimpleObjectPool : MonoBehaviour {

    // the prefab that this object pool returns instances of
    public GameObject prefab;
    // collection of currently inactive instances of the prefab
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    
    /// <summary>
    /// Returns an instance of the prefab 
    /// </summary>
    /// <returns></returns>
    public GameObject GetObject() {
        GameObject spawnedGameObject;

        // if there is an inactive instance of the prefab ready to return, return that
        if (inactiveInstances.Count > 0) {
            // remove the instance from teh collection of inactive instances
            spawnedGameObject = inactiveInstances.Pop();
        }
        // otherwise, create a new instance
        else {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

            // add the PooledObject component to the prefab so we know it came from this pool
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        // enable the instance
        spawnedGameObject.SetActive(true);

        // return a reference to the instance
        return spawnedGameObject;
    }

    
    /// <summary>
    /// Return an instance of the prefab to the pool
    /// </summary>
    /// <param name="toReturn">object to be available</param>
    public void ReturnObject(GameObject toReturn) {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        // if the instance came from this pool, return it to the pool
        if (pooledObject != null && pooledObject.pool == this) {
            // disable the instance
            toReturn.SetActive(false);

            // add the instance to the collection of inactive instances
            inactiveInstances.Push(toReturn);
        }
        // otherwise, just destroy it
        else {
            Debug.LogWarning(toReturn.name + " was returned to a pool it wasn't spawned from! Destroying.");
            Destroy(toReturn);
        }
    }
}


/// <summary>
/// a component that simply identifies the pool that a GameObject came from
/// </summary>
public class PooledObject : MonoBehaviour {
    public SimpleObjectPool pool;
}
