
singleton TSShapeConstructor(basemale1_4Dts)
{
   baseShape = "./BaseMale1_4.dts";
};

function basemale1_4Dts::onLoad(%this)
{
   %this.renameNode("upperJaw", "Eye");
   %this.setNodeTransform("eye", "0.000158001 0.126053 2.43575 1 0 0 0", "1");
   %this.addNode("cam", "root", "0 -0.983047 2.34118 1 0 0 0", "1");
   %this.addNode("mount4", "lForeArm", "-1.09296 0.158002 2.04982 1 0 0 0", "1");
   %this.addNode("mount7", "mount0", "0.598042 3.08894 2.63324 0.704737 -0.682837 -0.192561 3.02562", "1");
   %this.addNode("mount2", "lHand", "-1.09296 0.158002 2.04988 1 0 0 0", "1");
   %this.addNode("mount10", "rToe", "0.174183 0.0105287 0.041622 1 0 0 0", "1");
   %this.addNode("mount12", "lToe", "-0.210012 -0.00454873 0.0478135 1 0 0 0", "1");
   %this.addNode("mount1", "lHand", "-1.15746 0.192278 2.00405 -0.300286 0.910571 -0.284058 0.485323", "1");
   %this.addNode("mount31", "root", "0 0 0 0 0 1 0", "1");
   %this.addSequence("art/players/base/Seqs/Basic/Root.dsq", "Root", "0", "99", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("art/players/base/Seqs/Basic/HeadSide.dsq", "HeadSide", "0", "-1", "1", "0");
   %this.setSequencePriority("HeadSide", "1");
   %this.addSequence("art/players/base/Seqs/Basic/Head.dsq", "Head", "0", "-1", "1", "0");
   %this.setSequencePriority("Head", "1");
   %this.addSequence("art/players/base/Seqs/Basic/Walk.dsq", "RunFull_Forward", "0", "35", "1", "0");
   %this.setSequenceCyclic("RunFull_Forward", "1");
   %this.addTrigger("RunFull_Forward", "32", "1");
   %this.addTrigger("RunFull_Forward", "16", "2");
   %this.addSequence("art/players/base/Seqs/Basic/Back.dsq", "Back", "0", "34", "1", "0");
   %this.setSequenceCyclic("Back", "1");
   %this.addTrigger("Back", "8", "1");
   %this.addTrigger("Back", "25", "2");
   %this.addSequence("art/players/base/Seqs/Basic/Left.dsq", "RunFull_Left", "0", "19", "1", "0");
   %this.setSequenceCyclic("RunFull_Left", "1");
   %this.addTrigger("RunFull_Left", "1", "1");
   %this.addTrigger("RunFull_Left", "14", "2");
   %this.addSequence("art/players/base/Seqs/Basic/Right.dsq", "RunFull_Right", "0", "19", "1", "0");
   %this.setSequenceCyclic("RunFull_Right", "1");
   %this.addTrigger("RunFull_Right", "0", "1");
   %this.addTrigger("RunFull_Right", "10", "2");
   %this.addSequence("art/players/base/Seqs/Basic/Jump_Standing.dsq", "JumpFull", "0", "29", "1", "0");
   %this.addTrigger("JumpFull", "23", "1");
   %this.addTrigger("JumpFull", "23", "2");
   %this.addSequence("art/players/base/Seqs/Basic/Falling.dsq", "FallFull", "0", "39", "1", "0");
   %this.setSequenceCyclic("FallFull", "1");
   %this.addSequence("art/players/base/Seqs/Basic/LandFull.dsq", "Land", "0", "30", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/LandFull.dsq", "LandFull", "0", "30", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/Sprint.dsq", "SprintFull_Forward", "0", "23", "1", "0");
   %this.setSequenceCyclic("SprintFull_Forward", "1");
   %this.addTrigger("SprintFull_Forward", "5", "2");
   %this.addTrigger("SprintFull_Forward", "17", "1");
   %this.addSequence("art/players/base/Seqs/Basic/SprintFull_Back.dsq", "SprintFull_Back", "0", "59", "1", "0");
   %this.addTrigger("SprintFull_Back", "8", "1");
   %this.addTrigger("SprintFull_Back", "23", "2");
   %this.addTrigger("SprintFull_Back", "38", "3");
   %this.addTrigger("SprintFull_Back", "52", "4");
   %this.addSequence("art/players/base/Seqs/Basic/Jump_Sprint.dsq", "Sprint_Jump", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/Sitting_M.dsq", "Sitting_M", "0", "49", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/Crawling.dsq", "Crawling", "0", "29", "1", "0");
   %this.setSequenceCyclic("Crawling", "1");
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
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Root.dsq", "CrouchFull_Root", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Forward.dsq", "CrouchFull_Forward", "0", "55", "1", "0");
   %this.setSequenceCyclic("CrouchFull_Forward", "1");
   %this.addTrigger("CrouchFull_Forward", "11", "1");
   %this.addTrigger("CrouchFull_Forward", "37", "2");
   %this.addTrigger("CrouchFull_Forward", "55", "3");
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Back.dsq", "CrouchFull_Back", "0", "55", "1", "0");
   %this.setSequenceCyclic("CrouchFull_Back", "1");
   %this.addTrigger("CrouchFull_Back", "0", "1");
   %this.addTrigger("CrouchFull_Back", "29", "2");
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Left.dsq", "CrouchFull_Left", "0", "138", "1", "0");
   %this.setSequenceCyclic("CrouchFull_Left", "1");
   %this.addTrigger("CrouchFull_Left", "1", "1");
   %this.addTrigger("CrouchFull_Left", "32", "2");
   %this.addTrigger("CrouchFull_Left", "67", "3");
   %this.addTrigger("CrouchFull_Left", "105", "4");
   %this.addSequence("art/players/base/Seqs/Basic/CrouchFull_Right.dsq", "CrouchFull_Right", "0", "138", "1", "0");
   %this.setSequenceCyclic("CrouchFull_Right", "1");
   %this.addTrigger("CrouchFull_Right", "31", "1");
   %this.addTrigger("CrouchFull_Right", "70", "2");
   %this.addTrigger("CrouchFull_Right", "100", "3");
   %this.addTrigger("CrouchFull_Right", "136", "4");
   %this.addSequence("art/players/base/Seqs/Basic/SwimFull_Root.dsq", "SwimFull_Root", "0", "209", "1", "0");
   %this.setSequenceCyclic("SwimFull_Root", "1");
   %this.addSequence("art/players/base/Seqs/Basic/SwimFull_Above.dsq", "SwimFull_Forward", "0", "29", "1", "0");
   %this.setSequenceCyclic("SwimFull_Forward", "1");
   %this.addSequence("art/players/base/Seqs/Basic/SwimFull_Under.dsq", "SwimFull_ForwardUnder", "0", "244", "1", "0");
   %this.addSequence("art/players/base/Seqs/Basic/SwimFull_Back.dsq", "SwimFull_Backward", "0", "244", "1", "0");
   %this.setSequenceCyclic("SwimFull_Backward", "1");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_B1.dsq", "Damage_Body_B1", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_F1.dsq", "Damage_Body_F1", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_F2.dsq", "Damage_Body_F2", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_F1.dsq", "Damage_Head_F1", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_F2.dsq", "Damage_Head_F2", "0", "39", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_L1.dsq", "Damage_Head_L1", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Head_R1.dsq", "Damage_Head_R1", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_R1.dsq", "Damage_Body_R1", "0", "16", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_L1.dsq", "Damage_Body_L1", "0", "16", "1", "0");
   %this.addSequence("art/players/base/Seqs/Damage/Damage_Body_F3.dsq", "Damage_Body_F3", "0", "17", "1", "0");
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
   %this.addSequence("art/players/base/Seqs/H2H/Kick1_LF.dsq", "Kick1_LF", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick1_RF.dsq", "Kick1_RF", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick2_LF.dsq", "Kick2_LF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick2_RF.dsq", "Kick2_RF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick3_LF.dsq", "Kick3_LF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Kick3_RF.dsq", "Kick3_RF", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch1_LH.dsq", "Punch1_LH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch1_RH.dsq", "Punch1_RH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch2_LH.dsq", "Punch2_LH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch2_RH.dsq", "Punch2_RH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch3_LH.dsq", "Punch3_LH", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch3_RH.dsq", "Punch3_RH", "0", "19", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch4_LH.dsq", "Punch4_LH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/H2H/Punch4_RH.dsq", "Punch4_RH", "0", "24", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell1.dsq", "M_CastSpell1", "0", "79", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell2.dsq", "M_CastSpell2", "0", "49", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell3.dsq", "M_Castspell3", "0", "89", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell4.dsq", "M_CastSpell4", "0", "74", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell5.dsq", "M_Castspell5", "0", "69", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell6.dsq", "M_CastSpell6", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell7.dsq", "M_CastSpell7", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell8.dsq", "M_CastSpell8", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell9.dsq", "M_CastSpell9", "0", "239", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_CastSpell10.dsq", "M_CastSpell10", "0", "558", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_Staff_EarthQuake.dsq", "M_Staff_EarthQuake", "0", "34", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_Staff_Fire.dsq", "M_Staff_Fire", "0", "29", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_Staff_MagicHelix.dsq", "M_Staff_MagicHelix", "0", "69", "1", "0");
   %this.addSequence("art/players/base/Seqs/Magic/M_Staff_MagicLight.dsq", "M_Staff_MagicLight", "0", "49", "1", "0");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Root.dsq", "H_Root", "0", "102", "1", "0");
   %this.setSequenceCyclic("H_Root", "1");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Walk.dsq", "H_WalkTrot", "0", "44", "1", "0");
   %this.setSequenceCyclic("H_WalkTrot", "1");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Gallop.dsq", "H_Gallop", "0", "33", "1", "0");
   %this.setSequenceCyclic("H_Gallop", "1");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Damage1.dsq", "H_Damage1", "0", "44", "1", "0");
   %this.setSequencePriority("H_Damage1", "1");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Death1.dsq", "H_Death1", "0", "44", "1", "0");
   %this.setSequencePriority("H_Death1", "1");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Melee1.dsq", "H_Melee1", "0", "44", "1", "0");
   %this.setSequencePriority("H_Melee1", "1");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Melee2.dsq", "H_Melee2", "0", "21", "1", "0");
   %this.setSequencePriority("H_Melee2", "1");
   %this.addSequence("art/players/base/Seqs/Mounted/H_Thrown1.dsq", "H_Thrown1", "0", "54", "1", "0");
   %this.setSequencePriority("H_Thrown1", "1");
   %this.addSequence("art/players/base/Seqs/Mounted/H_WarCry.dsq", "H_WarCry", "0", "49", "1", "0");
   %this.setSequencePriority("H_WarCry", "1");
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
   %this.setSequencePriority("CrouchFull_Root", "1");
   %this.setSequencePriority("SprintFull_Back", "1");
   %this.setSequencePriority("SwimFull_ForwardUnder", "1");
   %this.setSequencePriority("Damage_Body_R1", "1");
   %this.setSequencePriority("Damage_Body_L1", "1");
   %this.setSequencePriority("M_CastSpell1", "1");
   %this.setSequencePriority("M_CastSpell9", "1");
   %this.setSequencePriority("M_CastSpell10", "1");
   %this.addSequence("art/players/base/Seqs/Basic/Cast.dsq", "CastLine", "0", "34", "1", "0");
   %this.addTrigger("CastLine", "19", "3");
   %this.addSequence("art/players/base/Seqs/Basic/Cast_Blend.dsq", "Castline_Blend", "0", "33", "1", "0");
   %this.addTrigger("Castline_Blend", "19", "3");
   %this.addSequence("art/players/base/Seqs/Guns/Fire_GunFull.dsq", "Fire_Flintlock", "0", "19", "1", "0");
   %this.addTrigger("Fire_Flintlock", "9", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_AxeFull.dsq", "Throw_HamAxe", "0", "34", "1", "0");
   %this.addTrigger("Throw_HamAxe", "15", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_SpearFull.dsq", "Throw_Javelin", "0", "34", "1", "0");
   %this.addTrigger("Throw_Javelin", "15", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_GrenadeFull.dsq", "Throw_Grenade", "0", "-1", "1", "0");
   %this.addTrigger("Throw_Grenade", "23", "3");
   %this.addSequence("art/players/base/Seqs/Bow/B_Fire.dsq", "B_Fire", "0", "-1", "1", "0");
   %this.addTrigger("B_Fire", "34", "3");
   %this.addSequence("art/players/base/Seqs/Basic/TapLink.dsq", "TAPLink", "0", "3", "1", "0");
   %this.setSequencePriority("taplink", "5");
   %this.addSequence("art/players/base/Seqs/Guns/Fire_GunBlend.dsq", "Fire_FlintLockBlend", "0", "29", "1", "0");
   %this.addTrigger("Fire_FlintLockBlend", "9", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_AxeBlend.dsq", "Throw_HamAxeBlend", "0", "29", "1", "0");
   %this.addTrigger("Throw_HamAxeBlend", "15", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_SpearBlend.dsq", "Throw_JavelinBlend", "0", "29", "1", "0");
   %this.addTrigger("Throw_JavelinBlend", "15", "3");
   %this.addSequence("art/players/base/Seqs/Thrown/Throw_GrenadeBlend.dsq", "Throw_GrenadeBlend", "0", "29", "1", "0");
   %this.addTrigger("Throw_GrenadeBlend", "17", "3");
   %this.addSequence("art/players/base/Seqs/Guns/Look_XR75.dsq", "Look_XR75", "0", "29", "1", "0");

}

$mack = true;
