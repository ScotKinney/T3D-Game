datablock SpellData(DefaultAOESpell){
   CastType = "AOE";
   TargetType = "Point";
   TypeMask = $TypeMasks::TerrainObjectType;
   SpellDecalManager = DefaultSpellIndicator;
   range = 20;
   Logo = "";
   Cost = 0;
   
   ChannelTimesMS[0] = 0;
   ChannelTimesMS[1] = 0;
   ChannelTimesMS[2] = 0;
   CastTimesMS[0] = 0;
   CastTimesMS[1] = 0;
   CastTimesMS[2] = 0;
};

datablock SpellData(DefaultTargetSpell){
   CastType = "Target";
   TargetType = "Object";
   TypeMask = $TypeMasks::PlayerObjectType;
   SpellDecalManager = DefaultSpellIndicator;
   range = 20;
   Logo = "";
   Cost = 0;
   
   ChannelTimesMS[0] = 0;
   ChannelTimesMS[1] = 0;
   ChannelTimesMS[2] = 0;
   CastTimesMS[0] = 0;
   CastTimesMS[1] = 0;
   CastTimesMS[2] = 0;
};


datablock SpellData(DefaultSelfSpell){
   CastType = Self;
   TargetType = "Object";
   TypeMask = $TypeMasks::PlayerObjectType;
   SpellDecalManager = DefaultSpellIndicator;
   range = 10;
   Logo = "";
   Cost = 0;
   
   ChannelTimesMS[0] = 0;
   ChannelTimesMS[1] = 0;
   ChannelTimesMS[2] = 0;
   CastTimesMS[0] = 0;
   CastTimesMS[1] = 0;
   CastTimesMS[2] = 0;
};