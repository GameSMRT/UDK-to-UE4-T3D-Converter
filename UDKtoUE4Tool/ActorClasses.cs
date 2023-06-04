using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//public classes for each type of actor, to store their raw values

namespace UDKtoUE4Tool
{
    public class Actorclasses
    {
    }

    public class StaticMesh
    {
        public MatchCollection Collection;
        public List<StaticMeshData> ListOfData = new List<StaticMeshData>();
        public int Count;
        public string[] results;
    }

    public class StaticMeshData
    {

        string AssetPath;
        string Name;
        string location;
        string rotation;
        string scale;
        string scale3D;
        string Materials;
        string Lightmap;
        string VertexColors;
        string VertexColorData;
    }

    public class KStaticMesh
    {
        public MatchCollection Collection;
        public List<KStaticMeshData> ListOfData = new List<KStaticMeshData>();
        public int Count;
        public string[] results;
    }

    public class KStaticMeshData
    {
        string AssetPath;
        string Name;
        string location;
        string rotation;
        string scale;
        string scale3D;
        string Materials;
        string Lightmap;
        bool KDamage;
    }

    public class SkeletalMesh
    {
        public MatchCollection Collection;
        public List<SkeletalMeshData> ListOfData = new List<SkeletalMeshData>();
        public int Count;
        public string[] results;
    }

    public class SkeletalMeshData
    {
        string AssetPath;
        string Name;
        string location;
        string rotation;
        string scale;
        string scale3D;
        string Materials;
    }

    public class InteropStaticMesh
    {
        public MatchCollection Collection;
        public List<InteropStaticMeshData> ListOfData = new List<InteropStaticMeshData>();
        public int Count;
        public string[] results;
    }


    public class InteropStaticMeshData
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

    public class FoliageActor
    {
        public MatchCollection Collection;
        public List<FoliageActorData> ListOfData = new List<FoliageActorData>();
        public int Count;
        public string[] results;
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

    public class PointLight
    {
        public MatchCollection Collection;
        public List<PointLightData> ListOfData = new List<PointLightData>();
        public int Count;
        public string[] results;
    }

    public class PointLightData
    {
        string Name;
        string location;
        string rotation;
        string scale;
        string scale3D;
        string Intensity;
        string Color;
        string Radius;
        bool Movable;
    }

    public class SpotLIght
    {
        public MatchCollection Collection;
        public List<SpotLIghtData> ListOfData = new List<SpotLIghtData>();
        public int Count;
        public string[] results;
    }

    public class SpotLIghtData
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

    public class DirectionalLight
    {
        public MatchCollection Collection;
        public List<DirectionalLightData> ListOfData = new List<DirectionalLightData>();
        public int Count;
        public string[] results;
    }

    public class DirectionalLightData
    {
        string Name;
        string location;
        string rotation;
        string scale;
        string scale3D;
        string Intensity;
        string Color;
        bool Movable;
    }

    public class PlayerStart
    {
        public MatchCollection Collection;
        public List<PlayerStartData> ListOfData = new List<PlayerStartData>();
        public int Count;
        public string[] results;
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

    public class Decals
    {
        public MatchCollection Collection;
        public List<DecalsData> ListOfData = new List<DecalsData>();
        public int Count;
        public string[] results;
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

    public class Particles
    {
        public MatchCollection Collection;
        public List<ParticlesData> ListOfData = new List<ParticlesData>();
        public int Count;
        public string[] results;
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

    public class DestructableStaticMesh
    {
        public MatchCollection Collection;
        public List<DestructableStaticMeshData> ListOfData = new List<DestructableStaticMeshData>();
        public int Count;
        public string[] results;
    }

    public class DestructableStaticMeshData
    {
        string DestructStaticMesh;
        string DestructName;
        string DestructLocation;
        string DestructRotation;
        string DestructScale;
        string DestructScale3D;
        string DestructMaterials;
    }

    public class ApexMesh
    {
        public MatchCollection Collection;
        public List<ApexMeshData> ListOfData = new List<ApexMeshData>();
        public int Count;
        public string[] results;
    }

    public class ApexMeshData
    {
        string ApexStaticMesh;
        string ApexName;
        string ApexLocation;
        string ApexRotation;
        string ApexScale;
        string ApexScale3D;
        string ApexMaterials;
    }

}


