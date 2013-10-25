
singleton TSShapeConstructor(BaseFemale1_4Dts)
{
   baseShape = "./basefemale1_4.dts";
};

function BaseFemale1_4Dts::onLoad(%this)
{
   %this.renameNode("upperJaw", "Eye");
   %this.setNodeTransform("Eye", "0.0143051 0.114877 2.35567 0.0652936 -0.983834 -0.166756 0.0252496", "1");
   %this.addNode("mount3", "hip", "-0.179803 0.157201 1.58944 1 0 0 0", "1");
   %this.addNode("cam", "root", "0 -0.983047 2.34118 1 0 0 0", "1");
   %this.addNode("mount7", "mount0", "0.472093 3.16589 2.59716 0.69705 -0.68378 -0.215794 3.07014", "1");
   %this.addNode("mount2", "lHand", "-1.01155 0.175602 2.02436 1 0 0 0", "1");
   %this.addNode("mount10", "rToe", "0.174183 0.0105287 0.041622 1 0 0 0", "1");
   %this.addNode("mount12", "lToe", "-0.210012 -0.00454873 0.0478135 1 0 0 0", "1");
   %this.addNode("mount1", "lHand", "-1.0277 0.228715 1.98335 -0.199266 0.524624 -0.827685 0.391181", "1");
   %this.addMesh("Sash_FJ 700", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "Sash_FJ 700");
   %this.addMesh("WristGrd_FJ_R 700", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "WristGrd_FJ_R 700");
   %this.addMesh("ChestStrap_FJ 700", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "ChestStrap_FJ 700");
   %this.addMesh("Pants_FJ 700", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "Pants_FJ 700");
   %this.addMesh("Boots_FJ 700", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "Boots_FJ 700");
   %this.addMesh("WristGrd_FJ_L 700", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "WristGrd_FJ_L 700");
   %this.addMesh("Sash_FJ 400", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "Sash_FJ 400");
   %this.addMesh("WristGrd_FJ_R 400", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "WristGrd_FJ_R 400");
   %this.addMesh("ChestStrap_FJ 400", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "ChestStrap_FJ 400");
   %this.addMesh("Pants_FJ 400", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "Pants_FJ 400");
   %this.addMesh("Boots_FJ 400", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "Boots_FJ 400");
   %this.addMesh("WristGrd_FJ_L 400", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "WristGrd_FJ_L 400");
   %this.addMesh("Sash_FJ 50", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "Sash_FJ 50");
   %this.addMesh("WristGrd_FJ_R 50", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "WristGrd_FJ_R 50");
   %this.addMesh("ChestStrap_FJ 50", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "ChestStrap_FJ 50");
   %this.addMesh("Pants_FJ 50", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "Pants_FJ 50");
   %this.addMesh("Boots_FJ 50", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "Boots_FJ 50");
   %this.addMesh("WristGrd_FJ_L 50", "art/players/base/BaseFemale/BaseFemale_FJ.dts", "WristGrd_FJ_L 50");
   %this.addSequence("art/players/base/Anims/Root.dsq", "Root", "0", "479", "1", "0");
   %this.addSequence("art/players/base/Anims/Run.dsq", "Run", "0", "70", "1", "0");
   %this.addTrigger("Run", "21", "1");
   %this.addTrigger("Run", "7", "2");
   %this.addSequence("art/players/base/Anims/Back.dsq", "Back", "0", "29", "1", "0");
   %this.addTrigger("Back", "3", "1");
   %this.addTrigger("Back", "16", "2");
   %this.addSequence("art/players/base/Anims/Left.dsq", "Left", "0", "29", "1", "0");
   %this.addTrigger("Left", "3", "1");
   %this.addTrigger("Left", "18", "2");
   %this.addSequence("art/players/base/Anims/Right.dsq", "Right", "0", "29", "1", "0");
   %this.addTrigger("right", "2", "2");
   %this.addTrigger("right", "17", "1");
   %this.addSequence("art/players/base/Anims/RunFull_Root.dsq", "RunFull_Root", "0", "479", "1", "0");
   %this.addSequence("art/players/base/Anims/RunFull_Forward.dsq", "RunFull_Forward", "0", "70", "1", "0");
   %this.addTrigger("RunFull_Forward", "21", "1");
   %this.addTrigger("RunFull_Forward", "7", "2");
   %this.addSequence("art/players/base/Anims/RunFull_Back.dsq", "RunFull_Back", "0", "29", "1", "0");
   %this.addTrigger("RunFull_Back", "2", "1");
   %this.addTrigger("RunFull_Back", "17", "2");
   %this.addSequence("art/players/base/Anims/RunFull_Left.dsq", "RunFull_Left", "0", "29", "1", "0");
   %this.addTrigger("RunFull_Left", "3", "1");
   %this.addTrigger("RunFull_Left", "19", "2");
   %this.addSequence("art/players/base/Anims/RunFull_Right.dsq", "RunFull_Right", "0", "29", "1", "0");
   %this.addTrigger("RunFull_Right", "3", "1");
   %this.addTrigger("RunFull_Right", "18", "2");
   %this.addSequence("art/players/base/Anims/RunFull_Root.dsq", "Sprint_Root", "0", "479", "1", "0");
   %this.addSequence("art/players/base/Anims/Sprint_Forward.dsq", "Sprint_Forward", "0", "78", "1", "0");
   %this.addTrigger("Sprint_Forward", "4", "1");
   %this.addTrigger("Sprint_Forward", "22", "2");
   %this.addTrigger("Sprint_Forward", "42", "1");
   %this.addTrigger("Sprint_Forward", "62", "2");
   %this.addSequence("art/players/base/Anims/Sprint_Back.dsq", "Sprint_Back", "0", "29", "1", "0");
   %this.addTrigger("Sprint_Back", "4", "1");
   %this.addTrigger("Sprint_Back", "11", "2");
   %this.addSequence("art/players/base/Anims/Sprint_Left.dsq", "Sprint_Left", "0", "29", "1", "0");
   %this.addTrigger("Sprint_Left", "1", "1");
   %this.addTrigger("Sprint_Left", "8", "2");
   %this.addSequence("art/players/base/Anims/Sprint_Right.dsq", "Sprint_Right", "0", "29", "1", "0");
   %this.addTrigger("Sprint_Right", "1", "1");
   %this.addTrigger("Sprint_Right", "8", "2");
   %this.addSequence("art/players/base/Anims/RunFull_Root.dsq", "SprintFull_Root", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/SprintFull_Forward.dsq", "SprintFull_Forward", "0", "118", "1", "0");
   %this.addTrigger("SprintFull_Forward", "1", "1");
   %this.addTrigger("SprintFull_Forward", "30", "2");
   %this.addTrigger("SprintFull_Forward", "60", "1");
   %this.addTrigger("SprintFull_Forward", "90", "2");
   %this.addSequence("art/players/base/Anims/SprintFull_Back.dsq", "SprintFull_Back", "0", "29", "1", "0");
   %this.addTrigger("SprintFull_Back", "3", "1");
   %this.addTrigger("SprintFull_Back", "11", "2");
   %this.addTrigger("SprintFull_Back", "19", "1");
   %this.addTrigger("SprintFull_Back", "26", "2");
   %this.addSequence("art/players/base/Anims/SprintFull_Left.dsq", "SprintFull_Left", "0", "29", "1", "0");
   %this.addTrigger("SprintFull_Left", "0", "1");
   %this.addTrigger("SprintFull_Left", "8", "2");
   %this.addTrigger("SprintFull_Left", "15", "1");
   %this.addTrigger("SprintFull_Left", "23", "2");
   %this.addSequence("art/players/base/Anims/SprintFull_Right.dsq", "SprintFull_Right", "0", "29", "1", "0");
   %this.addTrigger("SprintFull_Right", "9", "2");
   %this.addTrigger("SprintFull_Right", "1", "1");
   %this.addTrigger("SprintFull_Right", "16", "1");
   %this.addTrigger("SprintFull_Right", "23", "2");
   %this.addSequence("art/players/base/Anims/Crouch_Root.dsq", "Crouch_Root", "0", "29", "1", "0");
   %this.setSequenceCyclic("Crouch_Root", "1");
   %this.addSequence("art/players/base/Anims/Crouch_Forward.dsq", "Crouch_Forward", "0", "41", "1", "0");
   %this.setSequenceCyclic("Crouch_Forward", "1");
   %this.addTrigger("Crouch_Forward", "6", "1");
   %this.addTrigger("Crouch_Forward", "25", "2");
   %this.addSequence("art/players/base/Anims/Crouch_Back.dsq", "Crouch_Back", "0", "41", "1", "0");
   %this.setSequenceCyclic("Crouch_Back", "1");
   %this.addTrigger("Crouch_Back", "28", "1");
   %this.addTrigger("Crouch_Back", "1", "2");
   %this.addSequence("art/players/base/Anims/Crouch_Left.dsq", "Crouch_Left", "0", "92", "1", "0");
   %this.setSequenceCyclic("Crouch_Left", "1");
   %this.addTrigger("Crouch_Left", "1", "1");
   %this.addTrigger("Crouch_Left", "21", "2");
   %this.addTrigger("Crouch_Left", "45", "1");
   %this.addTrigger("Crouch_Left", "69", "2");
   %this.addSequence("art/players/base/Anims/Crouch_Right.dsq", "Crouch_Right", "0", "92", "1", "0");
   %this.setSequenceCyclic("Crouch_Right", "1");
   %this.addTrigger("Crouch_Right", "1", "2");
   %this.addTrigger("Crouch_Right", "23", "1");
   %this.addTrigger("Crouch_Right", "47", "2");
   %this.addTrigger("Crouch_Right", "69", "1");
   %this.addSequence("art/players/base/Anims/CrouchFull_Root.dsq", "CrouchFull_Root", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/CrouchFull_Forward.dsq", "CrouchFull_Forward", "0", "55", "1", "0");
   %this.setSequenceCyclic("CrouchFull_Forward", "1");
   %this.addTrigger("CrouchFull_Forward", "10", "1");
   %this.addTrigger("CrouchFull_Forward", "33", "2");
   %this.addSequence("art/players/base/Anims/CrouchFull_Back.dsq", "CrouchFull_Back", "0", "55", "1", "0");
   %this.setSequenceCyclic("CrouchFull_Back", "1");
   %this.addTrigger("CrouchFull_Back", "38", "1");
   %this.addTrigger("CrouchFull_Back", "4", "2");
   %this.addSequence("art/players/base/Anims/CrouchFull_Left.dsq", "CrouchFull_Left", "0", "138", "1", "0");
   %this.setSequenceCyclic("CrouchFull_Left", "1");
   %this.addTrigger("CrouchFull_Left", "0", "1");
   %this.addTrigger("CrouchFull_Left", "70", "1");
   %this.addTrigger("CrouchFull_Left", "35", "2");
   %this.addTrigger("CrouchFull_Left", "105", "2");
   %this.addSequence("art/players/base/Anims/CrouchFull_Right.dsq", "CrouchFull_Right", "0", "138", "1", "0");
   %this.setSequenceCyclic("CrouchFull_Right", "1");
   %this.addTrigger("CrouchFull_Right", "2", "2");
   %this.addTrigger("CrouchFull_Right", "34", "1");
   %this.addTrigger("CrouchFull_Right", "68", "2");
   %this.addTrigger("CrouchFull_Right", "101", "1");
   %this.addSequence("art/players/base/Anims/Swim_Root.dsq", "Swim_Root", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/Swim_Forward.dsq", "Swim_Forward", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/Swim_Backward.dsq", "Swim_Backward", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/Swim_Left.dsq", "Swim_Left", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/Swim_Right.dsq", "Swim_Right", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/Swim_Root.dsq", "SwimFull_Root", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/SwimFull_Forward.dsq", "SwimFull_Forward", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/Swim_Backward.dsq", "SwimFull_Backward", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/SwimFull_Left.dsq", "SwimFull_Left", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/SwimFull_Right.dsq", "SwimFull_Right", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/Fall.dsq", "Fall", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Anims/Jump.dsq", "Jump", "0", "70", "1", "0");
   %this.addTrigger("jump", "40", "1");
   %this.addTrigger("jump", "40", "2");
   %this.addSequence("art/players/base/Anims/StandJump.dsq", "StandJump", "0", "70", "1", "0");
   %this.addTrigger("StandJump", "40", "1");
   %this.addTrigger("StandJump", "40", "2");
   %this.addSequence("art/players/base/Anims/Land.dsq", "Land", "0", "29", "1", "0");
   %this.addTrigger("Land", "1", "1");
   %this.addTrigger("Land", "1", "2");
   %this.addSequence("art/players/base/Anims/Flip.dsq", "Flip", "0", "15", "1", "0");
   %this.addSequence("art/players/base/Anims/FallFull.dsq", "FallFull", "0", "15", "1", "0");
   %this.addSequence("art/players/base/Anims/JumpFull.dsq", "JumpFull", "0", "60", "1", "0");
   %this.addTrigger("jumpfull", "40", "1");
   %this.addTrigger("jumpfull", "40", "2");
   %this.addSequence("art/players/base/Anims/StandJumpFull.dsq", "StandJumpFull", "0", "60", "1", "0");
   %this.addTrigger("StandJumpFull", "40", "1");
   %this.addTrigger("StandJumpFull", "40", "2");
   %this.addSequence("art/players/base/Anims/LandFull.dsq", "LandFull", "0", "15", "1", "0");
   %this.addSequence("art/players/base/Anims/FlipFull.dsq", "FlipFull", "0", "15", "1", "0");
   %this.addSequence("art/players/base/Anims/ScoutRoot.dsq", "ScoutRoot", "0", "-1", "1", "0");
   %this.setSequenceCyclic("ScoutRoot", "1");
   %this.addSequence("art/players/base/Anims/shrug.dsq", "celsalute", "0", "20", "1", "0");
   %this.addSequence("art/players/base/Anims/Wave.dsq", "celwave", "0", "18", "1", "0");
   %this.setSequenceCyclic("celwave", "0");
   %this.addSequence("art/players/base/Anims/Head.dsq", "Head", "0", "2", "1", "0");
   %this.setSequenceBlend("head", "1", "Root", "0");
   %this.addSequence("art/players/base/Anims/HeadSide.dsq", "HeadSide", "0", "2", "1", "0");
   %this.setSequenceBlend("HeadSide", "1", "Root", "0");
   %this.addSequence("art/players/base/Anims/Death1.dsq", "Death1", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death2.dsq", "Death2", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death3.dsq", "Death3", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death4.dsq", "Death4", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death5.dsq", "Death5", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death6.dsq", "Death6", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death7.dsq", "Death7", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death8.dsq", "Death8", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death9.dsq", "Death9", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death10.dsq", "Death10", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Death11.dsq", "Death11", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/CastSpell1.dsq", "CastSpell1", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/CastSpell2.dsq", "CastSpell2", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Throw_HamAxe.dsq", "Throw_HamAxe", "0", "29", "1", "0");
   %this.addTrigger("Throw_HamAxe", "10", "3");
   %this.setSequenceBlend("Throw_HamAxe", "1", "Root", "0");
   %this.addSequence("art/players/base/Anims/Throw_Grenade.dsq", "Throw_Grenade", "0", "225", "1", "0");
   %this.addTrigger("Throw_Grenade", "170", "3");
   %this.addSequence("art/players/base/Anims/Throw_Javelin.dsq", "Throw_Javelin", "1", "29", "1", "0");
   %this.addTrigger("Throw_Javelin", "9", "3");
   %this.setSequenceBlend("Throw_Javelin", "1", "Root", "0");
   %this.addSequence("art/players/base/Anims/damageBody1.dsq", "damagebody1", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/damageHead1.dsq", "damagehead1", "0", "13", "1", "0");
   %this.addSequence("art/players/base/Anims/damageLegs1.dsq", "damageLegs1", "0", "13", "1", "0");
   %this.addSequence("art/players/base/Anims/bfb_hit.dsq", "bfb_hit", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/bfb_hit2.dsq", "bfb_hit2", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Summon.dsq", "summon", "0", "29", "1", "0");
   %this.setSequenceCyclic("summon", "1");
   %this.addSequence("art/players/base/Anims/fb.dsq", "fb", "0", "14", "1", "0");
   %this.setSequenceCyclic("fb", "1");
   %this.addSequence("art/players/base/Anims/throw.dsq", "throw", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Anims/ssj.dsq", "ssj", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/ssj_hold.dsq", "ssj_hold", "0", "0", "1", "0");
   %this.addSequence("art/players/base/Anims/ssj_lock.dsq", "ssj_lock", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/ssj_grab.dsq", "ssj_grab", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/mok.dsq", "mok", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/ap.dsq", "ap", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/mlf.dsq", "mlf", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/aitm.dsq", "aitm", "0", "119", "1", "0");
   %this.addSequence("art/players/base/Anims/uif_hit.dsq", "uif_hit", "0", "-1", "1", "0");
   %this.setSequenceCyclic("uif_hit", "1");
   %this.addSequence("art/players/base/Anims/ck.dsq", "ck", "0", "79", "1", "0");
   %this.addSequence("art/players/base/Anims/fst.dsq", "fst", "0", "79", "1", "0");
   %this.addSequence("art/players/base/Anims/th.dsq", "th", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Fire_Flintlock.dsq", "Fire_Flintlock", "0", "-1", "1", "0");
   %this.addTrigger("Fire_FlintLock", "7", "3");
   %this.addSequence("art/players/base/Anims/Look_XR75.dsq", "Look_XR75", "2", "28", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/EdGrimly.dsq", "EdGrimly", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/BreakDance.dsq", "BreakDance", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/FolkDance.dsq", "FolkDance", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/HipHop.dsq", "HipHop", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/Ballet.dsq", "Ballet", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/BellyDancer.dsq", "BellyDancer", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/ClubDance1.dsq", "ClubDance1", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/ClubDance2.dsq", "ClubDance2", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/IrishJig.dsq", "IrishJig", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/LordDance.dsq", "LordDance", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/Macerana.dsq", "Macarena", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/NiteClubLoop1.dsq", "NightClubLoop1", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/NiteClubLoop2.dsq", "NightClubLoop2", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/PulpFiction.dsq", "PulpFiction", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/RiverDance.dsq", "RiverDance", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/SaturdayNight.dsq", "SaturdayNight", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/SnakeDance.dsq", "SnakeDance", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/SuperDance.dsq", "SuperDance", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/SwingDance.dsq", "SwingDance", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/ThrowDown.dsq", "ThrowDown", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/BackFlip.dsq", "BackFlip", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/ArnoldPosing.dsq", "ArnoldPosing", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/BellyLaugh.dsq", "BellyLaugh", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/Bow.dsq", "Bow", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/Pray.dsq", "Pray", "0", "8", "1", "0");
   %this.addSequence("art/players/base/Anims/Extra/HangOver.dsq", "HangOver", "0", "11", "1", "0");
   %this.setSequenceCyclic("HangOver", "0");
   %this.addSequence("art/players/base/Anims/Cast.dsq", "CastLine", "0", "-1", "1", "0");
   %this.addTrigger("CastLine", "19", "3");
   %this.addSequence("art/players/base/Anims/LH_PunchCombo.dsq", "LH_PunchCombo", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/LH_PunchDown.dsq", "LH_PunchDown", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/LH_PunchJab.dsq", "LH_PunchJab", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/LH_PunchRound.dsq", "LH_PunchRound", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/RH_PunchCombo.dsq", "RH_PunchCombo", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/RH_PunchDown.dsq", "RH_PunchDown", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/RH_PunchJab.dsq", "RH_PunchJab", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/RH_PunchRound.dsq", "RH_PunchRound", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/LF_KickLow.dsq", "LF_KickLow", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/LF_KickHigh.dsq", "LF_KickHigh", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/LF_SpinKick1.dsq", "LF_SpinKick1", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/RF_KickLow.dsq", "RF_KickLow", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/RF_KickHigh.dsq", "RF_KickHigh", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/RF_SpinKick1.dsq", "RF_SpinKick1", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/kneel_right.dsq", "Kneel_R", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/kneel_left.dsq", "Kneel_L", "0", "1", "1", "0");
   %this.addSequence("art/players/base/Anims/Staff_Center.dsq", "Staff_Center", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Anims/Staff_LHHigh.dsq", "Staff_LHHigh", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Anims/Staff_LHLow.dsq", "Staff_LHLow", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Anims/Staff_RHHigh.dsq", "Staff_RHHigh", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Staff_RHLow.dsq", "Staff_RHLow", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Staff_Spin.dsq", "Staff_Spin", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Staff_Lunge.dsq", "Staff_Lunge", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Sword_Center.dsq", "Sword_Center", "0", "30", "1", "0");
   %this.addSequence("art/players/base/Anims/Sword_Lunge.dsq", "Sword_Lunge", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Anims/Sword_RHChop.dsq", "Sword_RHChop", "0", "30", "1", "0");
   %this.addSequence("art/players/base/Anims/Sword_DubSwing.dsq", "Sword_DubSwing", "0", "45", "1", "0");
   %this.addSequence("art/players/base/Anims/Sword_Spin.dsq", "Sword_Spin", "0", "45", "1", "0");
   %this.addSequence("art/players/base/Anims/GargSitFull.dsq", "GargSitFull", "0", "-1", "1", "0");
   %this.setSequenceCyclic("GargSitFull", "1");
   %this.addSequence("art/players/base/Anims/sit_chair.dsq", "Sit_Chair", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Anims/Sit_ArmChair.dsq", "Sit_ArmChair", "0", "1", "1", "0");
   %this.addSequence("art/players/base/Anims/Sit_CrossLeg.dsq", "Sit_CrossLeg", "0", "1", "1", "0");
   %this.setSequencePriority("Sit_CrossLeg", "5");
   %this.setSequenceCyclic("Sit_CrossLeg", "1");
   %this.addSequence("art/players/base/Anims/Sit_Ground.dsq", "Sit_Ground", "0", "1", "1", "0");
   %this.setSequencePriority("Sit_Ground", "5");
   %this.setSequenceCyclic("Sit_Ground", "1");
   %this.addSequence("art/players/base/Anims/TapLink.dsq", "Taplink", "0", "3", "1", "0");
   %this.setSequencePriority("taplink", "10");

}

$mack = true;
