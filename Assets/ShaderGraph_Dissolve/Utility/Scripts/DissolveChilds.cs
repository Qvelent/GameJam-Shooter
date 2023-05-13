using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace DissolveExample
{
    public class DissolveChilds : MonoBehaviour
    {
        // Start is called before the first frame update
        List<Material> materials = new List<Material>();

        bool PingPong = false;
        void Start()
        {
            var renders = GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renders.Length; i++)
            {
                materials.AddRange(renders[i].materials);
            }
        }

        private void Reset()
        {
            Start();
            SetValue(0);
        }

        // Update is called once per frame
        void Update()
        {

            //var value = Mathf.PingPong(Time.time * 0.5f, 1f);
           
        }

        //IEnumerator enumerator()
        //{

        //    //float value =         while (true)
        //    //{
        //    //    Mathf.PingPong(value, 1f);
        //    //    value += Time.deltaTime;
        //    //    SetValue(value);
        //    //    yield return new WaitForEndOfFrame();
        //    //}
        //}

        public void StartHideWall()
        {
            StartCoroutine(DisappearanceWall());
            GetComponent<Collider>().enabled = false;
        }

        public IEnumerator DisappearanceWall()
        {
            for (float t = 0; t < 1; t += Time.deltaTime)
            {
                SetValue(t);
                yield return null;
            }
        }

        public void SetValue(float value)
        {
            for (int i = 0; i < materials.Count; i++)
            {
                materials[i].SetFloat("_Dissolve", value);
            }
        }
    }
}