using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor {

   Spawner creator;

   void OnSceneGUI() {
        creator.UpdatePath ();
   }

   void OnEnable()
   {
       creator = (Spawner)target;
   }
}