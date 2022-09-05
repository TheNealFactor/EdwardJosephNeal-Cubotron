using UnityEngine;

namespace EdwardJosephNeal
{

    public class Rotate : MonoBehaviour
    {

        public Vector3 m_Rotation;
        public float m_Speed;


        // Update is called once per frame
        void Update()
        {
            RotateObject();
        }

        void RotateObject()
        {
            transform.Rotate(m_Rotation * m_Speed * Time.deltaTime);
        }
    }
}
