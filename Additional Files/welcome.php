<?php
$subject = $_POST["name"];
$path = $_POST["path"];

$NumOfAssets = 0;
$name= (array) null;
$StaticMesh= (array) null;
$location= (array) null;
$rotation= (array) null;
$scale= (array) null;
$scale3D= (array) null;

$SearchResults= (array) null;

$NoRotation = "Rotation=(Pitch=0,Yaw=0,Roll=0)";
$NoScale3D = "DrawScale3D=(X=1.000000,Y=1.000000,Z=1.000000)";

//search for text in between "Begin Actor" and "End Actor", store the results in an array.
$matchPattern = "/(?<=Begin Actor Class=StaticMeshActor)'.*?'(?=End Actor)/s";
if (preg_match_all ($matchPattern, $subject, $result, PREG_SET_ORDER)){
	$SearchResults = $result;
}else{
	echo "No Static Meshes Found";
	return;
}

//loop through all the results found.
for ($i = 0; $i <= count($SearchResults) - 1; $i++) {
	
	//re-add "Begin Actor" and "End Actor" that pre_match_all removed.
	$result[$i][0] = "Begin Actor Class=StaticMeshActor" . $result[$i][0] . "End Actor";
	
	
	//check for missing entries, if so push blank values into arrays
	if (strpos($result[$i][0], 'DrawScale3D=') !== FALSE){
	}else{
		//echo "Found No DrawScale3D<br>";
		array_push($scale3D, $NoScale3D);
	}
	
	if (strpos($result[$i][0], 'DrawScale=') !== FALSE){
	}else{
		//echo "Found No DrawScale<br>";
		array_push($scale, "1.000000" );
	}
	
	if (strpos($result[$i][0], 'Rotation=') !== FALSE){
	}else{
		//echo "Found No Rotation<br>";
		array_push($rotation, $NoRotation);
	}		

	//split the lines of the actor entry into an array, and loop through them.
	foreach(preg_split("/((\r?\n)|(\r\n?))/", $result[$i][0]) as $line){	
	
		if (strpos($line, 'Begin Actor Class=StaticMeshActor') !== FALSE){
			array_push($name, $line);
		}
		
		if (strpos($line, 'StaticMesh=') !== FALSE){
			array_push($StaticMesh, $line);
		}
		
		if (strpos($line, 'Location=') !== FALSE){
			array_push($location, $line);
		}
		
		if (strpos($line, 'Rotation=') !== FALSE){
			array_push($rotation, $line);
		}
		
		if (strpos($line, 'DrawScale=') !== FALSE){
			array_push($scale, $line);
		}

		if (strpos($line, 'DrawScale3D=') !== FALSE){
			array_push($scale3D, $line);
		}
				
		//echo $result[$i][0]. "<br>";
	}
}

// *** Old code that simply split all the incoming text into lines. 
/*//Spilt the incoming text into lines, loop through them and store the relevant info into arrays.
foreach(preg_split("/((\r?\n)|(\r\n?))/", $subject) as $line){	

	if (strpos($line, 'Begin Actor Class=') !== FALSE){
		array_push($name, $line);
		$NumOfAssets++;
	}
	
	if (strpos($line, 'StaticMesh=') !== FALSE){
		array_push($StaticMesh, $line);
	}
	
	if (strpos($line, 'Location=') !== FALSE){
		array_push($location, $line);
	}
	
	if (strpos($line, 'Rotation=') !== FALSE){
		array_push($rotation, $line);
	}
	
	if (strpos($line, 'DrawScale=') !== FALSE){
		array_push($scale, $line);
	}

	if (strpos($line, 'DrawScale3D=') !== FALSE){
		array_push($scale3D, $line);
	}	
} */

$NumOfAssets = count($SearchResults);
echo "<br>Number of Static Meshes: " . $NumOfAssets . "<br>";

//loop through the array that contains the names of the actors, strip/change data and save back
foreach ($name as &$value) {
	$str1 = str_replace("Begin Actor Class=StaticMeshActor"," ",$value);
	$str2= str_replace("Archetype=StaticMeshActor\'Engine.Default__StaticMeshActor\'","",$str1);
	$str3= str_replace(" ","",$str2);
	$value = $str3;
   // echo  $value . "<br>";
}

//loop through the array that contains the path to the static meshes of the actors, strip/change data and save back
foreach ($StaticMesh as &$value) {
	$str1 = str_replace(".","/",$value);
	$str2 = str_replace("\\","/",$str1);
	$str3 = str_replace("StaticMesh/'", "StaticMesh'$path", $str2);
	$value = $str3;
   
	//spilt by forward slashes /
	$output = explode('/', $value);  
	//grab the last value between slashes, append to the line with .
	$value = str_replace("/'",".".$output[count($output) - 2]."'",$value);
	// echo  $value . "<br>";
}

//loop through the array that contains the position of the actors, strip/change data and save back
foreach ($location as &$value) {
	$str = str_replace("Location=","RelativeLocation=",$value);
	$value = $str;
    //echo  $value . "<br>";
}

//loop through the array that contains the rotation of the actors, strip/change data and save back
foreach ($rotation as &$value) {
	
	//split the line by commas
	$output = explode(',', $value);  
	
	//grab the 3 values that was split
	$newpich = $output[count($output) - 3];
	$newyaw = $output[count($output) - 2];
	$newroll = $output[count($output) - 1];
	
	//strip away all data except the numerical values
	$newpich= str_replace("Rotation=(Pitch=","",$newpich);
	$newyaw = str_replace("Yaw=","",$newyaw);
	$newroll =str_replace("Roll=","",$newroll);
	$newroll =str_replace(")","",$newroll);
	
	//MATH to turn UDK's fucked up values to normal rotations (thanks epic!)
	$newpich = $newpich/ 65536 * 360;
	$newyaw = $newyaw / 65536 * 360;
	$newroll = $newroll/ 65536 * 360;
	
	//reconstruct and save the new line
	$value = "	    RelativeRotation=(Pitch=$newpich,Yaw=$newyaw,Roll=$newroll)";
	// echo  $value . "<br>";
	/*echo $newpich;
	echo  "<br>";
	echo $newyaw;
	echo  "<br>";
	echo $newroll;
	echo  "<br>";*/

}

//loop through the array that contains the scale of the actors, strip/change data and save back
foreach ($scale as &$value) {
	//strip the line
	$str2 = str_replace("DrawScale=","",$value);	
	$str = str_replace(" ","",$str2);		
	$value = $str;

}

//****** old code for looping through scale arrays
/*foreach ($scale3D as &$value) {
	//strip the line
	$str2 = str_replace("DrawScale3D=","",$value);	
	$str = str_replace(" ","",$str2);	
	
	$output = explode(',', $str);  
	
	//grab the 3 values that was split
	$newX = $output[count($output) - 3];
	$newY = $output[count($output) - 2];
	$newZ = $output[count($output) - 1];
	
	$newX= str_replace("(X=","",$newX);
	$newY = str_replace("Y=","",$newY);
	$newZ =str_replace("Z=","",$newZ);
	$newZ =str_replace(")","",$newZ);
	
	
	$value = $str;

    echo  $value . "<br>";
}*/



//loop through the array that contains the scale of the actors, strip/change data and save back
for ($i = 0; $i <= count($scale3D ) - 1; $i++) {

	//strip the line
	$str2 = str_replace("DrawScale3D=","",$scale3D[$i]);	
	$str = str_replace(" ","",$str2);	
	
	
	//split the line into an array by the commas
	$output = explode(',', $str);  
	
	//grab the 3 values that was split
	$newX = $output[count($output) - 3];
	$newY = $output[count($output) - 2];
	$newZ = $output[count($output) - 1];
	
	//strip all the text out so we only have the numerical values
	$newX= str_replace("(X=","",$newX);
	$newY = str_replace("Y=","",$newY);
	$newZ =str_replace("Z=","",$newZ);
	$newZ =str_replace(")","",$newZ);
	
	
	
	//Add the DrawScale multiplier, If there was no DrawScale specified it defaults to 1.
	//echo $newX.$scale[$i]."<br>";	
	
	$newX = $newX * $scale[$i];
	$newY = $newY * $scale[$i];
	$newZ = $newZ * $scale[$i];
	
	//reconstruct the new line and save back into the array
	$scale3D[$i] = "(X=$newX,Y=$newY,Z=$newZ)";
	
}
?>

<html>
<body>

<textarea rows="50" cols="250">
<?php echo "Begin Map
   Begin Level";
   
   for ($i = 0; $i <= $NumOfAssets - 1; $i++) {
   $name2 = str_replace("Name=","",$name[$i]);
   $name2 = '"'. $name2 . '"';
    echo "
      Begin Actor Class=StaticMeshActor $name[$i] Archetype=StaticMeshActor'/Script/Engine.Default__StaticMeshActor'
         Begin Object Class=StaticMeshComponent Name=StaticMeshComponent0 ObjName=StaticMeshComponent0 Archetype=StaticMeshComponent'/Script/Engine.Default__StaticMeshActor:StaticMeshComponent0'
         End Object
         Begin Object Name=StaticMeshComponent0
$StaticMesh[$i]
            BodyInstance=(Scale3D=($scale3D[$i]))
   $location[$i]
   $rotation[$i]
            RelativeScale3D=$scale3D[$i]
         End Object
         StaticMeshComponent=StaticMeshComponent0
         RootComponent=StaticMeshComponent0
	 ActorLabel=$name2
      End Actor";
}

echo "
   End Level
Begin Surface
End Surface
End Map
";
//echo var_dump($SearchResults);
   ?>
</textarea> <br>

</body>
</html>