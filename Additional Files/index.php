<html>
<body>

1.Export all meshes & textures from UDK<Br>
2. In Unreal 4, Create a folder for each package, and re-create the directory structure in each, you can use the "Asset Path:" input below to specify a subfolder<br>
3. Reimport all assets in their same location, with the same names as they were in UDK, you'll also have to recreate and assign the materials<br>
4. Copy actors in the scene, then Paste T3D from udk here, It will be coverted to UE4 T3D.<br>
Currently only supports Static meshes
<form action="welcome.php" method="post">
Asset Path: <input type="text" name="path" value="/Game/"><br>
<textarea rows="50" cols="100" name="name">Paste UDK T3D here...</textarea><br>
<input type="submit">
</form>

</body>
</html>