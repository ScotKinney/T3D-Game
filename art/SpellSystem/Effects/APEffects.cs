//------------------------------------------------------------------------------
//------------------------ Teleport Sound Deffinitions -------------------------
//------------------------------------------------------------------------------

datablock SFXProfile(AP_ArriveSpinUpSFX)
{
   filename = "art/sound/effects/AP_arrive_SpinUp";
   description = AudioClosest3D;
   preload = false;
};

datablock SFXProfile(AP_ArriveSpinDownSFX)
{
   filename = "art/sound/effects/AP_arrive_SpinDown";
   description = AudioClosest3D;
   preload = false;
};

datablock SFXProfile(AP_LeaveSpinUpSFX)
{
   filename = "art/sound/effects/AP_leave_SpinUp";
   description = AudioClosest3D;
   preload = false;
};

datablock SFXProfile(AP_LeaveSpinDownSFX)
{
   filename = "art/sound/effects/AP_leave_SpinDown";
   description = AudioClosest3D;
   preload = false;
};

//------------------------------------------------------------------------------
//------------------------------ Teleport Effects ------------------------------
//------------------------------------------------------------------------------

datablock ParticleEffectData(APLeaveEffect)
{
   //pEffect = "art/SpellSystem/APTest.pEffect";
   pEffect = "art/SpellSystem/Effects/APLeave.pEffect";
   lifeTimeMS = 2000;   // Total effect lifetime is 2 seconds
};

datablock ParticleEffectData(APArriveEffect)
{
   //pEffect = "art/SpellSystem/APTest.pEffect";
   pEffect = "art/SpellSystem/Effects/APArrive.pEffect";
   lifeTimeMS = 2000;   // Total effect lifetime is 2 seconds
};
