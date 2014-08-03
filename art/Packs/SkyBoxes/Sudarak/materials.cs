
new CubemapData(africaSky01)
{
   cubeFace[0] = "./africa01_Right.jpg";
   cubeFace[1] = "./africa01_Left.jpg";
   cubeFace[2] = "./africa01_Back.jpg";
   cubeFace[3] = "./africa01_Front.jpg";
   cubeFace[4] = "./africa01_up.jpg";
   cubeFace[5] = "./africa01_Down.jpg";
};

singleton Material(africaSky01_mat)
{
   mapTo = "africaSky01";
   cubemap = "africaSky01";
};
