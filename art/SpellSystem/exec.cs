echo("% - Initializing IPS/S datablocks");
//Load all utility scripts.


for(%emitterFile = findFirstFile("./Emitters/*.cs"); %emitterFile !$= ""; %emitterFile = findNextFile())
{
   exec(%emitterFile);
}

for(%projFile = findFirstFile("./Projectiles/*.cs"); %projFile !$= ""; %projFile = findNextFile())
{
   exec(%projFile);
}

for(%decalFile = findFirstFile("./Decals/*.cs"); %decalFile !$= ""; %decalFile = findNextFile())
{
   exec(%decalFile);
}

for(%spellFile = findFirstFile("./Explosions/*.cs"); %spellFile !$= ""; %spellFile = findNextFile())
{
   exec(%spellFile);
}

for(%spellFile = findFirstFile("./Spells/*.cs"); %spellFile !$= ""; %spellFile = findNextFile())
{
   exec(%spellFile);
}
