using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace EdwardJosephNeal
{
    public class Explosion : MonoBehaviour
    {
        public float m_ExplosionForce;
        public float m_Radius;
        public bool m_DrawRadius = true;
        public KeyCode m_Detonate;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(m_Detonate))
            {
                Knockedback();
            }
        }

        void Knockedback()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_Radius);

            foreach (Collider nearby in colliders)
            {
                Rigidbody rb = nearby.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(m_ExplosionForce, transform.position, m_Radius);
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            if (m_DrawRadius)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, m_Radius);
            }
            else
            {

            }
        }
    }
}
