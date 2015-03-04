
singleton TSShapeConstructor(BaseFemale1_4Dts)
{
   baseShape = "./basefemale1_4.dts";
};

function BaseFemale1_4Dts::onLoad(%this)
{
   %this.renameNode("upperJaw", "Eye");
   %this.setNodeTransform("Eye", "0.0143051 0.114877 2.35567 0.0652936 -0.983834 -0.166756 0.0252496", "1");
   %this.addNode("cam", "root", "0 -0.983047 2.34118 1 0 0 0", "1");
   %this.addNode("mount4", "lForeArm", "-1.01155 0.175602 2.00712 0.0145075 -0.163052 0.986511 0.193837", "1");
   %this.addNode("mount7", "mount0", "0.472093 3.16589 2.59716 0.69705 -0.68378 -0.215794 3.07014", "1");
   %this.addNode("mount2", "lHand", "-1.01155 0.175602 2.02436 1 0 0 0", "1");
   %this.addNode("mount10", "rToe", "0.174183 0.0105287 0.041622 1 0 0 0", "1");
   %this.addNode("mount12", "lToe", "-0.210012 -0.00454873 0.0478135 1 0 0 0", "1");
   %this.addNode("mount1", "lHand", "-1.04742 0.220753 1.94963 -0.296087 0.913308 -0.279644 0.479743", "1");
   %this.addNode("mount31", "root", "0 0 0 0 0 1 0", "1");
   %this.addMesh("Sash_FJ 700", "./BaseFemale_FJ.dts", "Sash_FJ 700");
   %this.addMesh("WristGrd_FJ_R 700", "./BaseFemale_FJ.dts", "WristGrd_FJ_R 700");
   %this.addMesh("ChestStrap_FJ 700", "./BaseFemale_FJ.dts", "ChestStrap_FJ 700");
   %this.addMesh("Pants_FJ 700", "./BaseFemale_FJ.dts", "Pants_FJ 700");
   %this.addMesh("Boots_FJ 700", "./BaseFemale_FJ.dts", "Boots_FJ 700");
   %this.addMesh("WristGrd_FJ_L 700", "./BaseFemale_FJ.dts", "WristGrd_FJ_L 700");
   %this.addMesh("Sash_FJ 400", "./BaseFemale_FJ.dts", "Sash_FJ 400");
   %this.addMesh("WristGrd_FJ_R 400", "./BaseFemale_FJ.dts", "WristGrd_FJ_R 400");
   %this.addMesh("ChestStrap_FJ 400", "./BaseFemale_FJ.dts", "ChestStrap_FJ 400");
   %this.addMesh("Pants_FJ 400", "./BaseFemale_FJ.dts", "Pants_FJ 400");
   %this.addMesh("Boots_FJ 400", "./BaseFemale_FJ.dts", "Boots_FJ 400");
   %this.addMesh("WristGrd_FJ_L 400", "./BaseFemale_FJ.dts", "WristGrd_FJ_L 400");
   %this.addMesh("Sash_FJ 50", "./BaseFemale_FJ.dts", "Sash_FJ 50");
   %this.addMesh("WristGrd_FJ_R 50", "./BaseFemale_FJ.dts", "WristGrd_FJ_R 50");
   %this.addMesh("ChestStrap_FJ 50", "./BaseFemale_FJ.dts", "ChestStrap_FJ 50");
   %this.addMesh("Pants_FJ 50", "./BaseFemale_FJ.dts", "Pants_FJ 50");
   %this.addMesh("Boots_FJ 50", "./BaseFemale_FJ.dts", "Boots_FJ 50");
   %this.addMesh("WristGrd_FJ_L 50", "./BaseFemale_FJ.dts", "WristGrd_FJ_L 50");
   %this.addSequence("art/players/base/Seqs/Basic/Root.dsq", "Root", "0", "59", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.setSequencePriority("Root", "1");
   %this.addSequence("art/players/base/Seqs/Basic/Customizer_Idle.dsq", "C_Idle", "0", "301", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/HeadSide.dsq", "HeadSide", "0", "-1", "1", "0");
   %this.setSequencePriority("HeadSide", "5");
   %this.addSequence("art/players/base/Seqs/Basic/Head.dsq", "head", "0", "8", "1", "0");
   %this.setSequencePriority("head", "5"); 
   %this.addSequence("art/players/base/Seqs/Basic/WalkFem.dsq", "Walk", "0", "27", "1", "0");
   %this.setSequenceCyclic("Walk", "1");
   %this.addTrigger("Walk", "11", "1");
   %this.addTrigger("Walk", "24", "2");  
   %this.addSequence("art/players/base/Seqs/Basic/Back.dsq", "Walk_Back", "0", "34", "1", "0");
   %this.addTrigger("Walk_Back", "8", "1");
   %this.addTrigger("Walk_Back", "25", "2");
   %this.addSequence("art/players/base/Seqs/Basic/Left.dsq", "Strafe_Left", "0", "19", "1", "0");
   %this.setSequenceCyclic("Strafe_Left", "1");
   %this.addTrigger("Strafe_Left", "1", "1");
   %this.addTrigger("Strafe_Left", "14", "2");
   %this.addSequence("art/players/base/Seqs/Basic/Right.dsq", "Strafe_Right", "0", "19", "1", "0");
   %this.setSequenceCyclic("Strafe_Right", "1");
   %this.addTrigger("Strafe_Right", "0", "1");
   %this.addTrigger("Strafe_Right", "10", "2");
   %this.addSequence("art/players/base/Seqs/Basic/Jump_Standing.dsq", "Stand_Jump", "0", "29", "1", "0");
   %this.addTrigger("Stand_Jump", "23", "1");
   %this.addTrigger("Stand_Jump", "23", "2");
   %this.addSequence("art/players/base/Seqs/Basic/Falling.dsq", "Fall", "0", "39", "1", "0");
   %this.setSequenceCyclic("Fall", "1");
   %this.addSequence("art/players/base/Seqs/Basic/LandFull.dsq", "Land", "0", "30", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/Run.dsq", "Run", "0", "19", "1", "0");
   %this.setSequenceCyclic("Run", "1");
   %this.addTrigger("Run", "8", "1");
   %this.addTrigger("Run", "18", "2");
   %this.addSequence("art/players/base/Seqs/Basic/SprintFull_Back.dsq", "Run_Back", "0", "59", "1", "0");
   %this.setSequencePriority("Run_Back", "1");
   %this.addTrigger("Run_Back", "8", "1");
   %this.addTrigger("Run_Back", "23", "2");
   %this.addTrigger("Run_Back", "38", "3");
   %this.addTrigger("Run_Back", "52", "4");
   %this.addSequence("art/players/base/Seqs/Basic/Jump_Sprint.dsq", "Move_Jump", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/Sitting_M.dsq", "Sitting_M", "0", "49", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/Crawling.dsq", "Prone_Root", "0", "29", "1", "0");
   %this.setSequenceCyclic("Prone_Root", "1");
   %this.addSequence("art/players/base/Seqs/Basic/Crawling.dsq", "Prone_Forward", "0", "29", "1", "0");
   %this.setSequenceCyclic("Prone_Forward", "1");
   %this.addSequence("art/players/base/Seqs/Basic/Digging.dsq", "Digging", "0", "44", "1", "0");
   %this.setSequenceCyclic("Digging", "1");
   %this.addSequence("art/players/base/Seqs/Basic/ClimbingLadderUp.dsq", "ClimbingLadder_Up", "0", "39", "1", "0");
   %this.setSequenceCyclic("ClimbingLadder_Up", "1");
   %this.addSequence("art/players/base/Seqs/Basic/ClimbingLadderDown.dsq", "ClimbingLadder_Down", "0", "39", "1", "0");
   %this.setSequenceCyclic("ClimbingLadder_Down", "1");
   %this.addSequence("art/players/base/Seqs/Basic/Climbingrope.dsq", "ClimbingRope", "0", "29", "1", "0");
   %this.setSequenceCyclic("ClimbingRope", "1");
   %this.addSequence("art/players/base/Seqs/Basic/Climbingwall.dsq", "ClimbingWall", "0", "29", "1", "0");
   %this.setSequenceCyclic("ClimbingWall", "1");
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Root.dsq", "Crouch_Root", "0", "39", "1", "0");
   %this.setSequencePriority("Crouch_Root", "1");
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Forward.dsq", "Crouch_Forward", "0", "55", "1", "0");
   %this.setSequenceCyclic("Crouch_Forward", "1");
   %this.addTrigger("Crouch_Forward", "11", "1");
   %this.addTrigger("Crouch_Forward", "37", "2");
   %this.addTrigger("Crouch_Forward", "55", "3");
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Back.dsq", "Crouch_Back", "0", "55", "1", "0");
   %this.setSequenceCyclic("Crouch_Back", "1");
   %this.addTrigger("Crouch_Back", "0", "1");
   %this.addTrigger("Crouch_Back", "29", "2");
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Left.dsq", "Crouch_Left", "0", "138", "1", "0");
   %this.setSequenceCyclic("Crouch_Left", "1");
   %this.addTrigger("Crouch_Left", "1", "1");
   %this.addTrigger("Crouch_Left", "32", "2");
   %this.addTrigger("Crouch_Left", "67", "3");
   %this.addTrigger("Crouch_Left", "105", "4");
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Right.dsq", "Crouch_Right", "0", "138", "1", "0");
   %this.setSequenceCyclic("Crouch_Right", "1");
   %this.addTrigger("Crouch_Right", "31", "1");
   %this.addTrigger("Crouch_Right", "70", "2");
   %this.addTrigger("Crouch_Right", "100", "3");
   %this.addTrigger("Crouch_Right", "136", "4");
   %this.addSequence("art/players/base/Seqs/Basic/SwimFull_Root.dsq", "Swim_Root", "0", "209", "1", "0");
   %this.setSequenceCyclic("Swim_Root", "1");
   %this.addSequence("art/players/base/Seqs/Basic/SwimFull_Above.dsq", "Swim_Surface", "0", "29", "1", "0");
   %this.setSequenceCyclic("Swim_Surface", "1");
   %this.addSequence("art/players/base/Seqs/Basic/SwimFull_Under.dsq", "Swim_Forward", "0", "244", "1", "0");
   %this.setSequencePriority("Swim_Forward", "1");
   %this.addSequence("art/players/base/Seqs/Basic/SwimFull_Back.dsq", "Swim_Back", "0", "244", "1", "0");
   %this.setSequenceCyclic("Swim_Back", "1");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_B1.dsq", "Damage_Body_B1", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_B2.dsq", "Damage_Body_B2", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_B3.dsq", "Damage_Body_B3", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_B4.dsq", "Damage_Body_B4", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_F1.dsq", "Damage_Body_F1", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_F2.dsq", "Damage_Body_F2", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_F3.dsq", "Damage_Body_F3", "0", "17", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_F4.dsq", "Damage_Body_F4", "0", "15", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_F5.dsq", "Damage_Body_F5", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_F6.dsq", "Damage_Body_F6", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_R1.dsq", "Damage_Body_R1", "0", "16", "1", "0");
   %this.setSequencePriority("Damage_Body_R1", "1");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_R2.dsq", "Damage_Body_R2", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_R3.dsq", "Damage_Body_R3", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_L1.dsq", "Damage_Body_L1", "0", "16", "1", "0");
   %this.setSequencePriority("Damage_Body_L1", "1");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_L2.dsq", "Damage_Body_L2", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_L3.dsq", "Damage_Body_L3", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_B1.dsq", "Damage_Head_B1", "0", "14", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_B2.dsq", "Damage_Head_B2", "0", "14", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_B3.dsq", "Damage_Head_B3", "0", "14", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_B4.dsq", "Damage_Head_B4", "0", "14", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_F1.dsq", "Damage_Head_F1", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_F2.dsq", "Damage_Head_F2", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_F3.dsq", "Damage_Head_F3", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_F4.dsq", "Damage_Head_F4", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_F5.dsq", "Damage_Head_F5", "0", "14", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_F6.dsq", "Damage_Head_F6", "0", "14", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_L1.dsq", "Damage_Head_L1", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_L2.dsq", "Damage_Head_L2", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_L3.dsq", "Damage_Head_L3", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_R1.dsq", "Damage_Head_R1", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_R2.dsq", "Damage_Head_R2", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_R3.dsq", "Damage_Head_R3", "0", "9", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Legs_B1.dsq", "Damage_Legs_B1", "0", "11", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Legs_B2.dsq", "Damage_Legs_B2", "0", "11", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Legs_F1.dsq", "Damage_Legs_F1", "0", "11", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Legs_L1.dsq", "Damage_Legs_L1", "0", "11", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Legs_R1.dsq", "Damage_Legs_R1", "0", "11", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_WBody_B1.dsq", "Damage_WBody_B1", "0", "99", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_WBody_F1.dsq", "Damage_WBody_F1", "0", "120", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death1.dsq", "Death1", "0", "64", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death2.dsq", "Death2", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death3.dsq", "Death3", "0", "139", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death4.dsq", "Death4", "0", "16", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death5.dsq", "Death5", "0", "16", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death6.dsq", "Death6", "0", "132", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death7.dsq", "Death7", "0", "79", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death8.dsq", "Death8", "0", "84", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death9.dsq", "Death9", "0", "169", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death11.dsq", "Death11", "0", "73", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death10.dsq", "Death10", "0", "168", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death12.dsq", "Death12", "0", "68", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death13.dsq", "Death13", "0", "79", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death14.dsq", "Death14", "0", "79", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death15.dsq", "Death15", "0", "109", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death16.dsq", "Death16", "0", "119", "1", "0");
   %this.addSequence("art/players/base/Seqs/Death/Death17.dsq", "Death17", "0", "89", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing1.dsq", "2HS_Swing1", "0", "41", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing2.dsq", "2HS_Swing2", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing3.dsq", "2HS_Swing3", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing4.dsq", "2HS_Swing4", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing5.dsq", "2HS_Swing5", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing6.dsq", "2HS_Swing6", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing7.dsq", "2HS_Swing7", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing8.dsq", "2HS_Swing8", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing9.dsq", "2HS_Swing9", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing10.dsq", "2HS_Swing10", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/2HS_Swing11.dsq", "2HS_Swing11", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Shield1_LH.dsq", "Shield1_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Shield2_LH.dsq", "Shield2_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Shield3_LH.dsq", "Shield3_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Shield4_LH.dsq", "Shield4_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing5_LHMove.dsq", "Shield2_LHBlend", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/Shield2_LH_Mount.dsq", "Shield2_LH_Mount", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Spear_Thrust1_RH.dsq", "Spear_Thrust1_RH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Spear_Thrust2_RH.dsq", "Spear_Thrust2_RH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Spear_Thrust3_RH.dsq", "Spear_Thrust3_RH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing1.dsq", "Staff_Swing1", "0", "79", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing2.dsq", "Staff_Swing2", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing3.dsq", "Staff_Swing3", "0", "109", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing4.dsq", "Staff_Swing4", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing5.dsq", "Staff_Swing5", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing6.dsq", "Staff_Swing6", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing7.dsq", "Staff_Swing7", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing8.dsq", "Staff_Swing8", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing9.dsq", "Staff_Swing9", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/Staff_Swing10.dsq", "Staff_Swing10", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing1_LH.dsq", "SwordSwing1_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing2_LH.dsq", "SwordSwing2_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing3_LH.dsq", "SwordSwing3_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing4_LH.dsq", "SwordSwing4_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing5_LH.dsq", "SwordSwing5_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing6_LH.dsq", "SwordSwing6_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing7_LH.dsq", "SwordSwing7_LH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing1_RH.dsq", "SwordSwing1_RH", "0", "44", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing2_RH.dsq", "SwordSwing2_RH", "0", "59", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing3_RH.dsq", "SwordSwing3_RH", "0", "69", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing4_RH.dsq", "SwordSwing4_RH", "0", "44", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing5_RH.dsq", "SwordSwing5_RH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing6_RH.dsq", "SwordSwing6_RH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing7_RH.dsq", "SwordSwing7_RH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing8_RH.dsq", "SwordSwing8_RH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing9_RH.dsq", "SwordSwing9_RH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing10_RH.dsq", "SwordSwing10_RH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing11_RH.dsq", "SwordSwing11_RH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing12_RH.dsq", "SwordSwing12_RH", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing5_RHMove.dsq", "SwordSwing5_RHBlend", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/Melee/SwordSwing5_LHMove.dsq", "SwordSwing5_LHBlend", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick1_LF.dsq", "Kick1_LF", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick1_RF.dsq", "Kick1_RF", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick2_LF.dsq", "Kick2_LF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick2_RF.dsq", "Kick2_RF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick3_LF.dsq", "Kick3_LF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick3_RF.dsq", "Kick3_RF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick4_LF.dsq", "Kick4_LF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick4_RF.dsq", "Kick4_RF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick5_LF.dsq", "Kick5_LF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick5_RF.dsq", "Kick5_RF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick1_BF.dsq", "Kick1_BF", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch1_LH.dsq", "Punch1_LH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch1_RH.dsq", "Punch1_RH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch2_LH.dsq", "Punch2_LH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch2_RH.dsq", "Punch2_RH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch3_LH.dsq", "Punch3_LH", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch3_RH.dsq", "Punch3_RH", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch4_LH.dsq", "Punch4_LH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch4_RH.dsq", "Punch4_RH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch5_LH.dsq", "Punch5_LH", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch5_RH.dsq", "Punch5_RH", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell1.dsq", "M_CastSpell1", "0", "79", "1", "0");
   %this.setSequencePriority("M_CastSpell1", "1");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell2.dsq", "M_CastSpell2", "0", "49", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell3.dsq", "M_Castspell3", "0", "89", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell4.dsq", "M_CastSpell4", "0", "74", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell5.dsq", "M_Castspell5", "0", "69", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell6.dsq", "M_CastSpell6", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell7.dsq", "M_CastSpell7", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell8.dsq", "M_CastSpell8", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell9.dsq", "M_CastSpell9", "0", "239", "1", "0");
   %this.setSequencePriority("M_CastSpell9", "1");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell10.dsq", "M_CastSpell10", "0", "558", "1", "0");
   %this.setSequencePriority("M_CastSpell10", "1");
   %this.addSequence("art/players/base/Seqs/Magic/M_Staff_EarthQuake.dsq", "M_Staff_EarthQuake", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_Staff_Fire.dsq", "M_Staff_Fire", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_Staff_MagicHelix.dsq", "M_Staff_MagicHelix", "0", "69", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_Staff_MagicLight.dsq", "M_Staff_MagicLight", "0", "49", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/GargSitFull.dsq", "GargSitFull", "0", "597", "1", "0");
   %this.setSequenceCyclic("GargSitFull", "1");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Angry.dsq", "E_Angry", "0", "49", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_ArnoldPosing.dsq", "E_ArnoldPosing", "0", "97", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_BackFlip.dsq", "E_BackFlip", "0", "22", "1", "0");
   %this.addTrigger("E_BackFlip", "19", "1");
   %this.addTrigger("E_BackFlip", "19", "2");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Ballet.dsq", "E_Ballet", "0", "563", "1", "0");
   %this.setSequenceCyclic("E_Ballet", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_BangShield.dsq", "E_BangShield", "0", "19", "1", "0");
   %this.setSequenceCyclic("E_BangShield", "1");
   %this.addSequence("art/players/base/Seqs/Emotes/E_BellyDancer.dsq", "E_BellyDancer", "0", "570", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_BellyLaugh.dsq", "E_BellyLaugh", "0", "87", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Bored.dsq", "E_Bored", "0", "124", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Bow.dsq", "E_Bow", "0", "52", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_BreakDance.dsq", "E_BreakDance", "0", "587", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_ClubDance1.dsq", "E_ClubDance1", "0", "599", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_ClubDance2.dsq", "E_ClubDance2", "0", "574", "1", "0");
   %this.setSequenceCyclic("E_BreakDance", "1");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Drinking.dsq", "E_Drinking", "0", "109", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Eating.dsq", "E_Eating", "0", "129", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_EdGrimly.dsq", "E_EdGrimleyDance", "0", "342", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_FolkDance.dsq", "E_FolkDance", "0", "266", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_HangOver.dsq", "E_HangOver", "0", "815", "1", "0");
   %this.setSequenceCyclic("E_HangOver", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_HipHop.dsq", "E_HipHop", "0", "548", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Hurray.dsq", "E_Hurray", "0", "49", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_IrishJig.dsq", "E_IrishJig", "0", "574", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_JumpingJacks.dsq", "E_JumpingJacks", "0", "24", "1", "0");
   %this.setSequenceCyclic("E_JumpingJacks", "1");
   %this.addSequence("art/players/base/Seqs/Emotes/E_LordDance.dsq", "E_LordDance", "0", "596", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Macerana.dsq", "E_Macarena", "0", "551", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_NiteClubLoop1.dsq", "E_NightClub1", "0", "275", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_NiteClubLoop2.dsq", "E_NightClub2", "0", "141", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_PickUpObject.dsq", "E_PickUpObject", "0", "49", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Pray.dsq", "E_Pray", "0", "83", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_PulpFiction.dsq", "E_PulpFictionDance", "0", "424", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_RiverDance.dsq", "E_RiverDance", "0", "442", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Salute1.dsq", "E_Salute1", "0", "62", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Salute2.dsq", "E_Salute2", "0", "69", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_SaturdayNight.dsq", "E_SaturdayNight", "0", "521", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_SayNo.dsq", "E_SayNo", "0", "59", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Shrug.dsq", "E_Shrug", "0", "54", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_SnakeDance.dsq", "E_SnakeDance", "0", "565", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Stretching.dsq", "E_Stretching", "0", "109", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_SuperDance.dsq", "E_SuperDance", "0", "1298", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_SwingDance.dsq", "E_SwingDance", "0", "278", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_ThrowDown.dsq", "E_ThrowDown", "0", "1230", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Victory.dsq", "E_Victory", "0", "74", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Warning.dsq", "E_Warning", "0", "69", "1", "0");
   %this.addSequence("art/players/base/Seqs/Emotes/E_Wave.dsq", "E_Wave", "0", "26", "1", "0");
   %this.setSequenceCyclic("E_Wave", "0");
   %this.addSequence("art/players/base/Seqs/Basic/TapLink.dsq", "TapLink", "0", "8", "1", "0");
   %this.setSequencePriority("TapLink", "3");
   %this.addSequence("art/players/base/Seqs/Basic/Cast.dsq", "CastLine", "0", "34", "1", "0");
   %this.addTrigger("CastLine", "19", "3");
   %this.addSequence("art/players/base/Seqs/Basic/Cast_Move.dsq", "Castline_Blend", "0", "24", "1", "0");
   %this.addTrigger("Castline_Blend", "19", "3");
   %this.addSequence("art/players/base/Seqs/Guns/Fire_GunFull.dsq", "Fire_Flintlock", "0", "19", "1", "0");
   %this.addTrigger("Fire_Flintlock", "10", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_AxeFull.dsq", "Throw_HamAxe", "0", "34", "1", "0");
   %this.addTrigger("Throw_HamAxe", "15", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_SpearFull.dsq", "Throw_Javelin", "0", "34", "1", "0");
   %this.addTrigger("Throw_Javelin", "15", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_GrenadeFull.dsq", "Throw_Grenade", "0", "-1", "1", "0");
   %this.addTrigger("Throw_Grenade", "23", "3");
   %this.addSequence("art/players/base/Seqs/Bow/B_Fire.dsq", "B_Fire", "0", "-1", "1", "0");
   %this.addTrigger("B_Fire", "36", "3");
   %this.addSequence("art/players/base/Seqs/Guns/Fire_GunMove.dsq", "Fire_FlintLockBlend", "0", "24", "1", "0");
   %this.addTrigger("Fire_FlintLockBlend", "13", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_SpearMove.dsq", "Throw_JavelinBlend", "0", "24", "1", "0");
   %this.addTrigger("Throw_JavelinBlend", "11", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_GrenadeMove.dsq", "Throw_GrenadeBlend", "0", "24", "1", "0");
   %this.addTrigger("Throw_GrenadeBlend", "11", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_AxeMove.dsq", "Throw_HamAxeBlend", "0", "24", "1", "0");
   %this.addTrigger("Throw_HamAxeBlend", "11", "3");
   %this.addSequence("art/players/base/Seqs/Bow/B_FireMove.dsq", "B_FireBlend", "0", "49", "1", "0");
   %this.addTrigger("B_FireBlend", "36", "3");
   %this.addSequence("art/players/base/Seqs/Guns/Look_XR75.dsq", "Look_XR75", "0", "8", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Gallop.dsq", "H_Gallop", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Damage1.dsq", "H_Damage1", "0", "33", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Death1.dsq", "H_Death1", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Root.dsq", "H_Root", "0", "99", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Walk.dsq", "H_WalkTrot", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/HM_Head.dsq", "HM_Head", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/HM_HeadSide.dsq", "HM_HeadSide", "0", "-1", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/Melee1_RH_Mount.dsq", "Melee1_RH_Mount", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/Melee2_RH_Mount.dsq", "Melee2_RH_Mount", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/Melee1_LH_Mount.dsq", "Melee1_LH_Mount", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/Melee2_LH_Mount.dsq", "Melee2_LH_Mount", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/Throw_HamAxeMount.dsq", "Throw_HamAxeMount", "0", "24", "1", "0");
   %this.addTrigger("Throw_HamAxeMount", "11", "3");
   %this.addSequence("art/players/base/Seqs/Mounted/Throw_GrenadeMount.dsq", "Throw_GrenadeMount", "0", "24", "1", "0");
   %this.addTrigger("Throw_GrenadeMount", "9", "3");
   %this.addSequence("art/players/base/Seqs/Mounted/Throw_JavelinMount.dsq", "Throw_JavelinMount", "0", "24", "1", "0");
   %this.addTrigger("Throw_JavelinMount", "11", "3");
   %this.addSequence("art/players/base/Seqs/Mounted/B_FireMount.dsq", "B_FireMount", "0", "49", "1", "0");
   %this.addTrigger("B_FireMount", "34", "3");
   %this.addSequence("art/players/base/Seqs/Mounted/Fire_GunMount.dsq", "Fire_FlintlockMount", "0", "24", "1", "0");
   %this.addTrigger("Fire_FlintlockMount", "13", "3");
   %this.addSequence("art/players/base/Seqs/Mounted/WarCry_Mount.dsq", "WarCry_Mount", "0", "49", "1", "0");
}

$mack = true;
