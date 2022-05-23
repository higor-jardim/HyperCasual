using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtManager : MonoBehaviour
{
   public enum ArtType
    {
        TYPE_01,
        TYPE_02,
        APOCRYPHA,
        COLDHARBOUR,
        MOONSHADOW,
        ASHPIT,
        COLORED_ROOMS
    }

    public List<ArtSetup> artSetups;

    public ArtSetup GetSetupByType(ArtType artType)
    {
        return artSetups.ForEach(i => i.artType = artType);
    }

    [System.Serializable]
    public class ArtSetup
    {
        public ArtManager.ArtType artType;
        public GameObject gameObject;
    }
}
