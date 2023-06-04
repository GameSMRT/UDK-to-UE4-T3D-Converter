using System;
using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
//using ConversionHelpers;

namespace UDKtoUE4Tool
{
    public partial class Form1 : Form
    {
        #region Declarations
        ConversionHelpers ConversionTools;
        private string input;
        private string path;

        private int NumberOfAssets;
        private int NumberOfKactors;
        private int NumberofSKMesh;
        private int NumberOfInterp;
        private int NumberOfPLights;
        private int NumberOfSLights;
        private int NumberOfDLights;
        private int NumberOfDomPLights;
        private int NumberOfDomSLights;
        private int NumberOfDomDLights;
        private int NumberOfPlayerStarts;
        private int NumberOfCameras;
        private int NumberOfSounds;
        private int NumberOfDecals;
        private int NumberOfParticles;
        private int NumberofFog;
        private int NumberOfFoliage;
        private int NumberOfDestruct;
        private int NumberOfApex;

        //arrays to store data
        private MatchCollection StaticMeshmatch;
        private MatchCollection SkMeshmatch;
        private MatchCollection Kactormatch;
        private MatchCollection PointLightsMatch;
        private MatchCollection SpotLightsMatch;
        private MatchCollection DirLightsMatch;
        private MatchCollection DomPlightsMatch;
        private MatchCollection DomSLightsMatch;
        private MatchCollection DomDLightsMatch;
        private MatchCollection PlayerStartMatch;
        private MatchCollection CameraMatch;
        private MatchCollection SoundsMatch;
        private MatchCollection DecalsMatch;
        private MatchCollection ParticlesMatch;
        private MatchCollection InterpMatch;
        private MatchCollection FogMatch;
        private MatchCollection FoliageMatch;
        private MatchCollection DestructMatch;
        private MatchCollection ApexMatch;

        private string[] results;
        private string[] KactorResults;
        private string[] SkelMeshResults;
        private string[] PointLightResults;
        private string[] SpotLightResults;
        private string[] DirLightResults;
        private string[] DomPLightResults;
        private string[] DomSLightResults;
        private string[] DomDLightResults;
        private string[] PlayerStartResults;
        private string[] CameraResults;
        private string[] SoundsResults;
        private string[] DecalsResults;
        private string[] ParticlesResults;
        private string[] InterpResults;
        private string[] FogResults;
        private string[] FoliageResults;
        private string[] DestructResults;
        private string[] ApexResults;

        private List<string> StaticMesh = new List<string>();
        private List<string> Name2 = new List<string>();
        private List<string> location = new List<string>();
        private List<string> rotation = new List<string>();
        private List<string> scale = new List<string>();
        private List<string> scale3D = new List<string>();
        private List<string> Materials = new List<string>();
        private List<string> LightMap = new List<string>();
        private List<string> VertexColors = new List<string>();
        private List<string> VertexColorsData = new List<string>();

        private List<string> KStaticMesh = new List<string>();
        private List<string> KName2 = new List<string>();
        private List<string> Klocation = new List<string>();
        private List<string> Krotation = new List<string>();
        private List<string> Kscale = new List<string>();
        private List<string> Kscale3D = new List<string>();
        private List<string> KMaterials = new List<string>();
        private List<bool> Kdamage = new List<bool>();
        private List<string> KLightMap = new List<string>();

        private List<string> SKStaticMesh = new List<string>();
        private List<string> SKName = new List<string>();
        private List<string> SKlocation = new List<string>();
        private List<string> SKrotation = new List<string>();
        private List<string> SKscale = new List<string>();
        private List<string> SKscale3D = new List<string>();
        private List<string> SKMaterials = new List<string>();

        private List<string> InterpStaticMesh = new List<string>();
        private List<string> InterpName = new List<string>();
        private List<string> InterpLocation = new List<string>();
        private List<string> InterpRotation = new List<string>();
        private List<string> InterpScale = new List<string>();
        private List<string> InterpScale3D = new List<string>();
        private List<string> InterpMaterials = new List<string>();
        private List<string> InterpLightMap = new List<string>();

        private List<string> FoliageStaticMesh = new List<string>();
        private List<string> FoliageName = new List<string>();
        private List<string> FoliageLocation = new List<string>();
        private List<string> FoliageRotation = new List<string>();
        private List<string> FoliageScale = new List<string>();
        private List<string> FoliageScale3D = new List<string>();
        private List<string> FoliageMaterials = new List<string>();
        private List<string> FoliageLightMap = new List<string>();

        private List<string> PLightsName = new List<string>();
        private List<string> PLightsLocation = new List<string>();
        private List<string> PLightsRotation = new List<string>();
        private List<string> PLightsScale = new List<string>();
        private List<string> PLightsScale3D = new List<string>();
        private List<string> PLightsIntensity = new List<string>();
        private List<string> PLightsColor = new List<string>();
        private List<string> PLightsRadius = new List<string>();
        private List<bool> PLightsMoveable = new List<bool>();

        private List<string> SLightsName = new List<string>();
        private List<string> SLightsLocation = new List<string>();
        private List<string> SLightsRotation = new List<string>();
        private List<string> SLightsScale = new List<string>();
        private List<string> SLightsScale3D = new List<string>();
        private List<string> SLightsIntensity = new List<string>();
        private List<string> SLightsColor = new List<string>();
        private List<string> SLightsRadius = new List<string>();
        private List<string> SLightsInnerRadius = new List<string>();
        private List<string> SLightsOutterRadius = new List<string>();
        private List<bool> SLightsMoveable = new List<bool>();

        private List<string> DLightsName = new List<string>();
        private List<string> DLightsLocation = new List<string>();
        private List<string> DLightsRotation = new List<string>();
        private List<string> DLightsScale = new List<string>();
        private List<string> DLightsScale3D = new List<string>();
        private List<string> DLightsIntensity = new List<string>();
        private List<string> DLightsColor = new List<string>();

        private List<string> DomDLightsName = new List<string>();
        private List<string> DomDLightsLocation = new List<string>();
        private List<string> DomDLightsRotation = new List<string>();
        private List<string> DomDLightsScale = new List<string>();
        private List<string> DomDLightsScale3D = new List<string>();
        private List<string> DomDLightsIntensity = new List<string>();
        private List<string> DomDLightsColor = new List<string>();
        private List<bool> DomDLightsMoveable = new List<bool>();

        private List<string> DomSLightsName = new List<string>();
        private List<string> DomSLightsLocation = new List<string>();
        private List<string> DomSLightsRotation = new List<string>();
        private List<string> DomSLightsScale = new List<string>();
        private List<string> DomSLightsScale3D = new List<string>();
        private List<string> DomSLightsIntensity = new List<string>();
        private List<string> DomSLightsColor = new List<string>();
        private List<string> DomSLightsRadius = new List<string>();
        private List<string> DomSLightsInnerRadius = new List<string>();
        private List<string> DomSLightsOutterRadius = new List<string>();

        private List<string> DomPLightsName = new List<string>();
        private List<string> DomPLightsLocation = new List<string>();
        private List<string> DomPLightsRotation = new List<string>();
        private List<string> DomPLightsScale = new List<string>();
        private List<string> DomPLightsScale3D = new List<string>();
        private List<string> DomPLightsIntensity = new List<string>();
        private List<string> DomPLightsColor = new List<string>();
        private List<string> DomPLightsRadius = new List<string>();

        private List<string> PlayerStartsName = new List<string>();
        private List<string> PlayerStartsLocation = new List<string>();
        private List<string> PlayerStartsRotation = new List<string>();
        private List<string> PlayerStartsScale = new List<string>();
        private List<string> PlayerStartsScale3D = new List<string>();

        private List<string> CamerasName = new List<string>();
        private List<string> CamerasLocation = new List<string>();
        private List<string> CamerasRotation = new List<string>();
        private List<string> CamerasScale = new List<string>();
        private List<string> CamerasScale3D = new List<string>();
        private List<string> CamerasFOV = new List<string>();
        private List<string> CamerasAS = new List<string>();
        private List<bool> CamerasConstrainAS = new List<bool>();

        private List<string> SoundsName = new List<string>();
        private List<string> SoundsSlots = new List<string>();
        private List<string> SoundCue = new List<string>();
        private List<string> SoundsLocation = new List<string>();
        private List<string> SoundsRotation = new List<string>();
        private List<string> SoundsScale = new List<string>();
        private List<string> SoundsScale3D = new List<string>();
        private List<bool> SoundsSimple = new List<bool>();
        private List<bool> SoundsAttenuate = new List<bool>();
        private List<bool> SoundsSpatialize = new List<bool>();
        private List<string> SoundsDM = new List<string>();
        private List<string> SoundsRadiusMin = new List<string>();
        private List<string> SoundsRadiusMax = new List<string>();
        private List<string> SoundsPitchMin = new List<string>();
        private List<string> SoundsPitchMax = new List<string>();
        private List<string> SoundsVolMin = new List<string>();
        private List<string> SoundsVolMax = new List<string>();        
        private List<string> SoundsVolumeMulti = new List<string>();
        private List<string> SoundsPitchMulti = new List<string>();
        private List<string> SoundsHFMulti = new List<string>();
        private List<bool> SoundsAttenuateLPF = new List<bool>();
        private List<string> SoundsLPFMin = new List<string>();
        private List<string> SoundsLPFMax = new List<string>();

        private List<string> DecalsName = new List<string>();
        private List<string> DecalsMat = new List<string>();
        private List<string> DecalsLocation = new List<string>();
        private List<string> DecalsRotation = new List<string>();
        private List<string> DecalsWidth= new List<string>();
        private List<string> DecalsHeight = new List<string>();

        private List<string> Particles = new List<string>();
        private List<string> ParticlesName = new List<string>();
        private List<string> ParticlesLocation = new List<string>();
        private List<string> ParticlesRotation = new List<string>();
        private List<string> ParticlesScale = new List<string>();
        private List<string> ParticlesScale3D = new List<string>();
        private List<string> ParticlesMaterials = new List<string>();

        private List<string> FogName = new List<string>();
        private List<string> FogLocation = new List<string>();
        private List<string> FogRotation = new List<string>();
        private List<string> FogScale = new List<string>();
        private List<string> FogScale3D = new List<string>();
        private List<string> FogDensity = new List<string>();
        private List<string> FogHeightFalloff = new List<string>();
        private List<string> FogMaxOpacity = new List<string>();
        private List<string> FogStartDistance = new List<string>();
        private List<string> FogOppLightColor = new List<string>();
        private List<string> FogLightInScatterColor = new List<string>();

        private List<string> DestructStaticMesh = new List<string>();
        private List<string> DestructName = new List<string>();
        private List<string> DestructLocation = new List<string>();
        private List<string> DestructRotation = new List<string>();
        private List<string> DestructScale = new List<string>();
        private List<string> DestructScale3D = new List<string>();
        private List<string> DestructMaterials = new List<string>();

        private List<string> ApexStaticMesh = new List<string>();
        private List<string> ApexName = new List<string>();
        private List<string> ApexLocation = new List<string>();
        private List<string> ApexRotation = new List<string>();
        private List<string> ApexScale = new List<string>();
        private List<string> ApexScale3D = new List<string>();
        private List<string> ApexMaterials = new List<string>();

        //strings that contain the default vaules of properties, that are used when the entry is missing
        private string NoRotation = "Rotation=(Pitch=0,Yaw=0,Roll=0)";
        private string NoScale3D = "DrawScale3D=(X=1.000000,Y=1.000000,Z=1.000000)";
        private string NoLocation = "Location=(X=0,Y=0,Z=0)";
        private string NoColor = "LightColor=(B=255,G=255,R=255,A=255)";
        private string NoIntensity = "Brightness=1.000000";
        private string NoRaduis = "Radius=1024.000000";
        private string NoInnerCone = "InnerConeAngle=1.000000";
        private string NoOutterCone = "OuterConeAngle=45.000000";

        private string materialsTemp;
        private string LoopOutput;
        private string KactorOutput;
        private string SKmeshOutput;
        private string PLightOutput;
        private string SLightOutput;
        private string DLightOutput;
        private string DomPLightOutput;
        private string DomSLightOutput;
        private string DomDLightOutput;
        private string PlayerStartOutput;
        private string CameraOutput;
        private string SoundOutput;
        private string DecalsOutput;
        private string ParticlesOutput;
        private string InterpOutput;
        private string FogOutput;
        private string FoliageOutput;
        private string DestructOutput;
        private string ApexOutput;
        private string Finaloutput;

        private string temp;
        private string temp2;
        private string temp3;
        private string temp4;

        private string UE4ProjectPath;
        private List<string> UE4Directories = new List<string>();

        float Pitch;
        float Yaw;
        float Roll;
        string newPitch;
        string newYaw;
        string newRoll;
        float intensity;
        float radius;

        string newX;
        string newY;
        string newZ;
        float X;
        float Y;
        float Z;
        float DrawScale;
        float width;
        float height;

        string newR;
        string newG;
        string newB;
        string newA;
        float R;
        float G;
        float B;
        float A;

        string[] split;
        string[] split2;
        string[] digits;

        int i;

        string SaveFilePath = @"UserData.txt";
        #endregion


        /************************* Material Converter *********************/

        string UE3Material;
        string UE3MaterialPath;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }

            /* this.checkedListBox1.SelectedItem = "None";
             this.checkedListBox1.SelectedValue = "None";
             int selInd = this.checkedListBox1.SelectedIndex;
             this.checkedListBox1.SetItemChecked(selInd, true);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //function to reset and clear all values
        private void ResetData()
        {
            input = null;
            path = null;
            temp = null;
            StaticMeshmatch = null;
            Kactormatch = null;
            SkMeshmatch = null;
            PointLightsMatch = null;
            SpotLightsMatch = null;
            DirLightsMatch = null;
            DomPlightsMatch = null;
            DomSLightsMatch = null;
            DomDLightsMatch = null;
            results = null;
            PointLightResults = null;
            SpotLightResults = null;
            DirLightResults = null;
            DomPLightResults = null;
            DomSLightResults = null;
            DomDLightResults = null;
            PlayerStartMatch = null;
            CameraMatch = null;
            SoundsMatch = null;
            DecalsMatch = null;
            ParticlesMatch = null;
            InterpMatch = null;
            FogMatch = null;
           // FoliageMatch = null;
            DestructMatch = null;
            ApexMatch = null;

            NumberOfAssets = 0;
            NumberOfPLights = 0;
            NumberOfSLights = 0;
            NumberOfDLights = 0;
            NumberOfDomPLights = 0;
            NumberOfDomSLights = 0;
            NumberOfDomDLights = 0;
            NumberOfPlayerStarts = 0;
            NumberOfCameras = 0;
            NumberOfSounds = 0;
            NumberOfKactors = 0;
            NumberofSKMesh = 0;
            NumberOfParticles = 0;
            NumberOfInterp = 0;
            NumberofFog = 0;
            NumberOfFoliage = 0;

            StaticMesh.Clear();
            Name2.Clear();
            location.Clear();
            rotation.Clear();
            scale.Clear();
            scale3D.Clear();
            LightMap.Clear();
            VertexColors.Clear();
            VertexColorsData.Clear();

            KStaticMesh.Clear();
            KName2.Clear();
            Klocation.Clear();
            Krotation.Clear();
            Kscale.Clear();
            Kscale3D.Clear();
            KMaterials.Clear();
            Kdamage.Clear();
            KLightMap.Clear();

            SKStaticMesh.Clear();
            SKName.Clear();
            SKlocation.Clear();
            SKrotation.Clear();
            SKscale.Clear();
            SKscale3D.Clear();
            SKMaterials.Clear();

            DestructStaticMesh.Clear();
            DestructName.Clear();
            DestructLocation.Clear();
            DestructRotation.Clear();
            DestructScale.Clear();
            DestructScale3D.Clear();
            DestructMaterials.Clear();

            ApexStaticMesh.Clear();
            ApexName.Clear();
            ApexLocation.Clear();
            ApexRotation.Clear();
            ApexScale.Clear();
            ApexScale3D.Clear();
            ApexMaterials.Clear();

            InterpStaticMesh.Clear();
            InterpName.Clear();
            InterpLocation.Clear();
            InterpRotation.Clear();
            InterpScale.Clear();
            InterpScale3D.Clear();
            InterpMaterials.Clear();
            InterpLightMap.Clear();

            FoliageStaticMesh.Clear();
            FoliageName.Clear();
            FoliageLocation.Clear();
            FoliageRotation.Clear();
            FoliageScale.Clear();
            FoliageScale3D.Clear();
            FoliageMaterials.Clear();
            FoliageLightMap.Clear();

            PLightsName.Clear();
            PLightsLocation.Clear();
            PLightsRotation.Clear();
            PLightsScale.Clear();
            PLightsIntensity.Clear();
            PLightsColor.Clear();
            PLightsRadius.Clear();
            PLightsMoveable.Clear();

            SLightsName.Clear();
            SLightsLocation.Clear();
            SLightsRotation.Clear();
            SLightsScale.Clear();
            SLightsIntensity.Clear();
            SLightsColor.Clear();
            SLightsRadius.Clear();
            SLightsInnerRadius.Clear();
            SLightsOutterRadius.Clear();
            SLightsMoveable.Clear();

            DLightsName.Clear();
            DLightsLocation.Clear();
            DLightsRotation.Clear();
            DLightsScale.Clear();
            DLightsIntensity.Clear();
            DLightsColor.Clear();

            DomSLightsName.Clear();
            DomSLightsLocation.Clear();
            DomSLightsRotation.Clear();
            DomSLightsScale.Clear();
            DomSLightsIntensity.Clear();
            DomSLightsColor.Clear();
            DomSLightsRadius.Clear();
            DomSLightsInnerRadius.Clear();
            DomSLightsOutterRadius.Clear();

            DomPLightsName.Clear();
            DomPLightsLocation.Clear();
            DomPLightsRotation.Clear();
            DomPLightsScale.Clear();
            DomPLightsIntensity.Clear();
            DomPLightsColor.Clear();
            DomPLightsRadius.Clear();

            DomDLightsName.Clear();
            DomDLightsLocation.Clear();
            DomDLightsRotation.Clear();
            DomDLightsScale.Clear();
            DomDLightsIntensity.Clear();
            DomDLightsColor.Clear();
            DomDLightsMoveable.Clear();

            PlayerStartsName.Clear();
            PlayerStartsLocation.Clear();
            PlayerStartsRotation.Clear();
            PlayerStartsScale.Clear();
            PlayerStartsScale3D.Clear();

            CamerasName.Clear();
            CamerasLocation.Clear();
            CamerasRotation.Clear();
            CamerasScale.Clear();
            CamerasScale3D.Clear();
            CamerasFOV.Clear();
            CamerasConstrainAS.Clear();
            CamerasAS.Clear();

            SoundsName.Clear();
            SoundCue.Clear();
            SoundsSimple.Clear();
            SoundsLocation.Clear();
            SoundsRotation.Clear();
            SoundsScale.Clear();
            SoundsScale3D.Clear();

            SoundsAttenuate.Clear();
            SoundsSpatialize.Clear();
            SoundsDM.Clear();
            SoundsRadiusMin.Clear();
            SoundsRadiusMax.Clear();
            SoundsPitchMin.Clear();
            SoundsPitchMax.Clear();
            SoundsVolMin.Clear();
            SoundsVolMax.Clear();

            SoundsSlots.Clear();
            SoundsVolumeMulti.Clear();
            SoundsPitchMulti.Clear();
            SoundsHFMulti.Clear();
            SoundsLPFMax.Clear();
            SoundsLPFMin.Clear();
            SoundsAttenuateLPF.Clear();

            DecalsName.Clear();
            DecalsMat.Clear();
            DecalsLocation.Clear();
            DecalsRotation.Clear();
            DecalsWidth.Clear();
            DecalsHeight.Clear();

            Particles.Clear();
            ParticlesName.Clear();
            ParticlesLocation.Clear();
            ParticlesRotation.Clear();
            ParticlesScale3D.Clear();
            ParticlesScale.Clear();
            ParticlesMaterials.Clear();

            FogName.Clear();
            FogLocation.Clear();
            FogRotation.Clear();
            FogScale.Clear();
            FogScale3D.Clear();
            FogDensity.Clear();
            FogHeightFalloff.Clear();
            FogMaxOpacity.Clear();
            FogStartDistance.Clear();
            FogOppLightColor.Clear();
            FogLightInScatterColor.Clear();

            LoopOutput = string.Empty;
            KactorOutput = string.Empty;
            SKmeshOutput = string.Empty;
            PLightOutput = string.Empty;
            SLightOutput = string.Empty;
            DLightOutput = string.Empty;
            DomPLightOutput = string.Empty;
            DomSLightOutput = string.Empty;
            DomDLightOutput = string.Empty;
            PlayerStartOutput = string.Empty;
            CameraOutput = string.Empty;
            SoundOutput = string.Empty;
            DecalsOutput = string.Empty;
            ParticlesOutput = string.Empty;
            InterpOutput = string.Empty;
            FogOutput = string.Empty;
            FoliageOutput = string.Empty;
            DestructOutput = string.Empty;
            ApexOutput = string.Empty;
            Finaloutput = string.Empty;

            intensity = 0;
            radius = 0;

            Pitch = 0;
            Yaw = 0;
            Roll = 0;
            newPitch = null;
            newYaw = null;
            newRoll = null;

            newX = string.Empty;
            newY = string.Empty;
            newZ = string.Empty;
            X = 0;
            Y = 0;
            Z = 0;

            newR = string.Empty;
            newG = string.Empty;
            newB = string.Empty;
            newA = string.Empty;
            R = 0;
            G = 0;
            B = 0;
            A = 0;

            temp = string.Empty;
            temp2 = string.Empty;
            temp3 = string.Empty;
            temp4 = string.Empty;

            width = 0;
            height = 0;

            split2 = null;
            split = null;
            digits = null;

            DrawScale = 0;
            i = 0;

            UE4ProjectPath = string.Empty;
            UE4Directories.Clear();

          //  materialsTemp = null;
            //RecombinedMaterials = null;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //Grab Input from the user
            #region GrabInput
            ResetData();

            //grab the input
            input = richTextBox1.Text.ToString();
            path = TB_AssetPath.Text.ToString();

            
            if (TB_ContentDir.Text != string.Empty)
            {
                UE4ProjectPath = TB_ContentDir.Text;
                split = UE4ProjectPath.Split("\\".ToCharArray());

               
                if (!split.Contains<String>("Content"))
                {
                    //if no content folder was provided
                    MessageBox.Show("No Content Folder Found");
                    return;
                }
                else
                {
                    //get all the file names and paths from the project folder
                    ConversionTools.DirSearch(UE4ProjectPath, UE4Directories);

                    //loop through the all file paths and remove the Drive path to the project "C://" etc...., so we just have the relative engine paths for each file.
                    for (i = 0; i < UE4Directories.Count; i++)
                    {
                        UE4Directories[i] = UE4Directories[i].Replace(UE4ProjectPath, "\\Game");
                        UE4Directories[i] = UE4Directories[i].Replace(".uasset", "");

                        split = UE4Directories[i].Split("\\".ToCharArray());
                        if (split.Length > 0)
                        {
                            UE4Directories[i] = UE4Directories[i] + "." + split[split.Length - 1];
                        }
                    }
                }
            }
            #endregion

            //use Regular Expressions to Search through the T3D
            #region SearchThroughInput
            //get all the text inbetween all sets of "Begin Actor Class=__"  and "End Actor", store the results in the arrays
            Regex r = new Regex(@"(?s)(Begin Actor Class=StaticMeshActor).+?(End Actor)");
            StaticMeshmatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=PointLight).+?(End Actor)");
            PointLightsMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=SpotLight).+?(End Actor)");
            SpotLightsMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=DirectionalLight).+?(End Actor)");
            DirLightsMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=DominantDirectionalLight).+?(End Actor)");
            DomDLightsMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=DominantSpotLight).+?(End Actor)");
            DomSLightsMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=DominantPointLight).+?(End Actor)");
            DomPlightsMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=PlayerStart).+?(End Actor)");
            PlayerStartMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=CameraActor).+?(End Actor)");
            CameraMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=AmbientSound).+?(End Actor)");
            SoundsMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=DecalActor).+?(End Actor)");
            DecalsMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=KActor).+?(End Actor)");
            Kactormatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=SkeletalMeshActor).+?(End Actor)");
            SkMeshmatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=Emitter).+?(End Actor)");
            ParticlesMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=InterpActor).+?(End Actor)");
            InterpMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=ExponentialHeightFog).+?(End Actor)");
            FogMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=InteractiveFoliageActor).+?(End Actor)");
            FoliageMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=FracturedStaticMeshActor).+?(End Actor)");
            DestructMatch = r.Matches(richTextBox1.Text);

            r = new Regex(@"(?s)(Begin Actor Class=ApexDestructibleActor).+?(End Actor)");
            ApexMatch = r.Matches(richTextBox1.Text);

            if (StaticMeshmatch.Count == 0 && PointLightsMatch.Count == 0 && SpotLightsMatch.Count == 0 && DirLightsMatch.Count == 0 && DomDLightsMatch.Count == 0 && DomSLightsMatch.Count == 0 && DomPlightsMatch.Count == 0 && PlayerStartMatch.Count == 0 && CameraMatch.Count == 0 && DecalsMatch.Count == 0 && Kactormatch.Count == 0 && SkMeshmatch.Count == 0 && ParticlesMatch.Count == 0 && InterpMatch.Count == 0 && FogMatch.Count == 0 && FoliageMatch.Count == 0 && DestructMatch.Count == 0 && ApexMatch.Count == 0 && SoundsMatch.Count == 0)
            {
                MessageBox.Show("No Actors found");
                return;
            }
            #endregion

            //Filter the Regular expressions results and strip away any other text so we are down to the raw values we need and store them.
            #region FilterResults



            //find any Static Meshes, insert default entries if missing, then store the data into arrays for access

            /*If an actor uses a default value (eg. scale is 1, 1, 1) then entry is missing in the T3D, which means when the arrays are built, 
            there is a missing entry, and the arrays are not the same size, which throws an error. so if the entry is missing I fill it with
            the default value instead 
            
             This way all the arrays are horizontally aligned correctly as expected*/

            if (StaticMeshmatch.Count != 0)
            {
                //store the number of assets, update the label
                NumberOfAssets = StaticMeshmatch.Count;
                label7.Text = "Static Meshes: " + NumberOfAssets.ToString();

                //fill the results array with the matches
                results = new string[StaticMeshmatch.Count];

                materialsTemp = string.Empty;
                // RecombinedMaterials = string.Empty;

                //loop through all the matched blocks of text for static meshes
                for (i = 0; i < StaticMeshmatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    results[i] = StaticMeshmatch[i].Groups[0].Value.ToString();

                    if (results[i].IndexOf("StaticMesh=") == -1)
                    {
                        StaticMesh.Add(string.Empty);
                    }


                    if (results[i].IndexOf("Location=") == -1)
                    {
                        location.Add(NoLocation);
                    }

                    //check for missing entries, if so push blank values into arrays
                    if (results[i].IndexOf("DrawScale3D=") == -1)
                    {
                        scale3D.Add(NoScale3D);
                    }

                    if (results[i].IndexOf("DrawScale=") == -1)
                    {
                        scale.Add("1.000000");
                    }

                    if (results[i].IndexOf("Rotation=") == -1)
                    {
                        rotation.Add(NoRotation);
                    }

                    if (results[i].IndexOf("OverriddenLightMapRes=") == -1)
                    {
                        LightMap.Add(string.Empty);
                    }

                    if (results[i].IndexOf("LODData(0)=") == -1)
                    {
                        VertexColors.Add(string.Empty);
                        VertexColorsData.Add(string.Empty);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(results[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=StaticMeshActor") != -1)
                        {
                            Name2.Add(value);
                        }
                        if (value.IndexOf("StaticMesh=") != -1)
                        {
                            StaticMesh.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            location.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            rotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            scale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            scale3D.Add(value);
                        }

                        if (value.IndexOf(" Materials(") != -1)
                        {
                            materialsTemp = materialsTemp + value + Environment.NewLine;
                            // Console.Write(value + Environment.NewLine);
                        }

                        if (value.IndexOf("OverriddenLightMapRes=") != -1)
                        {
                            LightMap.Add(value);
                        }

                        if (value.IndexOf("LODData(0)=") != -1)
                        {
                            VertexColors.Add(value);
                        }

                        if (value.IndexOf("ColorVertexData(") != -1)
                        {
                            VertexColorsData.Add(value);
                        }

                    }
                    if (materialsTemp != string.Empty)
                    {
                        Materials.Add(materialsTemp);
                    }
                    else
                    {
                        Materials.Add(string.Empty);
                    }
                    materialsTemp = string.Empty;

                    //Console.Write(Environment.NewLine + Materials.Count + Environment.NewLine);
                }
            }

            if (Kactormatch.Count != 0)
            {
                //store the number of assets, update the label
                NumberOfKactors = Kactormatch.Count;
                label21.Text = "KActors: " + NumberOfKactors.ToString();

                //fill the results array with the matches
                KactorResults = new string[Kactormatch.Count];

                //loop through all the matched blocks of text for static meshes
                for (i = 0; i < Kactormatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    KactorResults[i] = Kactormatch[i].Groups[0].Value.ToString();

                    if (KactorResults[i].IndexOf("StaticMesh=") == -1)
                    {
                        KStaticMesh.Add(string.Empty);
                    }

                    if (KactorResults[i].IndexOf("Location=") == -1)
                    {
                        Klocation.Add(NoLocation);
                    }

                    //check for missing entries, if so push blank values into arrays
                    if (KactorResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        Kscale3D.Add(NoScale3D);
                    }

                    if (KactorResults[i].IndexOf("DrawScale=") == -1)
                    {
                        Kscale.Add("1.000000");
                    }

                    if (KactorResults[i].IndexOf("Rotation=") == -1)
                    {
                        Krotation.Add(NoRotation);
                    }

                    if (KactorResults[i].IndexOf("bDamageAppliesImpulse=") == -1)
                    {
                        Kdamage.Add(true);
                    }
                    else
                    {
                        Kdamage.Add(false);
                    }

                    if (KactorResults[i].IndexOf("OverriddenLightMapRes=") == -1)
                    {
                        KLightMap.Add(string.Empty);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(KactorResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=KActor") != -1)
                        {
                            KName2.Add(value);
                        }
                        if (value.IndexOf("StaticMesh=") != -1)
                        {
                            KStaticMesh.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            Klocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            Krotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            Kscale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            Kscale3D.Add(value);
                        }

                        materialsTemp = string.Empty;

                        if (value.IndexOf("Materials(") != -1)
                        {
                            materialsTemp = materialsTemp + value + "---";
                        }

                        if (value.IndexOf("OverriddenLightMapRes=") != -1)
                        {
                            KLightMap.Add(value);
                        }

                    }

                    if (materialsTemp != string.Empty)
                    {
                        KMaterials.Add(materialsTemp);
                    }
                    else
                    {
                        KMaterials.Add(string.Empty);
                    }

                    materialsTemp = string.Empty;
                }
            }

            if (InterpMatch.Count != 0)
            {
                //store the number of assets, update the label
                NumberOfInterp = InterpMatch.Count;
                label7.Text = "Static Meshes: " + (NumberOfAssets + NumberOfInterp).ToString();

                //fill the results array with the matches
                InterpResults = new string[InterpMatch.Count];

                //loop through all the matched blocInterps of text for static meshes
                for (i = 0; i < InterpMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    InterpResults[i] = InterpMatch[i].Groups[0].Value.ToString();

                    if (InterpResults[i].IndexOf("StaticMesh=") == -1)
                    {
                        InterpStaticMesh.Add(string.Empty);
                    }

                    if (InterpResults[i].IndexOf("Location=") == -1)
                    {
                        InterpLocation.Add(NoLocation);
                    }

                    //checInterp for missing entries, if so push blanInterp values into arrays
                    if (InterpResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        InterpScale3D.Add(NoScale3D);
                    }

                    if (InterpResults[i].IndexOf("DrawScale=") == -1)
                    {
                        InterpScale.Add("1.000000");
                    }

                    if (InterpResults[i].IndexOf("Rotation=") == -1)
                    {
                        InterpRotation.Add(NoRotation);
                    }


                    if (InterpResults[i].IndexOf("OverriddenLightMapRes=") == -1)
                    {
                        InterpLightMap.Add(string.Empty);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(InterpResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=Interp") != -1)
                        {
                            InterpName.Add(value);
                        }
                        if (value.IndexOf("StaticMesh=") != -1)
                        {
                            InterpStaticMesh.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            InterpLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            InterpRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            InterpScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            InterpScale3D.Add(value);
                        }

                        materialsTemp = string.Empty;

                        if (value.IndexOf("Materials(") != -1)
                        {
                            materialsTemp = materialsTemp + value + "---";
                        }

                        if (value.IndexOf("OverriddenLightMapRes=") != -1)
                        {
                            InterpLightMap.Add(value);
                        }

                    }

                    if (materialsTemp != string.Empty)
                    {
                        InterpMaterials.Add(materialsTemp);
                    }
                    else
                    {
                        InterpMaterials.Add(string.Empty);
                    }

                    materialsTemp = string.Empty;
                }
            }

            //destructable meshes

            if (DestructMatch.Count != 0)
            {
                //store the number of assets, update the label
                NumberOfDestruct = DestructMatch.Count;
                //label7.Text = "Static Meshes: " + (NumberOfAssets + NumberOfDestruct).ToString();

                //fill the results array with the matches
                DestructResults = new string[DestructMatch.Count];

                //loop through all the matched blocDestructs of text for static meshes
                for (i = 0; i < DestructMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    DestructResults[i] = DestructMatch[i].Groups[0].Value.ToString();

                    if (DestructResults[i].IndexOf("StaticMesh=") == -1)
                    {
                        DestructStaticMesh.Add(string.Empty);
                    }

                    if (DestructResults[i].IndexOf("Location=") == -1)
                    {
                        DestructLocation.Add(NoLocation);
                    }

                    //checDestruct for missing entries, if so push blanDestruct values into arrays
                    if (DestructResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        DestructScale3D.Add(NoScale3D);
                    }

                    if (DestructResults[i].IndexOf("DrawScale=") == -1)
                    {
                        DestructScale.Add("1.000000");
                    }

                    if (DestructResults[i].IndexOf("Rotation=") == -1)
                    {
                        DestructRotation.Add(NoRotation);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(DestructResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=FracturedStaticMeshActor") != -1)
                        {
                            DestructName.Add(value);
                        }
                        if (value.IndexOf("StaticMesh=") != -1)
                        {
                            DestructStaticMesh.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            DestructLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            DestructRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            DestructScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            DestructScale3D.Add(value);
                        }

                        materialsTemp = string.Empty;

                        if (value.IndexOf("Materials(") != -1)
                        {
                            materialsTemp = materialsTemp + value + "---";
                        }
                    }

                    if (materialsTemp != string.Empty)
                    {
                        DestructMaterials.Add(materialsTemp);
                    }
                    else
                    {
                        DestructMaterials.Add(string.Empty);
                    }

                    materialsTemp = string.Empty;
                }
            }
            //apex actors

            if (ApexMatch.Count != 0)
            {
                //store the number of assets, update the label
                NumberOfApex = ApexMatch.Count;
                //label7.Text = "Static Meshes: " + (NumberOfAssets + NumberOfApex).ToString();

                //fill the results array with the matches
                ApexResults = new string[ApexMatch.Count];

                //loop through all the matched blocApexs of text for static meshes
                for (i = 0; i < ApexMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    ApexResults[i] = ApexMatch[i].Groups[0].Value.ToString();

                    if (ApexResults[i].IndexOf("Asset=") == -1)
                    {
                        ApexStaticMesh.Add(string.Empty);
                    }

                    if (ApexResults[i].IndexOf("Location=") == -1)
                    {
                        ApexLocation.Add(NoLocation);
                    }

                    //checApex for missing entries, if so push blanApex values into arrays
                    if (ApexResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        ApexScale3D.Add(NoScale3D);
                    }

                    if (ApexResults[i].IndexOf("DrawScale=") == -1)
                    {
                        ApexScale.Add("1.000000");
                    }

                    if (ApexResults[i].IndexOf("Rotation=") == -1)
                    {
                        ApexRotation.Add(NoRotation);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(ApexResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=ApexDestructibleActor") != -1)
                        {
                            ApexName.Add(value);
                        }
                        if (value.IndexOf("Asset=") != -1)
                        {
                            ApexStaticMesh.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            ApexLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            ApexRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            ApexScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            ApexScale3D.Add(value);
                        }

                        materialsTemp = string.Empty;

                        if (value.IndexOf("Materials(") != -1)
                        {
                            materialsTemp = materialsTemp + value + "---";
                        }
                    }

                    if (materialsTemp != string.Empty)
                    {
                        ApexMaterials.Add(materialsTemp);
                    }
                    else
                    {
                        ApexMaterials.Add(string.Empty);
                    }

                    materialsTemp = string.Empty;
                }
            }

            //foliage actors

            if (FoliageMatch.Count != 0)
            {
                //store the number of assets, update the label
                NumberOfFoliage = FoliageMatch.Count;
                label7.Text = "Static Meshes: " + (NumberOfAssets + NumberOfFoliage + NumberOfInterp).ToString();

                //fill the results array with the matches
                FoliageResults = new string[FoliageMatch.Count];

                //loop through all the matched blocFoliages of text for static meshes
                for (i = 0; i < FoliageMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    FoliageResults[i] = FoliageMatch[i].Groups[0].Value.ToString();

                    if (FoliageResults[i].IndexOf("StaticMesh=") == -1)
                    {
                        FoliageStaticMesh.Add(string.Empty);
                    }

                    if (FoliageResults[i].IndexOf("Location=") == -1)
                    {
                        FoliageLocation.Add(NoLocation);
                    }

                    if (FoliageResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        FoliageScale3D.Add(NoScale3D);
                    }

                    if (FoliageResults[i].IndexOf("DrawScale=") == -1)
                    {
                        FoliageScale.Add("1.000000");
                    }

                    if (FoliageResults[i].IndexOf("Rotation=") == -1)
                    {
                        FoliageRotation.Add(NoRotation);
                    }

                    if (FoliageResults[i].IndexOf("OverriddenLightMapRes=") == -1)
                    {
                        FoliageLightMap.Add(string.Empty);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(FoliageResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=InteractiveFoliageActor") != -1)
                        {
                            FoliageName.Add(value);
                        }
                        if (value.IndexOf("StaticMesh=") != -1)
                        {
                            FoliageStaticMesh.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            FoliageLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            FoliageRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            FoliageScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            FoliageScale3D.Add(value);
                        }
                        materialsTemp = string.Empty;

                        if (value.IndexOf("Materials(") != -1)
                        {
                            materialsTemp = materialsTemp + value + "---";
                        }

                        if (value.IndexOf("OverriddenLightMapRes=") != -1)
                        {
                            FoliageLightMap.Add(value);
                        }
                    }

                    if (materialsTemp != string.Empty)
                    {
                        FoliageMaterials.Add(materialsTemp);
                    }
                    else
                    {
                        FoliageMaterials.Add(string.Empty);
                    }

                    materialsTemp = string.Empty;
                }
            }

            //skeletal meshes
            if (SkMeshmatch.Count != 0)
            {
                //store the number of assets, update the label
                NumberofSKMesh = SkMeshmatch.Count;
                label18.Text = "Skeletal Meshes: " + NumberofSKMesh.ToString();

                //fill the results array with the matches
                SkelMeshResults = new string[SkMeshmatch.Count];

                //loop through all the matched blocks of text for static meshes
                for (i = 0; i < SkMeshmatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    SkelMeshResults[i] = SkMeshmatch[i].Groups[0].Value.ToString();

                    if (SkelMeshResults[i].IndexOf("SkeletalMesh=") == -1)
                    {
                        SKStaticMesh.Add(string.Empty);
                    }

                    if (SkelMeshResults[i].IndexOf("Location=") == -1)
                    {
                        SKlocation.Add(NoLocation);
                    }

                    //check for missing entries, if so push blank values into arrays
                    if (SkelMeshResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        SKscale3D.Add(NoScale3D);
                    }

                    if (SkelMeshResults[i].IndexOf("DrawScale=") == -1)
                    {
                        SKscale.Add("1.000000");
                    }

                    if (SkelMeshResults[i].IndexOf("Rotation=") == -1)
                    {
                        SKrotation.Add(NoRotation);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(SkelMeshResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=SkeletalMeshActor") != -1)
                        {
                            SKName.Add(value);
                        }
                        if (value.IndexOf("SkeletalMesh=") != -1)
                        {
                            SKStaticMesh.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            SKlocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            SKrotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            SKscale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            SKscale3D.Add(value);
                        }

                        if (value.IndexOf("Materials(") != -1)
                        {
                            materialsTemp = materialsTemp + value + "---";
                        }

                    }
                    if (materialsTemp != string.Empty)
                    {
                        SKMaterials.Add(materialsTemp);
                    }
                    else
                    {
                        SKMaterials.Add(string.Empty);
                    }
                    materialsTemp = string.Empty;
                }
            }

            //find any Point lights, insert default entries if missing, then store the data into arrays for access

            if (PointLightsMatch.Count != 0)
            {
                NumberOfPLights = PointLightsMatch.Count;
                label6.Text = "Point Lights: " + NumberOfPLights.ToString();

                //loop through all the matched blocks of text for Point PLights
                PointLightResults = new string[PointLightsMatch.Count];


                for (i = 0; i < PointLightsMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    PointLightResults[i] = PointLightsMatch[i].Groups[0].Value.ToString();

                    //check for missing entries, if so push blank values into arrays
                    if (PointLightResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        PLightsScale3D.Add(NoScale3D);
                    }

                    if (PointLightResults[i].IndexOf("Location=") == -1)
                    {
                        PLightsLocation.Add(NoLocation);
                    }

                    if (PointLightResults[i].IndexOf("DrawScale=") == -1)
                    {
                        PLightsScale.Add("1.000000");
                    }

                    if (PointLightResults[i].IndexOf("Rotation=") == -1)
                    {
                        PLightsRotation.Add(NoRotation);
                    }

                    if (PointLightResults[i].IndexOf(" Radius=") == -1)
                    {
                        PLightsRadius.Add(NoRaduis);
                    }

                    if (PointLightResults[i].IndexOf("LightColor=") == -1)
                    {
                        PLightsColor.Add(NoColor);
                    }

                    if (PointLightResults[i].IndexOf("Brightness=") == -1)
                    {
                        PLightsIntensity.Add(NoIntensity);
                    }

                    if (PointLightResults[i].IndexOf("Class=PointLightMovable") == -1)
                    {
                        PLightsMoveable.Add(false);
                    } else {
                        PLightsMoveable.Add(true);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(PointLightResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=PointLight") != -1)
                        {
                            PLightsName.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            PLightsLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            PLightsRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            PLightsScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            PLightsScale3D.Add(value);
                        }

                        if (value.IndexOf(" Radius=") != -1)
                        {
                            PLightsRadius.Add(value);
                        }

                        if (value.IndexOf("LightColor=") != -1)
                        {
                            PLightsColor.Add(value);
                        }

                        if (value.IndexOf("Brightness=") != -1)
                        {
                            PLightsIntensity.Add(value);
                        }

                    }
                }
            }

            //find any Dominant Point lights, insert default entries if missing, then store the data into arrays for access

            if (DomPlightsMatch.Count != 0)
            {
                NumberOfDomPLights = DomPlightsMatch.Count;
                label6.Text = "Point Lights: " + (NumberOfPLights + NumberOfDomPLights).ToString();

                //loop through all the matched blocks of text for Point PLights
                DomPLightResults = new string[DomPlightsMatch.Count];

                for (i = 0; i < DomPlightsMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    DomPLightResults[i] = DomPlightsMatch[i].Groups[0].Value.ToString();

                    //check for missing entries, if so push blank values into arrays
                    if (DomPLightResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        DomPLightsScale3D.Add(NoScale3D);
                    }

                    if (DomPLightResults[i].IndexOf("Location=") == -1)
                    {
                        DomPLightsLocation.Add(NoLocation);
                    }

                    if (DomPLightResults[i].IndexOf("DrawScale=") == -1)
                    {
                        DomPLightsScale.Add("1.000000");
                    }

                    if (DomPLightResults[i].IndexOf("Rotation=") == -1)
                    {
                        DomPLightsRotation.Add(NoRotation);
                    }

                    if (DomPLightResults[i].IndexOf(" Radius=") == -1)
                    {
                        DomPLightsRadius.Add(NoRaduis);
                    }

                    if (DomPLightResults[i].IndexOf("LightColor=") == -1)
                    {
                        DomPLightsColor.Add(NoColor);
                    }

                    if (DomPLightResults[i].IndexOf("Brightness=") == -1)
                    {
                        DomPLightsIntensity.Add(NoIntensity);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(DomPLightResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=DominantPointLight") != -1)
                        {
                            DomPLightsName.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            DomPLightsLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            DomPLightsRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            DomPLightsScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            DomPLightsScale3D.Add(value);
                        }

                        if (value.IndexOf(" Radius=") != -1)
                        {
                            DomPLightsRadius.Add(value);
                        }

                        if (value.IndexOf("LightColor=") != -1)
                        {
                            DomPLightsColor.Add(value);
                        }

                        if (value.IndexOf("Brightness=") != -1)
                        {
                            DomPLightsIntensity.Add(value);
                        }

                    }
                }
            }

            //find any Spot lights, insert default entries if missing, then store the data into arrays for access

            if (SpotLightsMatch.Count != 0)
            {
                NumberOfSLights = SpotLightsMatch.Count;
                label8.Text = "Spot Lights: " + NumberOfSLights.ToString();

                //loop through all the matched blocks of text for Spot Lights
                SpotLightResults = new string[SpotLightsMatch.Count];

                for (i = 0; i < SpotLightsMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    SpotLightResults[i] = SpotLightsMatch[i].Groups[0].Value.ToString();

                    //check for missing entries, if so push default values into arrays
                    if (SpotLightResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        SLightsScale3D.Add(NoScale3D);
                    }

                    if (SpotLightResults[i].IndexOf("Location=") == -1)
                    {
                        SLightsLocation.Add(NoLocation);
                    }

                    if (SpotLightResults[i].IndexOf("DrawScale=") == -1)
                    {
                        SLightsScale.Add("1.000000");
                    }

                    if (SpotLightResults[i].IndexOf("Rotation=") == -1)
                    {
                        SLightsRotation.Add("Rotation=(Pitch=-16384,Yaw=0,Roll=0)");
                    }

                    if (SpotLightResults[i].IndexOf(" Radius=") == -1)
                    {
                        SLightsRadius.Add(NoRaduis);
                    }

                    if (SpotLightResults[i].IndexOf("InnerConeAngle=") == -1)
                    {
                        SLightsInnerRadius.Add(NoInnerCone);
                    }

                    if (SpotLightResults[i].IndexOf("OuterConeAngle=") == -1)
                    {
                        SLightsOutterRadius.Add(NoOutterCone);
                    }

                    if (SpotLightResults[i].IndexOf("LightColor=") == -1)
                    {
                        SLightsColor.Add(NoColor);
                    }

                    if (SpotLightResults[i].IndexOf("Brightness=") == -1)
                    {
                        SLightsIntensity.Add(NoIntensity);
                    }

                    if (SpotLightResults[i].IndexOf("Class=SpotLightMovable") == -1)
                    {
                        SLightsMoveable.Add(false);
                    }
                    else
                    {
                        SLightsMoveable.Add(true);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(SpotLightResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=SpotLight") != -1)
                        {
                            SLightsName.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            SLightsLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            SLightsRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            SLightsScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            SLightsScale3D.Add(value);
                        }

                        if (value.IndexOf(" Radius=") != -1)
                        {
                            SLightsRadius.Add(value);
                        }

                        if (value.IndexOf("InnerConeAngle=") != -1)
                        {
                            SLightsInnerRadius.Add(value);
                        }

                        if (value.IndexOf("OuterConeAngle=") != -1)
                        {
                            SLightsOutterRadius.Add(value);
                        }

                        if (value.IndexOf("LightColor=") != -1)
                        {
                            SLightsColor.Add(value);
                        }

                        if (value.IndexOf("Brightness=") != -1)
                        {
                            SLightsIntensity.Add(value);
                        }

                    }
                }
            }

            //find any Dominant Spot lights, insert default entries if missing, then store the data into arrays for access

            if (DomSLightsMatch.Count != 0)
            {

                NumberOfDomSLights = DomSLightsMatch.Count;
                label8.Text = "Spot Lights: " + (NumberOfSLights + NumberOfDomSLights).ToString();

                //loop through all the matched blocks of text for Spot Lights
                DomSLightResults = new string[DomSLightsMatch.Count];

                for (i = 0; i < DomSLightsMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    DomSLightResults[i] = DomSLightsMatch[i].Groups[0].Value.ToString();


                    //check for missing entries, if so push default values into arrays
                    if (DomSLightResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        DomSLightsScale3D.Add(NoScale3D);
                    }

                    if (DomSLightResults[i].IndexOf("Location=") == -1)
                    {
                        DomSLightsLocation.Add(NoLocation);
                    }

                    if (DomSLightResults[i].IndexOf("DrawScale=") == -1)
                    {
                        DomSLightsScale.Add("1.000000");
                    }

                    if (DomSLightResults[i].IndexOf("Rotation=") == -1)
                    {
                        DomSLightsRotation.Add("Rotation=(Pitch=-16384,Yaw=0,Roll=0)");
                    }

                    if (DomSLightResults[i].IndexOf(" Radius=") == -1)
                    {
                        DomSLightsRadius.Add(NoRaduis);
                    }

                    if (DomSLightResults[i].IndexOf("InnerConeAngle=") == -1)
                    {
                        DomSLightsInnerRadius.Add(NoInnerCone);
                    }

                    if (DomSLightResults[i].IndexOf("OuterConeAngle=") == -1)
                    {
                        DomSLightsOutterRadius.Add(NoOutterCone);
                    }

                    if (DomSLightResults[i].IndexOf("LightColor=") == -1)
                    {
                        DomSLightsColor.Add(NoColor);
                    }

                    if (DomSLightResults[i].IndexOf("Brightness=") == -1)
                    {
                        DomSLightsIntensity.Add(NoIntensity);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(DomSLightResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=DominantSpotLight") != -1)
                        {
                            DomSLightsName.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            DomSLightsLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            DomSLightsRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            DomSLightsScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            DomSLightsScale3D.Add(value);
                        }

                        if (value.IndexOf(" Radius=") != -1)
                        {
                            DomSLightsRadius.Add(value);
                        }

                        if (value.IndexOf("InnerConeAngle=") != -1)
                        {
                            DomSLightsInnerRadius.Add(value);
                        }

                        if (value.IndexOf("OuterConeAngle=") != -1)
                        {
                            DomSLightsOutterRadius.Add(value);
                        }

                        if (value.IndexOf("LightColor=") != -1)
                        {
                            DomSLightsColor.Add(value);
                        }

                        if (value.IndexOf("Brightness=") != -1)
                        {
                            DomSLightsIntensity.Add(value);
                        }

                    }
                }
            }

            //find any Directional lights, insert default entries if missing, then store the data into arrays for access

            if (DirLightsMatch.Count != 0)
            {
                NumberOfDLights = DirLightsMatch.Count;
                label9.Text = "Directional Lights: " + NumberOfDLights.ToString();

                //loop through all the matched blocks of text for Directional Lights
                DirLightResults = new string[DirLightsMatch.Count];

                for (i = 0; i < DirLightsMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    DirLightResults[i] = DirLightsMatch[i].Groups[0].Value.ToString();

                    //check for missing entries, if so push default values into arrays
                    if (DirLightResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        DLightsScale3D.Add(NoScale3D);
                    }

                    if (DirLightResults[i].IndexOf("Location=") == -1)
                    {
                        DLightsLocation.Add(NoLocation);
                    }

                    if (DirLightResults[i].IndexOf("DrawScale=") == -1)
                    {
                        DLightsScale.Add("1.000000");
                    }

                    if (DirLightResults[i].IndexOf("Rotation=") == -1)
                    {
                        DLightsRotation.Add("Rotation=(Pitch=-16384,Yaw=0,Roll=0)");
                    }

                    if (DirLightResults[i].IndexOf("LightColor=") == -1)
                    {
                        DLightsColor.Add(NoColor);
                    }

                    if (DirLightResults[i].IndexOf("Brightness=") == -1)
                    {
                        DLightsIntensity.Add(NoIntensity);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(DirLightResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=DirectionalLight") != -1)
                        {
                            DLightsName.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            DLightsLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            DLightsRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            DLightsScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            DLightsScale3D.Add(value);
                        }

                        if (value.IndexOf("LightColor=") != -1)
                        {
                            DLightsColor.Add(value);
                        }

                        if (value.IndexOf("Brightness=") != -1)
                        {
                            DLightsIntensity.Add(value);
                        }

                    }
                }
            }

            //find any Dominant Directional lights, insert default entries if missing, then store the data into arrays for access

            if (DomDLightsMatch.Count != 0)
            {

                NumberOfDomDLights = DomDLightsMatch.Count;
                label9.Text = "Directional Lights: " + (NumberOfDomDLights + NumberOfDLights).ToString();

                //loop through all the matched blocks of text for Directional Lights
                DomDLightResults = new string[DomDLightsMatch.Count];

                for (i = 0; i < DomDLightsMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    DomDLightResults[i] = DomDLightsMatch[i].Groups[0].Value.ToString();

                    //check for missing entries, if so push default values into arrays
                    if (DomDLightResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        DomDLightsScale3D.Add(NoScale3D);
                    }

                    if (DomDLightResults[i].IndexOf("Location=") == -1)
                    {
                        DomDLightsLocation.Add(NoLocation);
                    }

                    if (DomDLightResults[i].IndexOf("DrawScale=") == -1)
                    {
                        DomDLightsScale.Add("1.000000");
                    }

                    if (DomDLightResults[i].IndexOf("Rotation=") == -1)
                    {
                        DomDLightsRotation.Add("Rotation=(Pitch=-16384,Yaw=0,Roll=0)");
                    }

                    if (DomDLightResults[i].IndexOf("LightColor=") == -1)
                    {
                        DomDLightsColor.Add(NoColor);
                    }

                    if (DomDLightResults[i].IndexOf("Brightness=") == -1)
                    {
                        DomDLightsIntensity.Add(NoIntensity);
                    }

                    if (DomDLightResults[i].IndexOf("Class=DirLightMovable") == -1)
                    {
                        DomDLightsMoveable.Add(false);
                    }
                    else
                    {
                        DomDLightsMoveable.Add(true);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(DomDLightResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=DominantDirectionalLight") != -1)
                        {
                            DomDLightsName.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            DomDLightsLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            DomDLightsRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            DomDLightsScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            DomDLightsScale3D.Add(value);
                        }

                        if (value.IndexOf("LightColor=") != -1)
                        {
                            DomDLightsColor.Add(value);
                        }

                        if (value.IndexOf("Brightness=") != -1)
                        {
                            DomDLightsIntensity.Add(value);
                        }

                    }
                }
            }

            //find any PlayerStarts, insert default entries if missing, then store the data into arrays for access

            if (PlayerStartMatch.Count != 0)
            {
                NumberOfPlayerStarts = PlayerStartMatch.Count;
                label19.Text = "PlayerStarts: " + NumberOfPlayerStarts.ToString();

                //fill the results array with the matches
                PlayerStartResults = new string[PlayerStartMatch.Count];

                //loop through all the matched blocks of text for static meshes
                for (i = 0; i < PlayerStartMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    PlayerStartResults[i] = PlayerStartMatch[i].Groups[0].Value.ToString();

                    if (PlayerStartResults[i].IndexOf("Location=") == -1)
                    {
                        PlayerStartsLocation.Add(NoLocation);
                    }

                    //check for missing entries, if so push blank values into arrays
                    if (PlayerStartResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        PlayerStartsScale3D.Add(NoScale3D);
                    }

                    if (PlayerStartResults[i].IndexOf("DrawScale=") == -1)
                    {
                        PlayerStartsScale.Add("1.000000");
                    }

                    if (PlayerStartResults[i].IndexOf("Rotation=") == -1)
                    {
                        PlayerStartsRotation.Add(NoRotation);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(PlayerStartResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=PlayerStart") != -1)
                        {
                            PlayerStartsName.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {

                            PlayerStartsLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            PlayerStartsRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            PlayerStartsScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            PlayerStartsScale3D.Add(value);
                        }
                    }
                }
            }

            //find any Cameras, insert default entries if missing, then store the data into arrays for access

            if (CameraMatch.Count != 0)
            {
                NumberOfCameras = CameraMatch.Count;
                label12.Text = "Cameras: " + NumberOfCameras.ToString();

                //fill the results array with the matches
                CameraResults = new string[CameraMatch.Count];

                //loop through all the matched blocks of text for static meshes
                for (i = 0; i < CameraMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    CameraResults[i] = CameraMatch[i].Groups[0].Value.ToString();

                    if (CameraResults[i].IndexOf("Location=") == -1)
                    {

                        CamerasLocation.Add(NoLocation);
                    }

                    //check for missing entries, if so push blank values into arrays
                    if (CameraResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        CamerasScale3D.Add(NoScale3D);
                    }

                    if (CameraResults[i].IndexOf("DrawScale=") == -1)
                    {
                        CamerasScale.Add("1.000000");
                    }

                    if (CameraResults[i].IndexOf("Rotation=") == -1)
                    {
                        CamerasRotation.Add(NoRotation);
                    }

                    if (CameraResults[i].IndexOf("FOVAngle=") == -1)
                    {
                        CamerasFOV.Add("FOVAngle=90.000000");
                    }

                    if (CameraResults[i].IndexOf(" AspectRatio=") == -1)
                    {
                        CamerasAS.Add(" AspectRatio=1.777778");
                    }

                    if (CameraResults[i].IndexOf("bConstrainAspectRatio=") == -1)
                    {
                        CamerasConstrainAS.Add(false);
                    }
                    else
                    {
                        CamerasConstrainAS.Add(true);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(CameraResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=Camera") != -1)
                        {
                            CamerasName.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            CamerasLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            CamerasRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            CamerasScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            CamerasScale3D.Add(value);
                        }
                        if (value.IndexOf("FOVAngle=") != -1)
                        {
                            CamerasFOV.Add(value);
                        }

                        if (value.IndexOf(" AspectRatio=") != -1)
                        {
                            CamerasAS.Add(value);
                        }
                    }
                }
            }

            //find any sounds

            if (SoundsMatch.Count != 0)
            {
                NumberOfSounds = SoundsMatch.Count;
                //label23.text = "Sounds: " + NumberOfSounds.ToString();
                //fill the results array with the matches
                SoundsResults = new string[SoundsMatch.Count];

                //loop through all the matched blocks of text for static meshes
                for (i = 0; i < SoundsMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    SoundsResults[i] = SoundsMatch[i].Groups[0].Value.ToString();

                    if (SoundsResults[i].IndexOf("Location=") == -1)
                    {
                        SoundsLocation.Add(NoLocation);
                    }

                    if (SoundsResults[i].IndexOf("=AmbientSoundSimple") == -1)
                    {
                        SoundsSimple.Add(false);
                    }
                    else
                    {
                        SoundsSimple.Add(true);
                    }

                    if (SoundsResults[i].IndexOf(" SoundCue=") == -1)
                    {
                        SoundCue.Add(string.Empty);
                    }

                    if (SoundsResults[i].IndexOf("SoundSlots(0)=") == -1)
                    {
                        SoundsSlots.Add(string.Empty);
                    }

                    //check for mising entries, if so push blank values into arrays
                    if (SoundsResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        SoundsScale3D.Add(NoScale3D);
                    }

                    if (SoundsResults[i].IndexOf("DrawScale=") == -1)
                    {
                        SoundsScale.Add("1.000000");
                    }

                    if (SoundsResults[i].IndexOf("Rotation=") == -1)
                    {
                        SoundsRotation.Add(NoRotation);
                    }

                    if (SoundsResults[i].IndexOf(" bAttenuate=") == -1)
                    {
                        SoundsAttenuate.Add(false);
                    }
                    else
                    {
                        SoundsAttenuate.Add(true);
                    }

                    if (SoundsResults[i].IndexOf(" bAttenuateWithLPF=") == -1)
                    {
                        SoundsAttenuateLPF.Add(false);
                    }
                    else
                    {
                        SoundsAttenuateLPF.Add(true);
                    }


                    if (SoundsResults[i].IndexOf(" bSpatialize=") == -1)
                    {
                        SoundsSpatialize.Add(false);
                    }
                    else
                    {
                        SoundsSpatialize.Add(true);
                    }

                    if (SoundsResults[i].IndexOf(" LPFRadiusMin=") == -1)
                    {
                        SoundsLPFMin.Add("LPFRadiusMin=3500.0");
                    }

                    if (SoundsResults[i].IndexOf(" LPFRadiusMax=") == -1)
                    {
                        SoundsLPFMax.Add("LPFRadiusMax=7000.0");
                    }

                    if (SoundsResults[i].IndexOf(" DistanceModel=") == -1)
                    {
                        SoundsDM.Add(string.Empty);
                    }

                    if (SoundsResults[i].IndexOf(" RadiusMin=") == -1)
                    {
                        SoundsRadiusMin.Add("RadiusMin=2000.000000");
                    }

                    if (SoundsResults[i].IndexOf(" RadiusMax=") == -1)
                    {
                        SoundsRadiusMax.Add("RadiusMax=5000.000000");
                    }

                    if (SoundsResults[i].IndexOf(" PitchMin=") == -1)
                    {
                        SoundsPitchMin.Add("PitchMin=1.000000");
                    }

                    if (SoundsResults[i].IndexOf(" PitchMax=") == -1)
                    {
                        SoundsPitchMax.Add("PitchMax=1.000000");
                    }

                    if (SoundsResults[i].IndexOf(" VolumeMin=") == -1)
                    {
                        SoundsVolMin.Add("VolumeMin=0.700000");
                    }

                    if (SoundsResults[i].IndexOf(" VolumeMax=") == -1)
                    {
                        SoundsVolMax.Add("VolumeMax=0.700000");
                    }

                    if (SoundsResults[i].IndexOf(" HighFrequencyGainMultiplier=") == -1) {
                        SoundsHFMulti.Add("HighFrequencyGainMultiplier=1.000000");
                    }

                    if (SoundsResults[i].IndexOf(" VolumeMultiplier=") == -1)
                    {
                        SoundsVolumeMulti.Add("VolumeMultiplier=1.000000");
                    }

                    if (SoundsResults[i].IndexOf(" PitchMultiplier=") == -1)
                    {
                        SoundsPitchMulti.Add("PitchMultiplier=1.000000");
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(SoundsResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=AmbientSound") != -1)
                        {
                            SoundsName.Add(value);
                        }

                        if (value.IndexOf("SoundCue=") != -1)
                        {
                            SoundCue.Add(value);
                        }

                        if (value.IndexOf("SoundSlots(0)=") != -1)
                        {
                            SoundsSlots.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            SoundsLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            SoundsRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            SoundsScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            SoundsScale3D.Add(value);
                        }

                        if (value.IndexOf(" DistanceModel=") != -1)
                        {
                            SoundsDM.Add(value);
                        }

                        if (value.IndexOf(" RadiusMin=") != -1)
                        {
                            SoundsRadiusMin.Add(value);
                        }

                        if (value.IndexOf(" RadiusMax=") != -1)
                        {
                            SoundsRadiusMax.Add(value);
                        }

                        if (value.IndexOf(" PitchMin=") != -1)
                        {
                            SoundsPitchMin.Add(value);
                        }

                        if (value.IndexOf(" PitchMax=") != -1)
                        {
                            SoundsPitchMax.Add(value);
                        }

                        if (value.IndexOf(" VolumeMin=") != -1)
                        {
                            SoundsVolMin.Add(value);
                        }

                        if (value.IndexOf(" VolumeMax=") != -1)
                        {
                            SoundsVolMax.Add(value);
                        }

                        if (value.IndexOf(" HighFrequencyGainMultiplier=") != -1)
                        {
                            SoundsHFMulti.Add(value);
                        }

                        if (value.IndexOf(" VolumeMultiplier=") != -1)
                        {
                            SoundsVolumeMulti.Add(value);
                        }

                        if (value.IndexOf(" LPFRadiusMin=") != -1)
                        {
                            SoundsLPFMin.Add(value);
                        }

                        if (value.IndexOf(" LPFRadiusMax=") != -1)
                        {
                            SoundsLPFMax.Add(value);
                        }
                    }
                }

            }



            //find any decals

            if (DecalsMatch.Count != 0)
            {
                NumberOfDecals = DecalsMatch.Count;
                label20.Text = "Decals: " + NumberOfDecals.ToString();

                //fill the results array with the matches
                DecalsResults = new string[DecalsMatch.Count];

                //loop through all the matched blocks of text for static meshes
                for (i = 0; i < DecalsMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    DecalsResults[i] = DecalsMatch[i].Groups[0].Value.ToString();

                    if (DecalsResults[i].IndexOf(" Location=") == -1)
                    {
                        DecalsLocation.Add(NoLocation);
                    }

                    if (DecalsResults[i].IndexOf(" Rotation=") == -1)
                    {
                        DecalsRotation.Add(NoRotation);
                    }

                    if (DecalsResults[i].IndexOf("DecalMaterial=") == -1)
                    {
                        DecalsMat.Add("");
                    }

                    if (DecalsResults[i].IndexOf(" Width=") == -1)
                    {
                        DecalsWidth.Add("Width=200.000000");
                    }

                    if (DecalsResults[i].IndexOf(" Height") == -1)
                    {
                        DecalsHeight.Add("Height=200.000000");
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(DecalsResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=DecalActor") != -1)
                        {
                            DecalsName.Add(value);
                        }
                        if (value.IndexOf(" Location=") != -1)
                        {
                            DecalsLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            DecalsRotation.Add(value);
                        }

                        if (value.IndexOf("DecalMaterial=") != -1)
                        {
                            DecalsMat.Add(value);
                        }

                        if (value.IndexOf(" Width=") != -1)
                        {
                            DecalsWidth.Add(value);
                        }

                        if (value.IndexOf(" Height") != -1)
                        {
                            DecalsHeight.Add(value);
                        }
                    }
                }
            }

            //particles

            if (ParticlesMatch.Count != 0)
            {
                //store the number of assets, update the label
                NumberOfParticles = ParticlesMatch.Count;
                // label21.Text = "Particles: " + NumberOfParticles.ToString();

                //fill the results array with the matches
                ParticlesResults = new string[ParticlesMatch.Count];

                //loop through all the matched blocParticless of text for static meshes
                for (i = 0; i < ParticlesMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    ParticlesResults[i] = ParticlesMatch[i].Groups[0].Value.ToString();

                    if (ParticlesResults[i].IndexOf("Template=") == -1)
                    {
                        Particles.Add(string.Empty);
                    }

                    if (ParticlesResults[i].IndexOf("Location=") == -1)
                    {
                        ParticlesLocation.Add(NoLocation);
                    }

                    //checParticles for missing entries, if so push blanParticles values into arrays
                    if (ParticlesResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        ParticlesScale3D.Add(NoScale3D);
                    }

                    if (ParticlesResults[i].IndexOf("DrawScale=") == -1)
                    {
                        ParticlesScale.Add("1.000000");
                    }

                    if (ParticlesResults[i].IndexOf("Rotation=") == -1)
                    {
                        ParticlesRotation.Add(NoRotation);
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(ParticlesResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=Emitter") != -1)
                        {
                            ParticlesName.Add(value);
                        }
                        if (value.IndexOf("Template=") != -1)
                        {
                            Particles.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            ParticlesLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            ParticlesRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            ParticlesScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            ParticlesScale3D.Add(value);
                        }

                        materialsTemp = string.Empty;

                        if (value.IndexOf("Materials(") != -1)
                        {
                            materialsTemp = materialsTemp + value + "---";
                        }

                    }
                    if (materialsTemp != string.Empty) {
                        ParticlesMaterials.Add(materialsTemp);
                    }
                    else
                    {
                        ParticlesMaterials.Add(string.Empty);
                    }
                    materialsTemp = string.Empty;
                }
            }

            if (FogMatch.Count != 0)
            {
                //store the number of assets, update the label
                NumberofFog = FogMatch.Count;
                label22.Text = "Fog: " + NumberofFog.ToString();

                //fill the results array with the matches
                FogResults = new string[FogMatch.Count];

                //loop through all the matched blocFog of text for static meshes
                for (i = 0; i < FogMatch.Count; i++)
                {
                    //re-add the text that the Regex removed
                    FogResults[i] = FogMatch[i].Groups[0].Value.ToString();

                    if (FogResults[i].IndexOf("Begin Actor Class=ExponentialHeightFog") == -1)
                    {
                        FogName.Add(string.Empty);
                    }

                    if (FogResults[i].IndexOf("Location=") == -1)
                    {
                        FogLocation.Add(NoLocation);
                    }

                    //checFog for missing entries, if so push blanFog values into arrays
                    if (FogResults[i].IndexOf("DrawScale3D=") == -1)
                    {
                        FogScale3D.Add(NoScale3D);
                    }

                    if (FogResults[i].IndexOf("DrawScale=") == -1)
                    {
                        FogScale.Add("1.000000");
                    }

                    if (FogResults[i].IndexOf("Rotation=") == -1)
                    {
                        FogRotation.Add(NoRotation);
                    }

                    if (FogResults[i].IndexOf("Rotation=") == -1)
                    {
                        FogRotation.Add(NoRotation);
                    }

                    if (FogResults[i].IndexOf("FogDensity=") == -1)
                    {
                        FogDensity.Add("FogDensity=0.020000");
                    }

                    if (FogResults[i].IndexOf("FogHeightFalloff=") == -1)
                    {
                        FogHeightFalloff.Add("FogHeightFalloff=0.200000");
                    }

                    if (FogResults[i].IndexOf("FogMaxOpacity=") == -1)
                    {
                        FogMaxOpacity.Add("FogMaxOpacity=1.000000");
                    }

                    if (FogResults[i].IndexOf("StartDistance=") == -1)
                    {
                        FogStartDistance.Add("StartDistance=0");
                    }

                    if (FogResults[i].IndexOf("OppositeLightColor=") == -1)
                    {
                        FogOppLightColor.Add("OppositeLightColor=(B=243,G=208,R=177,A=0)");
                    }

                    if (FogResults[i].IndexOf("LightInscatteringColor=") == -1)
                    {
                        FogLightInScatterColor.Add("LightInscatteringColor=(B=31,G=212,R=245,A=0)");
                    }

                    //spilt each line of the text into an array to parse through
                    digits = Regex.Split(FogResults[i], @"\r?\n|\r");

                    foreach (string value in digits)
                    {
                        //add lines to Lists to store them.
                        if (value.IndexOf("Begin Actor Class=ExponentialHeightFog") != -1)
                        {
                            FogName.Add(value);
                        }
                        if (value.IndexOf("Location=") != -1)
                        {
                            FogLocation.Add(value);
                        }
                        if (value.IndexOf("Rotation=") != -1)
                        {
                            FogRotation.Add(value);
                        }
                        if (value.IndexOf("DrawScale=") != -1)
                        {
                            FogScale.Add(value);
                        }
                        if (value.IndexOf("DrawScale3D=") != -1)
                        {
                            FogScale3D.Add(value);
                        }
                        if (value.IndexOf("FogDensity=") != -1)
                        {
                            FogDensity.Add(value);
                        }
                        if (value.IndexOf("FogHeightFalloff=") != -1)
                        {
                            FogHeightFalloff.Add(value);
                        }
                        if (value.IndexOf("FogMaxOpacity=") != -1)
                        {
                            FogMaxOpacity.Add(value);
                        }
                        if (value.IndexOf("StartDistance=") != -1)
                        {
                            FogStartDistance.Add(value);
                        }
                        if (value.IndexOf("OppositeLightColor=") != -1)
                        {
                            FogOppLightColor.Add(value);
                        }
                        if (value.IndexOf("LightInscatteringColor=") != -1)
                        {
                            FogLightInScatterColor.Add(value);
                        }
                    }
                }
            }

            #endregion

            //convert the data and generate new T3D Syntax
            #region ConvertMesh

            if (checkedListBox1.GetItemCheckState(0) == CheckState.Checked)
            {
                if (StaticMeshmatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfAssets - 1; i++)
                    {
                        Name2[i] = ConversionTools.ConvertName(Name2, i);
                        StaticMesh[i] = ConversionTools.ConvertStaticMeshPath(StaticMesh, i, 0, TB_AssetPath);
                        location[i] = ConversionTools.ConvertLocation(location, i, CB_MultiplyPosition);
                        rotation[i] = ConversionTools.ConvertRotation(rotation, i);
                        scale[i] = ConversionTools.ConvertScale(scale, i);
                        scale3D[i] = ConversionTools.ConvertScale3D(scale3D, i, scale, richTextBox1, CB_MultiplyScale);
                        
                        //Console.Write(Materials[i] + Environment.NewLine);
                        if (Materials[i] != string.Empty && Materials[i] != null)
                        {
                            Materials[i] = ConversionTools.ConvertMaterial(Materials, i, TB_AssetPath);
                        }

                        if (CB_VertextColors.Checked == true)
                        {
                            if (VertexColors[i] != string.Empty && VertexColors[i] != null)
                            {
                                VertexColors[i] = ConversionTools.ConvertVC(VertexColors, VertexColorsData, i);
                            }

                            // Console.Write(NumOfVC);
                        }

                    }


                    if (CB_UE4Mode.Checked)
                    {
                        //create a new static mesh entry using UE4 syntax for every static mesh found
                        for (i = 0; i <= NumberOfAssets - 1; i++)
                        {
                            LoopOutput = LoopOutput + Environment.NewLine + "      Begin Actor Class=StaticMeshActor Name=" + Name2[i] + " Archetype=StaticMeshActor'/Script/Engine.Default__StaticMeshActor'" + Environment.NewLine + "         Begin Object Class=StaticMeshComponent Name=StaticMeshComponent0 ObjName=StaticMeshComponent0 Archetype=StaticMeshComponent'/Script/Engine.Default__StaticMeshActor:StaticMeshComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Name=StaticMeshComponent0" + Environment.NewLine;
                            LoopOutput = LoopOutput + "        " + StaticMesh[i] + Environment.NewLine;
                            if (Materials[i] != string.Empty)
                            {
                                LoopOutput = LoopOutput + Materials[i];
                            }
                            if (LightMap[i] != string.Empty)
                            {
                                LoopOutput = LoopOutput + "                    bOverrideLightMapRes=True" + Environment.NewLine + "        " + LightMap[i] + Environment.NewLine;
                            }
                            LoopOutput = LoopOutput + "                    BodyInstance=(Scale3D=(" + scale3D[i] + "))" + Environment.NewLine;
                            LoopOutput = LoopOutput + "           " + location[i] + Environment.NewLine + "            " + rotation[i] + Environment.NewLine + "                    RelativeScale3D=" + scale3D[i] + Environment.NewLine;

                            if (VertexColors[i] != string.Empty)
                            {
                                LoopOutput = LoopOutput + VertexColors[i] + Environment.NewLine;
                            }
                            LoopOutput = LoopOutput + "         End Object" + Environment.NewLine + "        StaticMeshComponent=StaticMeshComponent0" + Environment.NewLine + "        RootComponent=StaticMeshComponent0" + Environment.NewLine + "        ActorLabel=\"" + Name2[i] + "\"\n      End Actor";

                        }
                    }
                    else
                    {
                        //UE5
                        for (i = 0; i <= NumberOfAssets - 1; i++)
                        {
                            LoopOutput = LoopOutput + Environment.NewLine + "      Begin Actor Class=StaticMeshActor Name=" + Name2[i] + " Archetype=StaticMeshActor'/Script/Engine.Default__StaticMeshActor'" + Environment.NewLine + "         Begin Object Class=StaticMeshComponent Name=StaticMeshComponent0 ObjName=StaticMeshComponent0 Archetype=StaticMeshComponent'/Script/Engine.Default__StaticMeshActor:StaticMeshComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Name=StaticMeshComponent0" + Environment.NewLine;
                            LoopOutput = LoopOutput + "        " + StaticMesh[i] + Environment.NewLine;
                            if (Materials[i] != string.Empty)
                            {
                                LoopOutput = LoopOutput + Materials[i];
                            }
                            if (LightMap[i] != string.Empty)
                            {
                                LoopOutput = LoopOutput + "                    bOverrideLightMapRes=True" + Environment.NewLine + "        " + LightMap[i] + Environment.NewLine;
                            }
                            LoopOutput = LoopOutput + "                    BodyInstance=(Scale3D=(" + scale3D[i] + "))" + Environment.NewLine;
                            LoopOutput = LoopOutput + "           " + location[i] + Environment.NewLine + "            " + rotation[i] + Environment.NewLine + "                    RelativeScale3D=" + scale3D[i] + Environment.NewLine;

                            if (VertexColors[i] != string.Empty)
                            {
                                LoopOutput = LoopOutput + VertexColors[i] + Environment.NewLine;
                            }
                            LoopOutput = LoopOutput + "         End Object" + Environment.NewLine + "        StaticMeshComponent=StaticMeshComponent0" + Environment.NewLine + "        RootComponent=StaticMeshComponent0" + Environment.NewLine + "        ActorLabel=\"" + Name2[i] + "\"\n      End Actor";

                        }
                    }
                }
            }
            #endregion
            #region ConvertKActor 
            //KActor Output
            if (checkedListBox1.GetItemCheckState(2) == CheckState.Checked)
            {
                if (Kactormatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfKactors - 1; i++)
                    {
                        KName2[i] = ConversionTools.ConvertName(KName2, i);
                        KStaticMesh[i] = ConversionTools.ConvertStaticMeshPath(KStaticMesh, i, 0, TB_AssetPath);
                        Klocation[i] = ConversionTools.ConvertLocation(Klocation, i, CB_MultiplyPosition);
                        Krotation[i] = ConversionTools.ConvertRotation(Krotation, i);
                        Kscale[i] = ConversionTools.ConvertScale(Kscale, i);
                        Kscale3D[i] = ConversionTools.ConvertScale3D(Kscale3D, i, Kscale, richTextBox1, CB_MultiplyScale);

                        if (KMaterials[i] != string.Empty && KMaterials[i] != null)
                        {
                            KMaterials[i] = ConversionTools.ConvertMaterial(KMaterials, i, TB_AssetPath);
                        }
                    }

                    //create a new static mesh entry using UE4 syntax for every static mesh found
                    for (i = 0; i <= NumberOfKactors - 1; i++)
                    {
                        KactorOutput = KactorOutput + Environment.NewLine + "      Begin Actor Class=StaticMeshActor Name=" + KName2[i] + " Archetype=StaticMeshActor'/Script/Engine.Default__StaticMeshActor'" + Environment.NewLine + "         Begin Object Class=StaticMeshComponent Name=StaticMeshComponent0 ObjName=StaticMeshComponent0 Archetype=StaticMeshComponent'/Script/Engine.Default__StaticMeshActor:StaticMeshComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Name=StaticMeshComponent0" + Environment.NewLine;
                        KactorOutput = KactorOutput + "        " + KStaticMesh[i] + Environment.NewLine;
                        if (KMaterials[i] != string.Empty)
                        {
                            KactorOutput = KactorOutput + KMaterials[i];
                        }
                        if (KLightMap[i] != string.Empty)
                        {
                            LoopOutput = LoopOutput + "                    bOverrideLightMapRes=True" + Environment.NewLine + "     " + KLightMap[i] + Environment.NewLine;
                        }
                        KactorOutput = KactorOutput + "                    BodyInstance=(Scale3D=" + Kscale3D[i] + ",CollisionProfileName=\"PhysicsActor\",ObjectType=ECC_PhysicsBody,bSimulatePhysics=True)" + Environment.NewLine + "            Mobility=Movable" + Environment.NewLine;
                        KactorOutput = KactorOutput + "           " + Klocation[i] + Environment.NewLine + "            " + Krotation[i] + Environment.NewLine + "                    RelativeScale3D=" + Kscale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        StaticMeshComponent=StaticMeshComponent0" + Environment.NewLine;
                        if (Kdamage[i])
                        {
                            KactorOutput = KactorOutput + "bCanBeDamaged=True" + Environment.NewLine;
                        }
                        KactorOutput = KactorOutput + "       RootComponent=StaticMeshComponent0" + Environment.NewLine + "        ActorLabel=\"" + KName2[i] + "\"\n      End Actor";
                    }
                }
            }
            #endregion
            #region ConvertInterop
            //interop actors
            if (checkedListBox1.GetItemCheckState(3) == CheckState.Checked)
            {
                if (InterpMatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfInterp - 1; i++)
                    {
                        InterpName[i] = ConversionTools.ConvertName(InterpName, i);
                        InterpStaticMesh[i] = ConversionTools.ConvertStaticMeshPath(InterpStaticMesh, i, 0, TB_AssetPath);
                        InterpLocation[i] = ConversionTools.ConvertLocation(InterpLocation, i, CB_MultiplyPosition);
                        InterpRotation[i] = ConversionTools.ConvertRotation(InterpRotation, i);
                        InterpScale[i] = ConversionTools.ConvertScale(InterpScale, i);
                        InterpScale3D[i] = ConversionTools.ConvertScale3D(InterpScale3D, i, InterpScale, richTextBox1, CB_MultiplyScale);

                        if (InterpMaterials[i] != string.Empty && InterpMaterials[i] != null)
                        {
                            InterpMaterials[i] = ConversionTools.ConvertMaterial(InterpMaterials, i, TB_AssetPath);
                        }
                    }

                    //create a new static mesh entry using UE4 syntax for every static mesh found
                    for (i = 0; i <= NumberOfInterp - 1; i++)
                    {
                        InterpOutput = InterpOutput + Environment.NewLine + "      Begin Actor Class=StaticMeshActor Name=" + InterpName[i] + " Archetype=StaticMeshActor'/Script/Engine.Default__StaticMeshActor'" + Environment.NewLine + "         Begin Object Class=StaticMeshComponent Name=StaticMeshComponent0 ObjName=StaticMeshComponent0 Archetype=StaticMeshComponent'/Script/Engine.Default__StaticMeshActor:StaticMeshComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Name=StaticMeshComponent0" + Environment.NewLine;
                        InterpOutput = InterpOutput + "        " + InterpStaticMesh[i] + Environment.NewLine;
                        if (InterpMaterials[i] != string.Empty)
                        {
                            InterpOutput = InterpOutput + InterpMaterials[i];
                        }
                        if (InterpLightMap[i] != string.Empty)
                        {
                            LoopOutput = LoopOutput + "                    bOverrideLightMapRes=True" + Environment.NewLine + "     " + InterpLightMap[i] + Environment.NewLine;
                        }
                        InterpOutput = InterpOutput + "                    BodyInstance=(Scale3D=(" + InterpScale3D[i] + "))" + Environment.NewLine + "            Mobility=Movable" + Environment.NewLine;
                        InterpOutput = InterpOutput + "           " + InterpLocation[i] + Environment.NewLine + "            " + InterpRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + InterpScale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        StaticMeshComponent=StaticMeshComponent0" + Environment.NewLine;
                        InterpOutput = InterpOutput + "       RootComponent=StaticMeshComponent0" + Environment.NewLine + "        ActorLabel=\"" + InterpName[i] + "\"\n      End Actor";
                    }
                }
            }
            #endregion
            #region ConvertDestructable
            //destructable actors

            if (checkedListBox1.GetItemCheckState(4) == CheckState.Checked)
            {
                if (DestructMatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfDestruct - 1; i++)
                    {
                        DestructName[i] = ConversionTools.ConvertName(DestructName, i);
                        DestructStaticMesh[i] = ConversionTools.ConvertStaticMeshPath(DestructStaticMesh, i, 3, TB_AssetPath);
                        DestructLocation[i] = ConversionTools.ConvertLocation(DestructLocation, i, CB_MultiplyPosition);
                        DestructRotation[i] = ConversionTools.ConvertRotation(DestructRotation, i);
                        DestructScale[i] = ConversionTools.ConvertScale(DestructScale, i);
                        DestructScale3D[i] = ConversionTools.ConvertScale3D(DestructScale3D, i, DestructScale, richTextBox1, CB_MultiplyScale);

                        if (DestructMaterials[i] != string.Empty && DestructMaterials[i] != null)
                        {
                            DestructMaterials[i] = ConversionTools.ConvertMaterial(DestructMaterials, i, TB_AssetPath);
                        }
                    }

                    //create a new static mesh entry using UE4 syntax for every static mesh found
                    for (i = 0; i <= NumberOfDestruct - 1; i++)
                    {
                        DestructOutput = DestructOutput + "@      Begin Actor Class=DestructibleActor Name=" + DestructName[i] + " Archetype=DestructibleActor'/Script/Engine.Default__DestructibleActor'@         Begin Object Class=DestructibleComponent Name=\"DestructibleComponent0\" Archetype=DestructibleComponent'/Script/Engine.Default__DestructibleActor:DestructibleComponent0'@         End Object@         Begin Object Name=\"DestructibleComponent0\"";
                        DestructOutput = DestructOutput + "@        " + DestructStaticMesh[i] + Environment.NewLine + "@BodyInstance=(bNotifyRigidBodyCollision=True,bSimulatePhysics=True)";
                        if (DestructMaterials[i] != string.Empty)
                        {
                            DestructOutput = DestructOutput + DestructMaterials[i];
                        }
                        DestructOutput = DestructOutput + "           " + DestructLocation[i] + Environment.NewLine + "            " + DestructRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + DestructScale3D[i] + "@         End Object@         DestructibleComponent=DestructibleComponent0@         RootComponent=DestructibleComponent0";
                        DestructOutput = DestructOutput + "@        ActorLabel=\"" + DestructName[i] + "\"\n      End Actor";
                        DestructOutput = DestructOutput.Replace("@", Environment.NewLine);
                    }
                }

                if (ApexMatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfApex - 1; i++)
                    {
                        ApexName[i] = ConversionTools.ConvertName(ApexName, i);
                        ApexStaticMesh[i] = ConversionTools.ConvertStaticMeshPath(ApexStaticMesh, i, 3, TB_AssetPath);
                        ApexLocation[i] = ConversionTools.ConvertLocation(ApexLocation, i, CB_MultiplyPosition);
                        ApexRotation[i] = ConversionTools.ConvertRotation(ApexRotation, i);
                        ApexScale[i] = ConversionTools.ConvertScale(ApexScale, i);
                        ApexScale3D[i] = ConversionTools.ConvertScale3D(ApexScale3D, i, ApexScale, richTextBox1, CB_MultiplyScale);

                        if (ApexMaterials[i] != string.Empty && ApexMaterials[i] != null)
                        {
                            ApexMaterials[i] = ConversionTools.ConvertMaterial(ApexMaterials, i, TB_AssetPath);
                        }
                    }

                    //create a new static mesh entry using UE4 syntax for every static mesh found
                    for (i = 0; i <= NumberOfApex - 1; i++)
                    {
                        ApexOutput = ApexOutput + "@      Begin Actor Class=DestructibleActor Name=" + ApexName[i] + " Archetype=DestructibleActor'/Script/Engine.Default__DestructibleActor'@         Begin Object Class=DestructibleComponent Name=\"DestructibleComponent0\" Archetype=DestructibleComponent'/Script/Engine.Default__DestructibleActor:DestructibleComponent0'@         End Object@         Begin Object Name=\"DestructibleComponent0\"";
                        ApexOutput = ApexOutput + "@        " + ApexStaticMesh[i] + Environment.NewLine + "@BodyInstance=(bNotifyRigidBodyCollision=True,bSimulatePhysics=True)";
                        if (ApexMaterials[i] != string.Empty)
                        {
                            ApexOutput = ApexOutput + ApexMaterials[i];
                        }
                        ApexOutput = ApexOutput + "           " + ApexLocation[i] + Environment.NewLine + "            " + ApexRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + ApexScale3D[i] + "@         End Object@         DestructibleComponent=DestructibleComponent0@         RootComponent=DestructibleComponent0";
                        ApexOutput = ApexOutput + "@        ActorLabel=\"" + ApexName[i] + "\"\n      End Actor";
                        ApexOutput = ApexOutput.Replace("@", Environment.NewLine);
                    }
                }
            }
            #endregion
            #region ConvertFoilage
            //foliage actor output

            if (checkedListBox1.GetItemCheckState(5) == CheckState.Checked)
            {
                if (NumberOfFoliage != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfFoliage - 1; i++)
                    {
                        FoliageName[i] = ConversionTools.ConvertName(FoliageName, i);
                        FoliageStaticMesh[i] = ConversionTools.ConvertStaticMeshPath(FoliageStaticMesh, i, 0, TB_AssetPath);
                        FoliageLocation[i] = ConversionTools.ConvertLocation(FoliageLocation, i, CB_MultiplyPosition);
                        FoliageRotation[i] = ConversionTools.ConvertRotation(FoliageRotation, i);
                        FoliageScale[i] = ConversionTools.ConvertScale(FoliageScale, i);
                        FoliageScale3D[i] = ConversionTools.ConvertScale3D(FoliageScale3D, i, FoliageScale, richTextBox1, CB_MultiplyScale);

                        if (FoliageMaterials[i] != string.Empty || FoliageMaterials[i] != null)
                        {
                            FoliageMaterials[i] = ConversionTools.ConvertMaterial(FoliageMaterials, i, TB_AssetPath);
                        }
                    }

                    //create a new static mesh entry using UE4 syntax for every static mesh found
                    for (i = 0; i <= NumberOfFoliage - 1; i++)
                    {
                        FoliageOutput = FoliageOutput + Environment.NewLine + "      Begin Actor Class=StaticMeshActor Name=" + FoliageName[i] + " Archetype=StaticMeshActor'/Script/Engine.Default__StaticMeshActor'" + Environment.NewLine + "         Begin Object Class=StaticMeshComponent Name=StaticMeshComponent0 ObjName=StaticMeshComponent0 Archetype=StaticMeshComponent'/Script/Engine.Default__StaticMeshActor:StaticMeshComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Name=StaticMeshComponent0" + Environment.NewLine;
                        FoliageOutput = FoliageOutput + "        " + FoliageStaticMesh[i] + Environment.NewLine;
                        if (FoliageMaterials[i] != string.Empty)
                        {
                            FoliageOutput = FoliageOutput + FoliageMaterials[i];
                        }
                        if (FoliageLightMap[i] != string.Empty)
                        {
                            LoopOutput = LoopOutput + "                    bOverrideLightMapRes=True" + Environment.NewLine + "     " + FoliageLightMap[i] + Environment.NewLine;
                        }
                        FoliageOutput = FoliageOutput + "                    BodyInstance=(Scale3D=(" + FoliageScale3D[i] + "))" + Environment.NewLine;
                        FoliageOutput = FoliageOutput + "           " + FoliageLocation[i] + Environment.NewLine + "            " + FoliageRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + FoliageScale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        StaticMeshComponent=StaticMeshComponent0" + Environment.NewLine;
                        FoliageOutput = FoliageOutput + "       RootComponent=StaticMeshComponent0" + Environment.NewLine + "        ActorLabel=\"" + FoliageName[i] + "\"\n      End Actor";
                    }
                }
            }
            #endregion
            #region ConvertSkeletalMeshes
            //skeletal mesh output

            if (checkedListBox1.GetItemCheckState(1) == CheckState.Checked)
            {
                if (SkMeshmatch.Count != 0)
                {
                    //SKmeshOutput = SKStaticMesh.Count + "," + SKName.Count + "," + SKlocation.Count + "," + SKrotation.Count + "," + SKscale.Count + "," + SKscale3D.Count + "," + SKMaterials.Count;
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberofSKMesh - 1; i++)
                    {
                        SKName[i] = ConversionTools.ConvertName(SKName, i);
                        SKStaticMesh[i] = ConversionTools.ConvertStaticMeshPath(SKStaticMesh, i, 1, TB_AssetPath);
                        SKlocation[i] = ConversionTools.ConvertLocation(SKlocation, i, CB_MultiplyPosition);
                        SKrotation[i] = ConversionTools.ConvertRotation(SKrotation, i);
                        SKscale[i] = ConversionTools.ConvertScale(SKscale, i);
                        SKscale3D[i] = ConversionTools.ConvertScale3D(SKscale3D, i, SKscale, richTextBox1, CB_MultiplyScale);

                        if (SKMaterials[i] != string.Empty && SKMaterials[i] != null)
                        {
                            SKMaterials[i] = ConversionTools.ConvertMaterial(SKMaterials, i, TB_AssetPath);
                        }

                    }

                    //create a new static mesh entry using UE4 syntax for every static mesh found
                    for (i = 0; i <= NumberofSKMesh - 1; i++)
                    {

                        SKmeshOutput = SKmeshOutput + Environment.NewLine + "      Begin Actor Class=SkeletalMeshActor Name=" + SKName[i] + " Archetype=SkeletalMeshActor'/Script/Engine.Default__SkeletalMeshActor'" + Environment.NewLine + "         Begin Object Class=SkeletalMeshComponent Name=\"SkeletalMeshComponent0\" Archetype=SkeletalMeshComponent'/Script/Engine.Default__SkeletalMeshActor:SkeletalMeshComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Name=\"SkeletalMeshComponent0\"" + Environment.NewLine;
                        SKmeshOutput = SKmeshOutput + "        " + SKStaticMesh[i] + Environment.NewLine;
                        if (SKMaterials[i] != string.Empty)
                        {
                            SKmeshOutput = SKmeshOutput + SKMaterials[i];
                        }
                        SKmeshOutput = SKmeshOutput + "           " + SKlocation[i] + Environment.NewLine + "            " + SKrotation[i] + Environment.NewLine + "                    RelativeScale3D=" + SKscale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        SkeletalMeshComponent=SkeletalMeshComponent0" + Environment.NewLine + "        RootComponent=SkeletalMeshComponent0" + Environment.NewLine + "        ActorLabel=\"" + SKName[i] + "\"\n      End Actor";

                    }
                }
            }
            #endregion
            #region ConvertPointLights

            if (checkedListBox1.GetItemCheckState(6) == CheckState.Checked)
            {
                if (PointLightsMatch.Count != 0)
                {
                    for (i = 0; i <= NumberOfPLights - 1; i++)
                    {
                        PLightsName[i] = ConversionTools.ConvertName(PLightsName, i);
                        PLightsLocation[i] = ConversionTools.ConvertLocation(PLightsLocation, i, CB_MultiplyPosition);
                        PLightsRotation[i] = ConversionTools.ConvertRotation(PLightsRotation, i);
                        PLightsScale[i] = ConversionTools.ConvertScale(PLightsScale, i);
                        PLightsScale3D[i] = ConversionTools.ConvertScale3D(PLightsScale3D, i, PLightsScale, richTextBox1, CB_MultiplyScale);
                        PLightsIntensity[i] = ConversionTools.ConvertIntensity(PLightsIntensity, i, false);
                        PLightsRadius[i] = ConversionTools.ConvertRadius(PLightsRadius, i);
                    }

                    for (i = 0; i <= NumberOfPLights - 1; i++)
                    {
                        PLightOutput = PLightOutput + "      Begin Actor Class=PointLight  Name=" + PLightsName[i] + " Archetype=PointLight'/Script/Engine.Default__PointLight'" + Environment.NewLine + "         Begin Object Class=PointLightComponent Name=\"LightComponent0\" Archetype=PointLightComponent'/Script/Engine.Default__PointLight:LightComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Name=\"LightComponent0\"" + Environment.NewLine;
                        if (PLightsMoveable[i] == true)
                        {
                            PLightOutput = PLightOutput + "                    Mobility=Movable" + Environment.NewLine;
                        }
                        else
                        {
                            if (CB_StaticLights.Checked)
                            {
                                PLightOutput = PLightOutput + "                    Mobility=Static" + Environment.NewLine;
                            }
                        }
                        PLightOutput = PLightOutput + "                    " + PLightsRadius[i] + Environment.NewLine + "        " + PLightsColor[i] + Environment.NewLine + "                    " + PLightsIntensity[i] + Environment.NewLine + "           " + PLightsLocation[i] + Environment.NewLine + "            " + PLightsRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + PLightsScale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        PointLightComponent=LightComponent0" + Environment.NewLine + "        LightComponent=LightComponent0" + Environment.NewLine + "        RootComponent=LightComponent0" + Environment.NewLine + "        ActorLabel=\"" + PLightsName[i] + "\"\n      End Actor" + Environment.NewLine;
                    }

                    // PLightOutput = PLightsName.Count.ToString() + ", " + PLightsLocation.Count.ToString() + ", " + PLightsRotation.Count.ToString() + ", " + PLightsScale.Count.ToString() + ", " + PLightsScale3D.Count.ToString() + ", " + PLightsIntensity.Count.ToString() + ", " + PLightsRadius.Count.ToString() + ", " + PLightsColor.Count.ToString();
                }


                if (DomPlightsMatch.Count != 0)
                {
                    for (i = 0; i <= NumberOfDomPLights - 1; i++)
                    {
                        DomPLightsName[i] = ConversionTools.ConvertName(DomPLightsName, i);
                        DomPLightsLocation[i] = ConversionTools.ConvertLocation(DomPLightsLocation, i, CB_MultiplyPosition);
                        DomPLightsRotation[i] = ConversionTools.ConvertRotation(DomPLightsRotation, i);
                        DomPLightsScale[i] = ConversionTools.ConvertScale(DomPLightsScale, i);
                        DomPLightsScale3D[i] = ConversionTools.ConvertScale3D(DomPLightsScale3D, i, DomPLightsScale, richTextBox1, CB_MultiplyScale);
                        DomPLightsIntensity[i] = ConversionTools.ConvertIntensity(DomPLightsIntensity, i, false);
                        DomPLightsRadius[i] = ConversionTools.ConvertRadius(DomPLightsRadius, i);
                    }

                    for (i = 0; i <= NumberOfDomPLights - 1; i++)
                    {
                        DomPLightOutput = DomPLightOutput + "      Begin Actor Class=PointLight  Name=" + DomPLightsName[i] + " Archetype=PointLight'/Script/Engine.Default__PointLight'" + Environment.NewLine + "         Begin Object Class=PointLightComponent Name=\"LightComponent0\" Archetype=PointLightComponent'/Script/Engine.Default__PointLight:LightComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Name=\"LightComponent0\"" + Environment.NewLine;
                        DomPLightOutput = DomPLightOutput + "                    " + DomPLightsRadius[i] + Environment.NewLine + "        " + DomPLightsColor[i] + Environment.NewLine + "                    " + DomPLightsIntensity[i] + Environment.NewLine + "           " + DomPLightsLocation[i] + Environment.NewLine + "            " + DomPLightsRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + DomPLightsScale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        PointLightComponent=LightComponent0" + Environment.NewLine + "        LightComponent=LightComponent0" + Environment.NewLine + "        RootComponent=LightComponent0" + Environment.NewLine + "        ActorLabel=\"" + DomPLightsName[i] + "\"\n      End Actor" + Environment.NewLine;
                    }

                    //DomPLightOutput = DomPLightsName.Count.ToString() + ", " + DomPLightsLocation.Count.ToString() + ", " + DomPLightsRotation.Count.ToString() + ", " + DomPLightsScale.Count.ToString() + ", " + DomPLightsScale3D.Count.ToString() + ", " + DomPLightsIntensity.Count.ToString() + ", " + DomPLightsRadius.Count.ToString() + ", " + DomPLightsColor.Count.ToString();
                }
            }
            #endregion
            #region ConvertSpotLights

            if (checkedListBox1.GetItemCheckState(6) == CheckState.Checked)
            {
                if (SpotLightsMatch.Count != 0)
                {
                    for (i = 0; i <= NumberOfSLights - 1; i++)
                    {
                        SLightsName[i] = ConversionTools.ConvertName(SLightsName, i);
                        SLightsLocation[i] = ConversionTools.ConvertLocation(SLightsLocation, i, CB_MultiplyPosition);
                        SLightsRotation[i] = ConversionTools.ConvertRotation(SLightsRotation, i);
                        SLightsScale[i] = ConversionTools.ConvertScale(SLightsScale, i);
                        SLightsScale3D[i] = ConversionTools.ConvertScale3D(SLightsScale3D, i, SLightsScale, richTextBox1, CB_MultiplyScale);
                        SLightsIntensity[i] = ConversionTools.ConvertIntensity(SLightsIntensity, i, false);
                        SLightsRadius[i] = ConversionTools.ConvertRadius(SLightsRadius, i);
                    }

                    for (i = 0; i <= NumberOfSLights - 1; i++)
                    {
                        SLightOutput = SLightOutput + "      Begin Actor Class=SpotLight   Name=" + SLightsName[i] + " Archetype=SpotLight'/Script/Engine.Default__SpotLight'" + Environment.NewLine + "         Begin Object Class=ArrowComponent Name=\"ArrowComponent0\"  Archetype=ArrowComponent'/Script/Engine.Default__SpotLight:ArrowComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Class=SpotLightComponent Name=\"LightComponent0\" Archetype=SpotLightComponent'/Script/Engine.Default__SpotLight:LightComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "            Begin Object Name=\"ArrowComponent0\"" + Environment.NewLine + "            AttachParent=LightComponent0" + Environment.NewLine + "         End Object" + Environment.NewLine + "Begin Object Name=\"LightComponent0\"";
                        if (SLightsMoveable[i] == true)
                        {
                            SLightOutput = SLightOutput + Environment.NewLine + "                    Mobility=Movable";
                        }
                        else
                        {
                            if (CB_StaticLights.Checked)
                            {
                                SLightOutput = SLightOutput + Environment.NewLine + "                    Mobility=Static";
                            }
                        }
                        SLightOutput = SLightOutput + Environment.NewLine + "                    " + SLightsRadius[i] + Environment.NewLine + "                    " + SLightsInnerRadius[i] + Environment.NewLine + "                    " + SLightsOutterRadius[i] + Environment.NewLine + "                    " + SLightsColor[i] + Environment.NewLine + "                    " + SLightsIntensity[i] + Environment.NewLine + "           " + SLightsLocation[i] + Environment.NewLine + "            " + SLightsRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + SLightsScale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        SpotLightComponent=LightComponent0" + Environment.NewLine + "        ArrowComponent=ArrowComponent0" + Environment.NewLine + "        LightComponent=LightComponent0" + Environment.NewLine + "        RootComponent=LightComponent0" + Environment.NewLine + "        ActorLabel=\"" + SLightsName[i] + "\"\n      End Actor" + Environment.NewLine;
                    }

                    //SLightOutput = SLightsName.Count.ToString() + ", " + SLightsLocation.Count.ToString() + ", " + SLightsRotation.Count.ToString() + ", " + SLightsScale.Count.ToString() + ", " + SLightsScale3D.Count.ToString() + ", " + SLightsIntensity.Count.ToString() + ", " + SLightsInnerRadius.Count.ToString() + ", " + SLightsOutterRadius.Count.ToString() + ", " + SLightsColor.Count.ToString();
                }

                if (DomSLightsMatch.Count != 0)
                {
                    for (i = 0; i <= NumberOfDomSLights - 1; i++)
                    {
                        DomSLightsName[i] = ConversionTools.ConvertName(DomSLightsName, i);
                        DomSLightsLocation[i] = ConversionTools.ConvertLocation(DomSLightsLocation, i, CB_MultiplyPosition);
                        DomSLightsRotation[i] = ConversionTools.ConvertRotation(DomSLightsRotation, i);
                        DomSLightsScale[i] = ConversionTools.ConvertScale(DomSLightsScale, i);
                        DomSLightsScale3D[i] = ConversionTools.ConvertScale3D(DomSLightsScale3D, i, DomSLightsScale, richTextBox1, CB_MultiplyScale);
                        DomSLightsIntensity[i] = ConversionTools.ConvertIntensity(DomSLightsIntensity, i, false);
                        DomSLightsRadius[i] = ConversionTools.ConvertRadius(DomSLightsRadius, i);
                    }

                    for (i = 0; i <= NumberOfDomSLights - 1; i++)
                    {
                        DomSLightOutput = DomSLightOutput + "      Begin Actor Class=SpotLight   Name=" + DomSLightsName[i] + " Archetype=SpotLight'/Script/Engine.Default__SpotLight'" + Environment.NewLine + "         Begin Object Class=ArrowComponent Name=\"ArrowComponent0\"  Archetype=ArrowComponent'/Script/Engine.Default__SpotLight:ArrowComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Class=SpotLightComponent Name=\"LightComponent0\" Archetype=SpotLightComponent'/Script/Engine.Default__SpotLight:LightComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "            Begin Object Name=\"ArrowComponent0\"" + Environment.NewLine + "            AttachParent=LightComponent0" + Environment.NewLine + "         End Object" + Environment.NewLine + "Begin Object Name=\"LightComponent0\"";
                        DomSLightOutput = DomSLightOutput + Environment.NewLine + "                    " + DomSLightsRadius[i] + Environment.NewLine + "                    " + DomSLightsInnerRadius[i] + Environment.NewLine + "                    " + DomSLightsOutterRadius[i] + Environment.NewLine + "                    " + DomSLightsColor[i] + Environment.NewLine + "                    " + DomSLightsIntensity[i] + Environment.NewLine + "           " + DomSLightsLocation[i] + Environment.NewLine + "            " + DomSLightsRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + DomSLightsScale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        SpotLightComponent=LightComponent0" + Environment.NewLine + "        ArrowComponent=ArrowComponent0" + Environment.NewLine + "        LightComponent=LightComponent0" + Environment.NewLine + "        RootComponent=LightComponent0" + Environment.NewLine + "        ActorLabel=\"" + DomSLightsName[i] + "\"\n      End Actor" + Environment.NewLine;
                    }

                    //SLightOutput = DomSLightsName.Count.ToString() + ", " + DomSLightsLocation.Count.ToString() + ", " + DomSLightsRotation.Count.ToString() + ", " + DomSLightsScale.Count.ToString() + ", " + DomSLightsScale3D.Count.ToString() + ", " + DomSLightsIntensity.Count.ToString() + ", " + DomSLightsInnerRadius.Count.ToString() + ", " + DomSLightsOutterRadius.Count.ToString() + ", " + DomSLightsColor.Count.ToString();
                }
            }
            #endregion
            #region ConvertDirectionalLights

            if (checkedListBox1.GetItemCheckState(8) == CheckState.Checked)
            {
                if (DirLightsMatch.Count != 0)
                {
                    for (i = 0; i <= NumberOfDLights - 1; i++)
                    {
                        DLightsName[i] = ConversionTools.ConvertName(DLightsName, i);
                        DLightsLocation[i] = ConversionTools.ConvertLocation(DLightsLocation, i, CB_MultiplyPosition);
                        DLightsRotation[i] = ConversionTools.ConvertRotation(DLightsRotation, i);
                        DLightsScale[i] = ConversionTools.ConvertScale(DLightsScale, i);
                        DLightsScale3D[i] = ConversionTools.ConvertScale3D(DLightsScale3D, i, DLightsScale, richTextBox1, CB_MultiplyScale);
                        DLightsIntensity[i] = ConversionTools.ConvertIntensity(DLightsIntensity, i, true);
                    }

                    for (i = 0; i <= NumberOfDLights - 1; i++)
                    {
                        DLightOutput = DLightOutput + "      Begin Actor Class=DirectionalLight Name=" + DLightsName[i] + " Archetype=DirectionalLight'/Script/Engine.Default__DirectionalLight'" + Environment.NewLine + "         Begin Object Class=ArrowComponent Name=\"ArrowComponent0\" Archetype=ArrowComponent'/Script/Engine.Default__DirectionalLight:ArrowComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Class=DirectionalLightComponent Name=\"LightComponent0\" Archetype=DirectionalLightComponent'/Script/Engine.Default__DirectionalLight:LightComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "            Begin Object Name=\"ArrowComponent0\"" + Environment.NewLine + "            ArrowColor=(B=33,G=0,R=255,A=255)" + Environment.NewLine + "            AttachParent=LightComponent0" + Environment.NewLine + "         End Object" + Environment.NewLine + "Begin Object Name=\"LightComponent0\"";
                        DLightOutput = DLightOutput + Environment.NewLine + "                    " + DLightsColor[i] + Environment.NewLine + "                    " + DLightsIntensity[i] + Environment.NewLine + "           " + DLightsLocation[i] + Environment.NewLine + "            " + DLightsRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + DLightsScale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        SpotLightComponent=LightComponent0" + Environment.NewLine + "        ArrowComponent=ArrowComponent0" + Environment.NewLine + "        LightComponent=LightComponent0" + Environment.NewLine + "        RootComponent=LightComponent0" + Environment.NewLine + "        ActorLabel=\"" + DLightsName[i] + "\"\n      End Actor" + Environment.NewLine;
                    }
                    //DLightOutput = DLightsName.Count.ToString() + ", " + DLightsLocation.Count.ToString() + ", " + DLightsRotation.Count.ToString() + ", " + DLightsScale.Count.ToString() + ", " + DLightsScale3D.Count.ToString() + ", " + DLightsIntensity.Count.ToString() + ", " + DLightsColor.Count.ToString();
                }

                if (DomDLightsMatch.Count != 0)
                {
                    for (i = 0; i <= NumberOfDomDLights - 1; i++)
                    {
                        DomDLightsName[i] = ConversionTools.ConvertName(DomDLightsName, i);
                        DomDLightsLocation[i] = ConversionTools.ConvertLocation(DomDLightsLocation, i, CB_MultiplyPosition);
                        DomDLightsRotation[i] = ConversionTools.ConvertRotation(DomDLightsRotation, i);
                        DomDLightsScale[i] = ConversionTools.ConvertScale(DomDLightsScale, i);
                        DomDLightsScale3D[i] = ConversionTools.ConvertScale3D(DomDLightsScale3D, i, DomDLightsScale, richTextBox1, CB_MultiplyScale);
                        DomDLightsIntensity[i] = ConversionTools.ConvertIntensity(DomDLightsIntensity, i, true);
                    }

                    for (i = 0; i <= NumberOfDomDLights - 1; i++)
                    {
                        DomDLightOutput = DomDLightOutput + "      Begin Actor Class=DirectionalLight Name=" + DomDLightsName[i] + " Archetype=DirectionalLight'/Script/Engine.Default__DirectionalLight'" + Environment.NewLine + "         Begin Object Class=ArrowComponent Name=\"ArrowComponent0\" Archetype=ArrowComponent'/Script/Engine.Default__DirectionalLight:ArrowComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "         Begin Object Class=DirectionalLightComponent Name=\"LightComponent0\" Archetype=DirectionalLightComponent'/Script/Engine.Default__DirectionalLight:LightComponent0'" + Environment.NewLine + "         End Object" + Environment.NewLine + "            Begin Object Name=\"ArrowComponent0\"" + Environment.NewLine + "            ArrowColor=(B=33,G=0,R=255,A=255)" + Environment.NewLine + "            AttachParent=LightComponent0" + Environment.NewLine + "         End Object" + Environment.NewLine + "Begin Object Name=\"LightComponent0\"";
                        if (DomDLightsMoveable[i] == true)
                        {
                            DomDLightOutput = DomDLightOutput + Environment.NewLine + "                    Mobility=Movable";
                        }
                        else
                        {
                            if (CB_StaticLights.Checked)
                            {
                                DomDLightOutput = DomDLightOutput + Environment.NewLine + "                    Mobility=Static";
                            }
                        }
                        DomDLightOutput = DomDLightOutput + Environment.NewLine + "                    " + DomDLightsColor[i] + Environment.NewLine + "                    " + DomDLightsIntensity[i] + Environment.NewLine + "           " + DomDLightsLocation[i] + Environment.NewLine + "            " + DomDLightsRotation[i] + Environment.NewLine + "                    RelativeScale3D=" + DomDLightsScale3D[i] + Environment.NewLine + "         End Object" + Environment.NewLine + "        SpotLightComponent=LightComponent0" + Environment.NewLine + "        ArrowComponent=ArrowComponent0" + Environment.NewLine + "        LightComponent=LightComponent0" + Environment.NewLine + "        RootComponent=LightComponent0" + Environment.NewLine + "        ActorLabel=\"" + DomDLightsName[i] + "\"\n      End Actor" + Environment.NewLine;
                    }
                    // DomDLightOutput = DomDLightsName.Count.ToString() + ", " + DomDLightsLocation.Count.ToString() + ", " + DomDLightsRotation.Count.ToString() + ", " + DomDLightsScale.Count.ToString() + ", " + DomDLightsScale3D.Count.ToString() + ", " + DomDLightsIntensity.Count.ToString() + ", " + DomDLightsColor.Count.ToString();
                }
            }
            #endregion
            #region ConvertPlayerStarts

            if (checkedListBox1.GetItemCheckState(9) == CheckState.Checked)
            {
                if (PlayerStartMatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfPlayerStarts - 1; i++)
                    {
                        PlayerStartsName[i] = ConversionTools.ConvertName(PlayerStartsName, i);
                        PlayerStartsLocation[i] = ConversionTools.ConvertLocation(PlayerStartsLocation, i, CB_MultiplyPosition);
                        PlayerStartsRotation[i] = ConversionTools.ConvertRotation(PlayerStartsRotation, i);
                        PlayerStartsScale[i] = ConversionTools.ConvertScale(PlayerStartsScale, i);
                        PlayerStartsScale3D[i] = ConversionTools.ConvertScale3D(PlayerStartsScale3D, i, PlayerStartsScale, richTextBox1, CB_MultiplyScale);
                    }

                    //create a new static mesh entry using UE4 syntax for every static mesh found
                    for (i = 0; i <= NumberOfPlayerStarts - 1; i++)
                    {
                        PlayerStartOutput = PlayerStartOutput + "@      Begin Actor Class=PlayerStart Name=" + PlayerStartsName[i] + " Archetype=PlayerStart'/Script/Engine.Default__PlayerStart'@         Begin Object Class=CapsuleComponent Name=\"CollisionCapsule\" Archetype=CapsuleComponent'/Script/Engine.Default__PlayerStart:CollisionCapsule'@            Begin Object Class=BodySetup Name=\"BodySetup_0\"@            End Object@         End Object@         Begin Object Class=BillboardComponent Name=\"Sprite\" Archetype=BillboardComponent'/Script/Engine.Default__PlayerStart:Sprite'@         End Object@         Begin Object Class=BillboardComponent Name=\"Sprite2\" Archetype=BillboardComponent'/Script/Engine.Default__PlayerStart:Sprite2'@         End Object@         Begin Object Class=ArrowComponent Name=\"Arrow\" Archetype=ArrowComponent'/Script/Engine.Default__PlayerStart:Arrow'@         End Object@         Begin Object Name=\"CollisionCapsule\"@            Begin Object Name=\"BodySetup_0\"@               AggGeom=(SphylElems=((TM=(XPlane=(W=0.000000,X=1.000000,Y=0.000000,Z=0.000000),YPlane=(W=0.000000,X=0.000000,Y=-0.000000,Z=1.000000),ZPlane=(W=1.000000,X=-290.000000,Y=11220.000000,Z=260.000000),WPlane=(W=0.000000,X=0.000000,Y=0.000000,Z=-47291914961027072.000000)),Radius=40.000000,Length=104.000000)))@               CollisionTraceFlag=CTF_UseSimpleAsComplex@            End Object";
                        PlayerStartOutput = PlayerStartOutput + "@           " + PlayerStartsLocation[i] + "@            " + PlayerStartsRotation[i] + "@                    RelativeScale3D=" + PlayerStartsScale3D[i] + "@End Object@         Begin Object Name=\"Sprite\"@            AttachParent=CollisionCapsule@         End Object@         Begin Object Name=\"Sprite2\"@            AttachParent=CollisionCapsule@         End Object@         Begin Object Name=\"Arrow\"@            AttachParent=CollisionCapsule@         End Object@         ArrowComponent=Arrow@         CapsuleComponent=CollisionCapsule@         GoodSprite=Sprite@         BadSprite=Sprite2@         RootComponent=CollisionCapsule@         ActorLabel=\"" + PlayerStartsName[i] + "\"@      End Actor";
                        PlayerStartOutput = PlayerStartOutput.Replace("@", Environment.NewLine);
                    }
                }
            }

            if (checkedListBox1.GetItemCheckState(10) == CheckState.Checked)
            {
                if (CameraMatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfCameras - 1; i++)
                    {
                        CamerasName[i] = ConversionTools.ConvertName(CamerasName, i);
                        CamerasLocation[i] = ConversionTools.ConvertLocation(CamerasLocation, i, CB_MultiplyPosition);
                        CamerasRotation[i] = ConversionTools.ConvertRotation(CamerasRotation, i);
                        CamerasScale[i] = ConversionTools.ConvertScale(CamerasScale, i);
                        CamerasScale3D[i] = ConversionTools.ConvertScale3D(CamerasScale3D, i, CamerasScale, richTextBox1, CB_MultiplyScale);
                        CamerasFOV[i] = ConversionTools.ConvertFOV(CamerasFOV, i);
                        CamerasAS[i] = ConversionTools.ConvertFOV(CamerasAS, i);
                    }

                    //create a new Camera entry using UE4 syntax for every Camera found
                    for (i = 0; i <= NumberOfCameras - 1; i++)
                    {
                        CameraOutput = CameraOutput + "@      Begin Actor Class=CameraActor Name=" + CamerasName[i] + " Archetype=CameraActor'/Script/Engine.Default__CameraActor'@         Begin Object Class=DrawFrustumComponent Name=\"DrawFrustumComponent_17\"@         End Object@         Begin Object Class=StaticMeshComponent Name=\"StaticMeshComponent_22\"@         End Object@         Begin Object Class=CameraComponent Name=\"CameraComponent\" Archetype=CameraComponent'/Script/Engine.Default__CameraActor:CameraComponent'@         End Object@         Begin Object Name=\"DrawFrustumComponent_17\"@            FrustumAngle=";
                        CameraOutput = CameraOutput + CamerasFOV[i] + "@";
                        CameraOutput = CameraOutput + "            FrustumAspectRatio=" + CamerasAS[i] + "@";
                        CameraOutput = CameraOutput + "            FrustumStartDist=10.000000@            AlwaysLoadOnClient=False@            AlwaysLoadOnServer=False@            AttachParent=CameraComponent@         End Object@         Begin Object Name=\"StaticMeshComponent_22\"@            StaticMesh=StaticMesh'/Engine/EditorMeshes/MatineeCam_SM.MatineeCam_SM'@            CastShadow=False@            BodyInstance=(ResponseToChannels=(Visibility=ECR_Ignore,Camera=ECR_Ignore),CollisionProfileName=\"NoCollision\",CollisionEnabled=NoCollision,ObjectType=ECC_WorldStatic,CollisionResponses=(ResponseArray=((Channel=\"Visibility\",Response=ECR_Ignore),(Channel=\"Camera\",Response=ECR_Ignore))))@            bHiddenInGame=True@            AttachParent=CameraComponent@         End Object@         Begin Object Name=\"CameraComponent\"@";
                        CameraOutput = CameraOutput + "            FieldOfView=" + CamerasFOV[i] + "@            AspectRatio=" + CamerasAS[i] + "@";
                        if (CamerasConstrainAS[i])
                        {
                            CameraOutput = CameraOutput + "            bConstrainAspectRatio = False@";
                        }
                        CameraOutput = CameraOutput + "   " + CamerasLocation[i] + "@            RelativeScale3D=" + CamerasScale3D[i] + "@   " + CamerasRotation[i] + "@         End Object@         CameraComponent=CameraComponent@         RootComponent=CameraComponent@         ActorLabel=\"" + CamerasName[i] + "\"@      End Actor";
                        CameraOutput = CameraOutput.Replace("@", Environment.NewLine);
                    }
                }
            }
            #endregion
            #region ConvertDecals

            if (checkedListBox1.GetItemCheckState(11) == CheckState.Checked)
            {
                if (DecalsMatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfDecals - 1; i++)
                    {
                        DecalsName[i] = ConversionTools.ConvertName(DecalsName, i);
                        DecalsLocation[i] = ConversionTools.ConvertLocation(DecalsLocation, i, CB_MultiplyPosition);
                        DecalsRotation[i] = ConversionTools.ConvertRotation(DecalsRotation, i);
                        DecalsMat[i] = ConversionTools.ConvertDecalMat(DecalsMat, i,TB_AssetPath);
                        temp2 = ConversionTools.GetDecalScale(DecalsWidth, DecalsHeight, i, CB_MultiplyScale);
                    }

                    //create a new Decal entry using UE4 syntax for every Decal found
                    for (i = 0; i <= NumberOfDecals - 1; i++)
                    {
                        DecalsOutput = DecalsOutput + "@      Begin Actor Class=DecalActor " + DecalsName[i] + " Archetype=DecalActor'Engine.Default__DecalActor'";
                        DecalsOutput = DecalsOutput + "@         Begin Object Class=DecalComponent Name=\"NewDecalComponent\" Archetype=DecalComponent'/Script/Engine.Default__DecalActor:NewDecalComponent'@         End Object@         Begin Object Class=BoxComponent Name=\"DrawBox0\" Archetype=BoxComponent'/Script/Engine.Default__DecalActor:DrawBox0'@            Begin Object Class=BodySetup Name=\"BodySetup_5\"@            End Object@         End Object@         Begin Object Class=ArrowComponent Name=\"ArrowComponent0\" Archetype=ArrowComponent'/Script/Engine.Default__DecalActor:ArrowComponent0'@         End Object@         Begin Object Class=BillboardComponent Name=\"Sprite\" Archetype=BillboardComponent'/Script/Engine.Default__DecalActor:Sprite'@         End Object@         Begin Object Name=\"NewDecalComponent\"";
                        DecalsOutput = DecalsOutput + "@" + DecalsMat[i];
                        DecalsOutput = DecalsOutput + "@" + DecalsLocation[i];
                        DecalsOutput = DecalsOutput + "@" + DecalsRotation[i];
                        DecalsOutput = DecalsOutput + "@            RelativeScale3D=" + temp2 + "@         End Object";
                        DecalsOutput = DecalsOutput + "@         Begin Object Name=\"ArrowComponent0\"@            AttachParent=NewDecalComponent@         End Object@         Begin Object Name=\"Sprite\"@            AttachParent=NewDecalComponent@         End Object@         Decal=NewDecalComponent@         ArrowComponent=ArrowComponent0@         SpriteComponent=Sprite@         BoxComponent=DrawBox0@         RootComponent=NewDecalComponent@         ActorLabel=\"" + DecalsName[i] + "\"@      End Actor";
                        DecalsOutput = DecalsOutput.Replace("@", Environment.NewLine);


                    }
                    //DecalsOutput = DecalsName.Count.ToString() + ", " + DecalsLocation.Count.ToString() + ", " + DecalsRotation.Count.ToString() + ", " + DecalsWidth.Count.ToString() + ", " + DecalsHeight.Count.ToString() + ", " + DecalsMat.Count.ToString();

                }
            }
            #endregion
            #region ConvertParticles
            //particles
            if (checkedListBox1.GetItemCheckState(12) == CheckState.Checked)
            {
                if (ParticlesMatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfParticles - 1; i++)
                    {
                        ParticlesName[i] = ConversionTools.ConvertName(ParticlesName, i);
                        Particles[i] = ConversionTools.ConvertStaticMeshPath(Particles, i, 2, TB_AssetPath);
                        ParticlesLocation[i] = ConversionTools.ConvertLocation(ParticlesLocation, i, CB_MultiplyPosition);
                        ParticlesRotation[i] = ConversionTools.ConvertRotation(ParticlesRotation, i);
                        ParticlesScale[i] = ConversionTools.ConvertScale(ParticlesScale, i);
                        ParticlesScale3D[i] = ConversionTools.ConvertScale3D(ParticlesScale3D, i, ParticlesScale, richTextBox1, CB_MultiplyScale);

                        if (ParticlesMaterials[i] != string.Empty && ParticlesMaterials[i] != null)
                        {
                            ParticlesMaterials[i] = ConversionTools.ConvertMaterial(ParticlesMaterials, i, TB_AssetPath);
                        }
                    }

                    //create a new static mesh entry using UE4 syntax for every static mesh found
                    for (i = 0; i <= NumberOfParticles - 1; i++)
                    {
                        ParticlesOutput = ParticlesOutput + "@      Begin Actor Class=Emitter Name=" + ParticlesName[i] + "  Archetype=Emitter'/Script/Engine.Default__Emitter'Begin Object Class=ParticleSystemComponent Name=\"ParticleSystemComponent0\" Archetype=ParticleSystemComponent'/Script/Engine.Default__Emitter:ParticleSystemComponent0'@         End Object@         Begin Object Class=BillboardComponent Name=\"Sprite\" Archetype=BillboardComponent'/Script/Engine.Default__Emitter:Sprite'@         End Object@         Begin Object Class=ArrowComponent Name=\"ArrowComponent0\" Archetype=ArrowComponent'/Script/Engine.Default__Emitter:ArrowComponent0'@         End Object@         Begin Object Name=\"ParticleSystemComponent0\"@";
                        ParticlesOutput = ParticlesOutput + "        " + Particles[i] + Environment.NewLine;
                        if (ParticlesMaterials[i] != string.Empty)
                        {
                            ParticlesOutput = ParticlesOutput + ParticlesMaterials[i];
                        }
                        ParticlesOutput = ParticlesOutput + "           " + ParticlesLocation[i] + "@            " + ParticlesRotation[i] + "@                    RelativeScale3D=" + ParticlesScale3D[i] + "@         End Object@         Begin Object Name=\"Sprite\"@            AttachParent=ParticleSystemComponent0@         End Object@         Begin Object Name=\"ArrowComponent0\"@            AttachParent=ParticleSystemComponent0@         End Object@         ParticleSystemComponent=ParticleSystemComponent0@         SpriteComponent=Sprite@         ArrowComponent=ArrowComponent0@         RootComponent=ParticleSystemComponent0@";
                        ParticlesOutput = ParticlesOutput + "         ActorLabel=\"" + ParticlesName[i] + "\"@      End Actor";
                        ParticlesOutput = ParticlesOutput.Replace("@", Environment.NewLine);
                    }
                }
            }
            #endregion
            #region ConvertFog

            //Fog Actors
            if (checkedListBox1.GetItemCheckState(13) == CheckState.Checked)
            {
                if (FogMatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberofFog - 1; i++)
                    {
                        FogName[i] = ConversionTools.ConvertName(FogName, i);
                        FogLocation[i] = ConversionTools.ConvertLocation(FogLocation, i, CB_MultiplyPosition);
                        FogRotation[i] = ConversionTools.ConvertRotation(FogRotation, i);
                        FogScale[i] = ConversionTools.ConvertScale(FogScale, i);
                        FogScale3D[i] = ConversionTools.ConvertScale3D(FogScale3D, i, FogScale, richTextBox1, CB_MultiplyScale);
                        FogOppLightColor[i] = ConversionTools.ConvertFogColor(FogOppLightColor, i, true);
                        FogLightInScatterColor[i] = ConversionTools.ConvertFogColor(FogLightInScatterColor, i, false);

                    }

                    //create a new static mesh entry using UE4 syntax for every static mesh found
                    for (i = 0; i <= NumberofFog - 1; i++)
                    {
                        FogOutput = FogOutput + "@      Begin Actor Class=ExponentialHeightFog " + FogName[i] + " Archetype=ExponentialHeightFog'/Script/Engine.Default__ExponentialHeightFog'@         Begin Object Class=ExponentialHeightFogComponent Name=\"HeightFogComponent0\" Archetype=ExponentialHeightFogComponent'/Script/Engine.Default__ExponentialHeightFog:HeightFogComponent0'@         End Object@        Begin Object Class=BillboardComponent Name=\"Sprite\" Archetype=BillboardComponent'/Script/Engine.Default__ExponentialHeightFog:Sprite'@         End Object@        Begin Object Name=\"HeightFogComponent0\"@";
                        FogOutput = FogOutput + "           " + FogLightInScatterColor[i] + "@           " + FogOppLightColor[i] + "@           " + FogStartDistance[i] + "@           " + FogHeightFalloff[i] + "@           " + FogMaxOpacity[i] + "@           " + FogDensity[i] + "@           " + FogLocation[i] + "@            " + FogRotation[i] + "@                    RelativeScale3D=" + FogScale3D[i];
                        FogOutput = FogOutput + "@         End Object@         Begin Object Name=\"Sprite\"@            AttachParent=HeightFogComponent0@         End Object@         Component=HeightFogComponent0@         SpriteComponent=Sprite@         RootComponent=HeightFogComponent0";
                        FogOutput = FogOutput + "@ ActorLabel=\"" + FogName[i] + "\"@      End Actor";
                        FogOutput = FogOutput.Replace("@", Environment.NewLine);
                    }

                    // FogOutput = FogName.Count + "," + FogLocation.Count + "," + FogRotation.Count + "," + FogScale.Count + "," + FogScale3D.Count + "," + FogDensity.Count + "," + FogMaxOpacity.Count + "," + FogStartDistance.Count + "," + FogOppLightColor.Count + "," + FogLightInScatterColor.Count;
                }
            }

            #endregion
            #region ConvertSounds
            //sounds

            if (checkedListBox1.GetItemCheckState(14) == CheckState.Checked)
            {
                if (SoundsMatch.Count != 0)
                {
                    //loop through every stored line, Strip unesssary text, replace as needed, and convert values
                    for (i = 0; i <= NumberOfSounds - 1; i++)
                    {
                        SoundsName[i] = ConversionTools.ConvertName(SoundsName, i);
                        if (!SoundsSimple[i])
                        {
                            SoundCue[i] = ConversionTools.ConvertStaticMeshPath(SoundCue, i, 5, TB_AssetPath);
                        }
                        else
                        {
                            SoundsSlots[i] = ConversionTools.ConvertStaticMeshPath(SoundsSlots, i, 6, TB_AssetPath);
                        }
                        SoundsLocation[i] = ConversionTools.ConvertLocation(SoundsLocation, i, CB_MultiplyPosition);
                        SoundsRotation[i] = ConversionTools.ConvertRotation(SoundsRotation, i);
                        SoundsScale[i] = ConversionTools.ConvertScale(SoundsScale, i);
                        SoundsScale3D[i] = ConversionTools.ConvertScale3D(SoundsScale3D, i, SoundsScale, richTextBox1, CB_MultiplyScale);
                        SoundsVolMin[i] = ConversionTools.ConvertModulation(SoundsVolMin, i);
                        SoundsVolMax[i] = ConversionTools.ConvertModulation(SoundsVolMax, i);
                        SoundsPitchMin[i] = ConversionTools.ConvertModulation(SoundsPitchMin, i);
                        SoundsPitchMax[i] = ConversionTools.ConvertModulation(SoundsPitchMax, i);

                        temp4 = string.Empty;

                        if (SoundsSpatialize[i])
                        {
                            temp4 = temp4 + "bAttenuate=False,";
                        }
                        if (SoundsAttenuate[i])
                        {
                            temp4 = temp4 + " bSpatialize=False,";
                        }
                        if (SoundsDM[i] != string.Empty)
                        {
                            SoundsDM[i] = SoundsDM[i].Replace("            DistanceModel", "DistanceAlgorithm");
                            temp4 = temp4 + SoundsDM[i] + ",";
                        }
                        if (SoundsAttenuateLPF[i])
                        {
                            temp4 = temp4 + "bAttenuateWithLPF=True,";
                        }

                        if (SoundsLPFMin[i] != string.Empty)
                        {
                            temp4 = temp4 + SoundsLPFMax[i] + ",";
                        }
                        if (SoundsLPFMin[i] != string.Empty)
                        {
                            temp4 = temp4 + SoundsLPFMax[i] + ",";
                        }

                        SoundsRadiusMin[i] = ConversionTools.ConvertSoundRadius(SoundsRadiusMin, i, true);
                        SoundsRadiusMax[i] = ConversionTools.ConvertSoundRadius(SoundsRadiusMax, i, false);
                        temp4 = temp4 + SoundsRadiusMin[i] + SoundsRadiusMax[i];
                    }

                    //create a new Sound entry using UE4 syntax for every sound found
                    for (i = 0; i <= NumberOfSounds - 1; i++)
                    {
                        SoundOutput = SoundOutput + "@      Begin Actor Class=AmbientSound " + SoundsName[i] + " Archetype=AmbientSound'/Script/Engine.Default__AmbientSound'@         Begin Object Class=AudioComponent Name=\"AudioComponent0\" Archetype=AudioComponent'/Script/Engine.Default__AmbientSound:AudioComponent0'@         End Object@         Begin Object Name=\"AudioComponent0\"@";

                        if (!SoundsSimple[i])
                        {
                            SoundOutput = SoundOutput + "        " + SoundCue[i] + Environment.NewLine;
                        }
                        else
                        {
                            SoundOutput = SoundOutput + "        " + SoundsSlots[i] + Environment.NewLine;
                        }
                        if (temp4 != string.Empty)
                        {
                            SoundOutput = SoundOutput + "                    bOverrideAttenuation=True@                    AttenuationOverrides=(" + temp4 + ")" + Environment.NewLine;
                        }
                        SoundOutput = SoundOutput + "                    " + SoundsVolumeMulti[i] + "@                    " + SoundsPitchMulti[i] + "@                    " + SoundsVolMin[i] + "@                    " + SoundsVolMax[i] + "@                    " + SoundsPitchMin[i] + "@                    " + SoundsPitchMax[i] + "@                    " + SoundsHFMulti[i] + "@           " + SoundsLocation[i] + "@            " + SoundsRotation[i] + "@                    RelativeScale3D=" + SoundsScale3D[i] + "@         End Object@         AudioComponent=AudioComponent0@         RootComponent=AudioComponent0@";
                        SoundOutput = SoundOutput + "         ActorLabel=\"" + SoundsName[i] + "\"@      End Actor";
                        SoundOutput = SoundOutput.Replace("@", Environment.NewLine);
                    }
                }
            }
            #endregion

            //Combine all outputs
            #region FinalOutput
            //wrap the New generated T3D actors in the level code.
            Finaloutput = "Begin Map" + Environment.NewLine + "   Begin Level" + Environment.NewLine;

            if (LoopOutput != string.Empty)
            {
                Finaloutput = Finaloutput + LoopOutput + Environment.NewLine;
            }
            if (KactorOutput != string.Empty)
            {
                Finaloutput = Finaloutput + KactorOutput + Environment.NewLine;
            }
            if (InterpOutput != string.Empty)
            {
                Finaloutput = Finaloutput + InterpOutput + Environment.NewLine;
            }
            if (SKmeshOutput != string.Empty)
            {
                Finaloutput = Finaloutput + SKmeshOutput + Environment.NewLine;
            }
            if (PLightOutput != string.Empty)
            {
                Finaloutput = Finaloutput + PLightOutput + Environment.NewLine;
            }
            if (SLightOutput != string.Empty)
            {
                Finaloutput = Finaloutput + SLightOutput + Environment.NewLine;
            }
            if (DLightOutput != string.Empty)
            {
                Finaloutput = Finaloutput + DLightOutput + Environment.NewLine;
            }
            if (DomPLightOutput != string.Empty)
            {
                Finaloutput = Finaloutput + DomPLightOutput + Environment.NewLine;
            }
            if (DomDLightOutput != string.Empty)
            {
                Finaloutput = Finaloutput + DomDLightOutput + Environment.NewLine;
            }
            if (DomSLightOutput != string.Empty)
            {
                Finaloutput = Finaloutput + DomSLightOutput + Environment.NewLine;
            }
            if (PlayerStartOutput != string.Empty)
            {
                Finaloutput = Finaloutput + PlayerStartOutput + Environment.NewLine;
            }
            if (CameraOutput != string.Empty)
            {
                Finaloutput = Finaloutput + CameraOutput + Environment.NewLine;
            }
            if (DecalsOutput != string.Empty)
            {
                Finaloutput = Finaloutput + DecalsOutput + Environment.NewLine;
            }
            if (ParticlesOutput != string.Empty)
            {
                Finaloutput = Finaloutput + ParticlesOutput + Environment.NewLine;
            }
            if (FoliageOutput != string.Empty)
            {
                Finaloutput = Finaloutput + FoliageOutput + Environment.NewLine;
            }
            if(DestructOutput != string.Empty)
            {
                Finaloutput = Finaloutput + DestructOutput + Environment.NewLine;
            }
            if (ApexOutput != string.Empty)
            {
                Finaloutput = Finaloutput + ApexOutput + Environment.NewLine;
            }
            if (SoundOutput != string.Empty)
            {
                Finaloutput = Finaloutput + SoundOutput + Environment.NewLine;
            }
            if (FogOutput != string.Empty)
            {
                Finaloutput = Finaloutput + FogOutput + Environment.NewLine;
            }

            Finaloutput = Finaloutput +  "   End Level" + Environment.NewLine + "Begin Surface" + Environment.NewLine + "End Surface" + Environment.NewLine + "End Map";

            richTextBox1.Text = Finaloutput;
            #endregion

        }


        #region UnsuedMaterialConverter
        //function for converting UE3 Material T3D
        private void button6_Click(object sender, EventArgs e)
        {
            if (File.Exists(UE3MaterialPath))
            {
                // Open the stream and read it back. 
                using (StreamReader sr = File.OpenText(UE3MaterialPath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(s);
                        UE3Material = UE3Material + s + Environment.NewLine;
                    }
                }

                UE3Material = UE3Material.Replace("Begin Object Class=MaterialExpressionTextureSample", "Begin Object");
                UE3Material = UE3Material.Replace("DiffuseColor=", "BaseColor=");
                UE3Material = UE3Material.Replace("Specular=", "SpecularColor=");
                UE3Material = UE3Material.Replace("SpecularPower=", "Roughness=");

                split = UE3MaterialPath.Split("\\".ToCharArray());
                
                UE3MaterialPath = UE3MaterialPath.Replace(split[split.Length - 1], "");

                //Console.WriteLine(UE3MaterialPath + "UE4_" + split[split.Length - 1]);

                System.IO.File.WriteAllText(UE3MaterialPath + "UE4_" + split[split.Length - 1], UE3Material);

                MessageBox.Show("UE4 T3D File Created: " + UE3MaterialPath + "UE4_" + split[split.Length - 1]);
            }
            else
            {
                //MessageBox.Show("File " + textBox3.Text + " Not Found");
                return;
            }
        }


        
        /******************** Code for Material Converter ************************ */

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About newFrm = new About();
            newFrm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(SaveFilePath))
            {
                using (StreamReader sr = File.OpenText(SaveFilePath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        TB_ContentDir.Text = s;
                       // textBox5.Text = s;
                    }
                }
            }
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "Paste UDK T3D here")
            {
            richTextBox1.Text = null;
            }
        }

        private void richTextBox1_DoubleClick(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
        }

        private void folderPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TB_ContentDir.Text = folderBrowserDialog1.SelectedPath;
               // textBox5.Text = folderBrowserDialog1.SelectedPath;
                WriteToSaveFile(folderBrowserDialog1.SelectedPath);
            }
        }

        //function that writes the UE4 Path to a text file.
        private void WriteToSaveFile(string input)
        {
            if (File.Exists(SaveFilePath))
            {
                File.Delete(SaveFilePath);
            }

            if (!File.Exists(SaveFilePath))
            {
                // Create the file. 
                using (FileStream fs = File.Create(SaveFilePath))
                {
                    Byte[] info =
                        new UTF8Encoding(true).GetBytes(input);

                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        private void documentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://db.tt/jgdUkAMD");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TB_ContentDir.Text = folderBrowserDialog1.SelectedPath;
               // textBox5.Text = folderBrowserDialog1.SelectedPath;
                WriteToSaveFile(folderBrowserDialog1.SelectedPath);
            }


        }
        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void actorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    // PaintedVertices(26)=((Position=(X=0.000000,Y=-191.999969,Z=0.000014),(Normal=(X=127,Y=127,Z=0,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-191.999969,Z=0.000014),(Normal=(X=127,Y=127,Z=0,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-0.000008,Z=0.000000),(Normal=(X=127,Y=127,Z=0,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-0.000008,Z=0.000000),(Normal=(X=127,Y=127,Z=0,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=0.000000,Y=-0.000008,Z=0.000000),(Normal=(X=127,Y=127,Z=0,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=0.000000,Y=-191.999969,Z=0.000014),(Normal=(X=127,Y=127,Z=0,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=0.000000,Y=-191.999939,Z=32.000015),(Normal=(X=127,Y=0,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-191.999939,Z=32.000015),(Normal=(X=127,Y=0,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-191.999969,Z=0.000014),(Normal=(X=127,Y=0,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=0.000000,Y=-191.999969,Z=0.000014),(Normal=(X=127,Y=0,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=0.000000,Y=-0.000008,Z=0.000000),(Normal=(X=127,Y=254,Z=127,W=255),(Color=(B=0,G=0,R=255,A=255)),((Position=(X=512.000000,Y=-0.000008,Z=0.000000),(Normal=(X=127,Y=254,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-0.000002,Z=32.000000),(Normal=(X=127,Y=254,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=0.000000,Y=-0.000002,Z=32.000000),(Normal=(X=127,Y=254,Z=127,W=255),(Color=(B=0,G=0,R=255,A=255)),((Position=(X=512.000000,Y=-191.999939,Z=32.000015),(Normal=(X=254,Y=127,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-0.000002,Z=32.000000),(Normal=(X=254,Y=127,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-0.000008,Z=0.000000),(Normal=(X=254,Y=127,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-191.999969,Z=0.000014),(Normal=(X=254,Y=127,Z=127,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=0.000000,Y=-191.999939,Z=32.000015),(Normal=(X=127,Y=127,Z=254,W=255),(Color=(B=0,G=0,R=255,A=255)),((Position=(X=0.000000,Y=-0.000002,Z=32.000000),(Normal=(X=127,Y=127,Z=254,W=255),(Color=(B=0,G=0,R=255,A=255)),((Position=(X=512.000000,Y=-0.000002,Z=32.000000),(Normal=(X=127,Y=127,Z=254,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=512.000000,Y=-191.999939,Z=32.000015),(Normal=(X=127,Y=127,Z=254,W=255),(Color=(B=255,G=255,R=255,A=255)),((Position=(X=0.000000,Y=-191.999969,Z=0.000014),(Normal=(X=0,Y=127,Z=127,W=255),(Color=(B=0,G=0,R=255,A=255)),((Position=(X=0.000000,Y=-0.000008,Z=0.000000),(Normal=(X=0,Y=127,Z=127,W=255),(Color=(B=0,G=0,R=255,A=255)),((Position=(X=0.000000,Y=-0.000002,Z=32.000000),(Normal=(X=0,Y=127,Z=127,W=255),(Color=(B=0,G=0,R=255,A=255)),((Position=(X=0.000000,Y=-191.999939,Z=32.000015),(Normal=(X=0,Y=127,Z=127,W=255),(Color=(B=0,G=0,R=255,A=255)) ColorVertexData(26)=(ffffffff,ffffffff,ffffffff,ffffffff,ffffffff,ffffffff,ffffffff,ffffffff,ffffffff,ffffffff,ffff0000,ffffffff,ffffffff,ffff0000,ffffffff,ffffffff,ffffffff,ffffffff,ffff0000,ffff0000,ffffffff,ffffffff,ffff0000,ffff0000,ffff0000,ffff0000)
    
}