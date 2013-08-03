function PVCSkinDlg::toggle(%this)
{
   if (%this.isAwake())
      Canvas.popDialog(%this);
   else
      Canvas.pushDialog(%this);
}

function PVCSkinDlg::onWake(%this)
{
   //%this.updateSkinsList();
}

function PVCSkinDlg::updateSkinsList(%this)
{
   // Empty the list control
   PVCSkinList.deleteAllObjects();

   %lineCount = 0;
   // Get the number of texture objects on the base model   
   %numMats = $currentPVC.getNumMaterials();
   for ( %i = 0; %i < %numMats; %i++ )
   {
      %texName = $currentPVC.getTextureName(%i);
      %matName = $currentPVC.getMaterialName(%i);
      PVCSkinList.addGuiControl(%this.makeTextControl(%texName));
      PVCSkinList.addGuiControl(%this.makeButtonControl(%matName, %texName, %i, -1));
      %lineCount++;
   }
   
   // Get the number of mounted shapes
   %numMounts = $currentPVC.getNumMounts();
   for ( %j = 0; %j < %numMounts; %j++ )
   {
      %nodeName = $currentPVC.getMountSlotName(%j);
      PVCSkinList.addGuiControl(%this.makeTextControl(%nodeName));
      %tmpControl = %this.makeTextControl(" ");
      %tmpControl.setActive(false);
      PVCSkinList.addGuiControl(%tmpControl);
      %lineCount++;
      
      // now add each material for this mesh
      %numMats = $currentPVC.getNumMaterials(%j);
      for ( %i = 0; %i < %numMats; %i++ )
      {
         %texName = $currentPVC.getTextureName(%i, %j);
         %matName = $currentPVC.getMaterialName(%i, %j);
         PVCSkinList.addGuiControl(%this.makeTextControl(%texName));
         PVCSkinList.addGuiControl(%this.makeButtonControl(%matName, %texName, %i, %j));
         %lineCount++;
      }
   }
}

function PVCSkinDlg::makeTextControl(%this, %ctrlText)
{
   %newCtrlID = new GuiTextCtrl() {
      text = "  " @ %ctrlText;
      margin = "0 0 0 0";
      padding = "0 0 0 0";
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "GuiTextProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "110 18";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      tooltipprofile = "GuiToolTipProfile";
      hovertime = "1000";
      groupNum = "-1";
   };
   
   return %newCtrlID;
}

function PVCSkinDlg::makeButtonControl(%this, %matName, %texName, %texIdx, %mountIdx)
{
   %ctrlText = FileBase(%matName.diffuseMap[0]);
   %newCtrlID = new GuiButtonCtrl() {
      text = %ctrlText;
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "GuiButtonProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "140 18";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      Command = "PVCSkinDlg.onMatChangeBtn(\"" @ %matName @ "\", \"" @ %texName @ "\", " @ %mountIdx @ ");";
      tooltipprofile = "GuiToolTipProfile";
      hovertime = "1000";
      groupNum = "-1";
      buttonType = "PushButton";
   };
   
   return %newCtrlID;
}

function PVCSkinDlg::onMatChangeBtn(%this, %matName, %skinTag, %mountIdx)
{
   %this.curMatName = %matName;
   %this.curSkinTag = %skinTag;
   %this.curMountIdx = %mountIdx;
   
   PVCTextureDlg.matName = %matName;
   PVCTextureDlg.skinTag = %skinTag;
   Canvas.pushDialog(PVCTextureDlg);
}

function PVCSkinDlg::onMatChanged(%this)
{
   if ( isObject(%this.newMat[%this.curSkinTag]) )
   {  // We already created a material for this skin so remove from model then delete
      if ( %this.curMountIdx == -1 )
         $currentPVC.SetModelSkin(%this.curSkinTag, %this.oldMat[%this.curSkinTag]);
      else
         $currentPVC.SetEquipmentSkin(%this.curSkinTag, %this.oldMat[%this.curSkinTag], %this.curMountIdx);
      %this.newMat[%this.curSkinTag].Delete();
      %this.newMat[%this.curSkinTag] = -1;
   }

   // Find the material currently assigned
   %numMats = $currentPVC.getNumMaterials(%this.curMountIdx);
   for ( %j = 0; %j < %numMats; %j++ )
   {
      %texName = $currentPVC.getTextureName(%j, %this.curMountIdx);
      %matName = $currentPVC.getMaterialName(%j, %this.curMountIdx);
      if ( %texName $= %this.curSkinTag )
         break;
   }
   
   if ( %j < %numMats )
   {  // skin was found
      %this.oldMat[%this.curSkinTag] = %matName;
      %newMatName = "PVCMat_" @ %this.curSkinTag;
      %this.newMat[%this.curSkinTag] = %this.cloneMaterial(%newMatName, %matName);
      if ( %this.curMountIdx == -1 )
         $currentPVC.SetModelSkin(%texName, %newMatName);
      else
         $currentPVC.SetEquipmentSkin(%texName, %newMatName, %this.curMountIdx);
   }

   %this.updateSkinsList();      
}

function PVCSkinDlg::saveSettings(%this, %file)
{  // Save all settings needed to restore the window to it's current state
   //%file.WriteLine("PVCCaptureDlg.captureFormat = \"" @ %this.captureFormat @ "\";" );

   // save the position and size.
   /*%pos = MeshControlDlg.getPosition();
   %ext = MeshControlDlg.getExtent();
   %file.WriteLine("MeshControlDlg.setPosition(" @ getWord(%pos, 0) @ ", " @ getWord(%pos, 1) @ ");");
   %file.WriteLine("MeshControlDlg.setExtent(" @ getWord(%ext, 0) @ ", " @ getWord(%ext, 1) @ ");");*/
}

function PVCSkinDlg::cloneMaterial(%this, %newName, %oldMat )
{
   //%diffuseMap = PVCTextureDlg.textureFile[0];
   //if ( %diffuseMap $= "" )
      //%diffuseMap = %oldMat.diffuseMap[0];

   %newMat = new Material(%newName) 
   {
      diffuseMap[0] = PVCTextureDlg.textureFile[0];
      diffuseMap[1] = PVCTextureDlg.textureFile[1];
      diffuseMap[2] = PVCTextureDlg.textureFile[2];
      diffuseMap[3] = PVCTextureDlg.textureFile[3];
      mapTo = "unmapped_mat";

      diffuseColor[0] = %oldMat.diffuseColor[0];
      diffuseColor[1] = %oldMat.diffuseColor[1];
      diffuseColor[2] = %oldMat.diffuseColor[2];
      diffuseColor[3] = %oldMat.diffuseColor[3];

      overlayMap[0] = %oldMat.overlayMap[0];
      overlayMap[1] = %oldMat.overlayMap[1];
      overlayMap[2] = %oldMat.overlayMap[2];
      overlayMap[3] = %oldMat.overlayMap[3];

      lightMap[0] = %oldMat.lightMap[0];
      lightMap[1] = %oldMat.lightMap[1];
      lightMap[2] = %oldMat.lightMap[2];
      lightMap[3] = %oldMat.lightMap[3];

      toneMap[0] = %oldMat.toneMap[0];
      toneMap[1] = %oldMat.toneMap[1];
      toneMap[2] = %oldMat.toneMap[2];
      toneMap[3] = %oldMat.toneMap[3];

      detailMap[0] = %oldMat.detailMap[0];
      detailMap[1] = %oldMat.detailMap[1];
      detailMap[2] = %oldMat.detailMap[2];
      detailMap[3] = %oldMat.detailMap[3];

      detailScale[0] = %oldMat.detailScale[0];
      detailScale[1] = %oldMat.detailScale[1];
      detailScale[2] = %oldMat.detailScale[2];
      detailScale[3] = %oldMat.detailScale[3];

      normalMap[0] = %oldMat.normalMap[0];
      normalMap[1] = %oldMat.normalMap[1];
      normalMap[2] = %oldMat.normalMap[2];
      normalMap[3] = %oldMat.normalMap[3];

      detailNormalMap[0] = %oldMat.detailNormalMap[0];
      detailNormalMap[1] = %oldMat.detailNormalMap[1];
      detailNormalMap[2] = %oldMat.detailNormalMap[2];
      detailNormalMap[3] = %oldMat.detailNormalMap[3];

      detailNormalMapStrength[0] = %oldMat.detailNormalMapStrength[0];
      detailNormalMapStrength[1] = %oldMat.detailNormalMapStrength[1];
      detailNormalMapStrength[2] = %oldMat.detailNormalMapStrength[2];
      detailNormalMapStrength[3] = %oldMat.detailNormalMapStrength[3];

      specular[0] = %oldMat.specular[0];
      specular[1] = %oldMat.specular[1];
      specular[2] = %oldMat.specular[2];
      specular[3] = %oldMat.specular[3];

      specularPower[0] = %oldMat.specularPower[0];
      specularPower[1] = %oldMat.specularPower[1];
      specularPower[2] = %oldMat.specularPower[2];
      specularPower[3] = %oldMat.specularPower[3];

      pixelSpecular[0] = %oldMat.pixelSpecular[0];
      pixelSpecular[1] = %oldMat.pixelSpecular[1];
      pixelSpecular[2] = %oldMat.pixelSpecular[2];
      pixelSpecular[3] = %oldMat.pixelSpecular[3];

      specularMap[0] = %oldMat.specularMap[0];
      specularMap[1] = %oldMat.specularMap[1];
      specularMap[2] = %oldMat.specularMap[2];
      specularMap[3] = %oldMat.specularMap[3];

      parallaxScale[0] = %oldMat.parallaxScale[0];
      parallaxScale[1] = %oldMat.parallaxScale[1];
      parallaxScale[2] = %oldMat.parallaxScale[2];
      parallaxScale[3] = %oldMat.parallaxScale[3];

      useAnisotropic[0] = %oldMat.useAnisotropic[0];
      useAnisotropic[1] = %oldMat.useAnisotropic[1];
      useAnisotropic[2] = %oldMat.useAnisotropic[2];
      useAnisotropic[3] = %oldMat.useAnisotropic[3];

      envMap[0] = %oldMat.envMap[0];
      envMap[1] = %oldMat.envMap[1];
      envMap[2] = %oldMat.envMap[2];
      envMap[3] = %oldMat.envMap[3];

      vertLit[0] = %oldMat.vertLit[0];
      vertLit[1] = %oldMat.vertLit[1];
      vertLit[2] = %oldMat.vertLit[2];
      vertLit[3] = %oldMat.vertLit[3];

      vertColor[0] = %oldMat.vertColor[0];
      vertColor[1] = %oldMat.vertColor[1];
      vertColor[2] = %oldMat.vertColor[2];
      vertColor[3] = %oldMat.vertColor[3];

      minnaertConstant[0] = %oldMat.minnaertConstant[0];
      minnaertConstant[1] = %oldMat.minnaertConstant[1];
      minnaertConstant[2] = %oldMat.minnaertConstant[2];
      minnaertConstant[3] = %oldMat.minnaertConstant[3];

      subSurface[0] = %oldMat.subSurface[0];
      subSurface[1] = %oldMat.subSurface[1];
      subSurface[2] = %oldMat.subSurface[2];
      subSurface[3] = %oldMat.subSurface[3];

      subSurfaceColor[0] = %oldMat.subSurfaceColor[0];
      subSurfaceColor[1] = %oldMat.subSurfaceColor[1];
      subSurfaceColor[2] = %oldMat.subSurfaceColor[2];
      subSurfaceColor[3] = %oldMat.subSurfaceColor[3];

      subSurfaceRolloff[0] = %oldMat.subSurfaceRolloff[0];
      subSurfaceRolloff[1] = %oldMat.subSurfaceRolloff[1];
      subSurfaceRolloff[2] = %oldMat.subSurfaceRolloff[2];
      subSurfaceRolloff[3] = %oldMat.subSurfaceRolloff[3];

      glow[0] = %oldMat.glow[0];
      glow[1] = %oldMat.glow[1];
      glow[2] = %oldMat.glow[2];
      glow[3] = %oldMat.glow[3];

      emissive[0] = %oldMat.emissive[0];
      emissive[1] = %oldMat.emissive[1];
      emissive[2] = %oldMat.emissive[2];
      emissive[3] = %oldMat.emissive[3];

      doubleSided = %oldMat.doubleSided;

      animFlags[0] = %oldMat.animFlags[0];
      animFlags[1] = %oldMat.animFlags[1];
      animFlags[2] = %oldMat.animFlags[2];
      animFlags[3] = %oldMat.animFlags[3];

      scrollDir[0] = %oldMat.scrollDir[0];
      scrollDir[1] = %oldMat.scrollDir[1];
      scrollDir[2] = %oldMat.scrollDir[2];
      scrollDir[3] = %oldMat.scrollDir[3];

      scrollSpeed[0] = %oldMat.scrollSpeed[0];
      scrollSpeed[1] = %oldMat.scrollSpeed[1];
      scrollSpeed[2] = %oldMat.scrollSpeed[2];
      scrollSpeed[3] = %oldMat.scrollSpeed[3];

      rotSpeed[0] = %oldMat.rotSpeed[0];
      rotSpeed[1] = %oldMat.rotSpeed[1];
      rotSpeed[2] = %oldMat.rotSpeed[2];
      rotSpeed[3] = %oldMat.rotSpeed[3];

      rotPivotOffset[0] = %oldMat.rotPivotOffset[0];
      rotPivotOffset[1] = %oldMat.rotPivotOffset[1];
      rotPivotOffset[2] = %oldMat.rotPivotOffset[2];
      rotPivotOffset[3] = %oldMat.rotPivotOffset[3];

      waveType[0] = %oldMat.waveType[0];
      waveType[1] = %oldMat.waveType[1];
      waveType[2] = %oldMat.waveType[2];
      waveType[3] = %oldMat.waveType[3];

      waveFreq[0] = %oldMat.waveFreq[0];
      waveFreq[1] = %oldMat.waveFreq[1];
      waveFreq[2] = %oldMat.waveFreq[2];
      waveFreq[3] = %oldMat.waveFreq[3];

      waveAmp[0] = %oldMat.waveAmp[0];
      waveAmp[1] = %oldMat.waveAmp[1];
      waveAmp[2] = %oldMat.waveAmp[2];
      waveAmp[3] = %oldMat.waveAmp[3];

      sequenceFramePerSec[0] = %oldMat.sequenceFramePerSec[0];
      sequenceFramePerSec[1] = %oldMat.sequenceFramePerSec[1];
      sequenceFramePerSec[2] = %oldMat.sequenceFramePerSec[2];
      sequenceFramePerSec[3] = %oldMat.sequenceFramePerSec[3];

      sequenceSegmentSize[0] = %oldMat.sequenceSegmentSize[0];
      sequenceSegmentSize[1] = %oldMat.sequenceSegmentSize[1];
      sequenceSegmentSize[2] = %oldMat.sequenceSegmentSize[2];
      sequenceSegmentSize[3] = %oldMat.sequenceSegmentSize[3];

      cellIndex[0] = %oldMat.cellIndex[0];
      cellIndex[1] = %oldMat.cellIndex[1];
      cellIndex[2] = %oldMat.cellIndex[2];
      cellIndex[3] = %oldMat.cellIndex[3];

      cellLayout[0] = %oldMat.cellLayout[0];
      cellLayout[1] = %oldMat.cellLayout[1];
      cellLayout[2] = %oldMat.cellLayout[2];
      cellLayout[3] = %oldMat.cellLayout[3];

      cellSize[0] = %oldMat.cellSize[0];
      cellSize[1] = %oldMat.cellSize[1];
      cellSize[2] = %oldMat.cellSize[2];
      cellSize[3] = %oldMat.cellSize[3];

      bumpAtlas[0] = %oldMat.bumpAtlas[0];
      bumpAtlas[1] = %oldMat.bumpAtlas[1];
      bumpAtlas[2] = %oldMat.bumpAtlas[2];
      bumpAtlas[3] = %oldMat.bumpAtlas[3];

      castShadows = %oldMat.castShadows;
      planarReflection = %oldMat.planarReflection;
      translucent = %oldMat.translucent;
      translucentBlendOp = %oldMat.translucentBlendOp;
      translucentZWrite = %oldMat.translucentZWrite;
      alphaTest = %oldMat.alphaTest;
      alphaRef = %oldMat.alphaRef;
      dynamicCubemap = %oldMat.dynamicCubemap;
      showFootprints = %oldMat.showFootprints;
      showDust = %oldMat.showDust;
      effectColor[0] = %oldMat.effectColor[0];
      effectColor[1] = %oldMat.effectColor[1];
      footstepSoundId = %oldMat.footstepSoundId;
      customFootstepSound = %oldMat.customFootstepSound;
      impactSoundId = %oldMat.impactSoundId;
      customImpactSound = %oldMat.customImpactSound;
   };
   
   return %newMat;
}
