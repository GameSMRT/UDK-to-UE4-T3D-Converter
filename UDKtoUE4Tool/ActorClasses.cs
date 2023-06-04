using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//public classes for each type of actor, to store their raw values

namespace UDKtoUE4Tool
{
    public class StaticMeshData
    {

        public string AssetPath;
        public string Name;
        public string location;
        public string rotation;
        public string scale;
        public string scale3D;
        public string Materials;
        public string LightMap;
        public string VertexColors;
        public string VertexColorData;
        public bool KDamage;
    }

    public class StaticMesh
    {
        public MatchCollection Collection;
        public List<StaticMeshData> ListOfData = new List<StaticMeshData>();
        public int Count;
        public string[] results;
        public string FinalOutput;

    }

    public class KStaticMesh
    {
        public MatchCollection Collection;
        public List<StaticMeshData> ListOfData = new List<StaticMeshData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }


    public class SkeletalMesh
    {
        public MatchCollection Collection;
        public List<StaticMeshData> ListOfData = new List<StaticMeshData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }



    public class InteropStaticMesh
    {
        public MatchCollection Collection;
        public List<StaticMeshData> ListOfData = new List<StaticMeshData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class DestructableStaticMesh
    {
        public MatchCollection Collection;
        public List<StaticMeshData> ListOfData = new List<StaticMeshData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class ApexMesh
    {
        public MatchCollection Collection;
        public List<StaticMeshData> ListOfData = new List<StaticMeshData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class FoliageActor
    {
        public MatchCollection Collection;
        public List<FoliageActorData> ListOfData = new List<FoliageActorData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class FoliageActorData
    {
        string AssetPath;
        string Name;
        string location;
        string rotation;
        string scale;
        string scale3D;
        string Materials;
        string Lightmap;
    }

    public class LightData
    {
        string Name;
        string location;
        string rotation;
        string scale;
        string scale3D;
        string Intensity;
        string Color;
        string Radius;
        string RadiusInnter;
        string RadiusOutter;
        bool Movable;
    }

    public class PointLight
    {
        public MatchCollection Collection;
        public List<LightData> ListOfData = new List<LightData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class SpotLIght
    {
        public MatchCollection Collection;
        public List<LightData> ListOfData = new List<LightData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }


    public class DirectionalLight
    {
        public MatchCollection Collection;
        public List<LightData> ListOfData = new List<LightData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }


    public class PlayerStart
    {
        public MatchCollection Collection;
        public List<PlayerStartData> ListOfData = new List<PlayerStartData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class PlayerStartData
    {
        string Name;
        string location;
        string rotation;
        string scale;
        string scale3D;
    }

    public class Camera
    {
        public MatchCollection Collection;
        public List<CameraData> ListOfData = new List<CameraData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class CameraData
    {
        string Name;
        string location;
        string rotation;
        string scale;
        string scale3D;
        string FOV;
        string Aspect;
        bool ConstrainAspect;
    }

    public class Sound
    {
        public MatchCollection Collection;
        public List<SoundData> ListOfData = new List<SoundData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class SoundData
    {
        string SoundsName;
        string SoundsSlots;
        string SoundCue;
        string SoundsLocation;
        string SoundsRotation;
        string SoundsScale;
        string SoundsScale3D;
        bool SoundsSimple;
        bool SoundsAttenuate;
        bool SoundsSpatialize;
        string SoundsDM;
        string SoundsRadiusMin;
        string SoundsRadiusMax;
        string SoundsPitchMin;
        string SoundsPitchMax;
        string SoundsVolMin;
        string SoundsVolMax;
        string SoundsVolumeMulti;
        string SoundsPitchMulti;
        string SoundsHFMulti;
        bool SoundsAttenuateLPF;
        string SoundsLPFMin;
        string SoundsLPFMax;
    }

    public class Decal
    {
        public MatchCollection Collection;
        public List<DecalsData> ListOfData = new List<DecalsData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }
    public class DecalsData
    {
        string DecalsName;
        string DecalsMat;
        string DecalsLocation;
        string DecalsRotation;
        string DecalsWidth;
        string DecalsHeight;
    }

    public class Particle
    {
        public MatchCollection Collection;
        public List<ParticlesData> ListOfData = new List<ParticlesData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class ParticlesData
    {
        string AssetPath;
        string ParticlesName;
        string ParticlesLocation;
        string ParticlesRotation;
        string ParticlesScale;
        string ParticlesScale3D;
        string ParticlesMaterials;
    }

    public class Fog
    {
        public MatchCollection Collection;
        public List<FogData> ListOfData = new List<FogData>();
        public int Count;
        public string[] results;
        public string FinalOutput;
    }

    public class FogData
    {
        string FogName;
        string FogLocation;
        string FogRotation;
        string FogScale;
        string FogScale3D;
        string FogDensity;
        string FogHeightFalloff;
        string FogMaxOpacity;
        string FogStartDistance;
        string FogOppLightColor;
        string FogLightInScatterColor;
    }
}


