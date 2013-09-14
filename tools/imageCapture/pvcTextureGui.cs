function PVCTextureDlg::onWake(%this)
{
   TexSelectionDlg.text = "Reskin " @ %this.skinTag;
   
   for (%i = 0; %i < 4; %i++)
   {
      %fieldName = "ReskinTexture" @ %i;
      %editCtrl = %this.findObjectByInternalName(%fieldName, true);
      %editCtrl.setText(%this.matName.diffuseMap[%i]);
      %this.textureFile[%i] = %this.matName.diffuseMap[%i];
   }
}

function PVCTextureDlg::onTextureBrowse(%this, %textureIdx)
{  // Let the user browse for a suitable bitmap.
   %this.curIndex = %textureIdx;
   %curFile = %this.textureFile[%textureIdx];
   if ( %curFile $= "" )
      %curFile = "art/players/base/tints/Tan0.png";
   getLoadFilename( "Image Files|*.png;*.jpg|JPG Files|*.jpg|PNG Files|*.png", %this @ ".onTextureSelect", %curFile);
}

function PVCTextureDlg::onTextureSelect(%this, %path)
{
   if ( %path $= "" )
      return;  // Canceled

   %path = makeRelativePath( %path, getMainDotCSDir() );
   if ( %path $= %this.textureFile[%this.curIndex] )
      return;  // Nothings changed

   %fieldName = "ReskinTexture" @ %this.curIndex;
   %editCtrl = %this.findObjectByInternalName(%fieldName, true);
   %editCtrl.setText(%path);
   %this.textureFile[%this.curIndex] = %path;
}

function PVCTextureDlg::onReskinButton(%this)
{
   for (%i = 0; %i < 4; %i++)
   {
      %fieldName = "ReskinTexture" @ %i;
      %editCtrl = %this.findObjectByInternalName(%fieldName, true);
      %this.textureFile[%i] = %editCtrl.getText();
   }

   PVCSkinDlg.onMatChanged();
   Canvas.popDialog(%this);
}
