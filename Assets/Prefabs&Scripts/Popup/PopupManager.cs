using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interview
{
    public class PopupManager : MonoBehaviour
    {
        public static PopupManager I;
        
        public void Awake()
        {
            if (I != null)
            {
                Destroy(gameObject);
                return;
            }
            
            I = this;
            DontDestroyOnLoad(gameObject);
        }

        public List<Popup> lstPopups;
        private List<Popup> showingPopups = new List<Popup>();
        [SerializeField] private Transform popPos;

        public T Show<T>() where T : Popup
        {
            T pop = null;
            if (showingPopups.Count > 0 && showingPopups.Find(x => x is T))
            {
                pop = showingPopups.Find(x => x is T) as T;
                pop.transform.SetAsLastSibling();
            }
            else
            {
                pop = lstPopups.Find(x => x is T) as T;
                pop = Instantiate(pop, popPos);
                showingPopups.Add(pop);
            }
            pop.Show();
            
            return pop;
        }

        public T Hide<T>() where T : Popup
        {
            T pop = null;
            if (showingPopups.Count > 0 && showingPopups.Find(x => x is T))
            {
                pop = showingPopups.Find(x => x is T) as T;
                pop.Hide();
            }
            
            return pop;
        }
    }
}