using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace EdwardJosephNeal
{
    public class CubeSpawner : MonoBehaviour
    {
        ObjectPooler objectPooler;

        public Vector3 center;
        public Vector3 size;

        private Renderer m_Rend;
        private Transform m_Transform;

        public LayerField m_cubeLayer;

        private void Start()
        {
            Physics.IgnoreLayerCollision(2, 2, true);
            objectPooler = ObjectPooler.Instance;
            m_Transform = GetComponent<Transform>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            ObjectPooler.Instance.SpawnFromPool("Cube", Quaternion.identity);
        }

        public Vector3 CreateRandomPosition()
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            return pos;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = UnityEngine.Color.green;
            Gizmos.DrawWireCube(transform.localPosition + center, size);
        }
    }
}
