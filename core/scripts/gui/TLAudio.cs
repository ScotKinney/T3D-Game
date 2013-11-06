//-----------------------------------------------------------------------------
// TAP-Link audio pane

function GetAudioSettings()
{  // Called from the TL when the audio page is loading.
   schedule(1, 0, "sendTLAudioSetup");
}

function sendTLAudioSetup()
{
   // Get the list of audio providers and the devices that they support
   %buffer = sfxGetAvailableDevices();
   %count = getRecordCount( %buffer );
   %providerList = new ArrayObject();
   for(%i = 0; %i < %count; %i++)
   {
      %record = getRecord(%buffer, %i);
      %provider = getField(%record, 0);
      %device = getField(%record, 1);

      %index = %providerList.getIndexFromKey(%provider);
      if ( %index == -1 )
      {
         %deviceList = new ArrayObject();
         %providerList.add(%provider, %deviceList);
      }
      else
         %deviceList = %providerList.getValue(%index);

      %deviceList.add(%device, "0");
   }

   // Send the provider/device lists to the TL
   %providerList.sortka();
   %count = %providerList.count();
   for ( %i = 0; %i < %count; %i++ )
   {
      %provider = %providerList.getKey(%i);
      %buffer = %provider @ "\t";
      %buffer = %buffer @ ((%provider $= $pref::SFX::provider) ? "1" : "0");

      %deviceList = %providerList.getValue(%i);
      %deviceList.sortka();
      %dCount = %deviceList.count();
      for ( %j = 0; %j < %dCount; %j++ )
      {
         %device = %deviceList.getKey(%j);
         %buffer = %buffer @ "\t" @ %device @ "\t";
         %buffer = %buffer @ ((%device $= $pref::SFX::device) ? "1" : "0");
      }

      %command = "//iframe[@name='mainframe']::AddProvider(\"" @ %buffer @ "\");";
      executeJavaScriptOnTAPLink(%command);
   }

   // Send Volumes to the TL
   %buffer = $pref::SFX::masterVolume;
   for ( %i = 1; %i < 6; %i++ )
      %buffer = %buffer @ "," @ $pref::SFX::channelVolume[%i];
   %command = "//iframe[@name='mainframe']::SetVolumes(" @ %buffer @ ");";
   executeJavaScriptOnTAPLink(%command);

   // Tell the TL to display the settings
   %command = "//iframe[@name='mainframe']::UpdateSettings();";
   executeJavaScriptOnTAPLink(%command);

   // Remove our temporary objects.
   for ( %i = 0; %i < %count; %i++ )
   {
      %deviceList = %providerList.getValue(%i);
      %deviceList.delete();
   }
   %providerList.delete();
}

function ApplyAudio(%provider, %device, %master, %uiv, %effv, %musicv, %npcv, %helpv)
{
   // Create the device if it has changed
   if ((%provider !$= $pref::SFX::provider) || (%device !$= $pref::SFX::device))
   {
      $pref::SFX::provider = %provider;
      $pref::SFX::device = %device;
      if ( !sfxCreateDevice(  $pref::SFX::provider,
                              $pref::SFX::device,
                              $pref::SFX::useHardware,
                              -1 ) )
         error( "Unable to create SFX device: " @ $pref::SFX::provider
                                                SPC $pref::SFX::device
                                                SPC $pref::SFX::useHardware );
   }

   // Apply master volume
   $pref::SFX::masterVolume = %master;
   sfxSetMasterVolume( $pref::SFX::masterVolume );

   // Apply channel volumes
   $pref::SFX::channelVolume[1] = %uiv;
   $pref::SFX::channelVolume[2] = %effv;
   $pref::SFX::channelVolume[3] = %musicv;
   $pref::SFX::channelVolume[4] = %npcv;
   $pref::SFX::channelVolume[5] = %helpv;
   for( %channel = 1; %channel <= 5; %channel++ )
      sfxSetChannelVolume( %channel, $pref::SFX::channelVolume[%channel] );

   // Save the settings to prefs
   export("$pref::*", "scripts/client/prefs.cs", false);
}
