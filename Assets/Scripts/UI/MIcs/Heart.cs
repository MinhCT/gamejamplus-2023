using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.MIcs
{
    public class Heart : MonoBehaviour
    {
        public GameObject heartOn;
        

        public void Disable()
        {
            heartOn.SetActive(false);
        }

        public void Enable()
        {
            heartOn.SetActive(true);
        }
    }
}
