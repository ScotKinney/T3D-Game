
singleton TSShapeConstructor(Palmtree_tallDAE)
{
   baseShape = "./palmtree_tall.DAE";
   loadLights = "0";
};

function Palmtree_tallDAE::onLoad(%this)
{
   %this.addImposter("1", "24", "0", "0", "512", "0", "0");
   %this.setDetailLevelSize("100", "200");
   %this.removeDetailLevel("-1");
   %this.removeNode("Col-1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "palmtree", "0", "60", "30", "32", "0", "0", "100");
   %this.addNode("ColCapsule-1", "Col-1", "0.0268454 -0.0920396 11.5179 -0.933988 0.213706 0.286349 1.43602", "0");
   %this.addNode("ColCapsuleB-1", "Col-1", "0.0533395 1.66278 11.9009 -0.683262 0.0209661 0.729872 3.09032", "0");
   %this.addNode("ColCapsuleC-1", "Col-1", "-1.76973 -0.337491 11.6434 -0.617486 -0.563587 0.548708 1.90932", "0");
   %this.addNode("ColCapsuleD-1", "Col-1", "-1.06687 0.469199 13.1414 -0.742179 0.652078 -0.154802 1.70387", "0");
   %this.addNode("ColCapsuleE-1", "Col-1", "-1.56476 0.678112 12.1025 0.0210965 0.0124284 0.9997 2.03665", "0");
   %this.addNode("ColCapsuleF-1", "Col-1", "-0.00430964 -0.126365 10.5748 -0.525829 -0.548135 -0.650424 2.01797", "0");
   %this.addNode("ColCapsuleG-1", "Col-1", "0.0713469 -0.345224 10.5938 0.00936826 0.705947 0.708203 3.07133", "0");
   %this.addNode("ColCapsuleH-1", "Col-1", "0.0319374 -0.0576075 6.01471 -0.787844 -0.435489 -0.435489 1.81696", "0");
   %this.addNode("ColCapsuleI-1", "Col-1", "0.481668 0.95633 13.2103 -0.51903 -0.833274 -0.190428 1.62809", "0");
   %this.addNode("ColCapsuleJ-1", "Col-1", "0.768681 -0.511263 9.95443 0.657529 0.609457 -0.442965 2.25967", "0");
   %this.addNode("ColCapsuleK-1", "Col-1", "0.138843 1.41203 10.9978 0.994938 0.00906123 -0.100082 3.6364", "0");
   %this.addNode("ColCapsuleL-1", "Col-1", "0.807649 -1.35526 13.0336 -0.0915462 0.256902 0.962092 2.53019", "0");
   %this.addNode("ColCapsuleM-1", "Col-1", "1.60827 -0.297626 10.9461 -0.324568 0.637122 0.699093 4.01601", "0");
   %this.addNode("ColCapsuleN-1", "Col-1", "1.63411 -0.0318488 12.5584 -0.70601 -0.546737 0.450142 1.8966", "0");
   %this.addNode("ColCapsuleO-1", "Col-1", "-0.0654565 -0.302252 11.3296 -0.990616 -0.103032 -0.0897967 1.75857", "0");
   %this.addNode("ColCapsuleP-1", "Col-1", "0.0869162 -0.20655 11.2665 0.646218 -0.434741 -0.627218 3.97959", "0");
   %this.addNode("ColCapsuleQ-1", "Col-1", "-0.677821 -1.7382 11.3913 0.267472 0.94968 0.162994 3.33967", "0");
   %this.addNode("ColCapsuleR-1", "Col-1", "-0.761795 -1.00715 13.3114 0.320094 0.877223 -0.357798 2.93765", "0");
   %this.addNode("ColCapsuleS-1", "Col-1", "-0.130032 -0.167014 11.6859 -0.410239 0.65666 0.632851 2.40408", "0");
   %this.addNode("ColCapsuleT-1", "Col-1", "-0.0727085 -0.118353 10.7625 -0.82043 -0.375531 -0.431128 1.57665", "0");
   %this.addNode("ColCapsuleU-1", "Col-1", "0.00826305 -0.905698 10.0762 0.40169 0.72625 0.557859 4.17785", "0");
   %this.addNode("ColCapsuleV-1", "Col-1", "-0.176119 0.261672 9.8678 0.388639 0.652855 0.650185 3.58181", "0");
   %this.addNode("ColCapsuleW-1", "Col-1", "-0.0976981 -1.93243 12.0879 0.739654 -0.0449487 -0.671485 3.15564", "0");
   %this.addNode("ColCapsuleX-1", "Col-1", "-1.21425 -0.0361371 10.4658 0.800484 0.560001 -0.213597 4.13097", "0");
   %this.addNode("ColCapsuleY-1", "Col-1", "0.145905 -0.272051 11.7273 0.0585113 0.768434 -0.637248 3.75762", "0");
   %this.addNode("ColCapsuleZ-1", "Col-1", "-1.28824 -0.11239 10.5377 0.757033 0.642709 0.117583 3.39863", "0");
   %this.addNode("ColCapsuleAB-1", "Col-1", "-0.0328407 -0.339844 10.8979 -0.261695 0.682465 0.682465 2.59191", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "palmtree", "8", "60", "30", "32", "0", "0", "100");
   %this.removeMesh("ColCapsule -1");
   %this.removeMesh("ColCapsuleB -1");
   %this.removeMesh("ColCapsuleC -1");
   %this.removeMesh("ColCapsuleD -1");
   %this.removeMesh("ColCapsuleE -1");
   %this.removeMesh("ColCapsuleF -1");
   %this.removeMesh("ColCapsuleG -1");
   %this.removeMesh("ColCapsuleI -1");
   %this.removeMesh("ColCapsuleAB -1");
   %this.removeMesh("ColCapsuleZ -1");
   %this.removeMesh("ColCapsuleY -1");
   %this.removeMesh("ColCapsuleX -1");
   %this.removeMesh("ColCapsuleW -1");
   %this.removeMesh("ColCapsuleV -1");
   %this.removeMesh("ColCapsuleU -1");
   %this.removeMesh("ColCapsuleT -1");
   %this.removeMesh("ColCapsuleS -1");
   %this.removeMesh("ColCapsuleR -1");
   %this.removeMesh("ColCapsuleQ -1");
   %this.removeMesh("ColCapsuleP -1");
   %this.removeMesh("ColCapsuleO -1");
   %this.removeMesh("ColCapsuleN -1");
   %this.removeMesh("ColCapsuleM -1");
   %this.removeMesh("ColCapsuleL -1");
   %this.removeMesh("ColCapsuleK -1");
   %this.removeMesh("ColCapsuleJ -1");
   %this.renameObject("ColCapsuleH", "ColCapsule");
}

singleton TSShapeConstructor(Palmtree_tallDts)
{
   baseShape = "./palmtree_tall.dts";
};

function Palmtree_tallDts::onLoad(%this)
{
   %this.addImposter("1", "24", "0", "0", "256", "0", "60");
}
