using UnityEngine;
using System.Collections;

namespace EdwardJosephNeal
{
    public class CubeData : MonoBehaviour
    {

        public Material m_fadeMat;
        public float m_CurrentFadeDuration;
        public float m_MinFadeDuration;
        public float m_MaxFadeDuration;
        private float m_LifeTimeDuration;

        public int m_MinScaleSize;
        public int m_MaxScaleSize;

        private Renderer m_Renderer;
        private CubeSpawner m_CubeSpawner;

        private Rigidbody m_Rigidbody;
        private Collider m_Collider;
        private float m_elapsedTime;
        // Start is called before the first frame update
        void Start()
        {

            m_fadeMat.SetFloat("Vector1_2F83A8A0", 1);
            Physics.IgnoreCollision(m_Collider, GetComponent<Collider>());

        }

        // Update is called once per frame
        void Update()
        {

            if (m_CurrentFadeDuration > 0)
            {
                m_CurrentFadeDuration -= Time.deltaTime;
                m_elapsedTime += Time.deltaTime;
                var percentageComplete = m_elapsedTime / m_LifeTimeDuration;
                var lerpValue = new Vector3(Mathf.Lerp(1, 0, percentageComplete), 0);
                m_fadeMat.SetFloat("Vector1_2F83A8A0", lerpValue.x);

            }

            if (m_CurrentFadeDuration <= 0)
            {

                this.gameObject.SetActive(false);
                this.gameObject.SetActive(true);

            }
        }

        void OnEnable()
        {

            InitCube();
            SetRandomColour();
            FadeSetup();


            m_Rigidbody.velocity = Vector3.zero;
            m_Rigidbody.angularVelocity = Vector3.zero;
            this.transform.position = m_CubeSpawner.transform.localPosition + m_CubeSpawner.CreateRandomPosition();
            this.transform.localScale = CreateRandomScale();

        }

        public Vector3 CreateRandomScale()
        {
            var randomRange = Random.Range(-m_MinScaleSize, m_MaxScaleSize);
            Vector3 newRandomScale = new Vector3(randomRange, randomRange, randomRange);
            return newRandomScale;
        }

        public void FadeSetup()
        {
            m_elapsedTime = 0;
            m_LifeTimeDuration = Random.Range(m_MinFadeDuration, m_MaxFadeDuration);
            m_CurrentFadeDuration = m_LifeTimeDuration;
        }

        public void SetRandomColour()
        {
            var randomColour = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            m_fadeMat.SetColor("Color_5331BFB6", randomColour);
        }

        public void InitCube()
        {
            m_CubeSpawner = FindObjectOfType<CubeSpawner>();
            m_Rigidbody = GetComponent<Rigidbody>();
            m_Renderer = GetComponent<Renderer>();
            m_Collider = GetComponent<Collider>();
            m_fadeMat = m_Renderer.material;
        }
    }
}

