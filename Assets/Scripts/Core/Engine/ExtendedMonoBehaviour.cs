﻿using UnityEngine;

namespace EpicItems.Core.Engine
{
    public class ExtendedMonoBehaviour : MonoBehaviour
    {
        [HideInInspector]
        public GameObject _gameObject;
        [HideInInspector]
        public Transform _transform;

        protected virtual void Awake()
        {
            CacheReferences();
        }

        private void CacheReferences()
        {
            _gameObject = gameObject;
            _transform = transform;
        }
    }
}
