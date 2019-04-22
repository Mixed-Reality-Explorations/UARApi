﻿using System.Collections;using System.Collections.Generic;using UnityEngine;namespace UAR {    public class UARInit : MonoBehaviour    {        public bool debugLogs;        public GameObject ARCoreCamera;        public GameObject ARKitCamera;        public ScriptableObject ARKitImageSet;        public ScriptableObject ARCoreImageSet;        private void Awake()        {            Logger.enabled = debugLogs;            RuntimePlatform platform = Application.platform;            Logger.log(Logger.Type.Info, "platform is {0}", platform);            switch (platform)            {                case RuntimePlatform.IPhonePlayer:                    {                        var camera = Instantiate(ARKitCamera, new Vector3(0, 0, 0), Quaternion.identity);                        UARARKit.init(ARKitImageSet, camera);                        gameObject.AddComponent<UARARKit>();                        break;                    }                case RuntimePlatform.Android:                    {                        var camera = Instantiate(ARCoreCamera, new Vector3(0, 0, 0), Quaternion.identity);                        UARARCore.init(ARCoreImageSet, camera);                        gameObject.AddComponent<UARARCore>();                        break;                    }            }        }    }}