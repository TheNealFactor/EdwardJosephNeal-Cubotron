using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdwardJosephNeal
{
    public class GrabRotation : MonoBehaviour
    {
        Quaternion rotation;
        Vector3 position;
        private CubeSpawner spawner;
        // Start is called before the first frame update

        void Start()
        {
            spawner = Object.FindObjectOfType<CubeSpawner>();
        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = spawner.GetComponent<Transform>().rotation;
        }

    }
}
